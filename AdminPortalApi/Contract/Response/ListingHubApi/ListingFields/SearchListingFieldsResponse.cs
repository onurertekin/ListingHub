using System.Collections.Generic;

namespace Contract.Response.ListingFields
{
    public class SearchListingFieldsResponse
    {
        public class ListingField
        {
            public int id { get; set; }
            public int fieldId { get; set; }
            public string key { get; set; }
            public string value { get; set; }
        }
        public SearchListingFieldsResponse()
        {
            listingFields = new List<ListingField>();
        }

        public List<ListingField> listingFields { get; set; }

    }
}
