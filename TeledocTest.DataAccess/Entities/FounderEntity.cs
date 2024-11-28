using System.ComponentModel.DataAnnotations.Schema;

namespace TeledocTest.DataAccess.Entities
{
    public class FounderEntity
    {
        [Column("id")]
        public Guid Id { get; set;  }

        [Column("first_name")]
        public string FirstName { get; set; } = string.Empty;

        [Column("last_name")]
        public string LastName { get; set; } = string.Empty;

        [Column("inn")]
        public string INN { get; set; } = string.Empty;

        [Column("created_at")]
        public DateTime CreatedAt { get; set; }

        [Column("updated_at")]
        public DateTime UpdatedAt { get; set; }
    }
}
