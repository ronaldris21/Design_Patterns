using DLL.ModeloInyeccion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DLL.Models
{
    public class Alumno : IPersona 
    {
        //Asumiendo que ALUMNO Y Persona son dos entidades distinta
        //Por ejemplo Alumno y Empleado o algo así
        //En este ejemplo alumno y Persona tienen  e mismo codigo

        private IBaseDatos db;

        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Direccion { get; set; }
        public int Edad { get; set; }
        public int IdPersona { get; set; }

        public Alumno()
        {
            this.db = Inyector.Get<IBaseDatos>();
        }


        public bool Delete(IPersona item)
        {
            if (item == null)
            {
                return false;
            }
            return this.db.Delete(item);
        }

        public IPersona GetByID(int id)
        {
            return this.db.GetByID(id);
        }

        public List<IPersona> GetPersonas()
        {
            return this.db.GetPersonas();
        }

        public bool Save(IPersona item)
        {
            if (item == null)
            {
                return false;
            }
            return this.db.Save(item);
        }

        public bool Update(IPersona item)
        {
            if (item == null)
            {
                return false;
            }
            return this.db.Update(item);
        }

    }
}
