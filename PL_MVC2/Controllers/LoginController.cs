using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net.Http;
using System.Configuration;

namespace PL_MVC2.Controllers
{
    public class LoginController : Controller
    {

        [HttpGet]
        public ActionResult login()
         {
            ML.Usuario login = new ML.Usuario();
            return View(login);
        }
        [HttpPost]
        public ActionResult login(string userName, string password)
         {
            ML.Usuario usuario = new ML.Usuario();
            usuario.UserName = userName;
            usuario.Password = password;
            using (var client = new HttpClient())
                    {
                        client.BaseAddress = new Uri("http://localhost:20048/api/");

                        var responseTask = client.PostAsJsonAsync("Usuario/Authenticate/", usuario);
                        responseTask.Wait();

                        var resultAPI = responseTask.Result;
                        if (resultAPI.IsSuccessStatusCode)
                        {
                           var readTask = resultAPI.Content.ReadAsAsync<ML.Result>();
                           readTask.Wait();
                            usuario = Newtonsoft.Json.JsonConvert.DeserializeObject<ML.Usuario>(readTask.Result.Object.ToString());
                           if(password == usuario.Password)
                            {
                             return RedirectToAction("Index", "Home");
                    
                             }
                             else
                             {
                              return RedirectToAction("Login");
                             } 
                        }
                        else
                        {
                            ViewBag.Message = "Ocurrio un error al inicar sesión";
                        }
                    }
            return PartialView("Modal");
        }
        [HttpGet]
        public ActionResult ValidarUser()
        {
            ML.Usuario usuario = new ML.Usuario();

            return View();
        }
        [HttpPost]
        public ActionResult ValidarUser(ML.Usuario usuario)
        {
            string userName = usuario.UserName;
            string pathHTML = "C:/Users/digis/Documents/Leonardo Escogido Bravo/LEscogidoAseguradora/PL_MVC2/Email.html";
            string activateURL = "http://localhost:24587/Login/CambiarPassword?UserName=" + usuario.UserName;

            ML.Result result = BL.Usuario.GetByUserName(userName);
            usuario = ((ML.Usuario)result.Object);
            string Nombre = usuario.NombreCompleto;
            string emailTo = usuario.Email;

            if(result.Correct)
            {
                return EnviarEmail(pathHTML, userName, Nombre, activateURL, emailTo);
            }
            else
            {
                ViewBag.Message = "Ocurrio un error, comprueba que el User Name sea correcto " + result.ErrorMessage;
            }
            return PartialView("Modal");
        }
        private ActionResult EnviarEmail(string pathHTML, string UserName, string Nombre, string activateURL, string emailTo)
        {

            ML.Result result = new ML.Result();

            try
            {

                result = BL.Email.PopulateBody(pathHTML, UserName, "", Nombre, activateURL);

                ML.Email emailModel = new ML.Email();

                emailModel.From = ConfigurationManager.AppSettings["From"];// "test@digis01.com";//web.config
                emailModel.FromDisplayName = ConfigurationManager.AppSettings["FromDisplayName"];// "Control de Asistencia Escolar";//web.config
                emailModel.Host = ConfigurationManager.AppSettings["Host"]; // "digis01.com";//web.config               
                emailModel.User = ConfigurationManager.AppSettings["User"]; // "test@digis01.com";//web.config
                emailModel.Password = ConfigurationManager.AppSettings["Password"]; // "Welcome01$$$#";//web.config
                emailModel.Port = int.Parse(ConfigurationManager.AppSettings["Port"]); //465;//web.config
                emailModel.Body = result.Object.ToString();
                emailModel.Subject = "Recuperación de contraseña";//web.config
                emailModel.To = emailTo;//Recuperar el correo de la BD

                result = BL.Email.SendEmail(emailModel);

                if (result.Correct)
                {
                    ViewBag.Message = "Se ha enviado un E-mail a la cuenta: ";
                }
                else
                {
                    ViewBag.Message = "No se ha podido realizar la petición: " + result.ErrorMessage;
                }
               

            }
            catch (Exception ex)
            {
                result.Ex = ex;
                result.Correct = false;
                result.ErrorMessage = ex.Message;
            }
         return PartialView("Modal");

        }
        [HttpGet]
        public ActionResult CambiarPassword()
        {
            ML.Usuario usuario = new ML.Usuario();
            string UserName = "";
            if(Request.Params["UserName"] != null)
            {
                UserName = Request.Params["UserName"];
            }
            usuario.UserName = UserName;
            return View(usuario);
        }

        [HttpPost]
        public ActionResult CambiarPassword(ML.Usuario usuario)
        {
            ML.Result result = BL.Usuario.UpdatePassword(usuario);

            if (result.Correct)
            {
                ViewBag.Message = "Se ha actualizado la contraseña";
            }
            else
            {
                ViewBag.Message = "No se ha podido actualizar la contraseña" + result.ErrorMessage;
            }
            return PartialView("Modal");
        }
	}
}