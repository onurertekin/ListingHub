using DatabaseModel;
using DatabaseModel.Entities;
using DomainService.Base;
using DomainService.Exceptions;
using DomainService.Extensions;
using DomainService.Interface;

namespace DomainService.Operations
{
    public class SubNeighbourhoodOperations : DbContextHelper, ISubNeighbourhoodOperations
    {
        private readonly MainDbContext mainDbContext;
        public SubNeighbourhoodOperations(MainDbContext mainDbContext) : base(mainDbContext)
        {
            this.mainDbContext = mainDbContext;
        }

        public IList<SubNeighbourhood> Search(int? neighbourhoodId, string? name, string sortBy, string sortDirection, int pageSize, int pageNumber, out int totalCount)
        {
            var query = mainDbContext.SubNeighbourhoods.AsQueryable();

            if (neighbourhoodId.HasValue)
                query = mainDbContext.SubNeighbourhoods.Where(x => x.NeighbourhoodId == neighbourhoodId);

            if (!string.IsNullOrEmpty(name))
                query = mainDbContext.SubNeighbourhoods.Where(x => x.Name == name);

            return query.GetPagedAndSorted(pageNumber, pageSize, sortDirection, sortBy, out totalCount);
        }

        public SubNeighbourhood GetSingle(int id)
        {
            var subNeighbourhood = mainDbContext.SubNeighbourhoods.Where(x => x.Id == id).SingleOrDefault();

            if (subNeighbourhood == null)
                throw new BusinessException(404, "Kayıt bulunamadı.");

            return subNeighbourhood;
        }
    }
}
