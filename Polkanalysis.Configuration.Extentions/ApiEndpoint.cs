﻿using Microsoft.Extensions.Configuration;
using Polkanalysis.Configuration.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polkanalysis.Configuration.Extentions
{
    public class ApiEndpoint : IApiEndpoint
    {
        public Uri? ApiUri { get; init; }

        public ApiEndpoint(IConfiguration configuration) {
            var apiSection = configuration.GetSection("Api").GetChildren().ToList();
            var apiUriSection = apiSection.FirstOrDefault(e => e.Key == "uri");

            if (apiUriSection != null && apiUriSection.Value != null)
                ApiUri = new Uri(apiUriSection.Value);
        }
    }
}
