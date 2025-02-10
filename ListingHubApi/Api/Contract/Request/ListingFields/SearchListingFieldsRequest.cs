namespace Contract.Request.ListingFields
{
    public class SearchListingFieldsRequest : PaginatedRequest
    {
        public int? fieldId { get; set; }
        public string? value { get; set; }
    }
}
