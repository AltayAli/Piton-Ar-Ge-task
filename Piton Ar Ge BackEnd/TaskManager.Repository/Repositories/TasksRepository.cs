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
        public TasksRepository() => _context = new TaskManagerContext();

        public List<Task> GetList()
        => (from t in _context.Tasks
            select t).AsNoTracking().ToList();
        public List<Task> GetUndoList()
        => (from t in _context.Tasks where !t.Position
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

            _context.Tasks.Add(model);
            _context.SaveChanges();
        }

        public void Update(int id, Task task)
        {
            var updatedTask = GetSingle(id);

            _context.Attach(updatedTask);
            updatedTask.Title = task.Title;
            updatedTask.Content = task.Content;
            updatedTask.StartDate = task.StartDate;
            updatedTask.EndDate = task.EndDate;
            _context.SaveChanges();
        }
        public bool DoUnDo(int id)
        {
            var updatedTask = GetSingle(id);

            _context.Attach(updatedTask);
            updatedTask.Position = !updatedTask.Position;
            _context.SaveChanges();
            return updatedTask.Position;
        }

        public void Delete(int id)
        {
            _context.Tasks.Remove(GetSingle(id));
            _context.SaveChanges();
        }

    }
}
