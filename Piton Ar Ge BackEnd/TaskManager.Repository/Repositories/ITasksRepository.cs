using System.Collections.Generic;
using TaskManager.Data.Models;

namespace TaskManager.Repository.Repositories
{
    public interface ITasksRepository
    {
        List<Task> GetList();
        List<Task> GetUndoList();
        Task GetSingle(int id);
        void Create(Task model);
        void Update(int id, Task model);
        void Delete(int id);
        bool DoUnDo(int id);
    }
}
