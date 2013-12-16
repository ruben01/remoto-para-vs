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

        [HttpGet]
        public ActionResult Index()
        {

                return View();

        }
        [HttpPost]
        public ActionResult Index( string sender,string reciver,string body)
        {

            var twilio = new TwilioRestClient("AC7329769855ac2319f51129e29352294c","30b5abfcedeec6ec14586780e880fc88");
            var sms = twilio.SendSmsMessage(sender,reciver,body);

            return Content(sms.Sid);
            
        }

       
    }

}