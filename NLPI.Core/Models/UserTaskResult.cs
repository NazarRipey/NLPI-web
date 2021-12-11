using NLPI.Core.Models.Base;
using System.Collections.Generic;

namespace NLPI.Core.Models
{
    public class UserTaskResult : IBaseEntity
    {
        public int Id { get; set; }
        public int TaskId { get; set; }
        public int UserId { get; set; }
        public int Score { get; set; }

        public virtual List<UserAnswer> UserAnswers { get; set; }
    }
}
