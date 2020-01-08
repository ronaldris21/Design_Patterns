

namespace ProxyXamarinP.Classes
{
    using Acr.UserDialogs;
    using DLL.Models;
    using DLL.Patterns;
    using System.Collections.Generic;
    using System.Threading.Tasks;
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


        private async void Loading()
        {
            using (UserDialogs.Instance.Loading("Cargando", null, null, true, MaskType.Black))
            {
                await Task.Delay(2000);
            }
        }
    }
}
