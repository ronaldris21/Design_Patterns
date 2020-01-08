
namespace Repository.Patterns
{
    using System.Collections.Generic;
    interface IRepository<T>
    {
        //Vamos simular un CRUD

        List<T> GetAll();//Obtiene todos los datos de tipo T almacenados
        T GetbyNombre(string nombre);//Obtiene un especifico tipo T
        bool Delete(T item);//Elimina un objeto T
        bool Save(T item);//Guardar un objeto
        bool Update(T old, T item);//Actualiza valores segun id


    }
}
