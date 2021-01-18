using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using TaskManager.Data.Datas;
using TaskManager.Data.Models;

namespace TaskManager.Repository.Repositories
{
    public class UsersRepository : IUsersRepository
    {
        private readonly TaskManagerContext _context;
        public UsersRepository(TaskManagerContext context) => _context = context;
        public User GetUser(int id)
        {
            var user = _context.Users.AsNoTracking().FirstOrDefault(x => x.Id == id);

            if (user == null)
                throw new Exception("User is not exists!");

            return user;
        }
        public int Create(User user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();

            return user.Id;
        }

        public void Update(int id, User user)
        {
            var updatedUser = GetUser(id);

            _context.Users.Attach(updatedUser);
            updatedUser.Name = user.Name;
            updatedUser.Surname = user.Surname;
        }

        public void Delete(int id)
        {
            _context.Users.Remove(GetUser(id));
        }


    }
}
