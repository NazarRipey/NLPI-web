using NLPI.Core.Abstractions.IRepositories;
using NLPI.Core.Models;
using NLPI.DAL.Repositories.Base;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NLPI.DAL.Repositories
{
    public class AchievementDataRepo : BaseRepo<AchievementData>, IAchievementDataRepo
    {
        private readonly NLPIDbContext _context;
        public AchievementDataRepo(NLPIDbContext context) : base(context)
        {
            _context = context;
        }

        public override async Task<IEnumerable<AchievementData>> GetAllAsync()
        {
            /* return await _context.Set<AchievementData>()
                 .Include(achievementData => achievementData.IdUserAchievementNavigation)
                 .ThenInclude(userAchievement => userAchievement.IdLevelNavigation)
                 .ToListAsync();*/
            return null;
        }

        public override async Task<AchievementData> GetByIdAsync(int id)
        {
            /*return await _context.Set<AchievementData>()
                .Where(e => e.Id == id)
                .Include(achievementData => achievementData.IdUserAchievementNavigation)
                .ThenInclude(userAchievement => userAchievement.IdLevelNavigation)
                .FirstOrDefaultAsync()
                .ConfigureAwait(false);*/

            return null;
        }
    }
}
