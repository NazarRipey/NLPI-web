using AutoMapper;
using NLPI.Core.Abstractions;
using NLPI.Core.Abstractions.IServices;
using NLPI.Core.DTO.AchievementsDTOs.StandartDTOs;
using NLPI.Core.DTO.AnotherDTOs.StandartDTOs;
using NLPI.Core.Enums;
using NLPI.Core.DTO.AnotherDTOs.SpecializedDTOs;
using NLPI.Core.Models;
using NLPI.Services.Base;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NLPI.Services.Exceptions;
using NLPI.Core.DTO.MainDTOs;

namespace NLPI.Services
{
    public class LevelService : BaseService, ILevelService
    {
        public LevelService(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        {

        }

        public async Task<LevelResult> CheckLevel(LevelAnswerDTO answer)
        {
            var level= await _unitOfWork.LevelRepo.GetByIdAsync(answer.LevelId);
            var user = (await _unitOfWork.UserRepo.GetAllAsync()).FirstOrDefault(u => u.Email == answer.Email);
            var res = 0;

            foreach (var task in level.Tasks)
                if (task.Answers.Select(a => a.EtalonAnswer).Contains(answer.Answers.SingleOrDefault(a => a.Id == task.Id).EtalonAnswer))
                    res++;

            var levelResult = new LevelResult()
            {
                Score = res,
                TaskCount = level.Tasks.Count(),
                UserId = user.Id,
            };

            await _unitOfWork.TaskResultRepo.AddAsync(levelResult);
            await _unitOfWork.SaveChangesAsync();

            return levelResult;
        }

        public virtual async Task CreateAsync(Level entity)
        {
            var value = new Level();
            _mapper.Map(entity, value);
            await _unitOfWork.LevelRepo.AddAsync(value);
            await _unitOfWork.SaveChangesAsync();
        }

        public virtual async Task DeleteAsync(int id)
        {
            var entity = await _unitOfWork.LevelRepo.GetByIdAsync(id);
            await _unitOfWork.LevelRepo.DeleteAsync(entity);
            await _unitOfWork.SaveChangesAsync();
        }

        public virtual async Task<List<Level>> GetAll()
        {
            var levels = (await _unitOfWork.LevelRepo.GetAllAsync()).ToList();
            return levels;
        }

        public virtual async Task<Level> GetIdAsync(int id)
        {
            var levels = await _unitOfWork.LevelRepo.Get()
                .Include(l => l.Tasks).ToListAsync();

            var level = levels.FirstOrDefault(l => l.Id == id);

            if (level == null)
                throw new Exception("Such level not found");


            return level;
        }

        public virtual async Task<Level> UpdateAsync(Level entity)
        {                        
            await _unitOfWork.LevelRepo.UpdateAsync(entity);
            await _unitOfWork.SaveChangesAsync();
            return entity;
        }
    }
}
