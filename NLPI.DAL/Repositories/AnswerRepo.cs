using NLPI.Core.Abstractions.IRepositories;
using NLPI.Core.Models;
using NLPI.DAL.Repositories.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace NLPI.DAL.Repositories
{
    public class AnswerRepo : BaseRepo<Answer>, IAnswerRepo
    {
        private readonly NLPIDbContext _context;
        public AnswerRepo(NLPIDbContext context) : base(context)
        {
            _context = context;
        }
    }
}
