using NLPI.Core.Abstractions.IRepositories;
using NLPI.Core.Models;
using NLPI.DAL.Repositories.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace NLPI.DAL.Repositories
{
    public class MetadataRepo : BaseRepo<Metadata>, IMetadataRepo
    {
        private readonly NLPIDbContext _context;
        public MetadataRepo(NLPIDbContext context) : base(context)
        {
            _context = context;
        }
    }
}
