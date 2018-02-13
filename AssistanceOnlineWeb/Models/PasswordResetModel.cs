using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AssistanceOnlineWeb.Models
{
    /// <summary>
    /// Modelo para el reset de la contraseña
    /// </summary>
    public class PasswordResetModel
    {
        /// <summary>
        /// Id del usuario
        /// </summary>
        public string userid { get; set; }
        /// <summary>
        /// Token
        /// </summary>
        public string token { get; set; }
        /// <summary>
        /// Nueva contraseña
        /// </summary>
        public string newPassword { get; set; }
    }
}