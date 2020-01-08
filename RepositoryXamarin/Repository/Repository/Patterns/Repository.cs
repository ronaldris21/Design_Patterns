

namespace Repository.Patterns
{
    using global::Repository.Models;
    using System;
    using System.Collections.Generic;
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
        public bool Delete(Persona item)
        {
            try
            {
                int index = Personas.FindIndex(p => p.Nombre.Equals(item.Nombre) && p.Apellido.Equals(item.Apellido) && p.Direccion.Equals(item.Direccion));
                Personas.RemoveAt(index);
                return true;
            }
            catch 
            {
                return false;
            }
        }

        public List<Persona> GetAll()
        {
            return this.Personas;
        }

        public Persona GetbyNombre(string nombre)
        {
            return this.Personas.Find(p=>p.Nombre== nombre);
        }

        public bool Save(Persona item)
        {
            try
            {
                Personas.Add(item);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool Update(Persona old, Persona item)
        {
            try
            {
                int index = Personas.FindIndex(p => p.Nombre.Equals(old.Nombre) && p.Apellido.Equals(old.Apellido) && p.Direccion.Equals(old.Direccion));
                Personas[index]  = item;
                return true;
            }
            catch
            {
                return false;
            }
        }

        #endregion

    }
}
