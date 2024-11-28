using Microsoft.EntityFrameworkCore;
using TeledocTest.Core.Abstractions;
using TeledocTest.Core.Models;
using TeledocTest.DataAccess.Entities;

namespace TeledocTest.DataAccess.Repositories
{
    public class ClientRepository : IRepository<Client>
    {
        private readonly TeledocDbContext _context;

        public ClientRepository(TeledocDbContext context)
        {
            _context = context;
        }

        public async Task<Client> GetByIdAsync(Guid id)
        {
            var clientEntity = await _context.Clients
                .Include(c => c.Founders)
                .FirstOrDefaultAsync(c => c.Id == id);

            if (clientEntity == null)
            {
                return null;
            }

            return MapToClient(clientEntity);
        }

        public async Task<List<Client>> GetAllAsync()
        {
            var clientEntities = await _context.Clients
                .Include(c => c.Founders)
                .ToListAsync();

            return clientEntities.Select(MapToClient).ToList();
        }

        public async Task<Guid> AddAsync(Client client)
        {
            var clientEntity = MapToClientEntity(client);
            await _context.Clients.AddAsync(clientEntity);
            await _context.SaveChangesAsync();
            return clientEntity.Id;
        }

        public async Task<Guid> UpdateAsync(Client client)
        {
            var clientEntity = MapToClientEntity(client);
            _context.Clients.Update(clientEntity);
            await _context.SaveChangesAsync();
            return clientEntity.Id;
        }

        public async Task<Guid> DeleteAsync(Guid id)
        {
            var clientEntity = await _context.Clients.FindAsync(id);
            if (clientEntity != null)
            {
                _context.Clients.Remove(clientEntity);
                await _context.SaveChangesAsync();
                return clientEntity.Id;
            }
            return Guid.Empty;
        }

        private static Client? MapToClient(ClientEntity clientEntity)
        {
            var founders = clientEntity.Founders.Select(f => Founder.Create(f.Id, f.FirstName, f.LastName, f.INN).Founder).ToList();
            var client = Client.Create(clientEntity.Id, clientEntity.INN, clientEntity.Title, clientEntity.Type, founders);

            if (client == null)
            {
                throw new InvalidOperationException();
            }

            return client;
        }

        private static ClientEntity MapToClientEntity(Client client)
        {
            var founders = client.Founders.Select(f => new FounderEntity
            {
                Id = f.Id,
                FirstName = f.FirstName,
                LastName = f.LastName,
                INN = f.INN,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            }).ToList();

            return new ClientEntity
            {
                Id = client.Id,
                INN = client.INN,
                Title = client.Title,
                Type = client.Type,
                Founders = founders,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            };
        }
    }
}
