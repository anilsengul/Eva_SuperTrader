using EvaTrader.Data;

namespace EvaTrader.Models
{
    public class UserRepository:IUser
    {
        private readonly DataContext context;

        public UserRepository(DataContext context)
        {
            this.context = context;
        }

        public User GetUser(int id)
        {
            return context.User.Find(id);
        }
        
        public List<User> GetUsers()
        {
            return context.User.ToList();
        }
        public User CreateUser(User user)
        {
            User newUser = new User();
            newUser.Name = user.Name;
            newUser.Surname = user.Surname;
            context.User.Add(newUser);
            context.SaveChanges();
            return newUser;
        }
        public User UpdateUser(User user)
        {
            context.User.Update(user);
            context.SaveChanges();
            return user;
        }
    }
}
