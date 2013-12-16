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

        public ActionResult Index()
        {

            string AccountSid = "AAC7329769855ac2319f51129e29352294c";
            string AuthToken = "30b5abfcedeec6ec14586780e880fc88";

            // instantiate a new Twilio Rest Client
            var client = new TwilioRestClient(AccountSid, AuthToken);

            // make an associative array of people we know, indexed by phone number
            var people = new Dictionary<string, string>() {
                {"+18294072985","viva"},
                {"+18099282276","Tricom"}
       
            };

            // iterate over all our friends
            foreach (var person in people)
            {
                /*
                // Send a new outgoing SMS by POSTing to the Messages resource 
                client.SendMessage(
                    "2766011354", // From number, must be an SMS-enabled Twilio number
                    person.Key,     // To number, if using Sandbox see note above
                    // message content
                    string.Format("Hey {0}, Monkey Party at 6PM. Bring Bananas!", person.Value)
                );

              */

                client.SendSmsMessage("(276) 601-1354","(809) 928-2276","Esto es una prueba");
                client.SendSmsMessage("(276) 601-1354", "(829) 407-2985", "Esto es una prueba");
                client.SendSmsMessage("(276) 601-1354", "(809) 890-6168", "Esto es una prueba");

            }

            return View();

        }

       
    }

}