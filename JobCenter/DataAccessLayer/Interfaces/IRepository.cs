using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Interfaces
{
    public interface IRepository<T> where T : Base
    {
        Task Create(T model);
        Task<IEnumerable<T>> ReadAll();
        Task<T?> ReadById(long id);
        Task Update(T model);
        Task Delete(T model);
    }
}
