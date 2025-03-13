using CodeMasterDev.Core.Interfaces.Repositories;
using CodeMasterDev.Core.Models;
using Microsoft.AspNetCore.Mvc;

namespace CodeMasterDev.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ActorController : ControllerBase
{
    private readonly IActorRepository _repository;

    public ActorController(IActorRepository actorRepository)
    {
        _repository = actorRepository;
    }

    [HttpGet]
    public async Task<ActionResult<Actor>> GetAll()
    {
        try
        {
            var actor = await _repository.GetAllActors();

            return Ok(actor);
        }
        catch (Exception e)
        {
           return StatusCode(500, e.Message);
        }

    }
}