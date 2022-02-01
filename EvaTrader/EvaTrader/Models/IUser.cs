namespace EvaTrader.Models
{
    public interface IUser
    {
        User GetUser(int id);
        List<User> GetUsers();
        User CreateUser(User user);
        User UpdateUser(User user);

    }
}
