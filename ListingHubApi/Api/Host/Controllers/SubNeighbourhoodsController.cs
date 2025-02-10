using Contract.Request.SubNeighbourhoods;
using Contract.Response.SubNeighbourhoods;
using DomainService.Interface;
using Microsoft.AspNetCore.Mvc;

namespace Host.Controllers
{
    [ApiController]
    [Route("listing-hub/subneighbourhoods")]
    public class SubNeighbourhoodsController : ControllerBase
    {
        private readonly ISubNeighbourhoodOperations subNeighbourhoodOperations;
        public SubNeighbourhoodsController(ISubNeighbourhoodOperations subNeighbourhoodOperations)
        {
            this.subNeighbourhoodOperations = subNeighbourhoodOperations;
        }

        [HttpGet]
        public ActionResult<SearchSubNeighbourhoodsResponse> Search([FromQuery] SearchSubNeighbourhoodsRequest request)
        {
            var subNeighbourhoods = subNeighbourhoodOperations.Search(request.neighbourhoodId, request.name, request.sortBy, request.sortDirection, request.pageSize, request.pageNumber, out int totalCount);
            var response = new SearchSubNeighbourhoodsResponse();

            foreach (var subNeighbourhood in subNeighbourhoods)
            {
                response.subNeighbourhoods.Add(new SearchSubNeighbourhoodsResponse.SubNeighbourhoods()
                {
                    name = subNeighbourhood.Name,
                    neighbourhoodId = subNeighbourhood.Id,
                });
            }

            return new JsonResult(response);
        }

        [HttpGet("{id}")]
        public ActionResult<GetSingleSubNeighbourhoodResponse> GetSingle(int id)
        {
            var subNeighbourhood = subNeighbourhoodOperations.GetSingle(id);
            var response = new GetSingleSubNeighbourhoodResponse();

            response.id = subNeighbourhood.Id;
            response.name = subNeighbourhood.Name;
            response.neighbourhoodId = subNeighbourhood.Id;

            return response;
        }

    }
}
