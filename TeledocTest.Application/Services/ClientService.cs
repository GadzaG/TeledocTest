using TeledocTest.Core.Models;
using TeledocTest.DataAccess.Repositories;

namespace TeledocTest.Application.Services
{
    public class ClientService
    {
        private readonly ClientRepository _clientRepository;

        public ClientService(ClientRepository clientRepository)
        {
            _clientRepository = clientRepository;
        }

        public async Task<List<Client>> GetAllClients()
        {
            return await _clientRepository.GetAllAsync();
        }

        public async Task<Client> GetClientById(Guid id)
        {
            return await _clientRepository.GetByIdAsync(id);
        }

        public async Task<Guid> UpdateClient(Client client)
        {
            return await _clientRepository.UpdateAsync(client);
        }

        public async Task<Guid> DeleteClient(Guid id)
        {
            return await _clientRepository.DeleteAsync(id);
        }

        public async Task<Guid> AddClient(Client client)
        {
            return await _clientRepository.AddAsync(client);
        }

    }
}
