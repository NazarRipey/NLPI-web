using NLPI.Core.Models.Base;

namespace NLPI.Core.Models
{
    public class UserAnswer : IBaseEntity
    {
        public int Id { get; set; }
        public int Position { get; set; }
        public bool IsCorrectAndInRightPosition { get; set; }
        public int AnswerId { get; set; }
        public int UserResultId { get; set; }

        public virtual Answer Answer { get; set; }
        public virtual UserTaskResult UserResult { get; set; }
    }
}
