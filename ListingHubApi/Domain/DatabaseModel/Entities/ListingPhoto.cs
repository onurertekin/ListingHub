namespace DatabaseModel.Entities
{
    public class ListingPhoto
    {
        public int Id { get; set; }
        public int? ListingId { get; set; }
        public string PhotoName { get; set; }


        #region Navigation Property

        public virtual Listing Listings { get; set; }

        #endregion
    }
}
