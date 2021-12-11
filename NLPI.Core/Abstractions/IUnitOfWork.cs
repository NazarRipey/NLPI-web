using NLPI.Core.Abstractions.IRepositories;
using System;
using System.Threading.Tasks;

namespace NLPI.Core.Abstractions
{
    public interface IUnitOfWork : IDisposable
    {
        IAnswerRepo AnswerRepo { get; }
        ITaskRepo TaskRepo { get; }
        IHintRepo HintRepo { get; }
        IMetadataRepo MetadataRepo { get; }
        IQuestionRepo QuestionRepo { get; }
        ITagDistributionRepo TagDistributionRepo { get; }
        ITagRepo TagRepo { get; }
        IUserTaskResultRepo UserTaskResultRepo { get; }
        ITaskTypeRepo TaskTypeRepo { get; }
        //IUnitDistributionRepo UnitDistributionRepo { get; }
        IUnitRepo UnitRepo { get; }
        IUserRepo UserRepo { get; }
        IUserAchievementRepo UserAchievementRepo { get; }
        IAchievementDataRepo AchievementDataRepo { get; }
        Task SaveChangesAsync();
    }
}
