using Contract.Request.Neighbourhoods;
using Contract.Response.Neighbourhoods;

using Host.Helpers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Host.Controllers.v1.ListingHubApi.Neighbourhood
{
    [ApiController]
    [Route("listing-api/neighbourhoods")]
    public class NeighbourhoodsController : ControllerBase
    {
        private readonly HttpHelper httpHelper;
        private readonly string listingHubApiUrl;
        public NeighbourhoodsController(HttpHelper httpHelper, IConfiguration configuration)
        {
            this.httpHelper = httpHelper;
            this.listingHubApiUrl = configuration.GetValue<string>("Services:ListingHubApi");
        }

        [HttpGet]
        //[Authorizable("Neighbourhoods_List")]
        [RequiredHeaderParameters("Token")]
        public async Task<ActionResult<SearchNeighbourhoodsResponse>> Search([FromQuery] SearchNeighbourhoodsRequest request)
        {
            SearchNeighbourhoodsResponse response = new SearchNeighbourhoodsResponse();
            string url = ($"{listingHubApiUrl}/listing-api/neighbourhoods?name={request.name}&districtId={request.districtId}&pageSize={request.pageSize}&pageNumber={request.pageNumber}&sortDirection={request.sortDirection}&sortBy={request.sortBy}");
            response = await httpHelper.Get<SearchNeighbourhoodsResponse>(url);
            return new JsonResult(response);
        }

        [HttpGet("{id}")]
        //[Authorizable("Neighbourhoods_GetSingle")]
        [RequiredHeaderParameters("Token")]
        public async Task<ActionResult<GetSingleNeighbourhoodResponse>> GetSingle(int id)
        {
            GetSingleNeighbourhoodResponse response = new GetSingleNeighbourhoodResponse();
            string url = ($"{listingHubApiUrl}/listing-api/neighbourhoods/{id}");
            response = await httpHelper.Get<GetSingleNeighbourhoodResponse>(url);
            return new JsonResult(response);
        }
    }
}
