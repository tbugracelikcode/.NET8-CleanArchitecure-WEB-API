namespace App.Repositories
{
    public class ConnectionStringOption
    {
        public string SqlServer { get; set; } = default!;

        public const string Key = "ConnectionStrings";
    }
}
