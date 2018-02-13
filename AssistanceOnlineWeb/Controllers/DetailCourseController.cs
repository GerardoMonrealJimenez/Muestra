using AssistanceOnlineBLL;
using AssistanceOnlineDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AssistanceOnlineWeb.Controllers
{
    public class DetailCourseController : Controller
    {
        // GET: DetailCourse
        /// <summary>
        /// Genera una pagina con el curso que se le solicita
        /// </summary>
        /// <param name="id">Id del curso</param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult Index(int id)
        {
            var model = DetailCourseBLL.getCourse(id);
            return View(model);
        }
    }
}