﻿using NLPI.Core.Abstractions.IRepositories;
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
        public LevelRepo(NLPIDbContext context) : base(context)
        {
   
        }        
    }
}
