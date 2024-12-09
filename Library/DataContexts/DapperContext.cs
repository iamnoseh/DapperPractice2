namespace DapperContexts;
using Npgsql;

public class DapperContext
{
    private readonly string connectionString = "Server = localhots;Database = coursedb; User Id=postgres;Port=5432;Password=12345;";

    public NpgsqlConnection GetConnection()
    {
        return new NpgsqlConnection(connectionString);
    }
    
}
