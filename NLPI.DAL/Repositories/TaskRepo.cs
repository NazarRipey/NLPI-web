using Microsoft.EntityFrameworkCore;
using NLPI.Core.Abstractions.IRepositories;
using NLPI.Core.Models;
using NLPI.DAL.Repositories.Base;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NLPI.DAL.Repositories
{
    public class TaskRepo : BaseRepo<TestTask>, ITaskRepo
    {
        public TaskRepo(NLPIDbContext context) : base(context)
        {

        }

        public async Task<List<TestTask>> GetTaskByTypeId(int typeId)
        {
            var tasks = await _context.Tasks.Where(t => t.TaskTypeId == typeId).ToListAsync();
            return tasks;
        }
    }
}
