﻿using NLPI.Core.Abstractions.IRepositories;
using NLPI.Core.Models;
using NLPI.DAL.Repositories.Base;

namespace NLPI.DAL.Repositories
{
    public class UserTaskResultRepo : BaseRepo<UserTaskResult>, IUserTaskResultRepo
    {
        private readonly NLPIDbContext _context;
        public UserTaskResultRepo(NLPIDbContext context) : base(context)
        {
            _context = context;
        }
    }
}
