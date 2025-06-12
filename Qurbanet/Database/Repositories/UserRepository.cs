using Microsoft.EntityFrameworkCore;
using Qurbanet.Models.Enums;
using Qurbanet.Models.Entities;

namespace Qurbanet.Database.Repositories
{
    public class UserRepository : BaseRepository<User>
    {
        public UserRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<User> GetByUsernameAsync(string username)
        {
            return await _dbSet.FirstOrDefaultAsync(u => u.Username == username);
        }

        public async Task<IEnumerable<User>> GetAdminsAsync()
        {
            return await _dbSet.Where(u => u.UserType == UserType.Admin).ToListAsync();
        }
    }
}
