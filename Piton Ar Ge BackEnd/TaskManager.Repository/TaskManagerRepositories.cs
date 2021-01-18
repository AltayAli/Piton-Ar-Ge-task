using TaskManager.Data.Datas;

namespace TaskManager.Repository.Repositories
{
    public class TaskManagerRepositories : ITaskManagerRepositories
    {
        private readonly TaskManagerContext _context;
        public TaskManagerRepositories() => _context = new TaskManagerContext();

        private IUsersRepository _usersRepository;
        public IUsersRepository UsersRepo
        {
            get
            {
                _usersRepository ??= new UsersRepository(_context);
                return _usersRepository;
            }
        }

        private IUserCredentialsRepository _userCredentialsRepository;
        public IUserCredentialsRepository UserCredentialsRepo
        {
            get
            {
                _userCredentialsRepository ??= new UserCredentialsRepository(_context);
                return _userCredentialsRepository;
            }
        }

        private ITasksRepository _tasksRepository;
        public ITasksRepository TasksRepository
        {
            get
            {
                _tasksRepository ??= new TasksRepository(_context);
                return _tasksRepository;
            }
        }

        public int Complete()
        => _context.SaveChanges();
    }
}
