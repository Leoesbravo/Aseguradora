using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace PL
{
    class Usuario
    {
        public static void Add()
        {
            ML.Usuario usuario = new ML.Usuario();
            

            //UserName
            Console.WriteLine("Ingresa el un User Name");
            usuario.UserName = Console.ReadLine();
            //Nombre
            Console.WriteLine("Ingresa el nombre del nuevo usuario");
            usuario.Nombre = Console.ReadLine();
            //Apaterno
            Console.WriteLine("Ingresa el apellido paterno");
            usuario.ApellidoPaterno = Console.ReadLine();
            //Amaterno
            Console.WriteLine("En caso de tener, ingresa el apellido materno");
            usuario.ApellidoMaterno = Console.ReadLine();
            //Email
            Console.WriteLine("ingresa el Email");
            usuario.Email = Console.ReadLine();
            //Sexo
            Console.WriteLine("ingresa el Sexo H-M");
            usuario.Sexo = Console.ReadLine();
            //Telefono
            Console.WriteLine("ingresa el telefono");
            usuario.Telefono = Console.ReadLine();
            //celular
            Console.WriteLine("ingresa el telefono celuar");
            usuario.Celular = Console.ReadLine();
            //FNacimiento
            Console.WriteLine("ingresa la fecha de nacimiento en formato dd-mm-yyyy");
            usuario.FechaNacimiento = Console.ReadLine();
            //curp
            Console.WriteLine("ingresa el CURP");
            usuario.Curp = Console.ReadLine();

            ML.Result result = BL.Usuario.Add(usuario);

            if (result.Correct)
            {
                Console.WriteLine("La materia fue insertada correctamente");
            }
            else
            {
                Console.WriteLine("La materia no fue insertada correctamente. Error: " + result.ErrorMessage);
            }
        }
        public static void DeleteSP()
        {
            ML.Usuario usuario = new ML.Usuario();

            //Id
            Console.WriteLine("Ingrese el ID del usuario que desea eliminar");
            usuario.IdUsuario = int.Parse(Console.ReadLine());


            ML.Result result = BL.Usuario.DeleteSP(usuario);

            if (result.Correct)
            {
                Console.WriteLine("Se ha dado de bajo al usuario");
            }
            else
            {
                Console.WriteLine("El usuario no se ha podido eliniar. Error: " + result.ErrorMessage);
            }
        }
        public static void UpdateSP()
        {
            ML.Usuario usuario = new ML.Usuario();

            //ID
            Console.WriteLine("Ingresa el ID del usuario");
            usuario.IdUsuario = int.Parse(Console.ReadLine());
            //User Name
            Console.WriteLine("Ingresa el  nuevo User Name");
            usuario.UserName = Console.ReadLine();
            //Nombre
            Console.WriteLine("Ingresa el nuevo nombre del usuario");
            usuario.Nombre = Console.ReadLine();
            //APaterno
            Console.WriteLine("Ingresa el nuevo apellido paterno del usuario");
            usuario.ApellidoPaterno = Console.ReadLine();
            //AMaterno
            Console.WriteLine("Ingresa el apellido materno del usuario");
            usuario.ApellidoMaterno = Console.ReadLine();
            //Email
            Console.WriteLine("Ingresa el nuevo email del usuario");
            usuario.Email = Console.ReadLine();
            //Sexo
            Console.WriteLine("Ingresa el nuevo sexo del usuario H-M");
            usuario.Sexo = Console.ReadLine();
            //Telefono
            Console.WriteLine("Ingresa el nuevo telefono del usuario");
            usuario.Telefono = Console.ReadLine();
            //Celular
            Console.WriteLine("Ingresa el nuevo celular del usuario");
            usuario.Celular = Console.ReadLine();
            //Fecha Nacimiento
            Console.WriteLine("Modifica la fecha de nacimiento del usuario");
            usuario.FechaNacimiento = Console.ReadLine();
            //Curp
            Console.WriteLine("Modifica el curp del usuario");
            usuario.Curp = Console.ReadLine();

            ML.Result result = BL.Usuario.UpdateSP(usuario);

            if (result.Correct)
            {
                Console.WriteLine("La materia fue actualizada correctamente");
            }
            else
            {
                Console.WriteLine("La materia no fue insertada correctamente. Error: " + result.ErrorMessage);
            }
        }
        public static void GetAllSP()
        {
            ML.Result result = BL.Usuario.GetAllSP();

            if (result.Correct)
            {
                foreach (ML.Usuario usuario in result.Objects)
                {
                    Console.WriteLine("IdMateria: " + usuario.IdUsuario);
                    Console.WriteLine("Nombre de usuario: " + usuario.UserName);
                    Console.WriteLine("Nombre: " + usuario.Nombre);
                    Console.WriteLine("Apellido Paterno: " + usuario.ApellidoPaterno);
                    Console.WriteLine("Apellido Materno: " + usuario.ApellidoMaterno);
                    Console.WriteLine("Email: " + usuario.Email);
                    Console.WriteLine("Sexo: " + usuario.Sexo);
                    Console.WriteLine("Telefono: " + usuario.Telefono);
                    Console.WriteLine("Celular: " + usuario.Celular);
                    Console.WriteLine("FechaNacimiento: " + usuario.FechaNacimiento);
                    Console.WriteLine("Curp: " + usuario.Curp);
                    Console.WriteLine("--------------------------------");
                    Console.WriteLine();
                }
            }
            else
            {
                Console.WriteLine("Ocurrió un error al consultar la información" + result.ErrorMessage);
            }
        }
        public static void GetByIdSP()
        {

            Console.WriteLine("Ingrese el ID del usuario");
            ML.Result result = BL.Usuario.GetByIdSP(int.Parse(Console.ReadLine()));


            if (result.Correct)
            {

                //unboxing 
                ML.Usuario usuario = ((ML.Usuario)result.Object);

                Console.WriteLine("IdMateria: " + usuario.IdUsuario);
                Console.WriteLine("Nombre de usuario: " + usuario.UserName);
                Console.WriteLine("Nombre: " + usuario.Nombre);
                Console.WriteLine("Apellido Paterno: " + usuario.ApellidoPaterno);
                Console.WriteLine("Apellido Materno: " + usuario.ApellidoMaterno);
                Console.WriteLine("Email: " + usuario.Email);
                Console.WriteLine("Sexo: " + usuario.Sexo);
                Console.WriteLine("Telefono: " + usuario.Telefono);
                Console.WriteLine("Celular: " + usuario.Celular);
                Console.WriteLine("FechaNacimiento: " + usuario.FechaNacimiento);
                Console.WriteLine("Curp: " + usuario.Curp);
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
          
            ServiceReference4.UsuarioClient objusuario = new ServiceReference4.UsuarioClient();

            ML.Usuario usuario = new ML.Usuario();
            usuario.Direccion = new ML.Direccion();
            usuario.Direccion.Colonia = new ML.Colonia();


            //UserName
            Console.WriteLine("Ingresa el un User Name");
            usuario.UserName = Console.ReadLine();
            //Nombre
            Console.WriteLine("Ingresa el nombre del nuevo usuario");
            usuario.Nombre = Console.ReadLine();
            //Apaterno
            Console.WriteLine("Ingresa el apellido paterno");
            usuario.ApellidoPaterno = Console.ReadLine();
            //Amaterno
            Console.WriteLine("En caso de tener, ingresa el apellido materno");
            usuario.ApellidoMaterno = Console.ReadLine();
            //Email
            Console.WriteLine("ingresa el Email");
            usuario.Email = Console.ReadLine();
            //Sexo
            Console.WriteLine("ingresa el Sexo H-M");
            usuario.Sexo = Console.ReadLine();
            //Telefono
            Console.WriteLine("ingresa el telefono");
            usuario.Telefono = Console.ReadLine();
            //celular
            Console.WriteLine("ingresa el telefono celuar");
            usuario.Celular = Console.ReadLine();
            //FNacimiento
            Console.WriteLine("ingresa la fecha de nacimiento en formato dd-mm-yyyy");
            usuario.FechaNacimiento = Console.ReadLine();
            //curp
            Console.WriteLine("ingresa el CURP");
            usuario.Curp = Console.ReadLine();

            Console.WriteLine("Calle");
            usuario.Direccion.Calle = Console.ReadLine();

            Console.WriteLine("Numero Interior");
            usuario.Direccion.NumeroInterior = Console.ReadLine();

            Console.WriteLine("Numero Exterior");
            usuario.Direccion.NumeroExterior = Console.ReadLine();

            Console.WriteLine("IdColonia");
            usuario.Direccion.Colonia.IdColonia = int.Parse(Console.ReadLine());

            Console.WriteLine("Password");
            usuario.Password = Console.ReadLine();

            //ML.Result result = BL.Usuario.AddEF(usuario);
            var result = objusuario.Add(usuario);

            if (result.Correct)
            {
                Console.WriteLine("El usuario fue registrado exitosamente");
            }
            else
            {
                Console.WriteLine("No se pudo realizar el registro. Error: " + result.ErrorMessage);
            }
        }
        public static void DeleteEF()
        {
            ServiceReference4.UsuarioClient objusuario = new ServiceReference4.UsuarioClient();

            ML.Usuario usuario = new ML.Usuario();

            //Id
            Console.WriteLine("Ingrese el ID del usuario que desea eliminar");
            usuario.IdUsuario = int.Parse(Console.ReadLine());


            //ML.Result result = BL.Usuario.DeleteEF(usuario);
            var result = objusuario.Delete(usuario);

            if (result.Correct)
            {
                Console.WriteLine("Se ha dado de bajo al usuario");
            }
            else
            {
                Console.WriteLine("El usuario no se ha podido eliniar. Error: " + result.ErrorMessage);
            }
        }
        public static void UpdateEF()
        {
            ServiceReference4.UsuarioClient objusuario = new ServiceReference4.UsuarioClient();

            ML.Usuario usuario = new ML.Usuario();
            usuario.Direccion = new ML.Direccion();
            usuario.Direccion.Colonia = new ML.Colonia();

            //ID
            Console.WriteLine("Ingresa el ID del usuario");
            usuario.IdUsuario = int.Parse(Console.ReadLine());
            //User Name
            Console.WriteLine("Ingresa el  nuevo User Name");
            usuario.UserName = Console.ReadLine();
            //Nombre
            Console.WriteLine("Ingresa el nuevo nombre del usuario");
            usuario.Nombre = Console.ReadLine();
            //APaterno
            Console.WriteLine("Ingresa el nuevo apellido paterno del usuario");
            usuario.ApellidoPaterno = Console.ReadLine();
            //AMaterno
            Console.WriteLine("Ingresa el apellido materno del usuario");
            usuario.ApellidoMaterno = Console.ReadLine();
            //Email
            Console.WriteLine("Ingresa el nuevo email del usuario");
            usuario.Email = Console.ReadLine();
            //Sexo
            Console.WriteLine("Ingresa el nuevo sexo del usuario H-M");
            usuario.Sexo = Console.ReadLine();
            //Telefono
            Console.WriteLine("Ingresa el nuevo telefono del usuario");
            usuario.Telefono = Console.ReadLine();
            //Celular
            Console.WriteLine("Ingresa el nuevo celular del usuario");
            usuario.Celular = Console.ReadLine();
            //Fecha Nacimiento
            Console.WriteLine("Modifica la fecha de nacimiento del usuario");
            usuario.FechaNacimiento = Console.ReadLine();
            //Curp
            Console.WriteLine("Modifica el curp del usuario");
            usuario.Curp = Console.ReadLine();

            Console.WriteLine("Calle");
            usuario.Direccion.Calle = Console.ReadLine();

            Console.WriteLine("Numero Interior");
            usuario.Direccion.NumeroInterior = Console.ReadLine();

            Console.WriteLine("Numero Exterior");
            usuario.Direccion.NumeroExterior = Console.ReadLine();

            Console.WriteLine("IdColonia");
            usuario.Direccion.Colonia.IdColonia = int.Parse(Console.ReadLine());

            Console.WriteLine("Password");
            usuario.Password = Console.ReadLine();

            var result = objusuario.Delete(usuario);
            //ML.Result result = BL.Usuario.UpdateEF(usuario);

            if (result.Correct)
            {
                Console.WriteLine("El usuario fue actualizado correctamente");
            }
            else
            {
                Console.WriteLine("El usuario no fue actualizado. Error: " + result.ErrorMessage);
            }
        }
        public static void GetByIdEF()
        {
            ServiceReference4.UsuarioClient objusuario = new ServiceReference4.UsuarioClient();

            Console.WriteLine("Ingrese el ID del usuario");
            var result = objusuario.GetById(int.Parse(Console.ReadLine()));
            //ML.Result result = BL.Usuario.GetbyIdEF(int.Parse(Console.ReadLine()));


            if (result.Correct)
            {

                //unboxing 
                ML.Usuario usuario = ((ML.Usuario)result.Object);

                Console.WriteLine("IdUsuario: " + usuario.IdUsuario);
                Console.WriteLine("Nombre de usuario: " + usuario.UserName);
                Console.WriteLine("Nombre: " + usuario.Nombre);
                Console.WriteLine("Apellido Paterno: " + usuario.ApellidoPaterno);
                Console.WriteLine("Apellido Materno: " + usuario.ApellidoMaterno);
                Console.WriteLine("Email: " + usuario.Email);
                Console.WriteLine("Sexo: " + usuario.Sexo);
                Console.WriteLine("Telefono: " + usuario.Telefono);
                Console.WriteLine("Celular: " + usuario.Celular);
                Console.WriteLine("FechaNacimiento: " + usuario.FechaNacimiento);
                Console.WriteLine("Curp: " + usuario.Curp);
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
            ServiceReference4.UsuarioClient objusuario = new ServiceReference4.UsuarioClient();

            //ML.Result result = BL.Usuario.GetAllEF();
            var result = objusuario.GetAll();

            if (result.Correct)
            {
                foreach (ML.Usuario usuario in result.Objects)
                {
                    Console.WriteLine("IdMateria: " + usuario.IdUsuario);
                    Console.WriteLine("Nombre de usuario: " + usuario.UserName);
                    Console.WriteLine("Nombre: " + usuario.Nombre);
                    Console.WriteLine("Apellido Paterno: " + usuario.ApellidoPaterno);
                    Console.WriteLine("Apellido Materno: " + usuario.ApellidoMaterno);
                    Console.WriteLine("Email: " + usuario.Email);
                    Console.WriteLine("Sexo: " + usuario.Sexo);
                    Console.WriteLine("Telefono: " + usuario.Telefono);
                    Console.WriteLine("Celular: " + usuario.Celular);
                    Console.WriteLine("FechaNacimiento: " + usuario.FechaNacimiento);
                    Console.WriteLine("Curp: " + usuario.Curp);
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
            ML.Usuario usuario = new ML.Usuario();


            //UserName
            Console.WriteLine("Ingresa el un User Name");
            usuario.UserName = Console.ReadLine();
            //Nombre
            Console.WriteLine("Ingresa el nombre del nuevo usuario");
            usuario.Nombre = Console.ReadLine();
            //Apaterno
            Console.WriteLine("Ingresa el apellido paterno");
            usuario.ApellidoPaterno = Console.ReadLine();
            //Amaterno
            Console.WriteLine("En caso de tener, ingresa el apellido materno");
            usuario.ApellidoMaterno = Console.ReadLine();
            //Email
            Console.WriteLine("ingresa el Email");
            usuario.Email = Console.ReadLine();
            //Sexo
            Console.WriteLine("ingresa el Sexo H-M");
            usuario.Sexo = Console.ReadLine();
            //Telefono
            Console.WriteLine("ingresa el telefono");
            usuario.Telefono = Console.ReadLine();
            //celular
            Console.WriteLine("ingresa el telefono celuar");
            usuario.Celular = Console.ReadLine();
            //FNacimiento
            Console.WriteLine("ingresa la fecha de nacimiento en formato dd-mm-yyyy");
            usuario.FechaNacimiento = Console.ReadLine();
            //curp
            Console.WriteLine("ingresa el CURP");
            usuario.Curp = Console.ReadLine();

            ML.Result result = BL.Usuario.AddLINQ(usuario);

            if (result.Correct)
            {
                Console.WriteLine("El usuario fue registrado exitosamente");
            }
            else
            {
                Console.WriteLine("No se pudo realizar el registro. Error: " + result.ErrorMessage);
            }
        }
        public static void GetAllLINQ()
        {
            ML.Result result = BL.Usuario.GetAllLINQ();

            if (result.Correct)
            {
                foreach (ML.Usuario usuario in result.Objects)
                {
                    Console.WriteLine("IdMateria: " + usuario.IdUsuario);
                    Console.WriteLine("Nombre de usuario: " + usuario.UserName);
                    Console.WriteLine("Nombre: " + usuario.Nombre);
                    Console.WriteLine("Apellido Paterno: " + usuario.ApellidoPaterno);
                    Console.WriteLine("Apellido Materno: " + usuario.ApellidoMaterno);
                    Console.WriteLine("Email: " + usuario.Email);
                    Console.WriteLine("Sexo: " + usuario.Sexo);
                    Console.WriteLine("Telefono: " + usuario.Telefono);
                    Console.WriteLine("Celular: " + usuario.Celular);
                    Console.WriteLine("FechaNacimiento: " + usuario.FechaNacimiento);
                    Console.WriteLine("Curp: " + usuario.Curp);
                    Console.WriteLine("--------------------------------");
                    Console.WriteLine();
                }
            }
            else
            {
                Console.WriteLine("Ocurrió un error al consultar la información" + result.ErrorMessage);
            }
        }
        public static void UpdateLINQ()
        {
            ML.Usuario usuario = new ML.Usuario();

            //ID
            Console.WriteLine("Ingresa el ID del usuario");
            usuario.IdUsuario = int.Parse(Console.ReadLine());
            //User Name
            Console.WriteLine("Ingresa el  nuevo User Name");
            usuario.UserName = Console.ReadLine();
            //Nombre
            Console.WriteLine("Ingresa el nuevo nombre del usuario");
            usuario.Nombre = Console.ReadLine();
            //APaterno
            Console.WriteLine("Ingresa el nuevo apellido paterno del usuario");
            usuario.ApellidoPaterno = Console.ReadLine();
            //AMaterno
            Console.WriteLine("Ingresa el apellido materno del usuario");
            usuario.ApellidoMaterno = Console.ReadLine();
            //Email
            Console.WriteLine("Ingresa el nuevo email del usuario");
            usuario.Email = Console.ReadLine();
            //Sexo
            Console.WriteLine("Ingresa el nuevo sexo del usuario H-M");
            usuario.Sexo = Console.ReadLine();
            //Telefono
            Console.WriteLine("Ingresa el nuevo telefono del usuario");
            usuario.Telefono = Console.ReadLine();
            //Celular
            Console.WriteLine("Ingresa el nuevo celular del usuario");
            usuario.Celular = Console.ReadLine();
            //Fecha Nacimiento
            Console.WriteLine("Modifica la fecha de nacimiento del usuario");
            usuario.FechaNacimiento = Console.ReadLine();
            //Curp
            Console.WriteLine("Modifica el curp del usuario");
            usuario.Curp = Console.ReadLine();

            ML.Result result = BL.Usuario.UpdateLINQ(usuario);

            if (result.Correct)
            {
                Console.WriteLine("El usuario fue actualizado correctamente");
            }
            else
            {
                Console.WriteLine("El usuario no fue actualizado. Error: " + result.ErrorMessage);
            }
        }
        public static void DeleteLINQ()
        {
            ML.Usuario usuario = new ML.Usuario();

            //Id
            Console.WriteLine("Ingrese el ID del usuario que desea eliminar");
            usuario.IdUsuario = int.Parse(Console.ReadLine());


            ML.Result result = BL.Usuario.DeleteLINQ(usuario);

            if (result.Correct)
            {
                Console.WriteLine("Se ha dado de bajo al usuario");
            }
            else
            {
                Console.WriteLine("El usuario no se ha podido eliniar. Error: " + result.ErrorMessage);
            }
        }
        public static void GetByIdLINQ()
        {

            Console.WriteLine("Ingrese el ID del usuario");
            ML.Result result = BL.Usuario.GetByIdLINQ(int.Parse(Console.ReadLine()));


            if (result.Correct)
            {

                //unboxing 
                ML.Usuario usuario = ((ML.Usuario)result.Object);

                Console.WriteLine("IdUsuario: " + usuario.IdUsuario);
                Console.WriteLine("Nombre de usuario: " + usuario.UserName);
                Console.WriteLine("Nombre: " + usuario.Nombre);
                Console.WriteLine("Apellido Paterno: " + usuario.ApellidoPaterno);
                Console.WriteLine("Apellido Materno: " + usuario.ApellidoMaterno);
                Console.WriteLine("Email: " + usuario.Email);
                Console.WriteLine("Sexo: " + usuario.Sexo);
                Console.WriteLine("Telefono: " + usuario.Telefono);
                Console.WriteLine("Celular: " + usuario.Celular);
                Console.WriteLine("FechaNacimiento: " + usuario.FechaNacimiento);
                Console.WriteLine("Curp: " + usuario.Curp);
                Console.WriteLine("--------------------------------");
                Console.WriteLine();

            }
            else
            {
                Console.WriteLine("Ocurrió un error al consultar la información" + result.ErrorMessage);
            }
        }
    }
}
