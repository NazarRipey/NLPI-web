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
        IUserTaskResultRepo UserTaskResultRepo { get; }
        ITaskTypeRepo TaskTypeRepo { get; }
        IUserRepo UserRepo { get; }
        Task SaveChangesAsync();
    }
}
