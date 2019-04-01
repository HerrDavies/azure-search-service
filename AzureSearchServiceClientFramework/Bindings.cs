using AzureSearchService;
using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AzureSearchServiceClientFramework
{
    public class Bindings : NinjectModule
    {
        public override void Load()
        {
            Bind<ISearchService>()
                .To<SearchService>()
                .WithConstructorArgument("name", "test")
                .WithConstructorArgument("key", "test")
                .WithConstructorArgument("indexName", "test");
        }
    }
}
