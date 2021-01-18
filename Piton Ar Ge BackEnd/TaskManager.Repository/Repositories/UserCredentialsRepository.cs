using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using TaskManager.Data.Datas;
using TaskManager.Data.Models;

namespace TaskManager.Repository.Repositories
{
    public class UserCredentialsRepository : IUserCredentialsRepository
    {
        private readonly TaskManagerContext _context;
        public UserCredentialsRepository(TaskManagerContext context) => _context = context;
        public void Create(UserCredential userCredential)
        {
            if (!_context.Users.Any(x => x.Id == userCredential.UserId))
                throw new Exception("User is not exists!");

            _context.Add(userCredential);
        }
        public void Update(int userId, UserCredential userCredential)
        {
            var updatedCredentails = GetSingle(userId);

            _context.UserCredentials.Attach(updatedCredentails);
            updatedCredentails.Email = userCredential.Email;
            updatedCredentails.Password = userCredential.Password;
        }
        public void Delete(int userId)
        {
            _context.UserCredentials.Remove(GetSingle(userId));
        }

        private UserCredential GetSingle(int userId)
        {
            var credential = (from u in _context.Users
                              join c in _context.UserCredentials
                              on u.Id equals c.UserId
                              where u.Id == userId
                              select c)
                              .AsNoTracking()
                              .FirstOrDefault();

            if (credential==null)
                throw new Exception("User credentials is not exists!");

            return credential;
        }

    }
}
