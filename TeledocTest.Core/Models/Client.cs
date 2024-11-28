namespace TeledocTest.Core.Models
{
    public class Client
    {
        public const int MAX_UL_INN_LENGHT = 10;

        public const int MAX_IP_INN_LENGHT = 12;

        
        public Guid Id { get; }
        
        public string INN { get;} = string.Empty;
        
        public string Title { get; } = string.Empty;

        public Type Type { get; }

        public List<Founder> Founders { get;}


        private Client(Guid id, string inn, string title, Type type, List<Founder> founders)
        {
            Id = id;
            INN = inn;
            Type = type;
            Founders = founders;
        }

        public static Client? Create(Guid id, string inn, string title, Type type, List<Founder> founders)
        {
            Client? client = null;


            if (founders.Count == 0)
            {
                return client;
            }
            if (type == Type.IP)
            {
                if (founders.Count > 1)
                {
                    return client;
                }
            }
            if (inn.Length != 11 || inn.Length != 12)
            {
                return client;
            }

            client = new Client(id, inn, title, type, founders);

            return client;
        }
    }

    public enum Type
    {
        UL,
        IP
    }
}
