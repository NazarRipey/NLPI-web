using NLPI.Core.Models.Base;

namespace NLPI.Core.Models
{
    public class LevelResult : IBaseEntity
    {
        public int Id { get; set; }
        public int TaskCount { get; set; }
        public int Score { get; set; }
        public int LevelId { get; set; }
        public virtual Level Level { get; set; }
        public int UserId { get; set; }
        public virtual User User { get; set; }
    }
}
