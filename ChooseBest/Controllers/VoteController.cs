using ChooseBest.Areas.Identity.Data;
using ChooseBest.Data;
using ChooseBest.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ChooseBest.Controllers
{
    public class VoteController : Controller
    {
        private readonly VoteDbContext _context;
        private readonly UserContext _ucontext;
        private readonly SignInManager<User> _signInManager;
        User? user;

        public VoteController(VoteDbContext context, UserContext ucontext, SignInManager<User> signInManager)
        {
            _context = context;
            _ucontext = ucontext;
            _signInManager = signInManager;
        }


        // GET: VoteController
        //[Authorize]
        public ActionResult Index(string display)
        {
            //ViewData["Display"] = display;
            switch (display)
            {
                case "player":
                    ViewData["Players"] = _context.Players;
                    return View();

                case "team":
                    ViewData["Teams"] = _context.Teams;
                    return View();

                case "trainer":
                    ViewData["Trainers"] = _context.Trainers;
                    return View();
            }
            return View();
        }

        // GET: VoteController/Create
        [Authorize(Roles = "Admin")]
        public ActionResult CreatePlayer()
        {
            return View();
        }

        // POST: VoteController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> CreatePlayer([Bind("Id,Name,TeamInfo,Info,Age,Img")] Player player)
        {

            if (ModelState.IsValid /*&& User.IsInRole("Admin")*/)
            {
                player.Id = Guid.NewGuid();
                _context.Add(player);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return RedirectToRoute(new { controller = "Vote", action = "Index", display = "player" });
        }

        // GET: VoteController/Edit/5
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> EditPlayer(Guid? id)
        {
            var item = await _context.Players.FindAsync(id);
            return View(item);
        }

        // POST: VoteController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> EditPlayer(Guid id, [Bind("Id,Name,TeamInfo,Info,Age,Img")] Player player)
        {
            player.Id = id;
            _context.Update(player);
            await _context.SaveChangesAsync();

            return RedirectToRoute(new { controller = "Vote", action = "Index", display = "player" });
        }





        [Authorize(Roles = "Admin")]
        public ActionResult CreateTeam()
        {
            return View();
        }

        // POST: VoteController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> CreateTeam([Bind("Id,Name,Info,Img")] Team team)
        {

            if (ModelState.IsValid /*&& User.IsInRole("Admin")*/)
            {
                team.Id = Guid.NewGuid();
                _context.Teams.Add(team);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(nameof(Index));
        }

        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> EditTeam(Guid? id)
        {
            var item = await _context.Teams.FindAsync(id);
            return View(item);
        }

        // POST: VoteController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> EditTeam(Guid id, [Bind("Id,Name,Info,Img")] Team team)
        {
            team.Id = id;
            _context.Update(team);
            await _context.SaveChangesAsync();

            return RedirectToRoute(new { controller = "Vote", action = "Index", display = "team" });
        }







        [Authorize(Roles = "Admin")]
        public ActionResult CreateTrainer()
        {
            return View();
        }

        // POST: VoteController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> CreateTrainer([Bind("Id,Name,TeamInfo,Info,Age,Img")] Trainer trainer)
        {

            if (ModelState.IsValid /*&& User.IsInRole("Admin")*/)
            {
                trainer.Id = Guid.NewGuid();
                _context.Trainers.Add(trainer);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(nameof(Index));
        }

        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> EditTrainer(Guid? id)
        {
            var item = await _context.Trainers.FindAsync(id);
            return View(item);
        }

        // POST: VoteController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> EditTrainer(Guid id, [Bind("Id,Name,Info,Img")] Trainer trainer)
        {
            trainer.Id = id;
            _context.Update(trainer);
            await _context.SaveChangesAsync();

            return RedirectToRoute(new { controller = "Vote", action = "Index", display = "trainer" });
        }

        public async Task<IActionResult> MakeVote(Guid id, string type)
        {
            user = await _signInManager.UserManager.GetUserAsync(User);

            switch (type)
            {
                case "player":
                    var player = _context.Players.Find(id);
                    player.Votes++;
                    user.VotePlayer = true;
                    user.ChosenPlayer = player.Id;
                    _ucontext.Update(user);
                    await _ucontext.SaveChangesAsync();
                    _context.Update(player);
                    await _context.SaveChangesAsync();
                    return RedirectToRoute(new { controller = "Vote", action = "Voted" });
                case "team":
                    var team = _context.Teams.Find(id);
                    team.Votes++;
                    user.VoteTeam = true;
                    user.ChosenTeam = team.Id;
                    _ucontext.Update(user);
                    await _ucontext.SaveChangesAsync();
                    _context.Update(team);
                    await _context.SaveChangesAsync();
                    return RedirectToRoute(new { controller = "Vote", action = "Voted" });
                case "trainer":
                    var trainer = _context.Trainers.Find(id);
                    trainer.Votes++;
                    user.VoteTrainer = true;
                    user.ChosenTrainer = trainer.Id;
                    _ucontext.Update(user);
                    await _ucontext.SaveChangesAsync();
                    _context.Update(trainer);
                    await _context.SaveChangesAsync();
                    return RedirectToRoute(new { controller = "Vote", action = "Voted" });
            }
            return RedirectToRoute(new { controller = "Home", action = "Index" });
        }
        //[Authorize(Roles = "Admin")]
        public async Task<IActionResult> Voted()
        {
            user = await _signInManager.UserManager.GetUserAsync(User);
            ViewData["Players"] = _context.Players;
            ViewData["Teams"] = _context.Teams;
            ViewData["Trainers"] = _context.Trainers;

            return View(user);
        }

        public async Task<IActionResult> Revote(string type)
        {
            user = await _signInManager.UserManager.GetUserAsync(User);
            switch (type)
            {
                case "player":
                    user.VotePlayer = false;
                    var player = _context.Players.Find(user.ChosenPlayer);
                    player.Votes--;
                    user.ChosenPlayer = null;
                    _context.Update(player);
                    await _context.SaveChangesAsync();
                    break;
                case "team":
                    user.VoteTeam = false;
                    var team = _context.Teams.Find(user.ChosenTeam);
                    team.Votes--;
                    user.ChosenTeam = null;
                    _context.Update(team);
                    await _context.SaveChangesAsync();
                    break;
                case "trainer":
                    user.VoteTrainer = false;
                    var trainer = _context.Teams.Find(user.ChosenTrainer);
                    trainer.Votes--;
                    user.ChosenTrainer = null;
                    _context.Update(trainer);
                    await _context.SaveChangesAsync();
                    break;

            }

            _ucontext.Update(user);
            await _ucontext.SaveChangesAsync();
            return RedirectToRoute(new { controller = "Vote", action = "Index", display = type });
        }

    }
}
