using AssistanceOnlineDAL.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssistanceOnlineDAL.Response
{
    /// <summary>
    /// Respuesta de una consulta a la base de datos
    /// </summary>
    /// <typeparam name="T"></typeparam>
   public class DataBaseResponse <T>
    {
        /// <summary>
        /// Respuesta
        /// </summary>
        public T Response { get; set; }
        /// <summary>
        /// Estatus
        /// </summary>
        public StatusQuery status { get; set; }
        /// <summary>
        /// Excepcion
        /// </summary>
        public string exception { get; set; }
    }
}
