using NLPI.Core.Models.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace NLPI.Core.Models
{
    public class LevelResult : IBaseEntity
    {
        public int Id { get; set; }      
        public int TaskCount { get; set; }
        public int Score { get; set; }
        public int LevelId { get; set; }
        public Level Level { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
    }
}
