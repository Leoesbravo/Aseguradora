using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PL
{
    class Program
    {
        static void Main(string[] args)
        {

            ServiceReference1.Service1Client obj = new ServiceReference1.Service1Client();
            Console.WriteLine(obj.Saludar(" Leonardo"));

            ServiceReferenceSuma.Service2Client service2Client = new ServiceReferenceSuma.Service2Client();
            Console.WriteLine("Ingrese un numero");
            int a = int.Parse(Console.ReadLine());
            Console.WriteLine("Ingrese un numero");
            int b = int.Parse(Console.ReadLine());

            Console.WriteLine("el resultado es: " + service2Client.Suma(a, b));


            Console.WriteLine("----------------------Bienvenido-------------------------");
            bool salir = false;

            while (!salir)
            {
                Console.WriteLine("----------------------USUARIO----------------------------");
                Console.WriteLine("1. Registrar un Usuario");
                Console.WriteLine("2. Eliminar un Usuario");
                Console.WriteLine("3. Editar un Usuario");
                Console.WriteLine("4. Consultar todos los Usuarios registrados");
                Console.WriteLine("5. Consultar un usuario registrado");
                Console.WriteLine("-----------------------ASEGURADORA-----------------------");
                Console.WriteLine("6. Registrar una aseguradora");
                Console.WriteLine("7. Eliminar una aseguradora");
                Console.WriteLine("8. Editar una aseguradora");
                Console.WriteLine("9. Consultar todas las aseguradoras registradas");
                Console.WriteLine("10. Consultar una aseguradora");
                Console.WriteLine("-----------------------USUARIO EF------------------------");
                Console.WriteLine("11. Registrar un Usuario con EF");
                Console.WriteLine("12. Eliminar un registro con EF");
                Console.WriteLine("13. Editar un registro con EF");
                Console.WriteLine("14. Consultar un registro por su ID con EF");
                Console.WriteLine("15. Consultar todos los registros");
                Console.WriteLine("---------------------ASEGURADORA EF----------------------");
                Console.WriteLine("16. Agregar un registro con EF");
                Console.WriteLine("17. Eliminar un registro con EF");
                Console.WriteLine("18. Editar un registro con EF");
                Console.WriteLine("19. Consultar un registro por su ID con EF");
                Console.WriteLine("20. Consultar todos los registros con EF");
                Console.WriteLine("--------------------USUARIOLINQ--------------------------");
                Console.WriteLine("21. Consultar todos los usuarios con LINQ");
                Console.WriteLine("22. Registrar un usuario con LINQ");
                Console.WriteLine("23. Editar un usuario con LINQ");
                Console.WriteLine("24. Eliminar un usuario con LINQ");
                Console.WriteLine("25. Consultar un usuario por su ID con LINQ");
                Console.WriteLine("--------------------ASEGURADORA LINQ---------------------");
                Console.WriteLine("26. Agregar una aseguradora con LINQ");
                Console.WriteLine("27. Eliminar una aseguradora con LINQ");
                Console.WriteLine("28. Editar una aseguradora con LINQ");
                Console.WriteLine("29. Consultar una aseguradora por su ID con LINQ");
                Console.WriteLine("30. Consultar todas las aseguradoras con LINQ");
                Console.WriteLine("---------------------------------------------------------");
                Console.WriteLine("31. Salir");
                Console.WriteLine("Elige una de las opciones");
                Console.WriteLine("---------------------------------------------------------");
                int opcion = int.Parse(Console.ReadLine());

                switch (opcion)
                {
                    case 1:
                        Console.WriteLine("Seleccion registrar un nuevo usuario");
                        PL.Usuario.Add();
                        break;

                    case 2:
                        Console.WriteLine("Has seleccionado elminar un un usuario");
                        PL.Usuario.DeleteSP();
                        break;

                    case 3:
                        Console.WriteLine("Has seleccionado editar un un usuario");
                        PL.Usuario.UpdateSP();
                        break;

                    case 4:
                        Console.WriteLine("Estos son los usuarios registrados");
                        Console.WriteLine("----------------------------------------");
                        PL.Usuario.GetAllSP();
                        break;

                    case 5:
                        Console.WriteLine("Ha seleccionado, consultar un registro");
                        PL.Usuario.GetByIdSP();
                        break;

                    case 6:
                        Console.WriteLine("Ha seleccionado registrar una aseguradora");
                        PL.Aseguradora.Add();
                        break;

                    case 7:
                        Console.WriteLine("Ha seleccionado eliminar el registro de una aseguradora");
                        PL.Aseguradora.Delete();
                        break;

                    case 8:
                        Console.WriteLine("Ha seleccionado editar un registro de una aseguradora");
                        PL.Aseguradora.Update();
                        break;

                    case 9:
                        Console.WriteLine("Estas son las aseguradoras registradas");
                        PL.Aseguradora.GetAll();
                        break;

                    case 10:
                        Console.WriteLine("Ha seleccionado consultar una aseguradora");
                        PL.Aseguradora.GetById();
                        break;

                    case 11:
                        Console.WriteLine("Ha seleccionado agregar un usuario con EF");
                        PL.Usuario.AddEF();
                        break;

                    case 12:
                        Console.WriteLine("Ha seleccionado eliminar un usuario con EF");
                        PL.Usuario.DeleteEF();
                        break;

                    case 13:
                        Console.WriteLine("Ha seleccionado editar un usuario con EF");
                        PL.Usuario.UpdateEF();
                        break;

                    case 14:
                        Console.WriteLine("Ha seleccionado consultar un usuario mediante su IDcon EF");
                        PL.Usuario.GetByIdEF();
                        break;

                    case 15:
                        Console.WriteLine("Ha seleccionado consultar todos los registros");
                        PL.Usuario.GetAllEF();
                        break;

                    case 16:
                        Console.WriteLine("Ha seleccionado agregar una aseguradora con EF");
                        PL.Aseguradora.AddEF();
                        break;

                    case 17:
                        Console.WriteLine("Ha seleccionado eliminar una aseguradora con EF");
                        PL.Aseguradora.DeleteEF();
                        break;

                    case 18:
                        Console.WriteLine("Ha seleccionado editar una aseguradora con EF");
                        PL.Aseguradora.UpdateEF();
                        break;

                    case 19:
                        Console.WriteLine("Ha seleccionado consultar un usuario mediante su IDcon EF");
                        PL.Aseguradora.GetByIdEF();
                        break;

                    case 20:
                        Console.WriteLine("Ha seleccionado consultar todos los registros");
                        PL.Aseguradora.GetAllEF();
                        break;

                    case 21:
                        Console.WriteLine("Ha seleccionado consultar todos los registros");
                        PL.Usuario.GetAllLINQ();
                        break;

                    case 22:
                        Console.WriteLine("Ha seleccionado registrar un usuario");
                        PL.Usuario.AddLINQ();
                        break;

                    case 23:
                        Console.WriteLine("Ha seleccionado editar un usuario");
                        PL.Usuario.UpdateLINQ();
                        break;

                    case 24:
                        Console.WriteLine("Ha seleccionado elimnar un usuario");
                        PL.Usuario.DeleteLINQ();
                        break;

                    case 25:
                        Console.WriteLine("Ha seleccionado consultar un usuario por su ID");
                        PL.Usuario.GetByIdLINQ();
                        break;

                    case 26:
                        Console.WriteLine("Ha seleccionado agregar una aseguradora");
                        PL.Aseguradora.AddLINQ();
                        break;

                    case 27:
                        Console.WriteLine("Ha seleccionado eliminar una aseguradora");
                        PL.Aseguradora.DeleteLINQ();
                        break;

                    case 28:
                        Console.WriteLine("Ha seleccionado editar una aseguradora");
                        PL.Aseguradora.UpdateLINQ();
                        break;

                    case 29:
                        Console.WriteLine("Ha seleccionado consultar una aseguradora por su ID");
                        PL.Aseguradora.GetByIdLINQ();
                        break;

                    case 30:
                        Console.WriteLine("Ha seleccionado consultar todas las aseguradoras");
                        PL.Aseguradora.GetAllLINQ();
                        break;

                    case 31:
                        salir = true;
                        break;
                }
            }
        }
    }
}