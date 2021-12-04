using NLPI.Core.DTO.AnotherDTOs.StandartDTOs;
using NLPI.Core.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace NLPI.Core.DTO.AchievementsDTOs.StandartDTOs
{
    public class LevelDTO
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int TasksCount { get; set; }
        public Difficulty LevelDifficulty { get; set; }
        public List<CSSTaskDTOOutput> Tasks { get; set; }
    }
}
