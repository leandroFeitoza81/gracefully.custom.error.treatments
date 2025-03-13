using CodeMasterDev.Core.DataBase;
using CodeMasterDev.Core.Interfaces.Repositories;
using CodeMasterDev.Core.Models;
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
            const string query = "SELECT * FROM Db_Movies..Actor";
            using var connection = _context.CreateConnection();
            var actors = await connection.QueryAsync<Actor>(query);
            return actors;
        }
    }
}
