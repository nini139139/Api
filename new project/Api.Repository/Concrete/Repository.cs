using Api.Domain.Data;
using Api.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Api.Repository.Concrete
{
    public class Repository : IRepository
    {
        private readonly DataContxt _context;

        public Repository(DataContxt context)
        {
            _context = context;
        }

        public void Delete<T>(T entity) where T : class
        {
            _context.Remove(entity);
        }


        public async Task<bool> SaveAll()
        {
            var result = await _context.SaveChangesAsync() > 0;
            return result;
        }
    }
}
