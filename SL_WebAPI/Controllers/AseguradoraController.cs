using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SL_WebAPI.Controllers
{
    public class AseguradoraController : ApiController
    {
        [HttpGet]
        [Route("api/Aseguradora/GetAll")]
        // GET api/aseguradora
        public IHttpActionResult GetAll()
        {

            ML.Aseguradora aseguradora = new ML.Aseguradora();
            aseguradora.Usuario = new ML.Usuario();
            aseguradora.Nombre = "";
            ML.Result result = BL.Aseguradora.GetAllEF();

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
        [Route("api/Aseguradora/GetById/{IdAseguradora}")]
        public IHttpActionResult GetById(int IdAseguradora)
        {

            ML.Result result = BL.Aseguradora.GetByIdEF(IdAseguradora);

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
        [Route("api/Aseguradora/Add")]
        public IHttpActionResult Post([FromBody] ML.Aseguradora aseguradora)
        {

            ML.Result result = BL.Aseguradora.AddEF(aseguradora);

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
        [Route("api/Aseguradora/Update/{IdAseguradora}")]
        public IHttpActionResult Put(int IdAseguradora, [FromBody] ML.Aseguradora aseguradora)
        {
            aseguradora.IdAseguradora = IdAseguradora;
            ML.Result result = BL.Aseguradora.UpdateEF(aseguradora);

            if (result.Correct)
            {
                return Content(HttpStatusCode.OK, result);
            }
            else
            {
                return Content(HttpStatusCode.NotFound, result);
            }
        }

        [HttpDelete]
        [Route("api/Aseguradora/Delete/{IdAseguradora}")]
        public IHttpActionResult Delete(int IdAseguradora)
        {

            ML.Result result = BL.Aseguradora.DeleteEF(IdAseguradora);

            if (result.Correct)
            {
                return Content(HttpStatusCode.OK, result);
            }
            else
            {
                return Content(HttpStatusCode.NotFound, result);
            }
        }
    }
}
