using ConsoleApp.Classes;
using DLL.Models;
using DLL.Patterns;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp
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
            Persona item1;
            int id;
            IRepository<Persona> datos = new ProxyRepository();
            bool salir = false;
            do
            {
                GetMenu();
                int num;
                if (int.TryParse(Console.ReadLine(), out num) && num > 0 && num < 7)
                {
                    switch (num)
                    {
                        case 1:
                            List<Persona> ListaPersona = datos.GetAll();
                            Console.WriteLine("================================");
                            Console.WriteLine("===LISTADO DE PERSONAS==========");
                            Console.WriteLine("====================================================================================================");
                            Console.WriteLine(String.Format("   {0,-5} ||   {1,-20} ||   {2,-20} ||   {3,-5} ||   {4}", "Id", "Nombre", "Apellido", "Edad", "Dirección"));
                            Console.WriteLine("===================================================================================================="); foreach (var item in ListaPersona)
                            {
                                Console.WriteLine(String.Format("   {0,-5} ||   {1,-20} ||   {2,-20} ||   {3,-5} ||   {4}", item.ID, item.Nombre, item.Apellido, item.Edad, item.Direccion));
                                Console.WriteLine("====================================================================================================");
                            }
                            break;

                        case 2:
                            Console.Write("\n\nIngrese el id a buscar: ");
                            if (int.TryParse(Console.ReadLine(), out id) && id > 0)
                            {
                                item1 = SingletonRepository.Instancia.Repository.GetByID(id);
                                if (item1 != null)
                                {
                                    Console.WriteLine(String.Format("   {0,-5} ||   {1,-20} ||   {2,-20} ||   {3,-5} ||   {4}", "Id", "Nombre", "Apellido", "Edad", "Dirección"));
                                    Console.WriteLine(String.Format("   {0,-5} ||   {1,-20} ||   {2,-20} ||   {3,-5} ||   {4}", item1.ID, item1.Nombre, item1.Apellido, item1.Edad, item1.Direccion));
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
                            if (int.TryParse(Console.ReadLine(), out id) && id > 0)
                            {
                                item1 = SingletonRepository.Instancia.Repository.GetByID(id);
                                if (item1 != null)
                                {
                                    Console.WriteLine(String.Format("   {0,-5} ||   {1,-20} ||   {2,-20} ||   {3,-5} ||   {4}", "Id", "Nombre", "Apellido", "Edad", "Dirección"));
                                    Console.WriteLine(String.Format("   {0,-5} ||   {1,-20} ||   {2,-20} ||   {3,-5} ||   {4}", item1.ID, item1.Nombre, item1.Apellido, item1.Edad, item1.Direccion));

                                    Console.WriteLine("Esta seguro que desea modificar (1=si,2=no)");
                                    int seguro1_2 = 0;
                                    seguro1_2 = int.Parse(Console.ReadLine());
                                    if (seguro1_2 == 1)
                                    {
                                        if (SingletonRepository.Instancia.Repository.ObjectOperation(item1, Facade.Operacion.Delete))
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
                            if (int.TryParse(Console.ReadLine(), out id) && id > 0)
                            {
                                item1 = SingletonRepository.Instancia.Repository.GetByID(id);
                                if (item1 != null)
                                {
                                    Console.WriteLine(String.Format("   {0,-5} ||   {1,-20} ||   {2,-20} ||   {3,-5} ||   {4}", "Id", "Nombre", "Apellido", "Edad", "Dirección"));
                                    Console.WriteLine(String.Format("   {0,-5} ||   {1,-20} ||   {2,-20} ||   {3,-5} ||   {4}", item1.ID, item1.Nombre, item1.Apellido, item1.Edad, item1.Direccion));

                                    Console.WriteLine("Esta seguro que desea modificar (1=si,2=no)");
                                    int seguro1_2 = 0;
                                    seguro1_2 = int.Parse(Console.ReadLine());
                                    if (seguro1_2==1)
                                    {
                                        Persona newPersona = new Persona() { ID = item1.ID };
                                        Console.WriteLine("Ingrese los siguientes datos:");
                                        Console.Write("Nombre: ");
                                        newPersona.Nombre = Console.ReadLine();
                                        Console.Write("Apellido: ");
                                        newPersona.Apellido = Console.ReadLine();
                                        Console.Write("Edad: ");
                                        newPersona.Edad = int.Parse(Console.ReadLine());
                                        Console.Write("Dirección: ");
                                        newPersona.Direccion = Console.ReadLine();

                                        if (SingletonRepository.Instancia.Repository.ObjectOperation(newPersona, Facade.Operacion.Update))
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
                            Persona newPersona2 = new Persona();
                            Console.WriteLine("Ingrese los siguientes datos:");
                            Console.Write("Nombre: ");
                            newPersona2.Nombre = Console.ReadLine();
                            Console.Write("Apellido: ");
                            newPersona2.Apellido = Console.ReadLine();
                            Console.Write("Edad: ");
                            newPersona2.Edad = int.Parse(Console.ReadLine());
                            Console.Write("Dirección: ");
                            newPersona2.Direccion = Console.ReadLine();

                            if (SingletonRepository.Instancia.Repository.ObjectOperation(newPersona2, Facade.Operacion.Save))
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
