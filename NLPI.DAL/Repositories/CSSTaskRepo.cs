using NLPI.Core.Abstractions.IRepositories;
using NLPI.Core.Models;
using NLPI.DAL.Repositories.Base;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NLPI.DAL.Repositories
{
    public class CSSTaskRepo : BaseRepo<CSSTask>, ICSSTaskRepo
    {
        private readonly NLPIDbContext _context;
        public CSSTaskRepo(NLPIDbContext context) : base(context)
        {
            _context = context;
        }

        public virtual async  Task<IEnumerable<CSSTask>> GetAllDetailedAsync()
        {
            return await _context.Set<CSSTask>()
                .Include(t => t.IdAnswerNavigation)
                .Include(t => t.IdQuestionNavigation)
                .Include(t => t.IdMetadataNavigation)
                .Include(t => t.TaskDistributions)
                .Include(t => t.TaskResults)
                .ToListAsync();
        }

        public virtual async Task<CSSTask> GetExecAsync(int id)
        {
            return await _context.Set<CSSTask>()
                .Include(t => t.IdAnswerNavigation)
                .Include(t => t.IdQuestionNavigation)
                .Include(t => t.TaskDistributions)
                    .ThenInclude(td => td.IdLevelNavigation)
                .FirstOrDefaultAsync(t => t.Id == id);
        }
    }
}
