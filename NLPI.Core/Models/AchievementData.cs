using NLPI.Core.Models.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace NLPI.Core.Models
{
    public class AchievementData : IBaseEntity
    {
        public int Id { get; set; }
        public int CompletedCount { get; set; }
        public int CorrectCount { get; set; }
        public int CurrentMark { get; set; }
        public int TryCount { get; set; }
        public int IdUserAchievement { get; set; }

        public virtual UserAchievement IdUserAchievementNavigation { get; set; }
    }
}
