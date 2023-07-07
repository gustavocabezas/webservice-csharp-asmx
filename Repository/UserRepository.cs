using System.Collections.Generic;
using System.Linq;
using WebServiceCSharp.Models;

namespace WebServiceCSharp.Repository
{

    public class UserRepository
    {
        private readonly UserDataContext _dataContext;

        public UserRepository(UserDataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public User GetUserById(int id)
        {
            User user = _dataContext.User.Find(id);
            return user;
        }

        public void InsertUser(User entity)
        {
            _dataContext.User.Add(entity);
            _dataContext.SaveChanges();
        }

        public void UpdateUser(User entity)
        {
            User existingUser = _dataContext.User.Find(entity.Id);

            if (existingUser != null)
            {
                _dataContext.Entry(existingUser).CurrentValues.SetValues(entity);
                _dataContext.SaveChanges();
            }
        }

        public void DeleteUser(int id)
        {
            User existingUser = _dataContext.User.Find(id);

            if (existingUser != null)
            {
                _dataContext.User.Remove(existingUser);
                _dataContext.SaveChanges();
            }
        }

        public List<User> GetAllUsers()
        {
            return _dataContext.User.ToList();
        }
    }
}