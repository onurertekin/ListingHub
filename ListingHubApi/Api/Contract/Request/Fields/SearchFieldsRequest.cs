namespace Contract.Request.Fields
{
    public class SearchFieldsRequest : PaginatedRequest
    {
        public int? fieldType { get; set; }
        public string? fieldName { get; set; }
        public bool? isRequired { get; set; }
    }
}
