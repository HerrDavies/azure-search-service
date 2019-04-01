using Microsoft.Azure.Search;
using Microsoft.Azure.Search.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace AzureSearchService
{
    public enum SearchEntityType
    {
        GENERIC
    }

    //[SerializePropertyNamesAsCamelCase]
    public class SearchEntityModel
    {
        [Key, IsSearchable]
        public string Id { get; set; }

        [IsSearchable]
        public string Name { get; set; }

        //[IsSearchable, IsFacetable]
        //public SearchEntityType Type { get; set; }
    }
}
