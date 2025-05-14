namespace CleanApp.Domain.Options
{
    public class ConnectionStringOption
    {
        public string SqlServer { get; set; } = default!;

        public const string Key = "ConnectionStrings";
    }
}
