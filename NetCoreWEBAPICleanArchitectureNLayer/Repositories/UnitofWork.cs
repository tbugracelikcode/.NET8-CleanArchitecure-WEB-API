﻿

namespace App.Repositories;

public class UnitofWork(AppDbContext context) : IUnitofWork
{
    public Task<int> SaveChangesAsync() => context.SaveChangesAsync();
}

