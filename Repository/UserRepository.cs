using WebServiceCSharp.Models;

namespace WebServiceCSharp.Repository
{

    public class UserRepository
    {
        private readonly YourDataContext _dataContext;

        public UserRepository(YourDataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public void InsertUser(UserBO user)
        {
            _dataContext.User.Add(user);
            _dataContext.SaveChanges();
        }

        public void UpdateUser(UserBO user)
        {
            UserBO existingUser = _dataContext.User.Find(user.Id);

            if (existingUser != null)
            {
                _dataContext.Entry(existingUser).CurrentValues.SetValues(user);

                _dataContext.SaveChanges();
            }
        }
    }
}