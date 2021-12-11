using NLPI.Core.Models.Base;
using System.Collections.Generic;

namespace NLPI.Core.Models
{
    public class TestTask : IBaseEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int TaskTypeId { get; set; }

        public virtual ICollection<Answer> Answers { get; set; }
        public virtual ICollection<Answer> EtalonAnswers { get; set; }
        public virtual TaskType TaskType { get; set; }
    }
}