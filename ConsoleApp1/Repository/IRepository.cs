using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Repository
{
    internal interface IRepository<T>
    {
        List<T> listar();
        T FindByID(int id);
        void Save(T entidade);
        void DeleteById(int id);
        void Update(int id, T entidade);
        int ProximoID();
    }
}
