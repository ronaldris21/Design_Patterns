using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DLL.Models
{
    public interface IPersona
    {
        int IdPersona { get; set; }
        string Nombre { get; set; }
        string Apellido { get; set; }
        string Direccion { get; set; }
        int Edad { get; set; }

        List<IPersona> GetPersonas();
        IPersona GetByID(int id);
        bool Save(IPersona item);
        bool Delete(IPersona item);
        bool Update(IPersona item);


    }
}
