namespace DapperContext;
using Npgsql;

public class DapperContext
{
    private readonly  string connectionString = "Server = localhost; Port = 5432; Database = coursedb; User Id=postgres; Password=12345;"; 
    public NpgsqlConnection Connection()
    {
        return new NpgsqlConnection(connectionString);
    }
}
