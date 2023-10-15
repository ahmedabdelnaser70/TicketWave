using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ticketWave.Data;
using ticketWave.Data.ViewModels;
using ticketWave.Models;

namespace ticketWave.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly AppDbContext _context;

        public AccountController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, AppDbContext context)
        {
            _context = context;
            _userManager = userManager;
            _signInManager = signInManager;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Login() => View(new LoginVM());
    }
}
