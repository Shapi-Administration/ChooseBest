using ChooseBest.Areas.Identity.Data;
using ChooseBest.Data;
using ChooseBest.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace ChooseBest.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly VoteDbContext _context;
        private readonly UserContext _ucontext;
        private readonly SignInManager<User> _signInManager;
        User? user;

        public HomeController(ILogger<HomeController> logger, VoteDbContext context, UserContext ucontext, SignInManager<User> signInManager)
        {
            _logger = logger;
            _context = context;
            _ucontext = ucontext;
            _signInManager = signInManager;
        }

        public IActionResult Index()
        {
            ViewData["BestPlayer"] = _context.Players.AsEnumerable().MaxBy(m => m.Votes);
            ViewData["BestTeam"] = _context.Teams.AsEnumerable().MaxBy(m => m.Votes);
            ViewData["BestTrainer"] = _context.Trainers.AsEnumerable().MaxBy(m => m.Votes);
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}