namespace TeledocTest.Core.Models
{
    public class Founder
    {
        public Guid Id { get; }

        public string FirstName { get; } = string.Empty;

        public string LastName { get; } = string.Empty;

        public string INN { get; } = string.Empty;

        private Founder(Guid id, string firstName, string lastName, string inn) 
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            INN = inn;
        }

        public static (Founder Founder, string Error) Create(Guid id, string firstName, string lastName, string inn)
        {
            string error = string.Empty;
            var founder = new Founder(id, firstName, lastName, inn);
            
            return (founder, error);
        }
    }
}
