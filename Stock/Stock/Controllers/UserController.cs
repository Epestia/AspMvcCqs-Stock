using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Stock.Commands;
using Stock.Models;
using Stock.Services;
using System.Threading.Tasks;

namespace Stock.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        public IActionResult User()
        {
            return View();
        }

        public IActionResult Login()
        {
            if (HttpContext.Session.GetString("UserEmail") != null)
            {
                TempData["InfoMessage"] = "Vous êtes déjà connecté.";
                return RedirectToAction("Dashboard");
            }
            return View();
        }

        public IActionResult Dashboard()
        {
            if (HttpContext.Session.GetString("UserEmail") == null)
            {
                TempData["ErrorMessage"] = "Vous devez être connecté pour accéder au tableau de bord.";
                return RedirectToAction("Login");
            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateUser(UserModel user)
        {
            if (!ModelState.IsValid)
            {
                return View(user);
            }

            var command = new CreateUserCommand(user.Nom, user.Prenom, user.Mail, user.MotDePasse);
            await _userService.CreateUserAsync(command);

            TempData["SuccessMessage"] = "Utilisateur créé avec succès! Veuillez vous connecter.";
            return RedirectToAction("Login");
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginModel loginModel)
        {
            if (!ModelState.IsValid)
            {
                return View(loginModel);
            }

            var user = await _userService.AuthenticateAsync(loginModel.Mail, loginModel.MotDePasse);

            if (user == null)
            {
                ModelState.AddModelError(string.Empty, "Email ou mot de passe incorrect.");
                return View(loginModel);
            }

            HttpContext.Session.SetString("UserEmail", user.Mail);
            HttpContext.Session.SetString("UserName", user.Nom);

            TempData["SuccessMessage"] = $"Bienvenue, {user.Nom} ! Connexion réussie.";
            return RedirectToAction("Dashboard");
        }


        public IActionResult Logout()
        {
           
            HttpContext.Session.Clear();

         
            TempData["SuccessMessage"] = "Déconnexion réussie!";

        
            return RedirectToAction("LogoutConfirmation");
        }

        public IActionResult LogoutConfirmation()
        {
            return View();
        }

    }
}
