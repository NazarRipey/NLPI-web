using NLPI.Core.Models.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace NLPI.Core.Models
{
    public class UnitDistribution : IBaseEntity
    {
        public int Id { get; set; }
        public int IdUnit { get; set; }
        public int IdMetadata { get; set; }
        public virtual Unit IdUnitNavigation { get; set; }
        public virtual Metadata IdMetadataNavigation { get; set; }
    }
}
