using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using TaskManager.Data.Datas;
using TaskManager.Data.Models;

namespace TaskManager.Repository.Repositories
{
    public class TasksRepository : ITasksRepository
    {
        private readonly TaskManagerContext _context;
        public TasksRepository(TaskManagerContext context) => _context = context;

        public List<Task> GetList(int userId)
        => (from t in _context.Tasks where t.UserId == userId
            select t).AsNoTracking().ToList();
        public List<Task> GetUndoList()
        => (from t in _context.Tasks where !t.IsDone
            select t).AsNoTracking().ToList();

        public Task GetSingle(int id)
        {
            var tasks = _context.Tasks.AsNoTracking().FirstOrDefault(x => x.Id == id);

            if (tasks == null)
                throw new Exception("Model is null!");

            return tasks;
        }
        public void Create(Task model)
        {
            if (!_context.Users.Any(x => x.Id == model.UserId))
                throw new Exception("User is not exists!");

            _context.Tasks.Add(model);
        }

        public void Update(int id, Task task)
        {
            var updatedTask = GetSingle(id);

            _context.Attach(updatedTask);
            updatedTask.Title = task.Title;
            updatedTask.Content = task.Content;
            updatedTask.StartDate = task.StartDate;
            updatedTask.EndDate = task.EndDate;
        }
        public bool DoUnDo(int id)
        {
            var updatedTask = GetSingle(id);

            _context.Attach(updatedTask);
            updatedTask.IsDone = !updatedTask.IsDone;

            return updatedTask.IsDone;
        }

        public void Delete(int id)
        {
            _context.Tasks.Remove(GetSingle(id));
        }

        public void DeleteRange(int userId)
        {
            var tasks = (from u in _context.Users
                         join t in _context.Tasks
                         on u.Id equals t.UserId
                         where u.Id == userId
                         select t);
            _context.Tasks.RemoveRange(tasks);
        }
    }
}
