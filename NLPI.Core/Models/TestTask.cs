using NLPI.Core.Enums;
using NLPI.Core.Models.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace NLPI.Core.Models
{
    public class TestTask : IBaseEntity
    {        
        public int Id { get; set; }
        public string Description { get; set; }
        public int LevelId { get; set; }
        public Level Level { get; set; }

        public ICollection<Answer> Answers{ get; set; }
    }
}
