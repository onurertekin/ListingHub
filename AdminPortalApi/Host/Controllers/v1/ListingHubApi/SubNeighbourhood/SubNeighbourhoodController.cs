using Contract.Request.SubNeighbourhoods;
using Contract.Response.SubNeighbourhoods;

using Host.Helpers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Host.Controllers.v1.ListingHubApi.SubNeighbourhood
{
    [ApiController]
    [Route("listing-api/subneighbourhoods")]
    public class SubNeighbourhoodController : ControllerBase
    {
        private readonly HttpHelper httpHelper;
        private readonly string listingHubApiUrl;
        public SubNeighbourhoodController(HttpHelper httpHelper, IConfiguration configuration)
        {
            this.httpHelper = httpHelper;
            this.listingHubApiUrl = configuration.GetValue<string>("Services:ListingHubApi");
        }
        [HttpGet]
        //[Authorizable("Subneighbourhoods_List")]
        [RequiredHeaderParameters("Token")]
        public async Task<ActionResult<SearchSubNeighbourhoodsResponse>> Search([FromQuery] SearchSubNeighbourhoodsRequest request)
        {
            SearchSubNeighbourhoodsResponse response = new SearchSubNeighbourhoodsResponse();
            string url = ($"{listingHubApiUrl}/listing-api/subneighbourhoods?name={request.name}&neighbourhoodId={request.neighbourhoodId}&pageSize={request.pageSize}&pageNumber={request.pageNumber}&sortDirection={request.sortDirection}&sortBy={request.sortBy}");
            response = await httpHelper.Get<SearchSubNeighbourhoodsResponse>(url);
            return new JsonResult(response);
        }

        [HttpGet("{id}")]
        //[Authorizable("Subneighbourhoods_GetSingle")]
        [RequiredHeaderParameters("Token")]
        public async Task<ActionResult<GetSingleSubNeighbourhoodResponse>> GetSingle(int id)
        {
            GetSingleSubNeighbourhoodResponse response = new GetSingleSubNeighbourhoodResponse();
            string url = ($"{listingHubApiUrl}/listing-api/subneighbourhoods/{id}");
            response = await httpHelper.Get<GetSingleSubNeighbourhoodResponse>(url);
            return new JsonResult(response);
        }
    }
}
