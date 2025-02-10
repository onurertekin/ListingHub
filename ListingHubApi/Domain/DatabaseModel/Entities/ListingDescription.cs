namespace DatabaseModel.Entities
{
    public class ListingDescription
    {
        public int Id { get; set; }
        public int ListingId { get; set; }
        public string Description { get; set; }

        #region Navigation Property
        public virtual Listing Listing { get; set; }
        #endregion
    }
}
