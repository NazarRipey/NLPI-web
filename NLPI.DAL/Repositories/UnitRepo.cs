using NLPI.Core.Abstractions.IRepositories;
using NLPI.Core.Models;
using NLPI.DAL.Repositories.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace NLPI.DAL.Repositories
{
    public class UnitRepo : BaseRepo<Unit>, IUnitRepo
    {
        private readonly NLPIDbContext _context;
        public UnitRepo(NLPIDbContext context) : base(context)
        {
            _context = context;
        }
    }
}
