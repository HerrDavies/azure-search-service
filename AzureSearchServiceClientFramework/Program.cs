using AzureSearchService;
using Newtonsoft.Json;
using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AzureSearchServiceClientFramework
{
    class Program
    {
        static ISearchService _searchService;


        static void Main(string[] args)
        {
            IKernel kernel = new StandardKernel();

            kernel.Bind<ISearchService>()
               .To<SearchService>()
               .WithConstructorArgument("name", "")
               .WithConstructorArgument("key", "")
               .WithConstructorArgument("indexName", "test");

            _searchService = kernel.Get<ISearchService>();


            





            Console.WriteLine(JsonConvert.SerializeObject(_searchService.Search("test*").GetAwaiter().GetResult(), Formatting.Indented));

            Console.ReadKey();
        }
    }
}
