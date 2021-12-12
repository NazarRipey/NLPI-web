using NLPI.Core.Abstractions.IServices.Base;
using NLPI.Core.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NLPI.Core.Abstractions.IServices
{
    public interface ITaskService : IBaseService<TestTask, TestTask>
    {
        Task<List<TestTask>> GetTaskByTypeId(int typeId);
    }
}
