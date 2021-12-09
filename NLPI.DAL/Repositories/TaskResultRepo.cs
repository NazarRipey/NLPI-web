using NLPI.Core.Abstractions.IRepositories;
using NLPI.Core.Models;
using NLPI.DAL.Repositories.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace NLPI.DAL.Repositories
{
    public class TaskResultRepo : BaseRepo<LevelResult>, ITaskResultRepo
    {
        private readonly NLPIDbContext _context;
        public TaskResultRepo(NLPIDbContext context) : base(context)
        {
            _context = context;
        }
    }
}
