using Microsoft.AspNetCore.Mvc;
using Tochka.JsonRpc.Server;

namespace JsonRPCServiceExample.Controllers
{
    public class HomeController : JsonRpcControllerBase
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        [HttpPost]
        public IEnumerable<int> Get()
        {
            return Enumerable.Range(1, 5).Select(index => index).ToArray();
        }
    }
}
