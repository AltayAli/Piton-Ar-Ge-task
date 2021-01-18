using TaskManager.Data.Models;
using TaskManager.Repository.Repositories;
using TaskManager.Service.DTOs;

namespace TaskManager.Service.Services
{
    public class UsersService : IUsersService
    {
        private readonly ITaskManagerRepositories _repo;
        public UsersService(ITaskManagerRepositories repo) => _repo = repo;
        public int Create(UserRegisterDTO model)
        {
            var userModel = new User
            {
                Name = model.Name,
                Surname = model.Surname
            };

            var userId = _repo.UsersRepo.Create(userModel);

            var credentials = new UserCredential
            {
                Email = model.Email,
                Password = model.Password.CreatePassword(),
                UserId = userId
            };

            _repo.UserCredentialsRepo.Create(credentials);

            _repo.Complete();

            return userId;
        }

        public void Update(int userId, UserRegisterDTO model)
        {
            var userModel = new User
            {
                Name = model.Name,
                Surname = model.Surname
            };
            var credentials = new UserCredential
            {
                Email = model.Email,
                Password = model.Password.CreatePassword(),
                UserId = userId
            };

            _repo.UsersRepo.Update(userId, userModel);
            _repo.UserCredentialsRepo.Update(userId, credentials);

            _repo.Complete();
        }
        public void Delete(int userId)
        {

            _repo.UsersRepo.Delete(userId);
            _repo.UserCredentialsRepo.Delete(userId);
            _repo.TasksRepository.DeleteRange(userId);

            _repo.Complete();
        }
    }
}
