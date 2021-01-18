using TaskManager.Service.Services;

namespace TaskManager.Service
{
    public interface ITaskManagerServices
    {
        IUsersService UsersService { get; }
        ITasksService TasksServices { get; }
    }
}
