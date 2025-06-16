using Microsoft.EntityFrameworkCore;
using Qurbanet.Models.Entities;

namespace Qurbanet.Database.Repositories
{
    public class AnimalRepository : BaseRepository<Animal>
    {
        public AnimalRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Animal>> GetByOrganizationAsync(int organizationId)
        {
            return await _dbSet.Where(a => a.OrganizationId == organizationId).ToListAsync();
        }
    }
}
