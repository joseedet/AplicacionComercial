﻿using AplicacionComercial.Common.Interfaces;
using AplicacionComercial.Web.Data;
using AplicacionComercial.Web.Interfaces;

using Microsoft.EntityFrameworkCore;

using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AplicacionComercial.Web.Repository
{
    public class GenericRepository<T> : IGenericRepository<T> where T:class,IEntity
    {
        private readonly DataContext _dataContext;

        public GenericRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }
        public async Task CreateAsync(T entity)
        {
            await _dataContext.Set<T>().AddAsync(entity);
            await _dataContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(T entity)
        {
            _dataContext.Remove(entity);
            await _dataContext.SaveChangesAsync();
        }

        public async Task<bool> ExistAsync(int id)
        {
            return await _dataContext.Set<T>().AnyAsync(e => e.Id == id);
        }

        public IQueryable<T> GetAll()
        {
            return _dataContext.Set<T>().AsNoTracking();
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await _dataContext.Set<T>()
                 .AsNoTracking()
                 .FirstOrDefaultAsync(e => e.Id == id);
        }

        public async Task UpdateAsync(T entity)
        {
            _dataContext.Update(entity);
            
            await _dataContext.SaveChangesAsync();
        }
        public IQueryable<T> GetAll(int pageNumber)
        {
            int pagesize = 1;
            return _dataContext.Set<T>().Skip(1).Take(pagesize);
        }

        public async Task<IAsyncEnumerable<T>> GetAllList()
        {
            Task<List<T>> task = _dataContext.Set<T>().AsNoTracking().ToListAsync();
            return (IAsyncEnumerable<T>)await task;
        }
    }
}
