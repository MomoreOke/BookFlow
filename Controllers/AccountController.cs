using LibraryManagement.Data;
using LibraryManagement.Models;
using LibraryManagement.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mail;

namespace LibraryManagement.Controllers
{
    public class AccountController : Controller
    {
        private AccountService _accountService;
        private readonly UserManager<ApplicationUser> _userManager;

        public AccountController(AccountService accountService, UserManager<ApplicationUser> userManager)
        {
            _accountService = accountService;
            _userManager = userManager;
        }

        // GET: AccountController
        public ActionResult Index()
        {
            return View();
        }

        // GET: AccountController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: AccountController/Create
        public ActionResult Register()
        { 
            return View();
        }
         
        // POST: AccountController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Register(AccountRegisterModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var result = await _accountService.RegisterUserAsync(model);
                    if (result.Succeeded)
                    {
                        return RedirectToAction("Index", "Home");
                    }
                }

                

                throw new Exception();
            }
            catch(Exception ex)
            {
                
                return View();
            }
        }

        // GET: AccountController/Edit/5
        public ActionResult Login() 
        {
            return View();
        }

        // POST: AccountController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Login(LoginModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var result = await _accountService.LoginAsync(model);
                    if (result.Succeeded)
                    {
                        MailAddress address = new(model.Email);
                        var userName = address.User;
                        var GetUser = await _userManager.FindByNameAsync(userName);
                        string userRole = _accountService.WhatRoleIsUser(GetUser.Id);
                        if (userRole == "Student")
                        {
                            //go to student page
                            return RedirectToAction("Student", "Dashboard");
                        }
                        else
                        {
                            return RedirectToAction("Admin", "Dashboard");

                        }

                    }

                }
                return View();
            }
            catch
            {
                return View();
            }
        }

        //Get logged in user's role
        
        public async Task<ActionResult> Logout()
        {
            await _accountService.LogOutAsync();
            return RedirectToAction("Index", "Home");
        }
    }
}
