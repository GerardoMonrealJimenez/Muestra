using AssistanceOnlineDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using AssistanceOnlineBLL;
using System.Threading.Tasks;

namespace AssistanceOnlineWeb.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            if (User.Identity.IsAuthenticated)
            {
                try
                {
                    var model = HomeBLL.getUserInformation(User.Identity.GetUserId());

                    return View(model);
                }
                catch (Exception ex)
                {
                    // regresar la pantalla de error
                    throw ex;
                }
                
            }

            return RedirectToAction("Login", "SignUp");
            
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        /// <summary>
        /// Retorna la vista parcial con el modelo para añadir un curso
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult modalAddCourse()
        {
            return PartialView("ModalAddCourse", new Courses());
        }

        /// <summary>
        /// Inserta un nuevo curso del usuario
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> AddCourse(Courses model)
        {
            try
            {
                model.Id_user = User.Identity.GetUserId();

                await HomeBLL.insertUserCourse(model);

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        /// <summary>
        /// Obtiene los cursos del usuario
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult courses()
        {
            var model = HomeBLL.getCourses(User.Identity.GetUserId());

            return PartialView("Courses", model);
        }

        /// <summary>
        /// Obtine los cursos en los que el usuario esta inscrito
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult enrolledCourses()
        {
            var model = HomeBLL.getEnrolledCourses(User.Identity.GetUserId());

            return PartialView("Courses", model);
        }
    }
}