using System.Collections.Generic;

namespace Contract.Response.ListingPhotos
{
    public class SearchListingPhotosResponse
    {
        public SearchListingPhotosResponse()
        {
            photos = new List<string>();
        }

        public List<string> photos { get; set; }
    }
}
