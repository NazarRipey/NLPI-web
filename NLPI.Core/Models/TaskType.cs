using NLPI.Core.Models.Base;

namespace NLPI.Core.Models
{
    public class TaskType : IBaseEntity
    {
        public int Id { get; set; }
        public string Type { get; set; }
    }
}
