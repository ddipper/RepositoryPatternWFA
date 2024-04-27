using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryPatternWFA.Repository
{
    public interface IRepository<TValue>
    {
        List<TValue> GetAll();
        int Insert(TValue value);
        int Update(int id, TValue value);
    }
}
