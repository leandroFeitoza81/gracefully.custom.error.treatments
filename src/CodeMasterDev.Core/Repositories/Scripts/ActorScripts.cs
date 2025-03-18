using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeMasterDev.Core.Repositories.Scripts
{
    static class ActorScripts
    {
        public const string QuerySelectActor = "SELECT * FROM Db_Movies..Actor";

        public const string QueryInsertActor = """
                                               INSERT INTO Db_Movies..Actor (
                                                       [Name], [Birthdate], [Nationality]
                                                   )
                                               VALUES (
                                                       @Name, @Birthdate, @Nationality
                                                   );
                                               """;
    }
}
