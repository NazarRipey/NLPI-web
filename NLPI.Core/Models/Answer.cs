using NLPI.Core.Models.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace NLPI.Core.Models
{
    public class Answer : IBaseEntity
    {
        public int Id { get; set; }
        public int TaskId { get; set; }

        [ForeignKey("TaskId")]
        public virtual TestTask Task { get; set; }
        public string TextAnswer { get; set; }
        public bool IsCorrect { get; set; }
        public int CorrectPosition { get; set; }
    }
}