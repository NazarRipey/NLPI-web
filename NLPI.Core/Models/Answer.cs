using NLPI.Core.Models.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace NLPI.Core.Models
{
    public class Answer : IBaseEntity
    {        
        public int Id { get; set; }
        public int TaskId { get; set; }
        public TestTask Task { get; set; }
        public string EtalonAnswer { get; set; }
    }
}
