using NLPI.Core.Abstractions.IRepositories.Base;
using NLPI.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NLPI.Core.Abstractions.IRepositories
{
    public interface ICSSTaskRepo : IBaseRepo<CSSTask>
    {
        Task<IEnumerable<CSSTask>> GetAllDetailedAsync();

        Task<CSSTask> GetExecAsync(int id);
    }
}
