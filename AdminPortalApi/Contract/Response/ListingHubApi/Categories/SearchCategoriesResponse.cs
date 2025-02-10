using System;
using System.Collections.Generic;

namespace Contract.Response.Categories
{
    public class SearchCategoriesResponse
    {
        public class Category
        {
            public int? id { get; set; }
            public string? name { get; set; }
            public int? parentCategoryId { get; set; }
            public int? fieldType { get; set; }
            public DateTime? createdOn { get; set; }
            public DateTime? updatedOn { get; set; }
        }
        public SearchCategoriesResponse()
        {
            categories = new List<Category>();
        }
        public List<Category> categories { get; set; }
    }
}
