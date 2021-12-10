using NLPI.Core.Models.Base;
using System.Collections.Generic;

namespace NLPI.Core.Models
{
    public class Level : IBaseEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Difficulty { get; set; }

        public virtual ICollection<TestTask> Tasks { get; set; }
    }
}
