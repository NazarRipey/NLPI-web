using NLPI.Core.Abstractions.IRepositories;
using NLPI.Core.Models;
using NLPI.DAL.Repositories.Base;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLPI.DAL.Repositories
{
    public class UserAchievementRepo : BaseRepo<UserAchievement>, IUserAchievementRepo
    {
        private readonly NLPIDbContext _context;
        public UserAchievementRepo(NLPIDbContext context) : base(context)
        {
            _context = context;
        }

        public override async Task<IEnumerable<UserAchievement>> GetAllAsync()
        {
            return await _context.Set<UserAchievement>()
                .Include(userAchievement => userAchievement.IdUserNavigation)
                .Include(userAchievement => userAchievement.IdLevelNavigation)
                .ToListAsync();
        }

        public override async Task<UserAchievement> GetByIdAsync(int id)
        {
            return await _context.Set<UserAchievement>()
                .Where(e => e.Id == id)
                .Include(userAchievement => userAchievement.IdUserNavigation)
                .Include(userAchievement => userAchievement.IdLevelNavigation)
                .FirstOrDefaultAsync()
                .ConfigureAwait(false);
        }
    }
}
