using System;
using System.Collections.Generic;
using System.Text;
using TaskManager.Repository.Repositories;
using TaskManager.Service.Services;

namespace TaskManager.Service
{
    public class TaskManagerServices : ITaskManagerServices
    {
        private readonly ITaskManagerRepositories _repo;
        public TaskManagerServices() => _repo = new TaskManagerRepositories();

        private IUsersService _usersService;
        public IUsersService UsersService
        {
            get
            {
                _usersService ??= new UsersService(_repo);
                return _usersService;
            }
        }

        private ITasksService _taskManagerServices;
        public ITasksService TasksServices
        {
            get
            {
                _taskManagerServices ??= new TasksService(_repo);
                return _taskManagerServices;
            }
        }
    }
}
