using EvaTrader.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EvaTrader.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ShareController : ControllerBase
    {
        private readonly IShare _shareRepository;
        public ShareController(IShare shareRepository)
        {
            this._shareRepository = shareRepository;
        }
        [HttpGet("{id}")]
        public Share GetShareById(int id)
        {
            return _shareRepository.GetShareById(id);
        }
        [HttpGet]
        public List<Share> GetShareList()
        {
            return _shareRepository.GetShareLit();
        }
        [HttpPost]
        public Share CreateShare(Share share)
        {
            return _shareRepository.CreateShare(share);
        }
        [HttpPut]
        public Share UpdateShare(Share share)
        {
            return _shareRepository.UpdateShare(share);
        }
        [HttpDelete("{id}")]
        public void DeleteShare(int id)
        {
            _shareRepository.DeleteShare(id);
        }
    }
}
