using NLPI.Core.Abstractions.IRepositories.Base;
using NLPI.Core.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NLPI.Core.Abstractions.IRepositories
{
    public interface ITaskRepo : IBaseRepo<TestTask>
    {
        public Task<List<TestTask>> GetTaskByTypeId(int typeId);
    }
}
