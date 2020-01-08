using DLL.ModeloInyeccion;
using DLL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Console_IOC
{
    class Program
    {
        private static void GetMenu()
        {
            Console.Clear();
            Console.WriteLine("*************     Menu   ********************");
            Console.WriteLine("** 1- Consultar datos");
            Console.WriteLine("** 2- Consultar por id");
            Console.WriteLine("** 3- Eliminar persona");
            Console.WriteLine("** 4- Actualizar datos de persona");
            Console.WriteLine("** 5- Guardar nueva persona");
            Console.WriteLine("** 6- Salir");
            Console.Write("---------- Elija opcion:   ");
        }
        static void Main(string[] args)
        {

            //PRIMERO SE REGISTRA LA REFENCIA DEL OBJETO DEL PROYECTO DLL
            //SEGUNDO Registrar las dependiencias

            Inyector.Map< IBaseDatos, BaseDatos>();
            Inyector.Map< IPersona,Alumno>();

            var alumno = Inyector.Get<IPersona>();
            var gestion = Inyector.Get<IBaseDatos>();


            //Agregare datos de prueba
            alumno.Nombre = "Ronald";
            alumno.Apellido = "Ris";
            alumno.Direccion = "SA";
            alumno.Edad = 19;
            gestion.Save(alumno);
            //Reinicio el objeto
            alumno = Inyector.Get<IPersona>();

            alumno.Nombre = "Dayana";
            alumno.Apellido = "Viocelli";
            alumno.Direccion = "SM";
            alumno.Edad = 19;
            gestion.Save(alumno);
            //Reinicio el objeto
            alumno = Inyector.Get<IPersona>();


            GetMenu();
            int opcionMenu;
            bool salir = false;

            int id_Ingresado;
            
            do
            {
                GetMenu();
                if (int.TryParse(Console.ReadLine(), out opcionMenu) && opcionMenu > 0 && opcionMenu < 7)
                {
                    switch (opcionMenu)
                    {
                        case 1:
                            List<IPersona> ListaPersona = gestion.GetPersonas();
                            Console.WriteLine("================================");
                            Console.WriteLine("===LISTADO DE PERSONAS==========");
                            Console.WriteLine("====================================================================================================");
                            Console.WriteLine(String.Format("   {0,-5} ||   {1,-20} ||   {2,-20} ||   {3,-5} ||   {4}", "Id", "Nombre", "Apellido", "Edad", "Dirección"));
                            Console.WriteLine("===================================================================================================="); foreach (var item in ListaPersona)
                            {
                                Console.WriteLine(String.Format("   {0,-5} ||   {1,-20} ||   {2,-20} ||   {3,-5} ||   {4}", item.IdPersona, item.Nombre, item.Apellido, item.Edad, item.Direccion));
                                Console.WriteLine("====================================================================================================");
                            }
                            break;

                        case 2:
                            Console.Write("\n\nIngrese el id a buscar: ");
                            if (int.TryParse(Console.ReadLine(), out id_Ingresado) && id_Ingresado > 0)
                            {
                                alumno = Inyector.Get<IPersona>();
                                alumno = gestion.GetByID(id_Ingresado);
                                if (alumno != null)
                                {
                                    Console.WriteLine(String.Format("   {0,-5} ||   {1,-20} ||   {2,-20} ||   {3,-5} ||   {4}", "Id", "Nombre", "Apellido", "Edad", "Dirección"));
                                    Console.WriteLine(String.Format("   {0,-5} ||   {1,-20} ||   {2,-20} ||   {3,-5} ||   {4}", alumno.IdPersona, alumno.Nombre, alumno.Apellido, alumno.Edad, alumno.Direccion));
                                }
                                else
                                {
                                    Console.WriteLine("No existe ese usuario");
                                }
                            }
                            else
                            {
                                Console.WriteLine("Ingrese un numero valido mayor o igual que 1");
                            }

                            break;
                        case 3:
                            Console.Write("\n\nIngrese el id a eliminar: ");
                            if (int.TryParse(Console.ReadLine(), out id_Ingresado) && id_Ingresado > 0)
                            {
                                alumno = gestion.GetByID(id_Ingresado);
                                if (alumno != null)
                                {
                                    Console.WriteLine(String.Format("   {0,-5} ||   {1,-20} ||   {2,-20} ||   {3,-5} ||   {4}", "Id", "Nombre", "Apellido", "Edad", "Dirección"));
                                    Console.WriteLine(String.Format("   {0,-5} ||   {1,-20} ||   {2,-20} ||   {3,-5} ||   {4}", alumno.IdPersona, alumno.Nombre, alumno.Apellido, alumno.Edad, alumno.Direccion));

                                    Console.WriteLine("Esta seguro que desea modificar (1=si,2=no)");
                                    int seguro1_2 = 0;
                                    seguro1_2 = int.Parse(Console.ReadLine());
                                    if (seguro1_2 == 1)
                                    {
                                        if(gestion.Delete(alumno))
                                        {
                                            Console.WriteLine("Eliminado con exito");
                                        }
                                        else
                                        {
                                            Console.WriteLine("No se pudo eliminar");
                                        }
                                    }
                                }
                                else
                                {
                                    Console.WriteLine("No existe ese usuario");
                                }
                            }
                            else
                            {
                                Console.WriteLine("Ingrese un numero valido mayor o igual que 1");
                            }
                            break;
                        case 4:
                            Console.Write("\n\nIngrese el id a buscar: ");
                            if (int.TryParse(Console.ReadLine(), out id_Ingresado) && id_Ingresado > 0)
                            {
                                alumno = gestion.GetByID(id_Ingresado);
                                if (alumno != null)
                                {
                                    Console.WriteLine(String.Format("   {0,-5} ||   {1,-20} ||   {2,-20} ||   {3,-5} ||   {4}", "Id", "Nombre", "Apellido", "Edad", "Dirección"));
                                    Console.WriteLine(String.Format("   {0,-5} ||   {1,-20} ||   {2,-20} ||   {3,-5} ||   {4}", alumno.IdPersona, alumno.Nombre, alumno.Apellido, alumno.Edad, alumno.Direccion));

                                    Console.WriteLine("Esta seguro que desea modificar (1=si,2=no)");
                                    int seguro1_2 = 0;
                                    seguro1_2 = int.Parse(Console.ReadLine());
                                    if (seguro1_2 == 1)
                                    {
                                        
                                        Console.WriteLine("Ingrese los siguientes datos:");
                                        Console.Write("Nombre: ");
                                        alumno.Nombre = Console.ReadLine();
                                        Console.Write("Apellido: ");
                                        alumno.Apellido = Console.ReadLine();
                                        Console.Write("Edad: ");
                                        alumno.Edad = int.Parse(Console.ReadLine());
                                        Console.Write("Dirección: ");
                                        alumno.Direccion = Console.ReadLine();

                                        if (gestion.Update(alumno))
                                        {
                                            Console.WriteLine("Actualizado");
                                        }
                                        else
                                        {
                                            Console.WriteLine("No se actualizo");
                                        }
                                    }

                                }
                                else
                                {
                                    Console.WriteLine("No existe ese usuario");
                                }
                            }
                            else
                            {
                                Console.WriteLine("Ingrese un numero valido mayor o igual que 1");
                            }
                            break;
                        case 5:
                            alumno = Inyector.Get<IPersona>();
                            Console.WriteLine("Ingrese los siguientes datos:");
                            Console.Write("Nombre: ");
                            alumno.Nombre = Console.ReadLine();
                            Console.Write("Apellido: ");
                            alumno.Apellido = Console.ReadLine();
                            Console.Write("Edad: ");
                            alumno.Edad = int.Parse(Console.ReadLine());
                            Console.Write("Dirección: ");
                            alumno.Direccion = Console.ReadLine();

                            if (gestion.Save(alumno))
                            {
                                Console.WriteLine("Guardado");
                            }
                            else
                            {
                                Console.WriteLine("No se guardó");
                            }
                            break;
                        case 6:
                            salir = true;
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Ingrese un numero valido");
                }
                Console.ReadKey();

            } while (!salir);
            Console.WriteLine("Programa finalizado, hasta luego!");
            Console.ReadKey();
        }
    }
}
