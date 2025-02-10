using System;
using System.Collections.Generic;

namespace Contract.Response.Listings
{
    public class GetSingleListingResponse
    {
        public class Field
        {
            public int fieldId { get; set; }
            public string? value { get; set; }
        }

        public GetSingleListingResponse()
        {
            fields = new List<Field>();
        }

        public int id { get; set; }
        public int categoryId { get; set; }
        public string title { get; set; }
        public decimal price { get; set; }
        public int cityId { get; set; }
        public int districtId { get; set; }
        public int subNeighbourhoodId { get; set; }
        public int neighbourhoodId { get; set; }
        public int userId { get; set; }
        public DateTime listingDate { get; set; }
        public string latLong { get; set; }
        public string? description { get; set; }
        public IList<Field> fields { get; set; }
    }
}
