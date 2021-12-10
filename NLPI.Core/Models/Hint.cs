using NLPI.Core.Models.Base;

namespace NLPI.Core.Models
{
    public class Hint : IBaseEntity
    {
        public int Id { get; set; }
        public string HintType { get; set; }
        public string HintText { get; set; }
        public int IdTask { get; set; }
        public virtual TestTask IdTaskNavigation { get; set; }
    }
}
