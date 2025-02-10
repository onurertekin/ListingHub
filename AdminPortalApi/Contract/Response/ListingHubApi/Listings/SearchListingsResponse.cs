using System;
using System.Collections.Generic;

namespace Contract.Response.Listings
{
    public class SearchListingsResponse
    {
        public class Listing
        {
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
            public string photo { get; set; }
            public int fieldType { get; set; }
            public string fieldTypeName { get; set; }
        }
        public SearchListingsResponse()
        {
            listings = new List<Listing>();
        }
        public List<Listing> listings { get; set; }

    }
}
