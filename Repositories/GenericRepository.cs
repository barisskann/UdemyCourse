﻿using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Repositories;

public class GenericRepository<T>(AppDbContext appDbContext) : IGenericRepository<T> where T : class
{
    private readonly DbSet<T> dbSet = appDbContext.Set<T>();
    public async ValueTask AddAsync(T entity) => await dbSet.AddAsync(entity);
    public void Delete(T entity) => dbSet.Remove(entity);
    public IQueryable<T> GetAll() => dbSet.AsQueryable().AsNoTracking();
    public async ValueTask<T?> GetByIdAsync(int id) => await dbSet.FindAsync(id);
    public void Update(T entity) => dbSet.Update(entity);
    public IQueryable<T> Where(Expression<Func<T, bool>> predicate) => dbSet.Where(predicate);
}





