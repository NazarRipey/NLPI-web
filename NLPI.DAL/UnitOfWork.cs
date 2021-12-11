using NLPI.Core.Abstractions;
using NLPI.Core.Abstractions.IRepositories;
using NLPI.DAL.Repositories;
using System.Threading.Tasks;

namespace NLPI.DAL
{
    public class UnitOfWork : IUnitOfWork
    {
        private IUserRepo _userRepo;
        private IUserAchievementRepo _userAchievementRepo;
        private IAchievementDataRepo _achievementDataRepo;
        private IAnswerRepo _answerRepo;
        private ITaskRepo _taskRepo;
        private ITaskTypeRepo _taskTypeRepo;
        private IHintRepo _hintRepo;
        private IMetadataRepo _metadataRepo;
        private IQuestionRepo _questionRepo;
        private ITagDistributionRepo _tagDistributionRepo;
        private ITagRepo _tagRepo;
        private IUserTaskResultRepo _userTaskResultRepo;
        //private IUnitDistributionRepo _unitDistributionRepo;
        private IUnitRepo _unitRepo;
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

        public IUserAchievementRepo UserAchievementRepo
        {
            get { return _userAchievementRepo ??= new UserAchievementRepo(_context); }
        }

        public IAchievementDataRepo AchievementDataRepo
        {
            get { return _achievementDataRepo ??= new AchievementDataRepo(_context); }
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

        public IMetadataRepo MetadataRepo
        {
            get { return _metadataRepo ??= new MetadataRepo(_context); }
        }

        public IQuestionRepo QuestionRepo
        {
            get { return _questionRepo ??= new QuestionRepo(_context); }
        }

        public ITagDistributionRepo TagDistributionRepo
        {
            get { return _tagDistributionRepo ??= new TagDistributionRepo(_context); }
        }

        public ITagRepo TagRepo
        {
            get { return _tagRepo ??= new TagRepo(_context); }
        }

        public IUserTaskResultRepo UserTaskResultRepo
        {
            get { return _userTaskResultRepo ??= new UserTaskResultRepo(_context); }
        }

        public ITaskTypeRepo TaskTypeRepo
        {
            get { return _taskTypeRepo ??= new TaskTypeRepo(_context); }
        }

        //public IUnitDistributionRepo UnitDistributionRepo
        //{
        //    get { return _unitDistributionRepo ??= new UnitDistributionRepo(_context); }
        //}

        public IUnitRepo UnitRepo
        {
            get { return _unitRepo ??= new UnitRepo(_context); }
        }
    }
}
