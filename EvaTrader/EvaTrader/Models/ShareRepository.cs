using EvaTrader.Data;

namespace EvaTrader.Models
{
    public class ShareRepository : IShare
    {
        private readonly DataContext context;
        public ShareRepository(DataContext context)
        {
            this.context = context;
        }
        public Share CreateShare(Share share)
        {
            Share newShare = new Share();
            newShare.ShareName = share.ShareName;
            newShare.ShareSymbol = share.ShareSymbol.ToUpper();
            newShare.BuyPrice = share.BuyPrice;
            newShare.SellPrice = share.SellPrice;
            context.Share.Add(newShare);
            context.SaveChanges();
            return share;
        }

        public void DeleteShare(int id)
        {
            var deletedShare = this.GetShareById(id);
            context.Share.Remove(deletedShare);
            context.SaveChanges();
        }

        public Share GetShareById(int id)
        {
            return context.Share.Find(id);
        }

        public List<Share> GetShareLit()
        {
            return context.Share.ToList();
        }

        public Share UpdateShare(Share share)
        {
            context.Share.Update(share);
            context.SaveChanges();
            return share;
        }
    }
}
