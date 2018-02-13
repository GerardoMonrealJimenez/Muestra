using AssistanceOnlineDAL;
using AssistanceOnlineDAL.Enums;
using AssistanceOnlineUtilities.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace AssistanceOnlineUtilities
{
    public static class UtilitesEmail
    {
        /// <summary>
        /// Manda el email de confirmación de cuenta al usuario
        /// </summary>
        /// <param name="name">Nombre</param>
        /// <param name="email">Email</param>
        /// <param name="url">Url</param>
        /// <returns></returns>
        public static async Task<bool> sendEmailVerificationAsync(string name, string email, string url)
        {
            var response = AssistanceOnlineQueries.getHtmlTemplateEmailConfirmation();

            string body = response.Response.Replace("{NOMBRE}", name)
                                                                     .Replace("{CORREO}", email)
                                                                     .Replace("[REDIRECT]", url);
            List<string> to = new List<string>();
            to.Add(email);



            return await sendEmail("Confirmación de cuenta", body, HtmlBody.isHtml, to);
        }

        /// <summary>
        /// Manda email de confirmación de reset password
        /// </summary>
        /// <param name="name">Nombre</param>
        /// <param name="email">Email</param>
        /// <param name="url">Url</param>
        /// <returns></returns>
        public static async Task<bool> sendEmailResetPasswordAsync(string name, string email, string url)
        {
            var response = AssistanceOnlineQueries.getHtmlTemplateResetPassword();

            string body = response.Response.Replace("{NOMBRE}", name)
                                                         .Replace("{CORREO}", email)
                                                         .Replace("[REDIRECT]", url);
            List<string> to = new List<string>();
            to.Add(email);



            return await sendEmail("Confirmación de cuenta", body, HtmlBody.isHtml, to);
        }

        /// <summary>
        /// Envia Email
        /// </summary>
        /// <param name="subject">Titulo</param>
        /// <param name="body">Cuerpo</param>
        /// <param name="isHtml">Es html</param>
        /// <param name="to">Para</param>
        /// <returns></returns>
        public static async Task<bool> sendEmail(string subject, string body, HtmlBody isHtml, List<string> to)
        {
            try
            {
                return await Task.Run(() =>
                {
                    MailMessage mail = new MailMessage();
                    SmtpClient googleSmpt = new SmtpClient();

                    var response = AssistanceOnlineQueries.selectKey(TypesKeys.MainEmail);

                    mail.From = new MailAddress(response.Response.value);

                    foreach (var email in to)
                    {
                        mail.To.Add(new MailAddress(email));
                    }

                    mail.Subject = subject;
                    mail.Body = body;

                    switch (isHtml)
                    {
                        case HtmlBody.isHtml:
                            mail.IsBodyHtml = true;
                            break;
                        case HtmlBody.isNotHtml:
                            mail.IsBodyHtml = false;
                            break;
                        default:
                            break;
                    }

                    var responseHost = AssistanceOnlineQueries.selectKey(TypesKeys.Hostemail);

                    var responseCredentialsUser = AssistanceOnlineQueries.selectKey(TypesKeys.MainEmail);

                    var responseCredentialsPassword = AssistanceOnlineQueries.selectKey(TypesKeys.MainEmailPassword);

                    googleSmpt.Host = responseHost.Response.value;
                    googleSmpt.Port = 587;
                    googleSmpt.Credentials = new NetworkCredential(responseCredentialsUser.Response.value, responseCredentialsPassword.Response.value);
                    googleSmpt.EnableSsl = true;
                    googleSmpt.Send(mail);

                    return Task.FromResult(true);
                });





            }
            catch (Exception ex)
            {

                return await Task.FromResult(false);
            }
        }
    }
}
