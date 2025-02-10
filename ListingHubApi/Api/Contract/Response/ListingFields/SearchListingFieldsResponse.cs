using Azure;

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

        #region Fill

        public void Fill(IList<DatabaseModel.Entities.ListingField> source)
        {
            foreach (var listingField in source)
            {
                this.listingFields.Add(new SearchListingFieldsResponse.ListingField()
                {
                    id = listingField.Id,
                    fieldId = listingField.FieldId,
                    key = listingField.Field.FieldName,
                    value = listingField.Value,
                });
            }
        }

        #endregion
    }
}


