using CodeMasterDev.Core.Domain.Models;

namespace CodeMasterDev.Core.Domain.Interfaces.Repositories;

public interface IActorRepository
{
    public Task<IEnumerable<Actor>> GetAll();
    public Task<Actor?> GetById(int id);
    Task<bool> Create(Actor actor);
    Task<bool> Update(Actor? actor);
    Task<bool> Delete(int id);
}