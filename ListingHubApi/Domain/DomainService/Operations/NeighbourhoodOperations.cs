using DatabaseModel;
using DatabaseModel.Entities;
using DomainService.Base;
using DomainService.Exceptions;
using DomainService.Extensions;
using DomainService.Interface;

namespace DomainService.Operations
{
    public class NeighbourhoodOperations : DbContextHelper, INeighbourhoodOperations
    {
        private readonly MainDbContext mainDbContext;
        public NeighbourhoodOperations(MainDbContext mainDbContext) : base(mainDbContext)
        {
            this.mainDbContext = mainDbContext;
        }

        public IList<Neighbourhood> Search(int? districtId, string? name, string sortBy, string sortDirection, int pageSize, int pageNumber, out int totalCount)
        {
            var query = mainDbContext.Neighbourhoods.AsQueryable();

            if (!string.IsNullOrEmpty(name))
                query = mainDbContext.Neighbourhoods.Where(x => x.Name == name);

            if (districtId.HasValue)
                query = mainDbContext.Neighbourhoods.Where(x => x.DistrictId == districtId);

            return query.GetPagedAndSorted(pageNumber, pageSize, sortDirection, sortBy, out totalCount);
        }

        public Neighbourhood GetSingle(int id)
        {
            var neighbourhood = mainDbContext.Neighbourhoods.Where(x => x.Id == id).SingleOrDefault();

            if (neighbourhood == null)
                throw new BusinessException(404, "Kayıt bulunamadı.");

            return neighbourhood;
        }
    }
}
