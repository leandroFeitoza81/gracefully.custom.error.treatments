using CodeMasterDev.Core.Domain.Models;

namespace CodeMasterDev.Core.Domain.Interfaces.Services
{
    public interface IActorService
    {
        Task<IEnumerable<Actor>> GetAll();
        Task<Actor?> GetById(int id);
        Task<bool> Insert(Actor actor);
        Task<bool> Update(Actor actor);
        Task<bool> Delete(int id);
    }
}
