using SendEmailAPI.Models;
using System;
using System.Web.Http;
using System.Web.Http.Description;
using System.Net.Mail;
using System.Configuration;

namespace SendEmailAPI.Controllers.API
{
    public class SendEmailController : ApiController
    {
        [HttpPost]
        [ResponseType(typeof(Email))]
        [Route("api/SendEmail/SendNewEmail")]
        public IHttpActionResult SendNewEmail([FromBody]Email email)
        {
            try
            {
                //string strBody = "<table border= 0 style='font-family: Verdana; color:#444444; font-size:12px; ' width=95% align=center height=20%>" + " <tr bgcolor=#D2EAF2> <td  align=center><h3> System Error Report </h3> <br>" + " <font style='font-size:12px; color:#0000C0'> <b>  The Error is " + errorMsg + " </b></font> <br/> Exception on server IP " + errorTrace + "<br/></td></tr> </table>";

                System.Net.Mail.MailMessage mm = new System.Net.Mail.MailMessage(email.From,email.To);
                MailAddress from = new MailAddress(email.From);
                mm.From = from;

                string[] receptions = email.To.Split(';'); //split list of To by ; -> to send it for list or one person as you wish
                foreach (var to in receptions)
                {
                    mm.To.Add(to);
                }

                mm.Subject = email.Subject;
                mm.Body = email.Body;
                mm.IsBodyHtml = true;

                //Get your SMTP server ip from Web.config file -> so you can change it easily in future no need to deploy any thing to change your IP
                SmtpClient smtp = new SmtpClient(ConfigurationSettings.AppSettings["SMTPIP"].ToString());
                smtp.Send(mm);

                return Json(new Response
                {
                    Code = "200",
                    IsSuccess = true,
                    Result = "Success",
                    Data = "Email has been sent.",
                    Error = null
                });
            }
            catch (Exception ex)
            {
                return Json(new Response
                {
                    Code = "520",
                    IsSuccess = false,
                    Result = "Faild",
                    Data = null,
                    Error = string.Format("=>{0} An Error occured: {1} Message: {2}{3}", DateTime.Now, ex.StackTrace, ex.Message, Environment.NewLine)
                });
            }
        }
    }
}