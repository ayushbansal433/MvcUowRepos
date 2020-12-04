using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MvcUowRepos.Repository
{
    public interface IMvcRepository<T> where T:class
    {
        Task<List<T>> GetAll();
        Task<T> Get(int id);
        Task<int> Add(T entity);
        void Update(T entity);
        Task<int> Delete(int id);
    }
}
