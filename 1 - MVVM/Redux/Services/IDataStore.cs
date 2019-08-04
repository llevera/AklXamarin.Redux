using System.Collections.Generic;
using Redux.Models;

namespace Redux.Services
{
    public interface IDataStore
    {
        IEnumerable<Account> GetMovies();
    }
}