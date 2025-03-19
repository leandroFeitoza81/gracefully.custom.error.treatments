using CodeMasterDev.Core.Domain.Interfaces.Repositories;
using CodeMasterDev.Core.Domain.Interfaces.Services;
using CodeMasterDev.Core.Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace CodeMasterDev.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ActorController : ControllerSuper
{
    private readonly IActorRepository _repository;
    private readonly IActorService _service;

    public ActorController(IActorRepository actorRepository, IActorService service)
    {
        _repository = actorRepository;
        _service = service;
    }

    [HttpGet]
    public async Task<ActionResult<ObjectResponse>> GetAll()
    {
        try
        {
            var actor = await _service.GetAll();

            return ResponseOk("", actor);
        }
        catch (Exception e)
        {
            return ResponseServerError(e);
        }

    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult<ObjectResponse>> GetById(int id)
    {
        try
        {
            var actor = await _service.GetById(id);
            return actor == null ? ResponseNotFound("Ator não encontrado.") : ResponseOk("", actor);
        }
        catch (Exception e)
        {
            return ResponseServerError(e);
        }
    }

    [HttpPost]
    public async Task<ActionResult<ObjectResponse>> Create(Actor? actor)
    {
        try
        {
            if(actor == null)
                return ResponseBadRequest("Dados inválidos.");

            var newActor = await _service.Insert(actor);

            return newActor ? ResponseOk("Ator criado com sucesso.") : ResponseBadRequest("Houve um erro ao criar um ator");
        }
        catch (Exception e)
        {
            return ResponseServerError(e);
        }
    }

    [HttpPut]
    public async Task<ActionResult<ObjectResponse>> Update(Actor? actor)
    {
        try
        {
            if (actor == null)
                return ResponseBadRequest("Dados inválidos.");

            var actorFounded = await _service.GetById(actor.Id);

            if (actorFounded == null)
                return ResponseNotFound("Ator não encontrado.");

            var newActor = await _repository.Update(actor);
            return newActor ? ResponseOk("Ator atualizado com sucesso.", newActor) : ResponseBadRequest("Houve um erro ao atualizar um ator");
        }
        catch (Exception e)
        {
            return ResponseServerError(e);
        }
    }

    [HttpDelete("{id:int}")]
    public async Task<ActionResult<ObjectResponse>> Delete(int id)
    {
        try
        {
            var actor = await _service.GetById(id);
            if (actor == null)
                return ResponseNotFound("Ator não encontrado.");
            var result = await _repository.Delete(id);
            return result ? ResponseOk("Ator deletado com sucesso.") : ResponseBadRequest("Houve um erro ao deletar um ator");
        }
        catch (Exception e)
        {
            return ResponseServerError(e);
        }
    }
}