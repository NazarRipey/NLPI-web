﻿using NLPI.Core.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace NLPI.Core.DTO.AnotherDTOs.StandartDTOs
{
    public class CSSTaskDTO
    {
        public int Id { get; set; }
        public int IdQuestion { get; set; }
        public int IdAnswer { get; set; }
        public int IdMetadata { get; set; }
        public Difficulty TaskDifficulty { get; set; }
    }
}
