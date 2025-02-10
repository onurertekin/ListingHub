namespace Contract.Request.ListingFields
{
    public class UpdateListingFieldsRequest
    {
        public class ListingField
        {
            public int fieldId { get; set; }
            public string value { get; set; }
        }
        public UpdateListingFieldsRequest()
        {
            listingFields = new List<ListingField>();
        }
        public List<ListingField> listingFields { get; set; }

    }
}
