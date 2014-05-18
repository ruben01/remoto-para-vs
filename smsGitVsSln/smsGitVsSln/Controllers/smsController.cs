using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Twilio;
using Twilio.TwiML.Mvc;

namespace smsGitVsSln.Controllers
{
    public class smsController : Controller
    {
        //
        // GET: /sms/
/*
        [HttpGet]
        public ActionResult Index()
        {

                return View();

        }
 */
       // [HttpPost]
        public ActionResult Index( string body,string From)
        {
            string sender = "2766011354";
            string respuesta;

            switch (body)
            {
                case "ayuda":
                    respuesta = "Hola Te brindaremos Ayuda";
                    break;

                case "AYUDA":
                    respuesta = "HOLA MAYUSCULA";
                    break;

                default:
                    respuesta = "No se Reconoce la Instruccion";
                    break;
                
            }


            var twilio = new TwilioRestClient("AC7329769855ac2319f51129e29352294c","30b5abfcedeec6ec14586780e880fc88");
            var sms = twilio.SendSmsMessage(sender,From,respuesta);

            return Content(sms.Sid);
            
        }

        public ActionResult smsHelloMonkey()
        {
            return RedirectToAction("Index", new {  reciver = "5088863180", body = "probando response" });
           
            
        }

       
    }

}