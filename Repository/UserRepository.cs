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

        public void InsertUser(User user)
        {
            _dataContext.User.Add(user);
            _dataContext.SaveChanges();
        }

        public void UpdateUser(User user)
        {
            User existingUser = _dataContext.User.Find(user.Id);

            if (existingUser != null)
            {
                _dataContext.Entry(existingUser).CurrentValues.SetValues(user);

                _dataContext.SaveChanges();
            }
        }
    }
}