using Microsoft.AspNetCore.Mvc;

namespace Receiver.Controllers
{
    public class ReceiverController : Controller
    {
        public IActionResult Index()
        {
            return Ok();
        }
    }
}
