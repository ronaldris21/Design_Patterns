using DLL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DLL.ModeloInyeccion
{
    public interface IBaseDatos
    {
        //Los mismos que en IPersona
        List<IPersona> GetPersonas();
        IPersona GetByID(int id);
        bool Save(IPersona item);
        bool Delete(IPersona item);
        bool Update(IPersona item);
    }
}
