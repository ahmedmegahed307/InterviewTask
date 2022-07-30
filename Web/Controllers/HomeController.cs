using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace AFS_.NET_Developer_Test.Controllers
{
    
    public class HomeController : Controller
    {
        private readonly ILeetSpeakService _leetSpeak;
        public HomeController(ILeetSpeakService leetSpeak)
        {
            _leetSpeak = leetSpeak;
           
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult GetCalls()
        {
            return View();
        }
        public IActionResult Delete(int id)
        {

        _leetSpeak.DeleteRecord(id);
            return View("GetCalls");
        }

    }
}
