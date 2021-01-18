using System;
using System.Collections.Generic;
using System.Linq;
using TaskManager.Data.Models;
using TaskManager.Repository.Repositories;
using TaskManager.Service.DTOs;

namespace TaskManager.Service.Services
{
    public class TasksService : ITasksService
    {
        private readonly ITaskManagerRepositories _repo;
        public TasksService(ITaskManagerRepositories repo) => _repo = repo;

        public List<Task> GetTasksList(int userId)
        => _repo.TasksRepository.GetList(userId);
        public TaskOperationModel GetSimpleTask(int id)
        {
            var task = _repo.TasksRepository.GetSingle(id);

            return new TaskOperationModel
            {
                Title = task.Title,
                Content = task.Content,
                StartDate = task.StartDate,
                EndDate = task.EndDate,
                IsDone = task.IsDone,
                UserId = task.UserId
            };
        }

        public void Create(TaskOperationModel model)
        {
            _repo.TasksRepository.Create(new Task
            {
                Title = model.Title,
                Content = model.Content,
                StartDate = model.StartDate,
                EndDate = model.EndDate,
                UserId = model.UserId
            });
            _repo.Complete();
        }

        public void Update(int id, TaskOperationModel model)
        {
            _repo.TasksRepository.Update(id,new Task
            {
                Title = model.Title,
                Content = model.Content,
                StartDate = model.StartDate,
                EndDate = model.EndDate,
                UserId = model.UserId
            });
            _repo.Complete();
        }

        public void Delete(int id)
        {
            _repo.TasksRepository.Delete(id);
            _repo.Complete();
        }


    }
}
