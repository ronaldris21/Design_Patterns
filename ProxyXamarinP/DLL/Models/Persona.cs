
namespace DLL.Models
{
    using System.Collections.Generic;

    public class Persona
    {
        public int ID { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public int Edad { get; set; }
        public string Direccion { get; set; }

        //Parametros estaticos para simular DB local y almacenar datos
        public static List<Persona> dbPersonas;
        public static int cant;
    }
}
