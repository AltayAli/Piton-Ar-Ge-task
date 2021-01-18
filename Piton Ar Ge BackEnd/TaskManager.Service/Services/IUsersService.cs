using TaskManager.Service.DTOs;

namespace TaskManager.Service.Services
{
    public interface IUsersService
    {
        int Create(UserRegisterDTO model);
        void Update(int userId, UserRegisterDTO model);
        void Delete(int userId);
    }
}
