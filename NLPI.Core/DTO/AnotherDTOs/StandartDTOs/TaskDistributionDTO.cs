﻿using NLPI.Core.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace NLPI.Core.DTO.AnotherDTOs.StandartDTOs
{
    public class TaskDistributionDTO
    {
        public int Id { get; set; }
        public Difficulty TaskDifficulty { get; set; }
        public int TaskOrder { get; set; }
        public int IdTask { get; set; }
        public int IdLevel { get; set; }
    }
}
