namespace CodeMasterDev.Core.Infra.Scripts
{
    internal static class ActorScripts
    {
        public const string QuerySelectActor = "SELECT * FROM Db_Movies..Actor";

        public const string QuerySelectActorById = "SELECT * FROM Db_Movies..Actor WHERE Id = @Id";

        public const string QueryInsertActor = """
                                               INSERT INTO Db_Movies..Actor (
                                                       [Name], [Birthdate], [Nationality]
                                                   )
                                               VALUES (
                                                       @Name, @Birthdate, @Nationality
                                                   );
                                               """;

        public const string QueryUpdateActor = """
                                               UPDATE 
                                                 Db_Movies..[Actor] 
                                               SET 
                                                 [Name] = @Name, 
                                                 [Birthdate] = @BirthDate, 
                                                 [Nationality] = @Nationality 
                                               WHERE 
                                                 Id = @Id
                                               """;

        public const string QueryDeleteActor = "DELETE FROM Db_Movies..Actor WHERE Id = @Id";
    }
}
