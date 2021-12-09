using NLPI.Core.Abstractions.IRepositories;
using NLPI.Core.Models;
using NLPI.DAL.Repositories.Base;
using NLPI.DAL.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NLPI.DAL.Repositories
{
    public class TaskRepo : BaseRepo<TestTask>, ITaskRepo
    {        
        public TaskRepo(NLPIDbContext context) : base(context)
        {
     
        }        
    }
}
