using System;

namespace Contract.Request.Categories
{
    public class CreateCategoriesRequest
    {
        public string name { get; set; }
        public int? parentCategoryId { get; set; }
        public int? fieldType { get; set; }
        public DateTime createdOn { get; set; }
    }
}
