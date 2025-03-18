using CodeMasterDev.Core.DataBase;
using CodeMasterDev.Core.Interfaces.Repositories;
using CodeMasterDev.Core.Models;
using CodeMasterDev.Core.Repositories.Scripts;
using Dapper;

namespace CodeMasterDev.Core.Repositories
{
    public class ActorRepository : IActorRepository
    {
        private readonly DapperContext _context;

        public ActorRepository(DapperContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Actor>> GetAllActors()
        {
            using var connection = _context.CreateConnection();
            var actors = await connection.QueryAsync<Actor>(ActorScripts.QuerySelectActor);
            return actors;
        }

        public async Task<bool> CreateActor(Actor actor)
        {
            using var connection = _context.CreateConnection();
            var newActor = await connection.ExecuteAsync(ActorScripts.QueryInsertActor, actor);
            return newActor > 0;
        }
    }
}
