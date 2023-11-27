using LibraryManagement.Data;
using Microsoft.AspNetCore.Identity;

namespace LibraryManagement.Service
{
    public class RoleService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        public RoleService(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager, SignInManager<ApplicationUser> signInManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _signInManager = signInManager;
        }

        //Create user roles if they donot in the DB
        public async Task GenerateRolesAsync()
        {

            var AdminRoleExist = await _roleManager.FindByNameAsync("Admin");
            var StudentExist = await _roleManager.FindByNameAsync("Student");
            
            if (AdminRoleExist == null)
            {
                var CreateAdmin = _roleManager.CreateAsync(new IdentityRole("Admin")).Result;
            }
            if (StudentExist == null)
            {
                var CreateStudent = _roleManager.CreateAsync(new IdentityRole("Student")).Result;
            }
            
        }




    }
}
