using CodeMasterDev.Core.Models;

namespace CodeMasterDev.Core.Interfaces.Repositories;

public interface IActorRepository
{
    public Task<IEnumerable<Actor>> GetAllActors();
    Task<bool> CreateActor(Actor actor);
}