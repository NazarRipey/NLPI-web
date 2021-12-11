using System.Collections.Generic;

namespace NLPI.Core.DTO.MainDTOs
{
    public class TaskPassingDTO
    {
        public int TaskId { get; set; }
        public int UserId { get; set; }
        public virtual ICollection<UserAnswerDTO> UserAnswers { get; set; }
    }
}
