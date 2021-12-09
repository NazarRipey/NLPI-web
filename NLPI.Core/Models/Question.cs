using NLPI.Core.Models.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace NLPI.Core.Models
{
    public class Question : IBaseEntity
    {
        public Question()
        {
            Tasks = new HashSet<TestTask>();
        }
        public int Id { get; set; }
        public string QuestionText { get; set; }
        public string HtmlText { get; set; }
        public virtual ICollection<TestTask> Tasks { get; set; }
    }
}
