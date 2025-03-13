namespace CodeMasterDev.Api.Configuration;

public class ConnectionStringConfiguration
{
    private readonly string? _connectionString;
    
    public ConnectionStringConfiguration(IConfiguration configuration)
    {
        _connectionString = configuration.GetConnectionString("SqlConnection");
    }
    
    public string? GetConnectionString()
    {
        return _connectionString;
    }
}