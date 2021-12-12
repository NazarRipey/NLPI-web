using AutoMapper;
using NLPI.Core.Abstractions;
using NLPI.Core.Abstractions.IServices;
using NLPI.Core.Models;
using NLPI.Services.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NLPI.Services
{
    public class TaskService : BaseService, ITaskService
    {
        public TaskService(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        {

        }
        public virtual async Task CreateAsync(TestTask entity)
        {
            int positionCounter = 1;

            foreach (var ea in entity.EtalonAnswers)
            {
                ea.CorrectPosition = positionCounter++;
                ea.Task = entity;
            }

            foreach (var a in entity.Answers)
            {
                a.Task = entity;
            }


            await _unitOfWork.TaskRepo.AddAsync(entity);
            await _unitOfWork.SaveChangesAsync();
        }

        public virtual async Task DeleteAsync(int id)
        {
            var entity = await _unitOfWork.TaskRepo.GetByIdAsync(id);
            await _unitOfWork.TaskRepo.DeleteAsync(entity);
            await _unitOfWork.SaveChangesAsync();
        }

        public virtual async Task<List<TestTask>> GetAll()
        {
            var tasks = (await _unitOfWork.TaskRepo.GetAllAsync()).ToList();
            return tasks;
        }

        public virtual async Task<TestTask> GetIdAsync(int id)
        {
            var task = await _unitOfWork.TaskRepo.GetByIdAsync(id);

            task.Answers = (task.Answers.Concat(task.EtalonAnswers)).ToList();
            task.EtalonAnswers = task.EtalonAnswers.Concat(task.Answers.Where(a => a.IsCorrect)).ToList();

            task.EtalonAnswers = task.EtalonAnswers.OrderBy(e => e.CorrectPosition).ToList();

            task.Answers = Shuffle(task.Answers.ToList());

            if (task == null)
                throw new Exception("Such order not found");

            return task;
        }

        public async Task<List<TestTask>> GetTaskByTypeId(int typeId)
        {
            var tasks = await _unitOfWork.TaskRepo.GetTaskByTypeId(typeId);
            return tasks;
        }

        public virtual async Task<TestTask> UpdateAsync(TestTask entity)
        {
            await _unitOfWork.TaskRepo.UpdateAsync(entity);
            await _unitOfWork.SaveChangesAsync();
            return entity;
        }

        private static Random rng = new Random();

        public static IList<T> Shuffle<T>(IList<T> list)
        {
            int n = list.Count;
            while (n > 1)
            {
                n--;
                int k = rng.Next(n + 1);
                T value = list[k];
                list[k] = list[n];
                list[n] = value;
            }

            return list;
        }
    }
}
