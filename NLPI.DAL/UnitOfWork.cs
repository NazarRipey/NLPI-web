using NLPI.Core.Abstractions;
using NLPI.Core.Abstractions.IRepositories;
using NLPI.DAL.Repositories;
using System.Threading.Tasks;

namespace NLPI.DAL
{
    public class UnitOfWork : IUnitOfWork
    {
        private IUserRepo _userRepo;
        private IAnswerRepo _answerRepo;
        private ITaskRepo _taskRepo;
        private ITaskTypeRepo _taskTypeRepo;
        private IHintRepo _hintRepo;
        private IUserTaskResultRepo _userTaskResultRepo;
        private NLPIDbContext _context;

        public UnitOfWork(NLPIDbContext context)
        {
            _context = context;
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }
        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync().ConfigureAwait(false);
        }

        public void Dispose()
        {
            if (_context != null)
            {
                _context.Dispose();
                _context = null;
            }
        }

        public IUserRepo UserRepo
        {
            get { return _userRepo ??= new UserRepo(_context); }
        }

        public IAnswerRepo AnswerRepo
        {
            get { return _answerRepo ??= new AnswerRepo(_context); }
        }

        public ITaskRepo TaskRepo
        {
            get { return _taskRepo ??= new TaskRepo(_context); }
        }

        public IHintRepo HintRepo
        {
            get { return _hintRepo ??= new HintRepo(_context); }
        }

        public IUserTaskResultRepo UserTaskResultRepo
        {
            get { return _userTaskResultRepo ??= new UserTaskResultRepo(_context); }
        }

        public ITaskTypeRepo TaskTypeRepo
        {
            get { return _taskTypeRepo ??= new TaskTypeRepo(_context); }
        }
    }
}
