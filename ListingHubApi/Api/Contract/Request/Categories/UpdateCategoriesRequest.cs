namespace Contract.Request.Categories
{
    public class UpdateCategoriesRequest
    {
        public string name { get; set; }
        public int? parentCategoryId { get; set; }
        public int? fieldType { get; set; }
        public DateTime updatedOn { get; set; }
    }
}
