using EvaTrader.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EvaTrader.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class PortfolioController : ControllerBase
    {
        private readonly IPortfolio _portfolioRepository;
        private readonly IUser _userRepository;
        private readonly IShare _shareRepository;
        public PortfolioController(IPortfolio portfolioRepository,IUser userRepository,IShare shareRepository)
        {
            this._portfolioRepository = portfolioRepository;
            this._userRepository = userRepository;
            this._shareRepository = shareRepository;
        }
        [HttpGet]
        public List<Portfolio> GetPortfolioList()
        {
            return _portfolioRepository.GetPortfolioList();
        }
        [HttpGet("{id}")]
        public List<Portfolio> GetPortfolioByUserId(int id)
        {
            return _portfolioRepository.GetPortfolioByUserId(id);
        }
        [HttpPost]
        public IActionResult BuyPortfolio(int userId,int shareId,int quantity)
        {
            var userModel = _userRepository.GetUser(userId);
            var shareModel = _shareRepository.GetShareById(shareId);
            if (userModel != null && shareModel != null)
            {
                return Ok(_portfolioRepository.BuyPortfolio(userModel,shareModel,quantity));
            }
            else
            {
                return NotFound();
            }
        }
        [HttpDelete]
        public IActionResult SellPortfolio(int userId,int shareId,int quantity)
        {
            var portfolioModel = _portfolioRepository.getPortfolioByUserAndShare(userId,shareId);
            if (portfolioModel != null)
            {
                if (portfolioModel.Quantity>=quantity)
                {
                    _portfolioRepository.SellPortfolio(portfolioModel,quantity);
                    return Ok();
                }
                else
                {
                    return NotFound();
                }
                
            }
            else
            {
                return NotFound();
            }
        }
    }
}
