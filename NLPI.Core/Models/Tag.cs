using NLPI.Core.Models.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace NLPI.Core.Models
{
    public class Tag : IBaseEntity
    {
        public Tag()
        {
            TagDistributions = new HashSet<TagDistribution>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<TagDistribution> TagDistributions { get; set; }
    }
}
