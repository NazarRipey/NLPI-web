using NLPI.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace NLPI.Core.DTO.MainDTOs
{
    public class LevelAnswerDTO
    {
        public int LevelId { get; set; }
        public ICollection<Answer> Answers { get; set; }
        public string Email { get; set; }
    }
}
