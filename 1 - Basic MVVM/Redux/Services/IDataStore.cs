using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Redux.Services
{
    public interface IDataStore<T>
    {
        Task<IEnumerable<T>> GetItemsAsync();
    }
}