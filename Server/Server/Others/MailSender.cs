using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;

namespace Server.Others
{
    public class MailSender
    {

        public static void sendMail(string subject,string email,string text )
        {
         
            var smtp = new SmtpClient("smtp.mail.ru", 587)// айпи нашего SMTP клиента
   
            {
                DeliveryMethod = SmtpDeliveryMethod.Network,
                Credentials = new NetworkCredential(
                    "krasnovandr@mail.ru",
                    "3323876may1993")
            };
  
            var message = new MailMessage(); // формируем письмо
            //message.ReplyToList.Add("admin@test.com");
            message.From = new MailAddress("krasnovandr@mail.ru"); // отправитель
            message.To.Add(new MailAddress(email)); // адрес регистрирующегося
            message.IsBodyHtml = true; // тело письма - html
            message.Subject = subject; // заголовок письма
            message.Body = text; // текст письма

            try
            {
                  smtp.Send(message); //отправляем письмо
            }
            catch (Exception ex)
            {
               
            }
        }
    }
}