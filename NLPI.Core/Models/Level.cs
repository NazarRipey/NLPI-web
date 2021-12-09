using NLPI.Core.Enums;
using NLPI.Core.Models.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace NLPI.Core.Models
{
    public class Level : IBaseEntity
    {        
        public int Id { get; set; }
        public string Name { get; set; }     
        public Difficulty LevelDifficulty { get; set; }
        
        public virtual ICollection<TestTask> Tasks { get; set; }
    }
}
