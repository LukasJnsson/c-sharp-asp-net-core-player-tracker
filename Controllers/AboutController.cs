
using Microsoft.AspNetCore.Mvc;
namespace c_sharp_asp_net_core_player_tracker.Controllers;


public class AboutController : Controller
{
    // GET: AboutController
    [HttpGet]
    public ActionResult Index()
    {
        return View();
    }
}