using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PL
{
    class Aseguradora
    {
        public static void Add()
        {
            ServiceReference3.ServicioAseguradoraClient objaseguradora = new ServiceReference3.ServicioAseguradoraClient();
           

            ML.Aseguradora aseguradora = new ML.Aseguradora();
            aseguradora.Usuario = new ML.Usuario();

            //Nombre
            Console.WriteLine("Ingresa el nombre de la aseguradora");
            aseguradora.Nombre = Console.ReadLine();
            //IdUsuario
            Console.WriteLine("Ingresa el ID del usuario ");
            aseguradora.Usuario.IdUsuario = int.Parse(Console.ReadLine());

                
            //ML.Result result = BL.Aseguradora.Add(aseguradora);
            var result = objaseguradora.Add(aseguradora);

            if (result.Correct)
            {
                Console.WriteLine("La aseguradorafue insertada correctamente");
            }
            else
            {
                Console.WriteLine("La aseguradora no fue insertada correctamente. Error: " + result.ErrorMessage);
            }
        }
        public static void Delete()
        {
            ServiceReference3.ServicioAseguradoraClient objaseguradora = new ServiceReference3.ServicioAseguradoraClient();

            ML.Aseguradora aseguradora = new ML.Aseguradora();

            //Id
            Console.WriteLine("Ingrese el ID de la aseguradora que desea eliminar");
            aseguradora.IdAseguradora = int.Parse(Console.ReadLine());


            //ML.Result result = BL.Aseguradora.Delete(aseguradora);
            var result = objaseguradora.Delete(aseguradora);

            if (result.Correct)
            {
                Console.WriteLine("Se ha dado de bajo la aseguradora");
            }
            else
            {
                Console.WriteLine("La aseguradora no se ha podido eliniar. Error: " + result.ErrorMessage);
            }
        }
        public static void Update()
        {
            ServiceReference3.ServicioAseguradoraClient objaseguradora = new ServiceReference3.ServicioAseguradoraClient();

            ML.Aseguradora aseguradora = new ML.Aseguradora();
            aseguradora.Usuario = new ML.Usuario();

            //ID
            Console.WriteLine("Ingresa el ID de la aseguradora");
            aseguradora.IdAseguradora = int.Parse(Console.ReadLine());
            //NOmbre
            Console.WriteLine("Ingresa el  nuevo nombre de la Aseguradora");
            aseguradora.Nombre = Console.ReadLine();
            //ID Usuario
            Console.WriteLine("Ingresa el nuevo ID del usuario");
            aseguradora.Usuario.IdUsuario = int.Parse(Console.ReadLine());

            //ML.Result result = BL.Aseguradora.Update(aseguradora);
            var result = objaseguradora.Update(aseguradora);

            if (result.Correct)
            {
                Console.WriteLine("Se ha actualizado la aseguradora");
            }
            else
            {
                Console.WriteLine("La aseguradora no se pudo editar. Error: " + result.ErrorMessage);
            }
        }
        public static void GetAll()
        {
            ServiceReference3.ServicioAseguradoraClient objaseguradora = new ServiceReference3.ServicioAseguradoraClient();

            //ML.Result result = BL.Aseguradora.GetAll();
            var result = objaseguradora.GetAll();
            if (result.Correct)
            {
                foreach (ML.Aseguradora aseguradora in result.Objects)
                {
                    Console.WriteLine("IdAseguradora: " + aseguradora.IdAseguradora);
                    Console.WriteLine("Nombre de la aseguradora: " + aseguradora.Nombre);
                    Console.WriteLine("Fecha de creacion del registro: " + aseguradora.FechaCreacion);
                    Console.WriteLine("Fecha de la ultima modificacion: " + aseguradora.FechaModificacion);
                    Console.WriteLine("ID del usuario: " + aseguradora.Usuario.IdUsuario);
                    Console.WriteLine("--------------------------------");
                    Console.WriteLine();
                }
            }
            else
            {
                Console.WriteLine("Ocurrió un error al consultar la información" + result.ErrorMessage);
            }
        }
        public static void GetById()
        {
            ServiceReference3.ServicioAseguradoraClient objaseguradora = new ServiceReference3.ServicioAseguradoraClient();

            Console.WriteLine("Ingrese el ID de la aseguradora");
            var result = objaseguradora.GetById(int.Parse(Console.ReadLine()));
            //ML.Result result = BL.Aseguradora.GetById(int.Parse(Console.ReadLine()));


            if (result.Correct)
            {

                //unboxing 
                ML.Aseguradora aseguradora = ((ML.Aseguradora)result.Object);

                Console.WriteLine("IdAseguradora: " + aseguradora.IdAseguradora);
                Console.WriteLine("Nombre de la aseguradora: " + aseguradora.Nombre);
                Console.WriteLine("Fecha de creacion del registro: " + aseguradora.FechaCreacion);
                Console.WriteLine("Fecha de la ultima modificacion: " + aseguradora.FechaModificacion);
                Console.WriteLine("ID del usuario: " + aseguradora.Usuario.IdUsuario);
                Console.WriteLine("--------------------------------");
                Console.WriteLine();

            }
            else
            {
                Console.WriteLine("Ocurrió un error al consultar la información" + result.ErrorMessage);
            }
        }
        public static void AddEF()
        {
            ML.Aseguradora aseguradora = new ML.Aseguradora();
            aseguradora.Usuario = new ML.Usuario();

            //Nombre
            Console.WriteLine("Ingresa el nombre de la aseguradora");
            aseguradora.Nombre = Console.ReadLine();
            //IdUsuario
            Console.WriteLine("Ingresa el ID del usuario ");
            aseguradora.Usuario.IdUsuario = int.Parse(Console.ReadLine());


            ML.Result result = BL.Aseguradora.AddEF(aseguradora);

            if (result.Correct)
            {
                Console.WriteLine("La aseguradora fue insertada correctamente");
            }
            else
            {
                Console.WriteLine("La aseguradora no fue insertada correctamente. Error: " + result.ErrorMessage);
            }
        }
        public static void DeleteEF()
        {
            ML.Aseguradora aseguradora = new ML.Aseguradora();

            //Id
            Console.WriteLine("Ingrese el ID de la aseguradora que desea eliminar");
            aseguradora.IdAseguradora = int.Parse(Console.ReadLine());


            ML.Result result = BL.Aseguradora.DeleteEF(aseguradora.IdAseguradora);

            if (result.Correct)
            {
                Console.WriteLine("Se ha dado de bajo la aseguradora");
            }
            else
            {
                Console.WriteLine("La aseguradora no se ha podido eliniar. Error: " + result.ErrorMessage);
            }
        }
        public static void UpdateEF()
        {
            ML.Aseguradora aseguradora = new ML.Aseguradora();
            aseguradora.Usuario = new ML.Usuario();

            //ID
            Console.WriteLine("Ingresa el ID de la aseguradora");
            aseguradora.IdAseguradora = int.Parse(Console.ReadLine());
            //NOmbre
            Console.WriteLine("Ingresa el  nuevo nombre de la Aseguradora");
            aseguradora.Nombre = Console.ReadLine();
            //ID Usuario
            Console.WriteLine("Ingresa el nuevo ID del usuario");
            aseguradora.Usuario.IdUsuario = int.Parse(Console.ReadLine());

            ML.Result result = BL.Aseguradora.UpdateEF(aseguradora);

            if (result.Correct)
            {
                Console.WriteLine("Se ha actualizado la aseguradora");
            }
            else
            {
                Console.WriteLine("La aseguradora no se pudo editar. Error: " + result.ErrorMessage);
            }
        }
        public static void GetByIdEF()
        {

            Console.WriteLine("Ingrese el ID de la aseguradora");
            ML.Result result = BL.Aseguradora.GetByIdEF(int.Parse(Console.ReadLine()));


            if (result.Correct)
            {

                //unboxing 
                ML.Aseguradora aseguradora = ((ML.Aseguradora)result.Object);

                Console.WriteLine("IdAseguradora: " + aseguradora.IdAseguradora);
                Console.WriteLine("Nombre de la aseguradora: " + aseguradora.Nombre);
                Console.WriteLine("Fecha de creacion del registro: " + aseguradora.FechaCreacion);
                Console.WriteLine("Fecha de la ultima modificacion: " + aseguradora.FechaModificacion);
                Console.WriteLine("ID del usuario: " + aseguradora.Usuario.IdUsuario);
                Console.WriteLine("--------------------------------");
                Console.WriteLine();

            }
            else
            {
                Console.WriteLine("Ocurrió un error al consultar la información" + result.ErrorMessage);
            }
        }
        public static void GetAllEF()
        {
            ML.Result result = BL.Aseguradora.GetAllEF();
            if (result.Correct)
            {
                foreach (ML.Aseguradora aseguradora in result.Objects)
                {
                    Console.WriteLine("IdAseguradora: " + aseguradora.IdAseguradora);
                    Console.WriteLine("Nombre de la aseguradora: " + aseguradora.Nombre);
                    Console.WriteLine("Fecha de creacion del registro: " + aseguradora.FechaCreacion);
                    Console.WriteLine("Fecha de la ultima modificacion: " + aseguradora.FechaModificacion);
                    Console.WriteLine("ID del usuario: " + aseguradora.Usuario.IdUsuario);
                    Console.WriteLine("--------------------------------");
                    Console.WriteLine();
                }
            }
            else
            {
                Console.WriteLine("Ocurrió un error al consultar la información" + result.ErrorMessage);
            }
        }
        public static void AddLINQ()
        {
            ML.Aseguradora aseguradora = new ML.Aseguradora();
            aseguradora.Usuario = new ML.Usuario();

            //Nombre
            Console.WriteLine("Ingresa el nombre de la aseguradora");
            aseguradora.Nombre = Console.ReadLine();
            //IdUsuario
            Console.WriteLine("Ingresa el ID del usuario ");
            aseguradora.Usuario.IdUsuario = int.Parse(Console.ReadLine());


            ML.Result result = BL.Aseguradora.AddLINQ(aseguradora);

            if (result.Correct)
            {
                Console.WriteLine("La aseguradora fue insertada correctamente");
            }
            else
            {
                Console.WriteLine("La aseguradora no fue insertada correctamente. Error: " + result.ErrorMessage);
            }
        }
        public static void DeleteLINQ()
        {
            ML.Aseguradora aseguradora = new ML.Aseguradora();

            //Id
            Console.WriteLine("Ingrese el ID de la aseguradora que desea eliminar");
            aseguradora.IdAseguradora = int.Parse(Console.ReadLine());


            ML.Result result = BL.Aseguradora.DeleteLINQ(aseguradora);

            if (result.Correct)
            {
                Console.WriteLine("Se ha dado de bajo la aseguradora");
            }
            else
            {
                Console.WriteLine("La aseguradora no se ha podido eliniar. Error: " + result.ErrorMessage);
            }
        }
        public static void UpdateLINQ()
        {
            ML.Aseguradora aseguradora = new ML.Aseguradora();
            aseguradora.Usuario = new ML.Usuario();

            //ID
            Console.WriteLine("Ingresa el ID de la aseguradora");
            aseguradora.IdAseguradora = int.Parse(Console.ReadLine());
            //NOmbre
            Console.WriteLine("Ingresa el  nuevo nombre de la Aseguradora");
            aseguradora.Nombre = Console.ReadLine();
            //ID Usuario
            Console.WriteLine("Ingresa el nuevo ID del usuario");
            aseguradora.Usuario.IdUsuario = int.Parse(Console.ReadLine());

            ML.Result result = BL.Aseguradora.UpdateLINQ(aseguradora);

            if (result.Correct)
            {
                Console.WriteLine("Se ha actualizado la aseguradora");
            }
            else
            {
                Console.WriteLine("La aseguradora no se pudo editar. Error: " + result.ErrorMessage);
            }
        }
        public static void GetByIdLINQ()
        {

            Console.WriteLine("Ingrese el ID de la aseguradora");
            ML.Result result = BL.Aseguradora.GetByIdLINQ(int.Parse(Console.ReadLine()));


            if (result.Correct)
            {

                //unboxing 
                ML.Aseguradora aseguradora = ((ML.Aseguradora)result.Object);

                Console.WriteLine("IdAseguradora: " + aseguradora.IdAseguradora);
                Console.WriteLine("Nombre de la aseguradora: " + aseguradora.Nombre);
                Console.WriteLine("Fecha de creacion del registro: " + aseguradora.FechaCreacion);
                Console.WriteLine("Fecha de la ultima modificacion: " + aseguradora.FechaModificacion);
                Console.WriteLine("ID del usuario: " + aseguradora.Usuario.IdUsuario);
                Console.WriteLine("--------------------------------");
                Console.WriteLine();

            }
            else
            {
                Console.WriteLine("Ocurrió un error al consultar la información" + result.ErrorMessage);
            }
        }
        public static void GetAllLINQ()
        {
            ML.Result result = BL.Aseguradora.GetAllLINQ();
            if (result.Correct)
            {
                foreach (ML.Aseguradora aseguradora in result.Objects)
                {
                    Console.WriteLine("IdAseguradora: " + aseguradora.IdAseguradora);
                    Console.WriteLine("Nombre de la aseguradora: " + aseguradora.Nombre);
                    Console.WriteLine("Fecha de creacion del registro: " + aseguradora.FechaCreacion);
                    Console.WriteLine("Fecha de la ultima modificacion: " + aseguradora.FechaModificacion);
                    Console.WriteLine("ID del usuario: " + aseguradora.Usuario.IdUsuario);
                    Console.WriteLine("--------------------------------");
                    Console.WriteLine();
                }
            }
            else
            {
                Console.WriteLine("Ocurrió un error al consultar la información" + result.ErrorMessage);
            }
        }

    }
}
