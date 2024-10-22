using Substrate.NET.Metadata.Base;
using Substrate.NET.Metadata.Service;
using Substrate.NET.Metadata.V14;
using Substrate.NetApi.Model.Meta;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Substrate.NET.Utils.Core
{
    public static class MetadataHelper
    {
        public static MetaData GetMetadataFromHex(string metadataHex)
        {
            var version = MetadataUtils.GetMetadataVersion(metadataHex);

            MetadataV14? v14 = null;
            switch (version)
            {
                case MetadataVersion.V9:
                    var v9 = new Substrate.NET.Metadata.V9.MetadataV9(metadataHex);
                    v14 = v9.ToMetadataV14();
                    break;
                case MetadataVersion.V10:
                    var v10 = new Substrate.NET.Metadata.V10.MetadataV10(metadataHex);
                    v14 = v10.ToMetadataV14();
                    break;
                case MetadataVersion.V11:
                    var v11 = new Substrate.NET.Metadata.V11.MetadataV11(metadataHex);

                    v14 = v11.ToMetadataV14();
                    break;
                case MetadataVersion.V12:
                    var v12 = new Substrate.NET.Metadata.V12.MetadataV12(metadataHex);
                    v14 = v12.ToMetadataV14();
                    break;
                case MetadataVersion.V13:
                    var v13 = new Substrate.NET.Metadata.V13.MetadataV13(metadataHex);
                    v14 = v13.ToMetadataV14();
                    break;
                case MetadataVersion.V14:
                    v14 = new MetadataV14(metadataHex);
                    break;
                default:
                    throw new InvalidOperationException($"Metadata version {version} is not supported!");
            }

            Substrate.NetApi.Model.Meta.MetaData metadata = v14.ToNetApiMetadata();
            return metadata;
        }
    }
}
