
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using CSharpbelt.Models;
using System.Linq;
using Microsoft.AspNetCore.Identity;

namespace CSharpbelt.Controllers
{
    public class UserController : Controller
    {
        private AshContext _context;
        public UserController(AshContext context)
        {
            _context = context;
        }
        // this is my home page, this displays the login reg and maybe later i should change the links above on the
        // nav bar. 
        [HttpGet]
        [Route("")]
        public IActionResult Index()
        {
            return View();
        }
        //         [HttpPost("register")]
        // public IActionResult Register(User user)
        // {
        //     User Validate = dbContext.User.Where(u => u.email == user.email).SingleOrDefault(); 
        //     if(ModelState.IsValid && Validate == null)
        //     {
        //             PasswordHasher<User> Hasher = new PasswordHasher<User>();
        //             user.password = Hasher.HashPassword(user, user.password);
        //             dbContext.Add(user);
        //             dbContext.SaveChanges();
        //             HttpContext.Session.SetInt32("UserID", user.id);
        //             // var loggeduser = new User();
        //             User loggeduser = dbContext.User.Where(u => u.email == user.email).SingleOrDefault();
        //             TempData["user"] = loggeduser.first_name;
        //             return RedirectToAction ("Success");
        //     }
        //     else
        //     {
        //         return View("Index");
        //     }
        // }

        [HttpPost]
        [Route("RegisterUser")]
        public IActionResult RegisterUser(RegisterUser newUser)
        {
            if(_context.Users.Where(user => user.Email == newUser.Email).SingleOrDefault() != null)
            {
                ModelState.AddModelError("Email", "Email already in use");
            }
            PasswordHasher<RegisterUser> hasher = new PasswordHasher<RegisterUser>();
            if(ModelState.IsValid)
            {
                User theUser = new User
                {
                    FirstName = newUser.FirstName,
                    LastName = newUser.LastName,
                    Email = newUser.Email,
                    Password = hasher.HashPassword(newUser, newUser.Password),
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now,          
                };
                User loggedUser = _context.Add(theUser).Entity;
                _context.SaveChanges();
                HttpContext.Session.SetInt32("id", loggedUser.UserId);
                return RedirectToAction ("Index", "Activity");
            };
            return View("Index");
        }

        //         [HttpPost("login")]
        // public IActionResult Login_User(Login user)
        // {
        //     if(ModelState.IsValid)
        //     {
        //         var userInDb = dbContext.User.FirstOrDefault(u => u.email == user.email);
        //         if(userInDb == null)
        //         {
        //             ModelState.AddModelError("email", "Invalid Email");
        //             return View("Login");
        //         }
        //         HttpContext.Session.SetInt32("UserID", userInDb.id);
        //         var hasher = new PasswordHasher<Login>();
        //         var result = hasher.VerifyHashedPassword(user, userInDb.password, user.password);
                
        //         if(result == 0)
        //         {
        //             ModelState.AddModelError("password", "Invalid Password");
        //             return View("Login");
        //         }
                 
        //         else
        //         {
        //             User loggeduser = dbContext.User.Where(u => u.email == user.email).SingleOrDefault();
        //             TempData["user"] = loggeduser.first_name;
        //             return RedirectToAction ("Success", loggeduser);
        //         }
        //     }
        //     else
        //     {
        //         return View("Login");
        //     }
        // }

        [Route("LoginUser")]
        public IActionResult LoginUser(LoginUser returningUser)
        {
            PasswordHasher<LoginUser> hasher = new PasswordHasher<LoginUser>();
            User loginUser = _context.Users.Where(user => user.Email == returningUser.LogEmail).SingleOrDefault();
            if(loginUser == null)
            {
                ModelState.AddModelError("LogEmail", "Invalid Email/Password");
            }
            else if(hasher.VerifyHashedPassword(returningUser,loginUser.Password, returningUser.LogPassword) == 0)
            {
                ModelState.AddModelError("LogEmail", "Invalid Email/Passowrd");
            }
            if(!ModelState.IsValid)
            {
                return View("Index");
            }
            HttpContext.Session.SetInt32("id", loginUser.UserId);
            return RedirectToAction ("Index", "Activity");
        }
        [HttpGet]
        [Route("Logout")]
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index");
        }
    }
}