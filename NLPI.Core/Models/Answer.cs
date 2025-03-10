﻿using NLPI.Core.Models.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace NLPI.Core.Models
{
    public class Answer : IBaseEntity
    {
        public Answer()
        {
            Tasks = new HashSet<CSSTask>();
        }
        public int Id { get; set; }
        public string EtalonAnswer { get; set; }
        public virtual ICollection<CSSTask> Tasks { get; set; }
    }
}
