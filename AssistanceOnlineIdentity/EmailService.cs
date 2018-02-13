using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using AssistanceOnlineUtilities;
using AssistanceOnlineUtilities.Enums;

namespace AssistanceOnlineIdentity
{
    public class EmailService : IIdentityMessageService
    {
        /// <summary>
        /// Envio de email de confirmación
        /// </summary>
        /// <param name="message">Propiedades del correo</param>
        /// <returns></returns>
        public async Task SendAsync(IdentityMessage message)
        {
            var to = new List<string>();

            to.Add(message.Destination);

            await UtilitesEmail.sendEmail(message.Subject, message.Body, HtmlBody.isHtml, to); 
        }
    }
}
