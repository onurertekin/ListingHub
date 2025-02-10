using Contract.Request.Neighbourhoods;
using Contract.Response.Neighbourhoods;
using DomainService.Interface;
using Microsoft.AspNetCore.Mvc;

namespace Host.Controllers
{
    [ApiController]
    [Route("listing-hub/neighbourhoods")]
    public class NeighbourhoodsController : ControllerBase
    {
        private readonly INeighbourhoodOperations neighbourhoodOperations;
        public NeighbourhoodsController(INeighbourhoodOperations neighbourhoodOperations)
        {
            this.neighbourhoodOperations = neighbourhoodOperations;
        }

        [HttpGet]
        public ActionResult<SearchNeighbourhoodsResponse> Search([FromQuery] SearchNeighbourhoodsRequest request)
        {
            var neighbourhoods = neighbourhoodOperations.Search(request.districtId, request.name, request.sortBy, request.sortDirection, request.pageSize, request.pageNumber, out int totalCount);
            var response = new SearchNeighbourhoodsResponse();

            foreach (var neighbourhood in neighbourhoods)
            {
                response.neighbourhoods.Add(new SearchNeighbourhoodsResponse.Neighbourhood()
                {
                    districtId = neighbourhood.DistrictId,
                    name = neighbourhood.Name,
                });
            }

            return new JsonResult(response);
        }

        [HttpGet("{id}")]
        public ActionResult<GetSingleNeighbourhoodResponse> GetSingle(int id)
        {
            var neighbourhood = neighbourhoodOperations.GetSingle(id);
            var response = new GetSingleNeighbourhoodResponse();

            response.id = id;
            response.districtId = neighbourhood.DistrictId;
            response.name = neighbourhood.Name;

            return response;
        }
    }
}
