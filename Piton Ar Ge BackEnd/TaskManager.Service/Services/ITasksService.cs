using System.Collections.Generic;
using TaskManager.Data.Models;
using TaskManager.Service.DTOs;

namespace TaskManager.Service.Services
{
    public interface ITasksService
    {
        public List<Task> GetTasksList(int userId);
        public TaskOperationModel GetSimpleTask(int id);
        void Create(TaskOperationModel model);
        void Update(int id, TaskOperationModel model);
        void Delete(int id);
    }
}
