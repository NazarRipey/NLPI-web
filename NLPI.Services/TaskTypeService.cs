using AutoMapper;
using NLPI.Core.Abstractions;
using NLPI.Core.Abstractions.IServices;
using NLPI.Core.Models;
using NLPI.Services.Base;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NLPI.Services
{
    public class TaskTypeService : BaseService, ITaskTypeService
    {
        public TaskTypeService(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        {

        }
        public virtual async Task CreateAsync(TaskType entity)
        {
            await _unitOfWork.TaskTypeRepo.AddAsync(entity);
            await _unitOfWork.SaveChangesAsync();
        }

        public virtual async Task DeleteAsync(int id)
        {
            var entity = await _unitOfWork.TaskTypeRepo.GetByIdAsync(id);
            await _unitOfWork.TaskTypeRepo.DeleteAsync(entity);
            await _unitOfWork.SaveChangesAsync();
        }

        public virtual async Task<List<TaskType>> GetAll()
        {
            var taskTypes = await _unitOfWork.TaskTypeRepo.GetAllAsync();
            return taskTypes.ToList();
        }

        public virtual async Task<TaskType> GetIdAsync(int id)
        {
            var taskType = await _unitOfWork.TaskTypeRepo.GetByIdAsync(id);
            return taskType;
        }

        public virtual async Task<TaskType> UpdateAsync(TaskType entity)
        {
            await _unitOfWork.TaskTypeRepo.UpdateAsync(entity);
            await _unitOfWork.SaveChangesAsync();
            return entity;
        }
    }
}
