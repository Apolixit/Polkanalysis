using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Polkanalysis.Components.Services.Http
{
    public static class ApiServiceExtension
    {
        public static async Task<TRes> GetHelperAsync<TRes>(
            this IApiService apiService, 
            string url)
        {
            var response = await apiService.Get<TRes>(url);
            if (!response.Success)
            {
                throw new InvalidOperationException(await response.GetBody());
            }
            return response.Response;
        }

        public static async Task<TRes> GetHelperAsync<TReq, TRes>(this IApiService apiService, string url, TReq req)
        {
            string query = string.Empty;
            if(req != null)
            {
                query = ObjToQueryString(req);
            }

            var response = await apiService.Get<TRes>($"{url}/{query}");
            if (!response.Success)
            {
                throw new InvalidOperationException(await response.GetBody());
            }
            return response.Response;
        }

        private static string ObjToQueryString(object obj)
        {
            var step1 = JsonConvert.SerializeObject(obj);

            var step2 = JsonConvert.DeserializeObject<IDictionary<string, string>>(step1);

            var step3 = step2.Select(x => HttpUtility.UrlEncode(x.Key) + "=" + HttpUtility.UrlEncode(x.Value));

            return string.Join("&", step3);
        }
    }
}
