

namespace ConsoleApp.Classes
{
    using DLL.Models;
    using DLL.Patterns;
    using System;
    using System.Collections.Generic;
    using System.Threading;
    public class ProxyRepository : IRepository<Persona>
    {
        public List<Persona> GetAll()
        {
            Loading();
            return SingletonRepository.Instancia.Repository.GetAll();
        }

        public Persona GetByID(int id)
        {

            Loading();
            return SingletonRepository.Instancia.Repository.GetByID(id);
        }

        public bool ObjectOperation(Persona item, Facade.Operacion option)
        {
            Loading();
            return SingletonRepository.Instancia.Repository.ObjectOperation(item, option);
        }

        private void Loading()
        {
            Console.WriteLine("Cargando...");
            Thread.Sleep(1000);
            Console.Clear();
        }
    }
}
