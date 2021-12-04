using NLPI.Core.Models.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace NLPI.Core.Models
{
    public class TagDistribution : IBaseEntity
    {
        public int Id { get; set; }
        public int IdTag { get; set; }
        public int IdMetadata { get; set; }
        public virtual Tag IdTagNavigation { get; set; }
        public virtual Metadata IdMetadataNavigation { get; set; }
    }
}
