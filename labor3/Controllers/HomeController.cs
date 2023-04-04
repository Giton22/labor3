using labor3.Data;
using labor3.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Diagnostics;

namespace labor3.Controllers
{
    public class HomeController : Controller
    {
        private readonly UserManager<SiteUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _db;

        public HomeController(UserManager<SiteUser> userManager, RoleManager<IdentityRole> roleManager, ILogger<HomeController> logger, ApplicationDbContext db, IEmailSender emailSender)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _logger = logger;
            _db = db;
        }
        public async Task<IActionResult> DelegateAdmin()
        {
            var principal = this.User;
            var user = await _userManager.GetUserAsync(principal);
            var role = new IdentityRole()
            {
                Name = "Admin"
            };
            if (!await _roleManager.RoleExistsAsync("Admin"))
            {
                await _roleManager.CreateAsync(role);
            }
            await _userManager.AddToRoleAsync(user, "Admin");
            return RedirectToAction(nameof(Index));
        }

        [Authorize(Roles = "Admin")]
        public IActionResult Admin()
        {
            return View(_db.Jobs);
        }

        [Authorize(Roles = "Admin")]
        public IActionResult Users()
        {
            return View(_userManager.Users);
        }

        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> RemoveAdmin(string uid)
        {
            var user = _userManager.Users.FirstOrDefault(t => t.Id == uid);
            await _userManager.RemoveFromRoleAsync(user, "Admin");
            return RedirectToAction(nameof(Users));
        }

        public IActionResult Index()
        {
            return View(_db.Jobs);
        }
        [Authorize]
        public IActionResult Add()
        {
            return View();
        }
        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Add(Job job)
        {
            job.UId = _userManager.GetUserId(this.User);

            var old = _db.Jobs.FirstOrDefault(t => t.Title == job.Title && job.UId == job.UId);
            if (old == null)
            {
                _db.Jobs.Add(job);
                _db.SaveChanges();
            }

            var user = await _userManager.GetUserAsync(this.User);

            return RedirectToAction(nameof(Index));
        }

        public IActionResult Delete(string uid)
        {
            var item = _db.Jobs.FirstOrDefault(t => t.UId == uid);
            if (item != null && item.UId == _userManager.GetUserId(this.User))
            {
                _db.Jobs.Remove(item);
                _db.SaveChanges();
            }
            return RedirectToAction(nameof(Index));
        }

        [Authorize(Roles = "Admin")]
        public IActionResult AdminDelete(string uid)
        {
            var item = _db.Jobs.FirstOrDefault(t => t.UId == uid);
            if (item != null)
            {
                _db.Jobs.Remove(item);
                _db.SaveChanges();
            }
            return RedirectToAction(nameof(Index));
        }



        [Authorize]
        public async Task<IActionResult> Privacy()
        {
            var principal = this.User;
            var user = await _userManager.GetUserAsync(principal);
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}