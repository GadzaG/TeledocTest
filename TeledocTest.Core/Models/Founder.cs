namespace TeledocTest.Core.Models
{
    public class Founder
    {
        public Guid Id { get; }

        public string FirstName { get; } = string.Empty;

        public string LastName { get; } = string.Empty;

        public string INN { get; } = string.Empty;

        private Founder() 
        {
            
        }
    }
}
