﻿using System.Collections.Generic;
using System.Threading.Tasks;

namespace Fan.Data
{
    /// <summary>
    /// Contract for a base repository that provides commonly used data access methods.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IRepository<T> where T : class 
    {
        Task<T> CreateAsync(T obj);
        Task<IEnumerable<T>> CreateRangeAsync(IEnumerable<T> objs);
        Task<T> UpdateAsync(T obj);
        Task UpdateAsync();
    }
}
