using LibraryManagement.Data;
using LibraryManagement.Data.LibraryDBContext;
using LibraryManagement.Models;
using Microsoft.AspNetCore.Identity;
using System.Net.Mail;

namespace LibraryManagement.Service
{
    public class AccountService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private RoleService _roleService;
        private LibraryDBContext _context;
        public AccountService(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager, SignInManager<ApplicationUser> signInManager, LibraryDBContext context, RoleService roleService)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _signInManager = signInManager;
            _context = context;
            _roleService = roleService;
        }

        public async Task<IdentityResult> RegisterUserAsync(AccountRegisterModel model)
        {
            await _roleService.GenerateRolesAsync();

            //Get username from email address
            MailAddress address = new(model.Email);
            var userName = address.User;
            DateTime lockoutendDate = Convert.ToDateTime("1/1/0001");
            var newUser = new ApplicationUser
            {
                LastName = model.LastName,
                FirstName = model.FirstName,
                PhoneNumber = model.PhoneNumber,
                Email = model.Email,
                NormalizedEmail = model.Email.ToUpper(),
                LockoutEnd = lockoutendDate,
                LockoutEnabled = false,
                UserName = userName,
                NormalizedUserName = userName.ToUpper(),

            };

            var result = await _userManager.CreateAsync(newUser, model.Password);

            if (result.Succeeded)
            {

                if (model.RoleId == 1)
                {

                    await _userManager.AddToRoleAsync(newUser, "Admin");
                }
                else
                {
                    //add student as a member
                    Member member = new()
                    {
                        
                        UserAddress = model.Email,
                        UserEmail = model.Email,
                        UserName = model.FirstName + " " + model.LastName,
                        UserPhoneNumber = model.PhoneNumber
                    };
                    _context.Members.Add(member);
                    _context.SaveChanges();

                    await _userManager.AddToRoleAsync(newUser, "Student");
                }

            }

            return result;


        }

        public async Task<SignInResult> LoginAsync(LoginModel model) 
        {
            var userName = new MailAddress(model.Email).User;

            var result = await _signInManager.PasswordSignInAsync(userName, model.Password, model.RememberMe, lockoutOnFailure: false);

            return result;

        }

        public string WhatRoleIsUser(string userId)
        {
            var GetUserRoleId = _context.UserRoles.Where(x => x.UserId == userId).FirstOrDefault();
            var GetUserRole = _context.Roles.Where(x => x.Id == GetUserRoleId.RoleId).FirstOrDefault();

            return GetUserRole.Name;

        }


        public async Task LogOutAsync()
        {
            await _signInManager.SignOutAsync();

        }
    }
}
