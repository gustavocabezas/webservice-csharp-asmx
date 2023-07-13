using System.Collections.Generic;
using System.Linq;
using webservicecsharpasmx.Models;

namespace webservicecsharpasmx.Repository
{

    public class UserRepository
    {
        private readonly UserDataContext _dataContext;
        public UserRepository(UserDataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public User AuthenticationUser(User entity)
        {
            /*User existingUser = _dataContext.User.Find(entity.Username);*/

            //linq
            User existingUser = _dataContext.User.FirstOrDefault(u => u.Username == entity.Username);

            if (existingUser != null)
                if (existingUser.Password == entity.Password)
                    return existingUser;

            return null;
        }


        public User GetUserById(int id)
        {
            User user = _dataContext.User.Find(id);
            return user;
        }

        public void CreateUser(User entity)
        {
            _dataContext.User.Add(entity);
            _dataContext.SaveChanges();
        }

        public void UpdateUser(User entity)
        {
            /*User existingUser = _dataContext.User.Find(entity.Id);*/

            //linq
            User existingUser = _dataContext.User.FirstOrDefault(u => u.Id == entity.Id);

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