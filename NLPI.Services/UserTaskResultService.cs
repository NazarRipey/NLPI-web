using AutoMapper;
using NLPI.Core.Abstractions;
using NLPI.Core.Abstractions.IServices;
using NLPI.Core.DTO.AnotherDTOs.StandartDTOs;
using NLPI.Core.DTO.MainDTOs;
using NLPI.Core.Models;
using NLPI.Services.Base;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NLPI.Services
{
    public class UserTaskResultService : BaseService, IUserTaskResultService
    {
        public UserTaskResultService(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        {

        }

        public virtual async Task<TaskScoreDTO> PassTask(TaskPassingDTO taskPassing)
        {
            List<UserAnswer> userAnswers = new List<UserAnswer>();

            var allAnswers = (await _unitOfWork.AnswerRepo.GetAllAsync()).Where(a => a.TaskId == taskPassing.TaskId && a.IsCorrect).ToList();

            foreach (var a in taskPassing.UserAnswers)
            {
                userAnswers.Add(new UserAnswer()
                {
                    AnswerId = a.Answer.Id,
                    Position = a.Position,
                    IsCorrectAndInRightPosition = a.Answer.IsCorrect && a.Position == a.Answer.CorrectPosition
                });
            }

            int correctAnswers = userAnswers.Where(a => a.IsCorrectAndInRightPosition).Count();
            double score_temp = correctAnswers == 0 ? 0 : (double)correctAnswers / allAnswers.Count();
            int score = (int)(score_temp * 100);

            UserTaskResult userTaskResult = new UserTaskResult()
            {
                TaskId = taskPassing.TaskId,
                UserId = taskPassing.UserId,
                Score = score
            };

            foreach (var a in userAnswers)
            {
                a.UserResult = userTaskResult;
            }

            await _unitOfWork.UserTaskResultRepo.AddAsync(userTaskResult);
            await _unitOfWork.SaveChangesAsync();

            return new TaskScoreDTO()
            {
                Score = score
            };
        }

        public virtual async Task CreateAsync(TaskResultDTO entity)
        {
            /*var value = new LevelResult();
            _mapper.Map(entity, value);
            await _unitOfWork.TaskResultRepo.AddAsync(value);
            await _unitOfWork.SaveChangesAsync();
            _mapper.Map(value, entity);*/
        }

        public virtual async Task<TaskResultDTO> CreateNewAsync(TaskResultCreateDTO dto)
        {
            //var users = await _unitOfWork.UserRepo.GetAllAsync();

            //var user = users.FirstOrDefault(u => u.Email == dto.UserEmail);
            //if (user == null)
            //{
            //    throw new NotFoundException("User");
            //}

            //var entity = _mapper.Map<LevelResult>(dto);
            //entity.ResultDate = DateTime.Now;
            //entity.IdUser = user.Id;
            //entity.Score = 0;
            //entity.UserAnswer = "";
            //entity.Duration = 0;
            //await _unitOfWork.TaskResultRepo.AddAsync(entity);
            //await _unitOfWork.SaveChangesAsync();
            return null;
        }

        public virtual async Task DeleteAsync(int id)
        {
            //var entity = await _unitOfWork.TaskResultRepo.GetByIdAsync(id);
            //await _unitOfWork.TaskResultRepo.DeleteAsync(entity);
            //await _unitOfWork.SaveChangesAsync();
        }

        public virtual async Task<List<TaskResultDTO>> GetAll()
        {
            //var taskResults = await _unitOfWork.TaskResultRepo.GetAllAsync();
            //List<TaskResultDTO> taskResultDTOs = taskResults.Select(taskResult => _mapper.Map(taskResult, new TaskResultDTO())).ToList();
            //return taskResultDTOs;

            return null;
        }

        public virtual async Task<TaskResultDTO> GetIdAsync(int id)
        {
            // var taskResult = await _unitOfWork.TaskResultRepo.GetByIdAsync(id);
            // if (taskResult == null)
            //     throw new Exception("Such order not found");
            //var dto = new TaskResultDTO();
            //_mapper.Map(taskResult, dto);
            //return dto;

            return null;
        }

        public virtual async Task<TaskResultDTO> UpdateAsync(TaskResultDTO entity)
        {
            /*var value = new LevelResult();
            _mapper.Map(entity, value);
            await _unitOfWork.TaskResultRepo.UpdateAsync(value);
            await _unitOfWork.SaveChangesAsync();
            return entity;*/

            return null;
        }
    }
}
