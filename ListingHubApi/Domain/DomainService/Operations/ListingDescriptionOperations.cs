using DatabaseModel;
using DatabaseModel.Entities;
using DomainService.Base;
using DomainService.Exceptions;
using DomainService.Extensions;
using DomainService.Interface;

namespace DomainService.Operations
{
    public class ListingDescriptionOperations : DbContextHelper, IListingDescriptionOperations
    {
        private readonly MainDbContext mainDbContext;
        public ListingDescriptionOperations(MainDbContext mainDbContext) : base(mainDbContext)
        {
            this.mainDbContext = mainDbContext;
        }

        public ListingDescription GetSingle(int listingId)
        {
            var listingDescription = mainDbContext.ListingDescriptions.Where(x => x.ListingId == listingId).SingleOrDefault();

            if (listingDescription == null)
                throw new BusinessException(404, "Kayıt bulunamadı.");

            return listingDescription;
        }

        public void Update( int listingId, string description)
        {
            #region Validations

            var listingDescription = mainDbContext.ListingDescriptions.Where(x => x.ListingId == listingId).SingleOrDefault();
            if (listingDescription == null)
                throw new BusinessException(404, "İlan açıklaması bulunamadı.");

            #endregion

            listingDescription.Description = description;

            UpdateEntity(listingDescription);
        }
    }
}
