using AssistanceOnlineDAL;
using AssistanceOnlineDAL.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssistanceOnlineBLL
{
    /// <summary>
    /// Negocio del controlador DetailCourse
    /// </summary>
    public static class DetailCourseBLL
    {
        /// <summary>
        /// Obtiene un curso
        /// </summary>
        /// <param name="id">Id del curso</param>
        /// <returns></returns>
        public static Courses getCourse(int id)
        {
            var course = AssistanceOnlineQueries.getCourse(id);

            switch (course.status)
            {
                case StatusQuery.Succesfull:
                    return course.Response;
                case StatusQuery.ConnectionError:
                    return null;
                default:
                    return null;
            }
        }
    }
}
