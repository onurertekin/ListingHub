namespace DatabaseModel.Entities
{
    public class SubNeighbourhood
    {
        public int Id { get; set; }
        public int NeighbourhoodId { get; set; }
        public string Name { get; set; }

        #region Navigation Properties

        public virtual Neighbourhood Neighbourhood { get; set; }

        #endregion
    }
}
