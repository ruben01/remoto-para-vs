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
            body = body.ToLower();
            string solicitud="";
            string respuesta;
            //si la longitud del mensaje enviado es mayor a 2 entonces procedemos a sacar una subcadena para verificar si es una solicitud
            if (body.Length > 2)
            {
                solicitud = body.Substring(0, 2);
            }

            if (solicitud == "**")
            {
                respuesta = ProcesarSolicitud(body);
            }
            else
            {

                switch (body)
                {
                    case "ayuda":
                        respuesta = "1 Nueva Solicitud(ayuda)\n2 Equipos(ayuda)\n3 Formato Fecha\n4 Fomato Hora";
                        break;

                    case "1":

                        respuesta = "Formato Solicitud:\n *fecha*horaInicio*horaFin*CodigoEquipo*cantidad*CodigoEquipo2*cantidad";
                        break;
                    case "2":

                        respuesta = "Codigos Equipos";//Funcion para devolver todos lo equipos disponibles por modelos
                        break;
                    case "3":

                        respuesta = "Formato Fecha\nDia/Mes/año \nEjemplo 24/12/1999";
                        break;
                    case "4":

                        respuesta = "Formato Hora\n24H Ejemplo \n07:00  \n20:00 \nhora fin mayor a la hora inicio";
                        break;
                    default:
                        respuesta = "No se Reconoce la Instruccion";
                        break;

                }
            }

            var twilio = new TwilioRestClient("AC7329769855ac2319f51129e29352294c","30b5abfcedeec6ec14586780e880fc88");
            var sms = twilio.SendSmsMessage(sender,From,respuesta);

            return Content(sms.Sid);
            
        }

        public ActionResult smsHelloMonkey()
        {
            return RedirectToAction("Index", new {  reciver = "5088863180", body = "probando response" });
           
            
        }

        public string ProcesarSolicitud(string solicitud)
        {
            try
            {
                string fecha;
                string horaInicio;
                string horaFin;
                string equiposStr;
               
                if (solicitud.Length > 23)
                {

                    fecha = solicitud.Substring(2, 10);
                    horaInicio = solicitud.Substring(10, 5);
                    horaFin = solicitud.Substring(15, 5);
                    equiposStr = solicitud.Substring(20, solicitud.Length - 20);
                }
                else
                {

                    return "Error al procesar solicitud verifique el formato";
                }

                List<Tuple<String, String>> equipos = new List<Tuple<string, string>>();
                /*
                int contador = 0;

                for (int i = 2; i < solicitud.Length; i++)
                {
                    if (contador == 0)
                    {
                        if (solicitud[i].ToString() == "*")
                        {
                            fecha = solicitud.Substring(2, i);
                            contador++;
                        }
                    }
                }*/
                return fecha + "|" + horaInicio + "|" + horaFin + "|" + equiposStr;
            }catch(Exception e){

                return "Error procesando su solicitud Revise el formato";
            }
               
        }

       
    }

}