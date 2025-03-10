﻿using NLPI.Core.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace NLPI.Core.DTO.AnotherDTOs.SpecializedDTOs
{
    public class LevelTasksDTO
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int TasksCount { get; set; }
        public Difficulty LevelDifficulty { get; set; }

        public List<TaskDistributionDetailedDTO> TaskDistributions { get; set; }
    }
}
