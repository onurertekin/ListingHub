using Contract.Request.Listings;
using Contract.Response.Listings;
using DomainService.Interface;
using Microsoft.AspNetCore.Mvc;

namespace Host.Controllers
{
    [ApiController]
    [Route("listing-api/listings")]
    public class ListingsController : ControllerBase
    {
        private readonly IListingOperations listingOperations;
        public ListingsController(IListingOperations listingOperations)
        {
            this.listingOperations = listingOperations;
        }

        [HttpGet]
        public ActionResult<SearchListingsResponse> Search([FromQuery] SearchListingsRequest request)
        {
            var listings = listingOperations.Search(request.categoryId, request.title, request.minPrice, request.maxPrice, request.cityId, request.districtId, request.neighbourhoodId, request.subNeighbourhoodId, request.userId, request.listingDate, request.latLong, request.sortBy, request.sortDirection, request.pageSize, request.pageNumber, out int totalCount);
            var response = new SearchListingsResponse();

            foreach (var listing in listings)
            {
                response.listings.Add(new SearchListingsResponse.Listing()
                {
                    id = listing.Id,
                    categoryId = listing.CategoryId,
                    title = listing.Title,
                    price = listing.Price,
                    cityId = listing.CityId,
                    districtId = listing.DistrictId,
                    neighbourhoodId = listing.NeighbourhoodId,
                    subNeighbourhoodId = listing.SubNeighbourhoodId,
                    userId = listing.UserId,
                    listingDate = listing.ListingDate,
                    latLong = listing.LatLong,
                    photo = listing.ListingPhotos.FirstOrDefault()?.PhotoName,
                    fieldType = listing.Category.FieldType.Value,
                    fieldTypeName = listing.Category.FieldType.Value == 1 ? "Vasıta" : "Emlak"
                });
            }

            return new JsonResult(response);
        }

        [HttpGet("{id}")]
        public ActionResult<GetSingleListingResponse> GetSingle(int id, [FromQuery] bool includeDescription, [FromQuery] bool includeFields)
        {
            var listing = listingOperations.GetSingle(id, includeDescription, includeFields);

            var response = new GetSingleListingResponse();

            response.id = id;
            response.price = listing.Price;
            response.cityId = listing.CityId;
            response.title = listing.Title;
            response.neighbourhoodId = listing.NeighbourhoodId;
            response.subNeighbourhoodId = listing.SubNeighbourhoodId;
            response.userId = listing.UserId;
            response.listingDate = listing.ListingDate;
            response.latLong = listing.LatLong;
            response.districtId = listing.DistrictId;
            response.categoryId = listing.CategoryId;

            if (includeDescription)
                response.description = listing.Description.Description;

            if (includeFields)
            {
                response.fields = listing.ListingFields.Select(x => new GetSingleListingResponse.Field()
                {
                    fieldId = x.FieldId,
                    value = x.Value,
                }).ToList();
            }
            return response;
        }

        [HttpPost]
        public void Create([FromBody] CreateListingsRequest request)
        {
            listingOperations.Create(request.categoryId, request.title, request.price, request.cityId, request.districtId, request.neighbourhoodId, request.subNeighbourhoodId, request.userId, request.listingDate, request.latLong);
        }

        [HttpPut("{id}")]
        public void Update([FromBody] UpdateListingsRequest request, int id)
        {
            listingOperations.Update(id, request.categoryId, request.title, request.price, request.cityId, request.districtId, request.neighbourhoodId, request.subNeighbourhoodId, request.userId, request.listingDate, request.latLong);
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            listingOperations.Delete(id);
        }
    }
}
