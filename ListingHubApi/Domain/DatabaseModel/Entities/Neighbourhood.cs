namespace DatabaseModel.Entities
{
    public class Neighbourhood
    {
        public Neighbourhood()
        {
            SubNeighbourhoods = new HashSet<SubNeighbourhood>();
        }

        public int Id { get; set; }
        public int DistrictId { get; set; }
        public string Name { get; set; }

        #region Navigation Properties

        public virtual District District { get; set; }
        public virtual ISet<SubNeighbourhood> SubNeighbourhoods { get; set; }

        #endregion
    }
}
