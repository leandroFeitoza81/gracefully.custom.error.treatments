using CodeMasterDev.Core.Models;
using Microsoft.AspNetCore.Mvc;

namespace CodeMasterDev.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ActorController : ControllerBase
{
    [HttpGet]
    public ActionResult<Actor> GetAll()
    {
        var actor = new Actor()
        {
            Id = 1,
            Name = "Tom Cruise",
            Birthdate = new DateTime(1962, 7, 3)
        };
        
        return Ok(actor);
    }
}