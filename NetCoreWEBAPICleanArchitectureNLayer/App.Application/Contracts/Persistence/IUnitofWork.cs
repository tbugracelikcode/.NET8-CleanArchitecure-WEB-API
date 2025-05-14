namespace CleanApp.Application.Contracts.Persistence
{
    public interface IUnitofWork
    {
        Task<int> SaveChangesAsync();
    }
}
