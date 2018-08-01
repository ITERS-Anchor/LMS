using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Managers.Interfaces
{
    public  interface IGenericManager<T> where T : class
    {
        T Create(T entity);

        IEnumerable<T> GetAll();

        T GetById(int id);

        T Update(T entity);

        bool Delete(int id);

    }
}
