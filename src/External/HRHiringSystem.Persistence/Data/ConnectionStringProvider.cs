namespace HRHiringSystem.Persistence.Data;
internal class ConnectionStringProvider : IConnectionStringProvider
{
    public string GetConnectionString()
    {
        string? connectionString = Environment.GetEnvironmentVariable("HRHiringSystem_DATABASE_CONNECTION_STRING");
        if (string.IsNullOrEmpty(connectionString))
        {
            throw new ApplicationException("Database connection string is not set in environment variables.");
        }

        return connectionString;
    }
}
