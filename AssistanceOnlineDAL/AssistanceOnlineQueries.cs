using AssistanceOnlineDAL.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AssistanceOnlineDAL.Response;


namespace AssistanceOnlineDAL
{
    /// <summary>
    /// Consultas a la base de datos
    /// </summary>
    public static class AssistanceOnlineQueries
    {
        /// <summary>
        /// Obtiene las llaves de la aplicacion
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public static DataBaseResponse<Key> selectKey(TypesKeys key)
        {
            try
            {
                using (var context = new AssistanceOnlineContext())
                {
                    var response = context.Key.FirstOrDefault(c => c.idKey == (int)key);

                    return new DataBaseResponse<Key> { status = StatusQuery.Succesfull, Response = response, exception = string.Empty }; 
                }
            }
            catch (Exception ex)
            {
                return new DataBaseResponse<Key> { status = StatusQuery.ConnectionError, exception = ex.Message, Response = null };
            }
        }

        /// <summary>
        /// Obtiene el template del email de confirmación
        /// </summary>
        /// <returns></returns>
        public static DataBaseResponse<string> getHtmlTemplateEmailConfirmation()
        {
            try
            {
                using (var context = new AssistanceOnlineContext())
                {
                    var response = context.HtmlTemplate.FirstOrDefault(c => c.idHtmlTemplate == 1).template;
                    return new DataBaseResponse<string> { status = StatusQuery.Succesfull, Response = response, exception = string.Empty};
                }
            }
            catch (Exception ex)
            {

                return new DataBaseResponse<string> { status = StatusQuery.ConnectionError, Response = null, exception = ex.Message };
            }
        }

        /// <summary>
        /// Obtiene el template del email de resetear el password
        /// </summary>
        /// <returns></returns>
        public static DataBaseResponse<string> getHtmlTemplateResetPassword()
        {
            try
            {
                using (var context = new AssistanceOnlineContext())
                {
                    var response = context.HtmlTemplate.FirstOrDefault(c => c.idHtmlTemplate == 2).template;

                    return new DataBaseResponse<string> { status = StatusQuery.Succesfull, Response = response, exception = null };
                }
            }
            catch (Exception ex)
            {
                return new DataBaseResponse<string> { status= StatusQuery.ConnectionError,Response = null, exception = ex.Message};
            }
        }

        /// <summary>
        /// Obtiene la información de los cursos en los que esta involucrado el usuario
        /// </summary>
        /// <param name="id">Id del usuario</param>
        /// <returns></returns>
        public static DataBaseResponse<AspNetUsers> getAllUser(string id)
        {
            try
            {
                using (var context = new AssistanceOnlineContext())
                {
                    var response = context.AspNetUsers
                                                .Include("Courses")
                                                .Include("UsersCourses")
                                                .Include("UsersCourses.Courses")
                                                .FirstOrDefault(
                                                                    c =>
                                                                            c.Id == id
                                                                );

                    return new DataBaseResponse<AspNetUsers> { status = StatusQuery.Succesfull, Response = response, exception = null };
                }
            }
            catch (Exception ex)
            {
                return new DataBaseResponse<AspNetUsers> { status = StatusQuery.ConnectionError, Response = null, exception = ex.Message };
            }
        }

        /// <summary>
        /// Inserta un nuevo curso para un usuario
        /// </summary>
        /// <param name="course">Información del curso</param>
        /// <returns></returns>
        public static async Task<DataBaseResponse<string>> insertUserCourseAsync(Courses course)
        {
            try
            {
                using (var context = new AssistanceOnlineContext())
                {
                    context.Sp_InsertCourse(course.Id_user, course.Name, course.Description, course.Password);
                    
                    await context.SaveChangesAsync();

                    return new DataBaseResponse<string> { status = StatusQuery.Succesfull, Response = string.Empty, exception = null };
                }
            }
            catch (Exception ex)
            {
                return new DataBaseResponse<string> { status = StatusQuery.ConnectionError, Response = string.Empty, exception = null };
                throw ex;
            }
        }

        /// <summary>
        /// Enrolla a un usuario en algun curso
        /// </summary>
        /// <param name="usersCourse"></param>
        /// <returns></returns>
        public static async Task<DataBaseResponse<string>> enrollCourse(UsersCourses usersCourse)
        {
            try
            {
                using (var context = new AssistanceOnlineContext())
                {
                    context.UsersCourses.Add(usersCourse);

                    await context.SaveChangesAsync();

                    return new DataBaseResponse<string> { status = StatusQuery.Succesfull, Response = string.Empty, exception = null };
                    
                }
            }
            catch (Exception ex)
            {
                return new DataBaseResponse<string> { status = StatusQuery.ConnectionError, exception = ex.Message };

            }
        }
        /// <summary>
        /// Obtiene los cursos que creo el usuario
        /// </summary>
        /// <param name="idUser"></param>
        /// <returns></returns>
        public static DataBaseResponse<List<Courses>> getCourses(string idUser)
        {
            try
            {
                using (var context = new AssistanceOnlineContext())
                {
                    var response = context.Courses.Where(c => c.Id_user == idUser).ToList();

                    return new DataBaseResponse<List<Courses>> { status = StatusQuery.Succesfull, Response = response, exception = null };
                }
            }
            catch (Exception ex)
            {
                return new DataBaseResponse<List<Courses>> { status = StatusQuery.ConnectionError, Response = null, exception = ex.Message }; 
            }
        }
        /// <summary>
        /// Obtiene un curso
        /// </summary>
        /// <param name="idCourse"></param>
        /// <returns></returns>
        public static DataBaseResponse<Courses> getCourse(int idCourse)
        {
            try
            {
                using (var context = new AssistanceOnlineContext())
                {
                    var course = context.Courses.FirstOrDefault(c => c.Id_course == idCourse);

                    return new DataBaseResponse<Courses> { Response = course, status = StatusQuery.Succesfull, exception = string.Empty}; 
                }
            }
            catch (Exception ex)
            {

                return new DataBaseResponse<Courses> { Response = null, status = StatusQuery.ConnectionError, exception = ex.Message};
            }
        }
        /// <summary>
        /// Obtiene los cursos en los cuales el usuario esta inscrito
        /// </summary>
        /// <param name="idUser">Id Usuario</param>
        /// <returns></returns>
        public static DataBaseResponse<List<Courses>> getEnrolledCourses(string idUser)
        {
            try
            {
                using (var context = new AssistanceOnlineContext())
                {
                    var courses = context.Courses.Where(
                                                    c => c.UsersCourses.Any(a => a.Id_user == idUser)
                                                ).ToList();

                    return new DataBaseResponse<List<Courses>> { Response = courses, status = StatusQuery.Succesfull, exception = string.Empty };
                }
            }
            catch (Exception ex)
            {

                return new DataBaseResponse<List<Courses>> { Response = null, status = StatusQuery.ConnectionError, exception = ex.Message };
            }
        }
    }


}
