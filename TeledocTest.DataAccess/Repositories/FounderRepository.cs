using Microsoft.EntityFrameworkCore;
using TeledocTest.Core.Abstractions;
using TeledocTest.Core.Models;
using TeledocTest.DataAccess.Entities;

namespace TeledocTest.DataAccess.Repositories
{
    public class FounderRepository : IRepository<Founder>
    {
        private readonly TeledocDbContext _context;

        public FounderRepository(TeledocDbContext context)
        {
            _context = context;
        }

        public async Task<Founder> GetByIdAsync(Guid id)
        {
            var founderEntity = await _context.Founders.FindAsync(id);

            if (founderEntity == null)
            {
                return null;
            }

            return MapToFounder(founderEntity);
        }

        public async Task<List<Founder>> GetAllAsync()
        {
            var founderEntities = await _context.Founders.ToListAsync();
            return founderEntities
                .Select(MapToFounder)
                .ToList();
        }

        public async Task<Guid> AddAsync(Founder founder)
        {
            var founderEntity = MapToFounderEntity(founder);
            await _context.Founders.AddAsync(founderEntity);
            await _context.SaveChangesAsync();
            return founderEntity.Id;
        }

        public async Task<Guid> UpdateAsync(Founder founder)
        {
            var founderEntity = MapToFounderEntity(founder);
            _context.Founders.Update(founderEntity);
            await _context.SaveChangesAsync();
            return founderEntity.Id;
        }

        public async Task<Guid> DeleteAsync(Guid id)
        {
            var founderEntity = await _context.Founders.FindAsync(id);
            if (founderEntity != null)
            {
                _context.Founders.Remove(founderEntity);
                await _context.SaveChangesAsync();
                return founderEntity.Id;
            }
            return Guid.Empty;
        }

        private static Founder? MapToFounder(FounderEntity founderEntity)
        {
            var (founder, error) = Founder.Create(founderEntity.Id, founderEntity.FirstName, founderEntity.LastName, founderEntity.INN);

            if (!string.IsNullOrEmpty(error))
            {
                throw new InvalidOperationException(error);
            }

            return founder;
        }

        private static FounderEntity MapToFounderEntity(Founder founder)
        {
            return new FounderEntity
            {
                Id = founder.Id,
                FirstName = founder.FirstName,
                LastName = founder.LastName,
                INN = founder.INN,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            };
        }
    }
}
