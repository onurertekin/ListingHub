using System.ComponentModel.DataAnnotations.Schema;

namespace DatabaseModel.Entities
{
    public class Transaction
    {
        public int Id { get; set; }
        public string To { get; set; }
        public string Subject { get; set; }
        public string? Body { get; set; }
        public DateTime CreatedOn { get; set; }
    }
}