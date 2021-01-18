using TaskManager.Data.Models;

namespace TaskManager.Repository.Repositories
{
    public interface IUserCredentialsRepository
    {
        void Create(UserCredential userCredential);
        void Update(int userId, UserCredential userCredential);
        void Delete(int userId);
    }
}
