namespace EvaTrader.Models
{
    public interface IShare
    {
        List<Share> GetShareLit();
        Share GetShareById(int id);
        Share CreateShare(Share share);
        Share UpdateShare(Share share);
        void DeleteShare(int id);
    }
}
