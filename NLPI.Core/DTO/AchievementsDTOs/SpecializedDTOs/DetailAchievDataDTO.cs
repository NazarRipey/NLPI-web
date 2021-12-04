using System;
using System.Collections.Generic;
using System.Text;

namespace NLPI.Core.DTO.AchievementsDTOs.SpecializedDTOs
{
    public class DetailAchievDataDTO : SimpleAchievDataDTO
    {
        public string AchievTitle { get; set; }
        public string AchievNotes { get; set; }
    }
}
