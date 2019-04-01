using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AzureSearchService
{
    public interface ISearchService
    {
        Task Add(SearchEntityModel document);

        //void RemoveEntry();

        Task<IList<SearchEntityModel>> Search(string searchTerm);
    }
}
