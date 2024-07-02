using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polkanalysis.Components.Services.Http
{
    public class ApiRequest<Res>
    {
        public Res? Result { get; set; }
        public required string Url { get; set; }

        [SetsRequiredMembers]
        public ApiRequest(string url)
        {
            Url = url;
        }

        //var url = NavManager.GetUriWithQueryParameters("https://api.fda.gov/food/enforcement.json", new Dictionary<string, object?>
        //            {
        //        { "skip", req.StartIndex },
        //        { "limit", req.Count },
        //            });

    }

    public class ApiRequest<Req, Res> : ApiRequest<Res>
    {
        public required Req RequestParam { get; set; }

        [SetsRequiredMembers]
        public ApiRequest(Req requestParam, string url) : base(url)
        {
            RequestParam = requestParam;
            Url = url;
        }
    }
}
