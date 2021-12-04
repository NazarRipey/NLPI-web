using NLPI.Core.DTO.AnotherDTOs.StandartDTOs;
using NLPI.Core.Enums;
using System.Collections.Generic;

namespace NLPI.Core.DTO.AnotherDTOs.SpecializedDTOs
{
    public class CSSTaskDetailedDTO
    {
        public int Id { get; set; }

        public string Question { get; set; }

        public string Answer { get; set; }

        public Difficulty TaskDifficulty { get; set; }

        public List<TaskResultDTO> TaskResults { get; set; }
    } 
}
