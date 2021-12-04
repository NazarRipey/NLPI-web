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
    public class LevelRepo : BaseRepo<Level>, ILevelRepo
    {
        private readonly NLPIDbContext _context;
        public LevelRepo(NLPIDbContext context) : base(context)
        {
            _context = context;
        }

        public virtual async Task<IEnumerable<Level>> GetAllDetailedAsync(int userId)
        {
            return await _context.Set<Level>()
                .Include(l => l.TaskDistributions)
                    .ThenInclude(td => td.IdTaskNavigation)
                        .ThenInclude(t => t.IdAnswerNavigation)
                .Include(l => l.TaskDistributions)
                    .ThenInclude(td => td.IdTaskNavigation)
                        .ThenInclude(t => t.IdQuestionNavigation)
                .Include(l => l.TaskDistributions)
                    .ThenInclude(td => td.IdTaskNavigation)
                        .ThenInclude(t => t.IdMetadataNavigation)
                .Include(l => l.TaskDistributions)
                    .ThenInclude(td => td.IdTaskNavigation)
                        .ThenInclude(t => t.TaskResults.Where(tr => tr.IdUser == userId))
                .ToListAsync();
        }
    }
}
