namespace TaskManager.Repository.Repositories
{
    public interface ITaskManagerRepositories
    {
        IUsersRepository UsersRepo { get; }
        IUserCredentialsRepository UserCredentialsRepo { get; }
        ITasksRepository TasksRepository { get; }
        int Complete();
    }
}
