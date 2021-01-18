using TaskManager.Data.Models;

namespace TaskManager.Repository.Repositories
{
    public interface IUsersRepository
    {
        User GetUser(int id);
        int Create(User user);
        void Update(int id, User user);
        void Delete(int id);

    }
}
