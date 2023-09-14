using System.Web.Mvc;

namespace EFApp.API.Controllers
{
    public class EmployeesController : Controller
    {
        // GET: Employees
        public ActionResult Index()
        {
            return View();
        }
    }
}