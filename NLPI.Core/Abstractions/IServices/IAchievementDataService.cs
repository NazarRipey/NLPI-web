using NLPI.Core.Abstractions.IServices.Base;
using NLPI.Core.DTO.AchievementsDTOs.SpecializedDTOs;
using NLPI.Core.DTO.AchievementsDTOs.StandartDTOs;
using NLPI.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NLPI.Core.Abstractions.IServices
{
    public interface IAchievementDataService : IBaseService<AchievementDataDTO, AchievementDataDTO>
    {
        Task<List<CompareAchievDataDTO>> GetCompareAchievs(string OwnUserEmail, string AnotherUserEmail);
        Task<List<SimpleAchievDataDTO>> GetAchievsByEmail(string UserEmail);
        Task<List<DetailAchievDataDTO>> GetDetailAchievsByEmail(string UserEmail);
        Task<bool> SaveAchievement(UpdateUserAchievement updateUserAchievementDTO);
    }
}
