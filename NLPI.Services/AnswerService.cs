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
    public class AnswerService : BaseService, IAnswerService
    {
        public AnswerService(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        {

        }
        public virtual async Task CreateAsync(AnswerDTO entity)
        {
            var value = new Answer();
            _mapper.Map(entity, value);
            await _unitOfWork.AnswerRepo.AddAsync(value);
            await _unitOfWork.SaveChangesAsync();
            _mapper.Map(value, entity);
        }

        public virtual async Task DeleteAsync(int id)
        {
            var entity = await _unitOfWork.AnswerRepo.GetByIdAsync(id);
            await _unitOfWork.AnswerRepo.DeleteAsync(entity);
            await _unitOfWork.SaveChangesAsync();
        }

        public virtual async Task<List<AnswerDTO>> GetAll()
        {
            var answers = await _unitOfWork.AnswerRepo.GetAllAsync();
            List<AnswerDTO> answerDTOs = answers.Select(answer => _mapper.Map(answer, new AnswerDTO())).ToList();
            return answerDTOs;
        }

        public virtual async Task<AnswerDTO> GetIdAsync(int id)
        {
            var answer = await _unitOfWork.AnswerRepo.GetByIdAsync(id);
            if (answer == null)
                throw new Exception("Such order not found");
            var dto = new AnswerDTO();
            _mapper.Map(answer, dto);
            return dto;
        }

        public virtual async Task<AnswerDTO> UpdateAsync(AnswerDTO entity)
        {
            var value = new Answer();
            _mapper.Map(entity, value);
            await _unitOfWork.AnswerRepo.UpdateAsync(value);
            await _unitOfWork.SaveChangesAsync();
            return entity;
        }
    }
}
