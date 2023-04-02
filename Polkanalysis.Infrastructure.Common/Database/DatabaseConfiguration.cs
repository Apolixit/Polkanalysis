using Polkanalysis.Domain.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polkanalysis.Infrastructure.Common.Database
{
    /// <summary>
    /// TODO : it's just temporary, i'm going to add it with DI
    /// </summary>
    public class DatabaseConfiguration : IDatabaseConfiguration
    {
        public string ConnectionString => "Host=localhost:5432; Username=postgres; Password=test; Database=Polkanalysis";
    }
}
