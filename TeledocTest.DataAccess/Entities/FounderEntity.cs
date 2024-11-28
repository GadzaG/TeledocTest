namespace TeledocTest.DataAccess.Entities
{
    public class FounderEntity
    {
        public Guid Id { get; set;  }

        public string FirstName { get; set; } = string.Empty;

        public string LastName { get; set; } = string.Empty;

        public string INN { get; set; } = string.Empty;

    }
}
