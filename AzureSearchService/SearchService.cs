using Microsoft.Azure.Search;
using Microsoft.Azure.Search.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AzureSearchService
{
    public class SearchService : ISearchService
    {
        SearchServiceClient _serviceClient;
        SearchIndexClient _indexClient;

        /// <summary>
        /// Creates the search index
        /// </summary>
        /// <param name="name">The name of the Azure Search Service</param>
        /// <param name="key">The access key of the Azure Search Service</param>
        /// <param name="indexName">The index name of the Azure Search Service</param>
        public SearchService(string name, string key, string indexName)
        {
            _serviceClient = new SearchServiceClient(name, new SearchCredentials(key));

            if (!_serviceClient.Indexes.Exists(indexName))
            {
                var indexDefinition = new Index
                {
                    Name = indexName,
                    Fields = FieldBuilder.BuildForType<SearchEntityModel>()
                };

                _serviceClient.Indexes.Create(indexDefinition);
            }

            _indexClient = new SearchIndexClient(name, indexName, new SearchCredentials(key));
        }

        public async Task<IList<SearchEntityModel>> Search(string searchTerm)
        {
            var search = await _indexClient.Documents.SearchAsync<SearchEntityModel>(searchTerm);

            var results = search.Results;

            return results.Select(r => new SearchEntityModel
            {
                Id = r.Document.Id,
                Name = r.Document.Name,
                //Type = r.Document.Type
            }).ToList();
        }

        public async Task Add(SearchEntityModel document)
        {
            var batch = IndexBatch.New(new IndexAction<SearchEntityModel>[] {
                IndexAction.Upload(document)
            });



            await _indexClient.Documents.IndexAsync(batch);
        }
    }
}
