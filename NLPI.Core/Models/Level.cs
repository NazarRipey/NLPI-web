using NLPI.Core.Enums;
using NLPI.Core.Models.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace NLPI.Core.Models
{
    public class Level : IBaseEntity
    {
        public Level()
        {
            UserAchievements = new HashSet<UserAchievement>();
            TaskDistributions = new HashSet<TaskDistribution>();
        }
        public int Id { get; set; }
        public string Title { get; set; }
        public int TasksCount { get; set; }
        public Difficulty LevelDifficulty { get; set; }

        public virtual ICollection<UserAchievement> UserAchievements { get; set; }
        public virtual ICollection<TaskDistribution> TaskDistributions { get; set; }
    }
}
