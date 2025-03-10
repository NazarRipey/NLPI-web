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
    public class QuestionService : BaseService, IQuestionService
    {
        public QuestionService(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        {

        }
        public virtual async Task CreateAsync(QuestionDTO entity)
        {
            var value = new Question();
            _mapper.Map(entity, value);
            await _unitOfWork.QuestionRepo.AddAsync(value);
            await _unitOfWork.SaveChangesAsync();
            _mapper.Map(value, entity);
        }

        public virtual async Task DeleteAsync(int id)
        {
            var entity = await _unitOfWork.QuestionRepo.GetByIdAsync(id);
            await _unitOfWork.QuestionRepo.DeleteAsync(entity);
            await _unitOfWork.SaveChangesAsync();
        }

        public virtual async Task<List<QuestionDTO>> GetAll()
        {
            var questions = await _unitOfWork.QuestionRepo.GetAllAsync();
            List<QuestionDTO> questionDTOs = questions.Select(question => _mapper.Map(question, new QuestionDTO())).ToList();
            return questionDTOs;
        }

        public virtual async Task<QuestionDTO> GetIdAsync(int id)
        {
            var question = await _unitOfWork.QuestionRepo.GetByIdAsync(id);
            if (question == null)
                throw new Exception("Such order not found");
            var dto = new QuestionDTO();
            _mapper.Map(question, dto);
            return dto;
        }

        public virtual async Task<QuestionDTO> UpdateAsync(QuestionDTO entity)
        {
            var value = new Question();
            _mapper.Map(entity, value);
            await _unitOfWork.QuestionRepo.UpdateAsync(value);
            await _unitOfWork.SaveChangesAsync();
            return entity;
        }
    }
}
