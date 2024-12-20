﻿//using Polkanalysis.Infrastructure.Blockchain.Contracts.Runtime;
//using Polkanalysis.Infrastructure.Blockchain.Contracts.Runtime.Mapping;
//using System;
//using System.Collections.Generic;
//using System.Diagnostics;
//using System.Diagnostics.CodeAnalysis;
//using System.Linq;
//using System.Runtime.InteropServices;
//using System.Text;
//using System.Threading.Tasks;

//namespace Polkanalysis.Infrastructure.Blockchain.Runtime
//{
//    [ExcludeFromCodeCoverage]
//    public class EventResult
//    {
//        // Build tree with selected depth
//        protected int depth = 2;

//        public void SetDepth(int depth)
//        {
//            this.depth = depth;
//        }

//        public static EventResult Create(INode eventNode)
//        {
//            if (eventNode.IsEmpty || eventNode.HumanData == null && eventNode.IsLeaf) return null;

//            string palletEventName = eventNode.HumanData.ToString();

//            var subEvent = eventNode.Children.First();
//            string eventName = subEvent.HumanData.ToString();

//            var details = new List<EventDetailsResult>();
//            if (!subEvent.IsLeaf)
//            {
//                details = subEvent.Children.Select(x =>
//                {
//                    return new EventDetailsResult()
//                    {
//                        ComponentName = x.ComponentName,
//                        Title = string.Empty,
//                        Value = x.HumanData
//                    };
//                }).ToList();
//            }
//            return Create(palletEventName, eventName, details);
//        }

//        public static EventResult Create(string palletEventName, string eventName)
//        {
//            return Create(palletEventName, eventName, new List<EventDetailsResult>());
//        }

//        public static EventResult Create(string palletEventName, string eventName, IList<EventDetailsResult>? details)
//        {
//            var result = new EventResult();
//            result.AddEvent(palletEventName);
//            result.AddEvent(eventName);
//            result.Details = details;

//            return result;
//        }

//        public string? PalletEventName
//        {
//            get
//            {
//                string? p;
//                _events.TryGetValue(0, out p);
//                return p;
//            }
//        }
//        public string? EventName
//        {
//            get
//            {
//                string? p;
//                _events.TryGetValue(1, out p);
//                return p;
//            }
//        }

//        private readonly IDictionary<int, string> _events = new Dictionary<int, string>();
//        public IList<EventDetailsResult>? Details { get; set; } = new List<EventDetailsResult>();

//        public void AddEvent(string ev)
//        {
//            int nextIndex = _events.Count > 0 ? _events.LastOrDefault().Key + 1 : default;
//            _events.Add(nextIndex, ev);
//        }

//        public void AddDetails(EventMappingElem mappingCategory, IMappingElement mapper, dynamic value)
//        {
//            if (Details == null) Details = new List<EventDetailsResult>();

//            Details.Add(mappingCategory.ToEventDetailsResult(value, mapper));
//        }
//    }

//    public class EventDetailsResult
//    {
//        /// <summary>
//        /// Use for reflexion and call dynamic Razor component
//        /// </summary>
//        public string ComponentName { get; set; } = string.Empty;
//        public string Title { get; set; } = string.Empty;
//        public dynamic? Value { get; set; }
//        public List<EventDetailsResult> Details { get; set; } = new List<EventDetailsResult>();
//    }
//}
