using AutoMapper;
using NLPI.Core.Abstractions;
using NLPI.Core.Abstractions.IServices;
using NLPI.Core.DTO.AnotherDTOs.SpecializedDTOs;
using NLPI.Core.DTO.AnotherDTOs.StandartDTOs;
using NLPI.Core.Models;
using NLPI.Services.Base;
using NLPI.Services.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLPI.Services
{
    public class TaskService : BaseService, ITaskService
    {
        public TaskService(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        {

        }
        public virtual async Task CreateAsync(TestTask entity)
        {            
            await _unitOfWork.TaskRepo.AddAsync(entity);
            await _unitOfWork.SaveChangesAsync();            
        }

        public virtual async Task DeleteAsync(int id)
        {
            var entity = await _unitOfWork.TaskRepo.GetByIdAsync(id);
            await _unitOfWork.TaskRepo.DeleteAsync(entity);
            await _unitOfWork.SaveChangesAsync();
        }

        public virtual async Task<List<TestTask>> GetAll()
        {
            var tasks = (await _unitOfWork.TaskRepo.GetAllAsync()).ToList();
            return tasks;
        }
        
        public virtual async Task<TestTask> GetIdAsync(int id)
        {
            var task = await _unitOfWork.TaskRepo.GetByIdAsync(id);
            if (task == null)
                throw new Exception("Such order not found");
            
            return task;
        }

        public virtual async Task<TestTask> UpdateAsync(TestTask entity)
        {            
            await _unitOfWork.TaskRepo.UpdateAsync(entity);
            await _unitOfWork.SaveChangesAsync();
            return entity;
        }
    }
}
