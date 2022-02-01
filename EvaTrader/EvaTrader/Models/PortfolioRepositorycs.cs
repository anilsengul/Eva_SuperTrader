using EvaTrader.Data;

namespace EvaTrader.Models
{
    public class PortfolioRepositorycs : IPortfolio
    {
        private readonly DataContext context;
        public PortfolioRepositorycs(DataContext context)
        {
            this.context = context;
        }
        public Portfolio BuyPortfolio(User userModel,Share shareModel,int quantity)
        {
                Portfolio newPortfolio=new Portfolio();
                newPortfolio.UserID = userModel.ID;
                newPortfolio.ShareID = shareModel.ID;
                newPortfolio.UserName = userModel.Name + " " + userModel.Surname;
                newPortfolio.ShareName = shareModel.ShareName;
                newPortfolio.Price = shareModel.BuyPrice;
                newPortfolio.Quantity = quantity;
                context.Portfolio.Add(newPortfolio);
                context.SaveChanges();
                return newPortfolio;
        }

        public List<Portfolio> GetPortfolioByUserId(int userId)
        {
            return context.Portfolio.Where(d => d.UserID == userId).ToList();
        }

        public List<Portfolio> GetPortfolioList()
        {
            return context.Portfolio.ToList();
        }

        public void SellPortfolio(Portfolio soldPortfolio,int quantity)
        {
            decimal lastPrice = context.Share.Where(d => d.ID == soldPortfolio.ShareID).Select(d => d.SellPrice).FirstOrDefault();
            soldPortfolio.Price = lastPrice;
            int difQuantity = soldPortfolio.Quantity - quantity;
            if (difQuantity > 0)
            {
                this.UpdatePortfolio(soldPortfolio, quantity);
            }
            else
            {
                context.Portfolio.Remove(soldPortfolio);
                context.SaveChanges();
            }
            
        }
        public Portfolio getPortfolioByUserAndShare(int userId,int shareId)
        {
            var model = context.Portfolio.Where(d => d.UserID == userId && d.ShareID == shareId).FirstOrDefault();
            if (model != null)
            {
                return model;
            }
            else
            {
                return null;
            }
        }

        public Portfolio UpdatePortfolio(Portfolio portfolio, int quantity)
        {
            portfolio.Quantity = quantity;
            context.Portfolio.Update(portfolio);
            context.SaveChanges();
            return portfolio;
        }
    }
}
