namespace EvaTrader.Models
{
    public interface IPortfolio
    {
        public List<Portfolio> GetPortfolioList();
        public List<Portfolio> GetPortfolioByUserId(int userId);
        public Portfolio BuyPortfolio(User user,Share share,int quantity);
        public Portfolio UpdatePortfolio(Portfolio portfolio,int quantity);
        public void SellPortfolio(Portfolio portfolio,int quantity);
        public Portfolio getPortfolioByUserAndShare(int userId,int shareId);
        
    }
}
