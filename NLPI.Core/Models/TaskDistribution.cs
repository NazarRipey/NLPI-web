using NLPI.Core.Enums;
using NLPI.Core.Models.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace NLPI.Core.Models
{
    public class TaskDistribution : IBaseEntity
    {
        public int Id { get; set; }
        public int TaskOrder { get; set; }
        public int IdTask { get; set; }
        public int IdLevel { get; set; }
        public virtual TestTask IdTaskNavigation { get; set; }
        public virtual Level IdLevelNavigation { get; set; }
    }
}
