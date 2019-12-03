using CommonDate.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Twilio;
using Twilio.Rest.Api.V2010.Account;
using Twilio.Types;
using Twilio.TwiML;
using Twilio.AspNet.Mvc;
using Microsoft.AspNet.Identity;

namespace CommonDate.Controllers
{
    public class SMSController : TwilioController
    {

        ApplicationDbContext context;

        public SMSController()
        {
            context = new ApplicationDbContext();
        }
        public ActionResult SendSMS(User user)
        {


            var accountSid = APIKeys.TwilioaccountSid;
            var authToken = APIKeys.TwilioauthToken;
            TwilioClient.Init(accountSid, authToken);

            var to = new PhoneNumber("+1" + user.PhoneNumber);
            var from = new PhoneNumber("+17736239204");

            var message = MessageResource.Create(
                to: to,
                from: from,
                body: "You not taking your mama out tonight, you got a match!");
            return Content(message.Sid);

            return View();
        }
    }
}