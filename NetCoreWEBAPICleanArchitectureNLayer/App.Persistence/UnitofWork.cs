using CleanApp.Application.Contracts.Persistence;

namespace CleanApp.Persistence
{
    public class UnitofWork(AppDbContext context) : IUnitofWork
    {
        public Task<int> SaveChangesAsync() => context.SaveChangesAsync();
    }

}
