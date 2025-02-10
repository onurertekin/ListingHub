using System.Collections.Generic;

namespace Contract.Response.SubNeighbourhoods
{
    public class SearchSubNeighbourhoodsResponse
    {
        public class SubNeighbourhoods
        {
            public int? neighbourhoodId { get; set; }
            public string? name { get; set; }
        }
        public SearchSubNeighbourhoodsResponse()
        {
            subNeighbourhoods = new List<SubNeighbourhoods>();
        }
        public IList<SubNeighbourhoods> subNeighbourhoods { get; set; }
    }
}
