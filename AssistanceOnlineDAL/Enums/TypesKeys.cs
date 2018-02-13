using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssistanceOnlineDAL.Enums
{
    /// <summary>
    /// Tipos de llaves
    /// </summary>
    public enum TypesKeys
    {
        /// <summary>
        /// Llave secreta
        /// </summary>
        secretKey = 2,
        /// <summary>
        /// Host para envio del email
        /// </summary>
        Hostemail = 3,
        /// <summary>
        /// Email
        /// </summary>
        MainEmail = 4,
        /// <summary>
        /// Password del email
        /// </summary>
        MainEmailPassword = 6,
        /// <summary>
        /// Id google
        /// </summary>
        ClientIdGoogle = 7,
        /// <summary>
        /// Client secret google
        /// </summary>
        ClientSecretGoogle = 8
    }
}
