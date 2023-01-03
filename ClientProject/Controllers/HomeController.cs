using Microsoft.AspNetCore.Mvc;

namespace ClientProject.Controllers
{
    
    public class HomeController : Controller
    {
        public IActionResult Index() => View();
        
    }
}
