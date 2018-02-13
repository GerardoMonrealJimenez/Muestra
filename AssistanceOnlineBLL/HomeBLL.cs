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
    /// Negocio del controlador Home
    /// </summary>
    public static class HomeBLL
    {
        /// <summary>
        /// Obtiene toda la información del cliente
        /// para poder mostrarla en la vista 
        /// </summary>
        /// <param name="id">Id del Usuario</param>
        /// <returns></returns>
        public static AspNetUsers getUserInformation(string id)
        {
            try
            {
                var response = AssistanceOnlineQueries.getAllUser(id);

                if (response.status == StatusQuery.Succesfull)
                {
                    return response.Response;
                }

                return null;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        /// <summary>
        /// Crea un curso para un usuario
        /// </summary>
        /// <param name="data">Datos del curso</param>
        /// <returns></returns>
        public static async Task insertUserCourse(Courses data)
        {
            try
            {

                await AssistanceOnlineQueries.insertUserCourseAsync(data);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        /// <summary>
        /// Enrrola a un usuario en un curso
        /// </summary>
        /// <returns></returns>
        public static async Task enrollCourse(UsersCourses data)
        {
            try
            {
                await AssistanceOnlineQueries.enrollCourse(data);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        /// <summary>
        /// Obtiene los cursos que el usuario dio de alta
        /// </summary>
        /// <param name="idUser">Id del usuario</param>
        /// <returns></returns>
        public static List<Courses> getCourses(string idUser)
        {
            try
            {
               var response = AssistanceOnlineQueries.getCourses(idUser);

                switch (response.status)
                {
                    case StatusQuery.Succesfull:
                        return response.Response;
                    case StatusQuery.ConnectionError:
                        return null;
                    default:
                        return null;
                }

                
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        /// <summary>
        /// Obtiene los cursos en que el usuario esta inscrito
        /// </summary>
        /// <param name="idUser">Id del usuario</param>
        /// <returns></returns>
        public static List<Courses> getEnrolledCourses(string idUser)
        {
            var coursesResponse = AssistanceOnlineQueries.getEnrolledCourses(idUser);

            switch (coursesResponse.status)
            {
                case StatusQuery.Succesfull:
                    return coursesResponse.Response;
                    
                case StatusQuery.ConnectionError:
                    return null;
                default:
                    return null;
            }
        }
    }
}
