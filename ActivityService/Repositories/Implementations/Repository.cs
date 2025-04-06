﻿using ActivityService.Data;
using ActivityService.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq.Expressions;

namespace ActivityService.Repositories.Implementations
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected readonly ApplicationDbContext _context;
        protected readonly DbSet<T> _dbSet;

        public Repository(ApplicationDbContext context)
        {
            _context = context;
            _dbSet = context.Set<T>();
        }

        public async Task<IEnumerable<T>> GetAsync(Expression<Func<T, bool>> predicate) => await _dbSet.Where(predicate).ToListAsync();

        public async Task<T?> GetFirstAsync(Expression<Func<T, bool>> predicate) => await _dbSet.Where(predicate).FirstOrDefaultAsync();

        public async Task AddAsync(T entity) => await _dbSet.AddAsync(entity);

        public void Update(T entity) => _dbSet.Update(entity);

        public void Delete(T entity) => _dbSet.Remove(entity);

        public async Task SaveChangesAsync() => await _context.SaveChangesAsync();
    }
}