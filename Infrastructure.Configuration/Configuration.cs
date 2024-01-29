namespace Infrastructure.Configuration
{
    public class Configuration
    {
        public RepositoryConfigurations repository { get; set; }
    }

    public class RepositoryConfigurations
    {
        public string connectionString { get; set; }

        public string GetConnectionString()
        {
            return this.connectionString;
        }
    }
}
