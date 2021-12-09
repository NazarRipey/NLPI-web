using NLPI.Core.Abstractions.IServices.Base;
using NLPI.Core.DTO.AchievementsDTOs.StandartDTOs;
using NLPI.Core.Enums;
using NLPI.Core.Models;
using NLPI.Core.DTO.AnotherDTOs.SpecializedDTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using NLPI.Core.DTO.MainDTOs;

namespace NLPI.Core.Abstractions.IServices
{
    public interface ILevelService : IBaseService<Level, Level>
    {
        public Task<LevelResult> CheckLevel(LevelAnswerDTO answer);
    }
}
