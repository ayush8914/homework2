using Homework2.Models;
using Homework2.Repositories;
using Homework2.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Homework2.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IClassroomRepository _classRepo;
        private readonly IInviteRepository _inviteRepo;
        private readonly IClassroomUserRepository _classroomUserRepo;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly UserManager<AppUser> _userManager;

        public HomeController(ILogger<HomeController> logger, IClassroomRepository classRepo, IInviteRepository inviteRepo, IClassroomUserRepository classroomUserRepo, SignInManager<AppUser> signInManager, UserManager<AppUser> userManager)
        {
            _logger = logger;
            _classRepo = classRepo;
            _classroomUserRepo = classroomUserRepo;
            _signInManager = signInManager;
            _userManager = userManager;
            _inviteRepo = inviteRepo;
            ;
        }
        public IActionResult Index()
        {
            if (_signInManager.IsSignedIn(HttpContext.User))
            {
                var id = _userManager.GetUserId(HttpContext.User);
                string user_email = _userManager.FindByIdAsync(id).Result.Email;
                HomeViewModel hvm = new HomeViewModel
                {
                    Invites = _inviteRepo.GetUserInvites(user_email),
                    UserClassrooms = _classroomUserRepo.GetUserClassrooms(id)
                };
                return View(hvm);
            }
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