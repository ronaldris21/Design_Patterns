using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DLL.Models;

namespace DLL.ModeloInyeccion
{
    public class BaseDatos : IBaseDatos
    {
        private static List<IPersona> dbPersonas;
        private int index;
        private static int cant;

        public BaseDatos()
        {
            if (dbPersonas==null)
            {
                dbPersonas = new List<IPersona>();
            }
            

        }

        public bool Delete(IPersona item)
        {
            try
            {
                index = dbPersonas.FindIndex(p => p.IdPersona == item.IdPersona);
                dbPersonas.RemoveAt(index);
                return true;
            }
            catch (Exception)
            {
                return false;
                throw;
            }
        }

        public IPersona GetByID(int id)
        {
            return dbPersonas.Find(p => p.IdPersona == id);
        }

        public List<IPersona> GetPersonas()
        {
            return dbPersonas;
        }

        public bool Save(IPersona item)
        {
            try
            {
                int id = cant + 1;
                item.IdPersona = id;
                dbPersonas.Add(item);
                cant++;
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool Update(IPersona item)
        {
            try
            {
                index = dbPersonas.FindIndex(p => p.IdPersona == item.IdPersona);
                dbPersonas[index] = item;
                return true;
            }
            catch (Exception)
            {
                return false;
                throw;
            }
        }
    }
}
