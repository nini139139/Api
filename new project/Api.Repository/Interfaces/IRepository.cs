using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Api.Repository.Interfaces
{
    interface IRepository
    {
        void Delete<T>(T entity) where T : class;
        Task<bool> SaveAll();
    }
}
