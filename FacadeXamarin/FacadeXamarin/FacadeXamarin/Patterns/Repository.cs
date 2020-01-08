
namespace FacadeXamarin.Patterns
{
    using global::FacadeXamarin.Models;
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Text;
    class Repository : IRepository<Persona>
    {

        //Persistencia de los datos
        #region Atributos
        private List<Persona> Personas;

        #endregion

        #region Metodo Contructor  
        public Repository()
        {
            Personas = new List<Persona>()
            {
                new Persona //Persona 1
                {
                    Nombre="Daniela", Apellido="Miranda",Direccion="SS",Edad=19
                },
                new Persona //Persona 2
                {
                    Nombre="Funes", Apellido="Bukele",Direccion="Bartolinas",Edad=40
                },
                new Persona //Persona 3
                {
                    Nombre="Ashley", Apellido="Rivera",Direccion="SA",Edad=19
                }
            };


        }
        #endregion

        #region Implementacion de Interfaz

        public List<Persona> GetAll()
        {
            return this.Personas;
        }



        public bool ObjectOperation(Persona item, Facade.Operacion option)
        {
            try
            {
                switch (option)
                {
                    case Facade.Operacion.Save:
                        Personas.Add(item);
                        break;
                    case Facade.Operacion.Update:
                        int index = Personas.FindIndex(p => p.Nombre.Equals(item.Nombre));
                        Personas[index] = item;
                        break;
                    case Facade.Operacion.Delete:
                        int index2 = Personas.FindIndex(p => p.Nombre.Equals(item.Nombre));
                        Personas.RemoveAt(index2);
                        break;
                    default:
                        return false;
                }
                return true;
            }
            catch (Exception x)
            {
                Debug.Print("Repository ObjectOperation Method error: " + x.Message);
                return false;
            }
        }



        #endregion

    }
}
