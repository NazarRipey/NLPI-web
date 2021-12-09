using NLPI.Core.Models.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace NLPI.Core.Models
{
    public class Metadata : IBaseEntity
    {
        public Metadata()
        {
            TagDistributions = new HashSet<TagDistribution>();
            Tasks = new HashSet<TestTask>();
        }
        public int Id { get; set; }
        public int IdUnit { get; set; }
        public virtual Unit IdUnitNavigation { get; set; }
        public virtual ICollection<TagDistribution> TagDistributions { get; set; }
        public virtual ICollection<TestTask> Tasks { get; set; }
    }
}
