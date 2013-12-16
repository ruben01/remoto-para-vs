using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Twilio.TwiML;
using Twilio.TwiML.Mvc;

namespace smsGitVsSln.Controllers
{
    public class callController : Controller
    {
        //
        // GET: /call/

        public ActionResult Index()
        {

            //prueba

            var response = new TwilioResponse();
            response.Say("Gracias Por llamar a Sigeret. Una empresa al servicio de sus clientes");

            return new TwiMLResult(response);

            //end
            
        }

    }
}
