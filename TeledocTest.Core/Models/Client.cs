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

        public static (Client Client, string Error) Create(Guid id, string inn, string title, Type type, List<Founder> founders)
        {
            string error = string.Empty;


            if (founders.Count == 0)
            {
                error = "нельзя создать клиента, без учередителя";
            }
            if (type == Type.IP)
            {
                if (founders.Count > 1)
                {
                    error = "у ИП должен быть только один учередитель";
                }
            }
            var client = new Client(id, inn, title, type, founders);

            return (client, error);
        }
    }

    public enum Type
    {
        UL,
        IP
    }
}
