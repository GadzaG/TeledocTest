using System.ComponentModel.DataAnnotations.Schema;

namespace TeledocTest.DataAccess.Entities
{
    public class ClientEntity
    {
        [Column("id")]
        public Guid Id { get; set; }

        [Column("inn")]
        public string INN { get; set; } = string.Empty;

        [Column("title")]
        public string Title { get; set; } = string.Empty;

        [Column("type")]
        public Core.Models.Type Type { get; set; }

        [Column("founders")]
        public List<FounderEntity> Founders { get; set; }

        [Column("created_at")]
        public DateTime CreatedAt { get; set; }

        [Column("updated_at")]
        public DateTime UpdatedAt { get; set; }

    }
}
