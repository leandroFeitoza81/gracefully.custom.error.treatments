using CodeMasterDev.Core.Domain.Interfaces.Repositories;
using CodeMasterDev.Core.Domain.Models;
using CodeMasterDev.Core.Infra.DataBase;
using CodeMasterDev.Core.Infra.Scripts;
using Dapper;

namespace CodeMasterDev.Core.Infra.Repositories
{
    public class ActorRepository : IActorRepository
    {
        private readonly DapperContext _context;

        public ActorRepository(DapperContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Actor>> GetAll()
        {
            using var connection = _context.CreateConnection();
            var actors = await connection.QueryAsync<Actor>(ActorScripts.QuerySelectActor);
            return actors;
        }

        public async Task<Actor?> GetById(int id)
        {
            using var connection = _context.CreateConnection();
            var actor = await connection.QueryFirstOrDefaultAsync<Actor>(ActorScripts.QuerySelectActorById,
                new { Id = id });
            return actor;
        }

        public async Task<bool> Create(Actor actor)
        {
            using var connection = _context.CreateConnection();
            var newActor = await connection.ExecuteAsync(ActorScripts.QueryInsertActor, actor);
            return newActor > 0;
        }

        public async Task<bool> Update(Actor? actor)
        {
            using var connection = _context.CreateConnection();
            var result = await connection.ExecuteAsync(ActorScripts.QueryUpdateActor, actor);
            return result > 0;
        }

        public async Task<bool> Delete(int id)
        {
            using var connection = _context.CreateConnection();
            var result = await connection.ExecuteAsync(ActorScripts.QueryDeleteActor, new { Id = id });
            return result > 0;
        }
    }
}
