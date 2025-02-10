using Contract.Request.Cities;
using Contract.Request.Districts;
using Contract.Response.Cities;
using Contract.Response.Districts;

using Host.Helpers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Host.Controllers.v1.ListingHubApi.District
{
    [ApiController]
    [Route("listing-api/districts")]
    public class DistrictsController : ControllerBase
    {
        private readonly HttpHelper httpHelper;
        private readonly string listingHubApiUrl;
        public DistrictsController(HttpHelper httpHelper, IConfiguration configuration)
        {
            this.httpHelper = httpHelper;
            this.listingHubApiUrl = configuration.GetValue<string>("Services:ListingHubApi");
        }

        [HttpGet]
        //[Authorizable("Districts_List")]
        [RequiredHeaderParameters("Token")]
        public async Task<ActionResult<SearchDistrictsResponse>> Search([FromQuery] SearchDistrictsRequest request)
        {
            SearchDistrictsResponse response = new SearchDistrictsResponse();
            string url = ($"{listingHubApiUrl}/listing-api/districts?name={request.name}&cityId={request.cityId}&sortBy={request.sortBy}&sortDirection={request.sortDirection}&pageNumber={request.pageNumber}&pageSize={request.pageSize}");
            response = await httpHelper.Get<SearchDistrictsResponse>(url);
            return new JsonResult(response);
        }

        [HttpGet("{id}")]
        //[Authorizable("Districts_GetSingle")]
        [RequiredHeaderParameters("Token")]
        public async Task<ActionResult<GetSingleDistrictResponse>> GetSingle(int id)
        {
            GetSingleDistrictResponse response = new GetSingleDistrictResponse();
            string url = ($"{listingHubApiUrl}/listing-api/districts/{id}");
            response = await httpHelper.Get<GetSingleDistrictResponse>(url);
            return new JsonResult(response);
        }
    }
}
