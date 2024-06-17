using Substrate.NetApi;
using Substrate.NetApi.Model.Extrinsics;
using Substrate.NetApi.Model.Types;
using Substrate.NetApi.Model.Types.Base;
using Substrate.NET.Utils;
using Polkanalysis.Domain.Contracts.Runtime;
using Polkanalysis.Domain.Contracts.Runtime.Mapping;
using Microsoft.Extensions.Logging;
using Polkanalysis.Domain.Contracts.Runtime.Module;
using Ardalis.GuardClauses;
using Polkanalysis.Infrastructure.Blockchain.Contracts;
using Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.System.Enums;
using AutoMapper;
using Substrate.NetApi.Model.Meta;
using Polkanalysis.Domain.Contracts.Service;

namespace Polkanalysis.Domain.Runtime
{
    public class SubstrateDecoding : ISubstrateDecoding
    {
        private readonly INodeMapping _mapping;
        private readonly ISubstrateService _substrateRepository;
        private readonly IPalletBuilder _palletBuilder;
        private readonly ICurrentMetaData _metaData;
        private readonly ILogger<SubstrateDecoding> _logger;

        public SubstrateDecoding(
            INodeMapping mapping,
            ISubstrateService substrateRepository,
            IPalletBuilder palletBuilder,
            ICurrentMetaData metaData,
            ILogger<SubstrateDecoding> logger)
        {
            _mapping = mapping;
            _substrateRepository = substrateRepository;
            _palletBuilder = palletBuilder;
            _metaData = metaData;
            _logger = logger;
        }

        public INode Decode(IType elem)
        {
            GenericNode node = new GenericNode();
            VisitNode(node, elem);

            return node;
        }

        public IEventNode DecodeEvent(string hex)
        {
            if (string.IsNullOrEmpty(hex))
                throw new ArgumentNullException($"{nameof(hex)}");

            var ev = new EventRecord();
            try
            {
                ev.Create(Utils.HexToByteArray(hex));
            } catch(Exception ex)
            {
                throw new InvalidOperationException($"{nameof(ev)} has not been instanciate properly, maybe due to invalid hex parameter", ex);
            }

            //_logger.LogInformation($"Event hex ({hex}) has been successfully converted to EventRecord");
            return DecodeEvent(ev);
        }

        public IEventNode DecodeEvent(EventRecord ev)
        {
            var eventNode = new EventNode();

            VisitNode(eventNode, ev);

            _logger.LogTrace("Node created from EventRecord");
            return eventNode;
        }

        public (string callModule, string callEvent) GetCallFromExtrinsic(Extrinsic extrinsic)
        {
            string callModule = string.Empty;
            string callEvent = string.Empty;
            var pallet = _metaData.GetCurrentMetadata().Modules[extrinsic.Method.ModuleIndex];
            callModule = pallet.Name;
            var palletType = _metaData.GetPalletType(pallet.Calls.TypeId);

            if (palletType is NodeTypeVariant nodeTypeVariant)
            {
                callEvent = nodeTypeVariant.Variants[extrinsic.Method.CallIndex].Name;
                return (callModule, callEvent);
            }

            throw new InvalidOperationException();
        }

        public INode DecodeExtrinsic(string hex)
        {
            if(string.IsNullOrWhiteSpace(hex)) throw new ArgumentNullException($"{nameof(hex)}");

            var extrinsic = new Extrinsic(hex, ChargeTransactionPayment.Default());

            _logger.LogInformation($"Extrinsic {hex} has been converted to a valid extrinsic");
            return DecodeExtrinsic(extrinsic);
        }

        public INode DecodeExtrinsic(Extrinsic extrinsic)
        {
            var pallet = _metaData.GetCurrentMetadata().Modules[extrinsic.Method.ModuleIndex];
            var extrinsicCall = _palletBuilder.BuildCall(pallet.Name, extrinsic.Method);

            #if DEBUG
            if (extrinsicCall is not null)
            {
                var isEqual = Utils.Bytes2HexString(extrinsic.Method.Encode()) == Utils.Bytes2HexString(extrinsicCall.Encode());
            }
            #endif


            var palletNode = new GenericNode();
            palletNode.Name = pallet.Name;
            palletNode.AddHumanData(pallet.Name);

            if(extrinsicCall is not null)
                palletNode.AddChild(Decode(extrinsicCall));

            return palletNode;
        }

        public INode DecodeLog(IEnumerable<string> logs)
        {
            if (logs == null)
                throw new ArgumentNullException($"{nameof(logs)}");

            return DecodeLog(logs.Select(log =>
            {
                var buildLogs = new EnumDigestItem();
                buildLogs.Create(log);

                return buildLogs;
            }));
        }

        public INode DecodeLog(IEnumerable<EnumDigestItem> logs)
        {
            if (logs == null)
                throw new ArgumentNullException($"{nameof(logs)}");

            GenericNode node = new GenericNode();
            foreach (var log in logs)
            {
                node.AddChild(VisitNode(log));
            }

            return node;
        }

        #region Internal visit tree
        private INode VisitNode(IType value)
        {
            GenericNode node = new GenericNode();
            VisitNode(node, value);
            return node;
        }

        /// <summary>
        /// Visit the current value
        /// </summary>
        /// <param name="node"></param>
        /// <param name="value"></param>
        /// <exception cref="ArgumentNullException"></exception>
        private void VisitNode(INode node, IType value)
        {
            if (value is BaseEnumType baseEnumValue)
            {
                var val = baseEnumValue.GetEnumValue();

                if (val == null) throw new ArgumentNullException($"The value element (enum) from {baseEnumValue.TypeName()} is null while visiting node");

                var doc = _palletBuilder.FindDocumentation(val);
                
                var AddDataToNode = (INode node) =>
                {
                    node
                        .AddData(value)
                        .AddName(val.ToString())
                        .AddHumanData(val);

                    if (!string.IsNullOrEmpty(doc))
                        node.AddDocumentation(doc);

                    return node;
                };

                var childNode = AddDataToNode(new GenericNode());

                var enumValue2 = baseEnumValue.GetValue2();
                //if (enumValue2.GetBytes() == null)
                if (enumValue2 is null)
                    return;
                    //throw new ArgumentNullException($"{baseEnumValue}.GetValue2() is null");

                if (node.IsEmpty)
                {
                    node = AddDataToNode(node);
                    VisitNode(node, enumValue2);
                }
                else
                {
                    VisitNode(childNode, enumValue2);

                    var props = _palletBuilder.FindProperty(val);
                    if(props is not null && props.Length == childNode.Children.Count)
                    {
                        for(int i = 0; i < childNode.Children.Count; i++)
                        {
                            childNode.Children[i].AddName(props[i].Name);
                        }
                    }

                    node.AddChild(childNode);
                }
            }
            else
            {
                VisitNodePrimitive(node, value);
            }
        }

        /// <summary>
        /// Visit node which is not an enum
        /// </summary>
        /// <param name="node"></param>
        /// <param name="value"></param>
        private void VisitNodePrimitive(INode node, IType value)
        {
            if (value is BaseVoid) return;

            var mapper = _mapping.Search(value.GetType());
            if (!mapper.IsIdentified && value.GetType().IsGenericType)
            {
                VisitNodeGeneric(node, value);
            }
            else if (!mapper.IsIdentified)
            {
                var properties = value.GetType().GetProperties();
                foreach (var property in properties)
                {
                    var prp = value.GetValue(property.Name);
                    if (prp is IType prpType)
                    {
                        var childNode = new GenericNode()
                                                .AddData(prpType)
                                                .AddName(property.Name);
                        node.AddChild(childNode);

                        VisitNode(childNode, prpType);
                    }
                }
            }
            else
            {
                var doc = _palletBuilder.FindDocumentation(value.GetType());
                var AddDataToNode = (INode node) =>
                {
                    node
                        .AddData(value)
                        .AddContext(mapper)
                        .AddHumanData(mapper.ToHuman(value));

                    if (doc != null)
                        node.AddDocumentation(doc);

                    return node;
                };

                //node = AddDataToNode(node);
                if (node.IsEmpty)
                    node = AddDataToNode(node);
                else
                    node.AddChild(AddDataToNode(new GenericNode()));
            }
        }

        private void VisitNodeGeneric(INode node, IType value)
        {
            // We try to get Value or Core
            var data = value.GetValue("Value") ?? value.GetValue("Core");
            if (data is null) return;

            var isArray = data.GetType().IsArray;

            if(isArray)
            {
                var valueArray = value.GetValueArray();

                if (valueArray == null)
                    throw new ArgumentException($"{nameof(valueArray)} GetValueArray() is null");

                foreach (IType currentValue in valueArray)
                {
                    if (currentValue.GetType().IsGenericType)
                    {
                        var childNode = new GenericNode().AddData(currentValue);
                        node.AddChild(childNode);

                        VisitNode(childNode, currentValue);
                    }
                    else
                    {
                        VisitNode(node, currentValue);
                    }
                }
            } else
            {
                //var currentValue = (IType?)value.GetValue();
                //var objectValue = value.GetValue();
                if(data is IType currentValue)
                {
                    Guard.Against.Null(currentValue, nameof(currentValue));

                    if (currentValue.GetType().IsGenericType)
                    {
                        var childNode = new GenericNode().AddData(currentValue);
                        node.AddChild(childNode);

                        VisitNode(childNode, currentValue);
                    }
                    else
                    {
                        VisitNode(node, currentValue);
                    }
                }
            }
            
        }
        #endregion
    }
}
