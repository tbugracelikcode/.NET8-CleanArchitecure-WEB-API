namespace App.Repositories
{
    public interface IUnitofWork
    {
        Task<int> SaveChangesAsync();
    }
}
