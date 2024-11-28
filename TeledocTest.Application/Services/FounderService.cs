using TeledocTest.Core.Models;
using TeledocTest.DataAccess.Repositories;

namespace TeledocTest.Application.Services
{
    public class FounderService
    {
        private readonly FounderRepository _founderRepository;

        public FounderService(FounderRepository founderRepository)
        {
            _founderRepository = founderRepository;
        }

        public async Task<List<Founder>> GetAllClients()
        {
            return await _founderRepository.GetAllAsync();
        }

        public async Task<Founder> GetClientById(Guid id)
        {
            return await _founderRepository.GetByIdAsync(id);
        }

        public async Task<Guid> UpdateClient(Founder founder)
        {
            return await _founderRepository.UpdateAsync(founder);
        }

        public async Task<Guid> DeleteClient(Guid id)
        {
            return await _founderRepository.DeleteAsync(id);
        }

        public async Task<Guid> AddClient(Founder founder)
        {
            return await _founderRepository.AddAsync(founder);
        }

    }
}
