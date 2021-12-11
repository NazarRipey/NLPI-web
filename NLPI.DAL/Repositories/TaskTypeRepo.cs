using NLPI.Core.Abstractions.IRepositories;
using NLPI.Core.Models;
using NLPI.DAL.Repositories.Base;

namespace NLPI.DAL.Repositories
{
    public class TaskTypeRepo : BaseRepo<TaskType>, ITaskTypeRepo
    {
        private readonly NLPIDbContext _context;

        public TaskTypeRepo(NLPIDbContext context) : base(context)
        {

        }
    }
}
