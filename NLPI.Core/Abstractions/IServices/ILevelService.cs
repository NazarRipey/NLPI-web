using NLPI.Core.Abstractions.IServices.Base;
using NLPI.Core.DTO.AchievementsDTOs.StandartDTOs;
using NLPI.Core.Enums;
using NLPI.Core.Models;
using NLPI.Core.DTO.AnotherDTOs.SpecializedDTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NLPI.Core.Abstractions.IServices
{
    public interface ILevelService : IBaseService<LevelDTO, LevelDTO>
    {
        Task GenerateAsync(Difficulty difficulty);
        Task<List<LevelTasksDTO>> GetAllDetailed(string email);
    }
}
