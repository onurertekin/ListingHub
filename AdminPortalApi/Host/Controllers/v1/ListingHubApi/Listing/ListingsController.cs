using Contract.Request.Listings;
using Contract.Response.Listings;

using Host.Helpers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Host.Controllers.v1.ListingHubApi.Listing
{
    [ApiController]
    [Route("listing-api/listings")]
    public class ListingsController : ControllerBase
    {
        private readonly HttpHelper httpHelper;
        private readonly string listingHubApiUrl;
        public ListingsController(HttpHelper httpHelper, IConfiguration configuration)
        {
            this.httpHelper = httpHelper;
            this.listingHubApiUrl = configuration.GetValue<string>("Services:ListingHubApi");
        }

        [HttpGet]
        [RequiredHeaderParameters("Token")]
        public async Task<ActionResult<SearchListingsResponse>> Search([FromQuery] SearchListingsRequest request)
        {
            SearchListingsResponse response = new SearchListingsResponse();
            string url = ($"{listingHubApiUrl}/listing-api/listings?title={request.title}&minPrice={request.minPrice}&maxPrice={request.maxPrice}&categoryId={request.categoryId}&cityId={request.cityId}&districtId={request.districtId}&neighbourhoodId={request.neighbourhoodId}&subNeighbourhoodId={request.subNeighbourhoodId}&userId={request.userId}&listingDate={request.listingDate}&latLong={request.latLong}&pageSize={request.pageSize}&pageNumber={request.pageNumber}&sortBy={request.sortBy}&sortDirection={request.sortDirection}");
            response = await httpHelper.Get<SearchListingsResponse>(url);
            return new JsonResult(response);
        }

        [HttpGet("{id}")]
        [RequiredHeaderParameters("Token")]
        public async Task<ActionResult<GetSingleListingResponse>> GetSingle(int id)
        {
            GetSingleListingResponse response = new GetSingleListingResponse();
            string url = ($"{listingHubApiUrl}/listing-api/listings/{id}");
            response = await httpHelper.Get<GetSingleListingResponse>(url);
            return new JsonResult(response);
        }

        [HttpPost]
        [RequiredHeaderParameters("Token")]
        public async Task Create([FromBody] CreateListingsRequest request)
        {
            await httpHelper.Create($"{listingHubApiUrl}/listing-api/listings", request);
        }

        [HttpPut]
        [RequiredHeaderParameters("Token")]
        public async Task Update([FromBody] UpdateListingsRequest request, int id)
        {
            await httpHelper.Update($"{listingHubApiUrl}/listing-api/listings/{id}", request);
        }

        [HttpDelete]
        [RequiredHeaderParameters("Token")]
        public async Task Delete(int id)
        {
            await httpHelper.Delete($"{listingHubApiUrl}/listing-api/listings/{id}");
        }
    }
}
