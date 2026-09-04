namespace SabzMarket.Infrastructure.Persistence.Mongo;

public class MongoSettings
{
    public const string SectionName = "Mongo";

        public string ConnectionString { get; set; } = "mongodb://localhost:27017";
    public string Database { get; set; } = "SabzMarket";
    public string ExceptionLogsCollection { get; set; } = "exception_logs";
}