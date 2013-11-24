using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Providers.Entities;
using ActionMailer.Net.Mvc;
using Server.Models;

namespace Server.Controllers
{
    public class EmailController : MailerBase
    {
        public EmailResult SendEmail(User model)
        {

            To.Add(model.Membership.Email);
            From = "no-reply@mycoolsite.com";
            Subject = "MyCoolSite Account Verification";
            return Email("SendEmail.txt",model);
        }
    }
}
