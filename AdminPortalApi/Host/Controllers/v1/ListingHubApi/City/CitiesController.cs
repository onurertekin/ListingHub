using Contract.Request.Cities;
using Contract.Response.Cities;

using Host.Helpers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Host.Controllers.v1.ListingHubApi.City
{
    [ApiController]
    [Route("listing-api/cities")]
    public class CitiesController
    {
        private readonly HttpHelper httpHelper;
        private readonly string listingHubApiUrl;
        public CitiesController(HttpHelper httpHelper, IConfiguration configuration)
        {
            this.httpHelper = httpHelper;
            this.listingHubApiUrl = configuration.GetValue<string>("Services:ListingHubApi");
        }

        [HttpGet]
        //[Authorizable("Cities_List")]
        [RequiredHeaderParameters("Token")]
        public async Task<ActionResult<SearchCitiesResponse>> Search([FromQuery] SearchCitiesRequest request)
        {
            SearchCitiesResponse response = new SearchCitiesResponse();
            string url = ($"{listingHubApiUrl}/listing-api/cities?name={request.name}&plateCode={request.plateCode}&sortBy={request.sortBy}&sortDirection={request.sortDirection}&pageSize={request.pageSize}&pageNumber={request.pageNumber}");
            response = await httpHelper.Get<SearchCitiesResponse>(url);
            return new JsonResult(response);
        }

        [HttpGet("{id}")]
        //[Authorizable("Cities_GetSingle")]
        [RequiredHeaderParameters("Token")]
        public async Task<ActionResult<GetSingleCityResponse>> GetSingle(int id)
        {
            GetSingleCityResponse response = new GetSingleCityResponse();
            string url = ($"{listingHubApiUrl}/listing-api/cities/{id}");
            response = await httpHelper.Get<GetSingleCityResponse>(url);
            return new JsonResult(response);
        }


    }
}
