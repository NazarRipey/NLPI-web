using NLPI.Core.Models.Base;
using System.Collections.Generic;

namespace NLPI.Core.Models
{
    public class TaskType : IBaseEntity
    {
        public int Id { get; set; }
        public string Type { get; set; }

        public virtual ICollection<TestTask> TestTasks { get; set; }
    }
}
