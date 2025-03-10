﻿using AutoMapper;
using NLPI.Core.Abstractions;
using NLPI.Core.Abstractions.IServices;
using NLPI.Core.DTO.AnotherDTOs.StandartDTOs;
using NLPI.Core.Models;
using NLPI.Services.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLPI.Services
{
    public class TaskDistributionService : BaseService, ITaskDistributionService
    {
        public TaskDistributionService(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        {

        }
        public virtual async Task CreateAsync(TaskDistributionDTO entity)
        {
            var value = new TaskDistribution();
            _mapper.Map(entity, value);
            await _unitOfWork.TaskDistributionRepo.AddAsync(value);
            await _unitOfWork.SaveChangesAsync();
            _mapper.Map(value, entity);
        }

        public virtual async Task DeleteAsync(int id)
        {
            var entity = await _unitOfWork.TaskDistributionRepo.GetByIdAsync(id);
            await _unitOfWork.TaskDistributionRepo.DeleteAsync(entity);
            await _unitOfWork.SaveChangesAsync();
        }

        public virtual async Task<List<TaskDistributionDTO>> GetAll()
        {
            var taskDistributions = await _unitOfWork.TaskDistributionRepo.GetAllAsync();
            List<TaskDistributionDTO> taskDistributionDTOs = taskDistributions.Select(taskDistribution => _mapper.Map(taskDistribution, new TaskDistributionDTO())).ToList();
            return taskDistributionDTOs;
        }

        public virtual async Task<TaskDistributionDTO> GetIdAsync(int id)
        {
            var taskDistribution = await _unitOfWork.TaskDistributionRepo.GetByIdAsync(id);
            if (taskDistribution == null)
                throw new Exception("Such order not found");
            var dto = new TaskDistributionDTO();
            _mapper.Map(taskDistribution, dto);
            return dto;
        }

        public virtual async Task<TaskDistributionDTO> UpdateAsync(TaskDistributionDTO entity)
        {
            var value = new TaskDistribution();
            _mapper.Map(entity, value);
            await _unitOfWork.TaskDistributionRepo.UpdateAsync(value);
            await _unitOfWork.SaveChangesAsync();
            return entity;
        }
    }
}
