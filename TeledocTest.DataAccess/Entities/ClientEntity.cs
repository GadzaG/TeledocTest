namespace TeledocTest.DataAccess.Entities
{
    public class ClientEntity
    {
        public Guid Id { get; set; }

        public string INN { get; set; } = string.Empty;

        public string Title { get; set; } = string.Empty;

        public Type Type { get; set; }

        public List<FounderEntity> Founders { get; set; }
    }

    public enum Type
    {
        UL,
        IP
    }
}
