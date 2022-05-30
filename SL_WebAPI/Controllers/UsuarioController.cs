using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SL_WebAPI.Controllers
{
    public class UsuarioController : ApiController
    {

        [HttpGet]
        [Route("api/Usuario/GetAll")]
        // GET api/usuario
        public IHttpActionResult GetAll()
        {

            ML.Usuario usuario = new ML.Usuario();
            //usuario.Direccion = new ML.Direccion();
            ML.Result result = BL.Usuario.GetAllEF();

            if (result.Correct)
            {
                return Content(HttpStatusCode.OK, result);
            }
            else
            {
                return Content(HttpStatusCode.NotFound, result);
            }
        }
        [HttpGet]
        [Route("api/Usuario/GetById/{IdUsuario}")]
        public IHttpActionResult GetById(int IdUsuario, ML.Usuario usuario)
        {
            ML.Result result = BL.Usuario.GetbyIdEF(IdUsuario);

            if (result.Correct)
            {
                return Content(HttpStatusCode.OK, result);
            }
            else
            {
                return Content(HttpStatusCode.NotFound, result);
            }


        }

        [HttpPost]
        [Route("api/Usuario/Add")]
        public IHttpActionResult Add([FromBody] ML.Usuario usuario)
        {

            ML.Result result = BL.Usuario.AddEF(usuario);

            if (result.Correct)
            {
                return Content(HttpStatusCode.OK, result);
            }
            else
            {
                return Content(HttpStatusCode.NotFound, result);
            }


        }

        [HttpPost]
        [Route("api/Usuario/Update/{IdUsuario}")]
        public IHttpActionResult Put(int IdUsuario,[FromBody] ML.Usuario usuario)
        {
            usuario.IdUsuario = IdUsuario;
            ML.Result result = BL.Usuario.UpdateEF(usuario);

            if (result.Correct)
            {
                return Content(HttpStatusCode.OK, result);
            }
            else
            {
                return Content(HttpStatusCode.NotFound, result);
            }
        }

        [HttpPost]
        [Route("api/Usuario/Delete/{IdUsuario}")]
        public IHttpActionResult Delete(ML.Usuario usuario)
        {

            ML.Result result = BL.Usuario.DeleteEF(usuario);

            if (result.Correct)
            {
                return Content(HttpStatusCode.OK, result);
            }
            else
            {
                return Content(HttpStatusCode.NotFound, result);
            }
        }

        [HttpGet]
        [Route("api/Usuario/Login/{userName}")]
        public IHttpActionResult GetByUserName(string userName)
        {
            
            ML.Result result = BL.Usuario.GetByUserName(userName);

            if (result.Correct)
            {
                return Content(HttpStatusCode.OK, result);
            }
            else
            {
                return Content(HttpStatusCode.NotFound, result);
            }


        }

        [HttpPost]
        [Route("api/Usuario/Authenticate")]
        public IHttpActionResult Authenticate([FromBody]ML.Usuario usuario)
        {
            ML.Usuario usuariologin = new ML.Usuario();
            ML.Result result = BL.Usuario.GetByUserName(usuario.UserName);
            usuariologin = (ML.Usuario)result.Object;   

            if (result.Correct)
            {
               
                if(usuario.UserName == usuariologin.UserName)
                {
                    if (usuario.Password == usuario.Password)
                    {
                        var token = TokenGenerator.GenerateTokenJwt(usuario.UserName);
                        return Ok(result);

                    }
                    else
                    {
                        result.ErrorMessage = "Contraseña incorrecta";
                        return Content(HttpStatusCode.NotFound, result.ErrorMessage);
                    } 
                }
                else
                {
                    result.ErrorMessage = "User Name incorrecto";
                    return Content(HttpStatusCode.NotFound, result.ErrorMessage);
                }
            }
            else
            {
                result.ErrorMessage = "No encontrado";
                return Content(HttpStatusCode.NotFound, result.ErrorMessage);
            }
        }
    }

}
