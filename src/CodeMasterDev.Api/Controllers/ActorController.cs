using System.Net;
using CodeMasterDev.Core.Interfaces.Repositories;
using CodeMasterDev.Core.Models;
using Microsoft.AspNetCore.Mvc;

namespace CodeMasterDev.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ActorController : ControllerSuper
{
    private readonly IActorRepository _repository;

    public ActorController(IActorRepository actorRepository)
    {
        _repository = actorRepository;
    }

    [HttpGet]
    public async Task<ActionResult<ObjectResponse>> GetAll()
    {
        try
        {
            var actor = await _repository.GetAllActors();

            return ResponseOk(actor);
        }
        catch (Exception e)
        {
            return ResponseServerError(e);
        }

    }

    [HttpPost]
    public async Task<ActionResult<ObjectResponse>> Create([FromBody] Actor actor)
    {
        try
        {
            var newActor = await _repository.CreateActor(actor);

            return newActor ? ResponseOk(actor) : ResponseBadRequest("Houve um erro ao criar um ator");
        }
        catch (Exception e)
        {
            return ResponseServerError(e);
        }
    }
}