using BookStore.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace BookStore.Repositories
{
    public class UserRepository
    {
        private readonly UserContext _options;

        public UserRepository(UserContext options)
        {
            _options = options;
        }

        public User GetById(int id)
        {
            return _options.Users.Where(i => i.UserId == id).FirstOrDefault();
        }

        public List<User> GetAll()
        {
            return _options.Users.ToList();
        }

        public void Insert(User item)
        {
            _options.Users.Add(item);
            _options.SaveChanges();

        }
        public void Update(User item)
        {
            _options.Entry(item).State = EntityState.Modified;
            _options.SaveChanges();
        }

        public void Delete(int id)
        {
            User item = _options.Users.Where(i => i.UserId == id).FirstOrDefault();
            _options.Users.Remove(item);
            _options.SaveChanges();

        }

        public User GetUsernameAndPassword(string username, string password)
        {
            return _options.Users.FirstOrDefault(u => u.Username == username && u.Password == password);
        }
    }
}
