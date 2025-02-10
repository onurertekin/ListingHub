using System;

namespace Contract.Request.Categories
{
    public class SearchCategoriesRequest :PaginatedRequest
    {
        public int id { get; set; }
        public string? name { get; set; }
        public int? parentCategoryId { get; set; }
        public int? fieldType { get; set; }
        public DateTime? createdOn { get; set; }
        public DateTime? updatedOn { get; set; }
    }
}
