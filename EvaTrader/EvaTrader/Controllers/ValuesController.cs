using EvaTrader.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EvaTrader.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class ValuesController : ControllerBase
    {
        private readonly IUser _userRepository;
        //private readonly IShare _shareRepository;
        //private readonly IPortfolio _portfolioRepository;

        public ValuesController(IUser userRepository)
        {
            this._userRepository = userRepository;
        }
        [HttpGet]
        public List<User> GetUsers()
        {
            return _userRepository.GetUsers();
        }
        [HttpPost]
        public User CreateUser(User user)
        {
            return _userRepository.CreateUser(user);
        }
        [HttpPut]
        public User UpdateUser(User user)
        {
            return _userRepository.UpdateUser(user);
        }
    }
}
