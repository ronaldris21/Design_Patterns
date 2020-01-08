
namespace DLL.Patterns
{
    using System.Collections.Generic;
    public interface IRepository<T>
    {
        //Vamos simular un CRUD

        List<T> GetAll();//Obtiene todos los datos de tipo T almacenados
        T GetByID(int id);
        bool ObjectOperation(T item, Facade.Operacion option);


    }
}
