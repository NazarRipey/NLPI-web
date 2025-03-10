﻿using AutoMapper;
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
    public class CSSTaskService : BaseService, ICSSTaskService
    {
        public CSSTaskService(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        {

        }
        public virtual async Task CreateAsync(CSSTaskDTO entity)
        {
            var value = new CSSTask();
            _mapper.Map(entity, value);
            await _unitOfWork.CSSTaskRepo.AddAsync(value);
            await _unitOfWork.SaveChangesAsync();
            _mapper.Map(value, entity);
        }

        public virtual async Task DeleteAsync(int id)
        {
            var entity = await _unitOfWork.CSSTaskRepo.GetByIdAsync(id);
            await _unitOfWork.CSSTaskRepo.DeleteAsync(entity);
            await _unitOfWork.SaveChangesAsync();
        }

        public virtual async Task<List<CSSTaskDTO>> GetAll()
        {
            var cSSTasks = await _unitOfWork.CSSTaskRepo.GetAllAsync();
            List<CSSTaskDTO> cSSTaskDTOs = cSSTasks.Select(cSSTask => _mapper.Map(cSSTask, new CSSTaskDTO())).ToList();
            return cSSTaskDTOs;
        }

        public virtual async Task<CSSTaskExecDTO> GetExecAsync(int id)
        {
            var cssTask = await _unitOfWork.CSSTaskRepo.GetExecAsync(id);
            if (cssTask == null)
                throw new NotFoundException("Task", id);
            return _mapper.Map<CSSTaskExecDTO>(cssTask);
        }

        public virtual async Task<CSSTaskDTO> GetIdAsync(int id)
        {
            var cSSTask = await _unitOfWork.CSSTaskRepo.GetByIdAsync(id);
            if (cSSTask == null)
                throw new Exception("Such order not found");
            var dto = new CSSTaskDTO();
            _mapper.Map(cSSTask, dto);
            return dto;
        }

        public virtual async Task<CSSTaskDTO> UpdateAsync(CSSTaskDTO entity)
        {
            var value = new CSSTask();
            _mapper.Map(entity, value);
            await _unitOfWork.CSSTaskRepo.UpdateAsync(value);
            await _unitOfWork.SaveChangesAsync();
            return entity;
        }
    }
}
