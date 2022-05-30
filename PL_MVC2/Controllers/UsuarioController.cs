using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net.Http;
using System.Xml.Serialization;
using System.Net;
using System.Text;


namespace PL_MVC.Controllers
{
    public class UsuarioController : Controller
    {

        //
        // GET: /Usuario/

        public ActionResult GetAll()
        {
            ML.Usuario resultusuario = new ML.Usuario();
            resultusuario.Usuarios = new List<Object>();

            const SecurityProtocolType tls13 = (SecurityProtocolType)12288;
            ServicePointManager.SecurityProtocol = tls13 | SecurityProtocolType.Tls12;

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:20048/api/");

                var responseTask = client.GetAsync("Usuario/GetAll ");
                responseTask.Wait();

                var result = responseTask.Result;

                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<ML.Result>();
                    readTask.Wait();

                    foreach (var resultItem in readTask.Result.Objects)
                    {
                        ML.Usuario resultItemList = Newtonsoft.Json.JsonConvert.DeserializeObject<ML.Usuario>(resultItem.ToString());
                        resultusuario.Usuarios.Add(resultItemList);
                    }
                }
            }
            return View(resultusuario);
        }

        public byte[] ConvertToBytes(HttpPostedFileBase Imagen)
        {
            byte[] data = null;
            System.IO.BinaryReader reader = new System.IO.BinaryReader(Imagen.InputStream);
            data = reader.ReadBytes((int)Imagen.ContentLength);

            return data;
        }

        [HttpGet]
        public ActionResult Form(int? IdUsuario)
        {
            ML.Usuario usuario = new ML.Usuario();
            ML.Result resultPaises = BL.Pais.GetAll();
            usuario.Direccion = new ML.Direccion();
            usuario.Direccion.Colonia = new ML.Colonia();
            usuario.Direccion.Colonia.Municipio = new ML.Municipio();
            usuario.Direccion.Colonia.Municipio.Estado = new ML.Estado();
            usuario.Direccion.Colonia.Municipio.Estado.Pais = new ML.Pais();

            usuario.Direccion.Colonia.Municipio.Estado.Pais.Paises = resultPaises.Objects;

            if (IdUsuario == null) //Add
            {
                return View(usuario);
            }
            else //Update
            {
                ML.Result result = new ML.Result();

                using (var client = new HttpClient())
                    try
                    {
                        client.BaseAddress = new Uri("http://localhost:20048/api/");
                        var responseTask = client.GetAsync("Usuario/GetById/" + IdUsuario);
                        responseTask.Wait();

                        var resultAPI = responseTask.Result;
                        if (resultAPI.IsSuccessStatusCode)
                        {
                            var readTask = resultAPI.Content.ReadAsAsync<ML.Result>();
                            readTask.Wait();

                            ML.Usuario resultItemList = new ML.Usuario();
                            resultItemList = Newtonsoft.Json.JsonConvert.DeserializeObject<ML.Usuario>(readTask.Result.Object.ToString());
                            result.Object = resultItemList;

                            usuario.Direccion = new ML.Direccion();
                            usuario.Direccion.Colonia = new ML.Colonia();
                            usuario.Direccion.Colonia.Municipio = new ML.Municipio();
                            usuario.Direccion.Colonia.Municipio.Estado = new ML.Estado();
                            usuario.Direccion.Colonia.Municipio.Estado.Pais = new ML.Pais();

                            usuario = ((ML.Usuario)result.Object);

                            ML.Result resultEstados = BL.Estado.GetByIdPais(usuario.Direccion.Colonia.Municipio.Estado.Pais.IdPais);           
                            ML.Result resultMunicipios = BL.Municipio.MunicipioGetByIdEstado(usuario.Direccion.Colonia.Municipio.Estado.IdEstado);
                            ML.Result resultColonias = BL.Colonia.ColoniaGetByIdMunicipio(usuario.Direccion.Colonia.Municipio.IdMunicipio);

                            

                            
                            usuario.Usuarios = resultPaises.Objects;
                            usuario.Direccion.Colonia.Municipio.Estado.Pais.Paises = resultPaises.Objects;
                            usuario.Direccion.Colonia.Municipio.Estado.Estados = resultEstados.Objects;
                            usuario.Direccion.Colonia.Municipio.Municipios = resultMunicipios.Objects;
                            usuario.Direccion.Colonia.Colonias = resultColonias.Objects;

                            return View(usuario);
                        }
                        else
                        {
                            result.Correct = false;
                            result.ErrorMessage = "No existen registros en la tabla Departamento";
                        }
                    }

                    catch (Exception ex)
                    {
                        result.Correct = false;
                        result.ErrorMessage = ex.Message;
                    }

                return View();
            }
        }
        [HttpPost]
        public ActionResult Form(ML.Usuario usuario)
        {
            ML.Result result = new ML.Result();

            HttpPostedFileBase file = Request.Files["ImagenData"];
            if (file.ContentLength > 0)
            {
                usuario.Imagen = ConvertToBytes(file);
            }
                if (usuario.IdUsuario == 0)
                {
                    using (var client = new HttpClient())
                    {
                        client.BaseAddress = new Uri("http://localhost:20048/api/");

                        //HTTP POST
                        var postTask = client.PostAsJsonAsync<ML.Usuario>("usuario/Add", usuario);
                        postTask.Wait();

                        var resultUsuario = postTask.Result;
                        if (resultUsuario.IsSuccessStatusCode)
                        {
                            ViewBag.Mensaje = "El usuario se registro correctamente";
                        }
                        else
                        {
                            ViewBag.Mensaje = "El usuario no se ha registrado correctamente" + result.ErrorMessage;
                        }
                    }

                }
                else
                {
                    using (var client = new HttpClient())
                    {
                        client.BaseAddress = new Uri("http://localhost:20048/api/");

                        var postTask = client.PostAsJsonAsync<ML.Usuario>("Usuario/Update/" + usuario.IdUsuario, usuario);
                        postTask.Wait();

                        var resultUsuario = postTask.Result;
                        if (resultUsuario.IsSuccessStatusCode)
                        {
                            ViewBag.Mensaje = "El usuario se ha actualizado correctamente";
                        }
                        else
                        {
                            ViewBag.Mensaje = "El usuario no se ha actualizado correctamente" + result.ErrorMessage;
                        }
                    }
                }
            
            return PartialView("Modal");
        }
        [HttpGet]
        public ActionResult Delete(ML.Usuario usuario)
        {

            ML.Result resultUsuario = new ML.Result();
            int IdUsuario = usuario.IdUsuario;
            usuario.IdUsuario = IdUsuario;

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:20048/api/");

                //HTTP POST
                var postTask = client.DeleteAsync("Usuario/Delete/" + IdUsuario);
                postTask.Wait();

                var result = postTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    ViewBag.Message = "El usuario ha sido eliminada";
                }
                else
                {
                    ViewBag.Message = "El usuario no pudo ser eliminado" + resultUsuario.ErrorMessage;
                }
            }

            return PartialView("Modal");
 
        }

        public ActionResult UpdateStatus(int IdUsuario)
        {
            ML.Usuario usuario = new ML.Usuario();
            ML.Result result = BL.Usuario.GetbyIdEF(IdUsuario);
            if (result.Correct)
            {
                usuario = ((ML.Usuario)result.Object);
                usuario.Status = usuario.Status ? false : true;
                ML.Result ResultUpdate = BL.Usuario.UpdateEF(usuario);
                ViewBag.Message = "El status ha sido cambiado";
            }
            else
            {
                ViewBag.Message = "El status no se pudo actualizar" + result.ErrorMessage;
            }

            return PartialView("Modal");
        }
        public FileResult CrearXML(int IdUsuario)
        {
            ML.Usuario usuario = new ML.Usuario();
            ML.Result result = BL.Usuario.GetbyIdEF(IdUsuario);
            ML.Usuario user = ((ML.Usuario)result.Object);


            XmlSerializer serializador = new XmlSerializer(usuario.GetType());
            var XmlString = usuario.ToXml;
            var file = usuario.Nombre + ".xml";
            byte[] contenido = System.Text.Encoding.ASCII.GetBytes(XmlString);

            return File(contenido, "application/xml", file);
        }
        public JsonResult GetEstado(int IdPais)
        {
            var result = BL.Estado.GetByIdPais(IdPais);

            return Json(result.Objects, JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetMunicipio(int IdEstado)
        {
            var result = BL.Municipio.MunicipioGetByIdEstado(IdEstado);

            return Json(result.Objects, JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetColonia(int IdMunicipio)
        {
            var result = BL.Colonia.ColoniaGetByIdMunicipio(IdMunicipio);

            return Json(result.Objects, JsonRequestBehavior.AllowGet);
        }
    }
}
