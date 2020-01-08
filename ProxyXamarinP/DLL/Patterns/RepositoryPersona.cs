

namespace DLL.Patterns
{
    using global::DLL.Models;
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Text;
    public class RepositoryPersona : IRepository<Persona>
    {

        //Persistencia de los datos
        #region Atributos
        private int _index;
        #endregion

        #region Metodo Contructor  
        public RepositoryPersona()
        {
            Persona.dbPersonas = new List<Persona>()
            {
                new Persona //Persona 1
                {
                    ID=1,
                    Nombre ="Daniela", Apellido="Miranda",Direccion="SS",Edad=19
                },
                new Persona //Persona 2
                {
                    ID=2,
                    Nombre="Funes", Apellido="Bukele",Direccion="Bartolinas",Edad=40
                },
                new Persona //Persona 3
                {
                    ID=3,
                    Nombre="Ashley", Apellido="Rivera",Direccion="SA",Edad=19
                }
            };

            Persona.cant = 3;
        }
        #endregion

        #region Implementacion de Interfaz

        public List<Persona> GetAll()
        {
            return Persona.dbPersonas;
        }

        public Persona GetByID(int id)
        {
            return Persona.dbPersonas.Find(p => p.ID == id);
        }

        public bool ObjectOperation(Persona item, Facade.Operacion option)
        {
            try
            {

                switch (option)
                {
                    case Facade.Operacion.Save:
                        int id = Persona.cant + 1;
                        item.ID = id;
                        Persona.dbPersonas.Add(item);
                        Persona.cant++;
                        return true;
                    case Facade.Operacion.Update:
                        _index = Persona.dbPersonas.FindIndex(p => p.ID == item.ID);
                        Persona.dbPersonas[_index] = item;
                        return true;
                    case Facade.Operacion.Delete:
                        _index = Persona.dbPersonas.FindIndex(p => p.ID == item.ID);
                        Persona.dbPersonas.RemoveAt(_index);
                        return true;
                    default:
                        return false;
                }
            }
            catch (Exception x)
            {
                Debug.Print("Repository EXception: " + option.ToString() + "  error: " + x.Message);
                return false;
            }

        }



        #endregion

    }
}
