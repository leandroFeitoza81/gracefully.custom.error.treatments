using Microsoft.AspNetCore.Mvc;

namespace CodeMasterDev.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        public ActionResult<string> Index()
        {
            return Ok("Controller administrativa");
        }
    }
}
