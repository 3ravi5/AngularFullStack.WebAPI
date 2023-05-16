using Microsoft.AspNetCore.Mvc;

namespace AngularFullStack.WebAPI.Controllers
{
    
    public class EmployeeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
