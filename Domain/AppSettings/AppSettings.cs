namespace Domain.AppSettings
{
    public class AppSettings
    {
        public DbSettings DbSettings { get; set; } = new DbSettings();
    }

    public class DbSettings
    {
        public string ConnectionString { get; set; } = default!;

        public string DatabaseName { get; set; } = default!;
    }
}
