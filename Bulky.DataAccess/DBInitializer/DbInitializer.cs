using Bulky.DataAccess.Data;
using Bulky.Models;
using Bulky.Utility;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bulky.DataAccess.DBInitializer
{
    public class DbInitializer : IDbInitializer
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly ApplicationDbContext _db;
        public DbInitializer(      
            UserManager<IdentityUser> userManager,
            RoleManager<IdentityRole> roleManager,
            ApplicationDbContext db){
            
                _roleManager = roleManager;
                _userManager = userManager;
                _db = db;
            
        }

        public void Initialize()
        {
            //migration 
            try
            {
                if (_db.Database.GetPendingMigrations().Count() > 0)
                {
                    _db.Database.Migrate();
                }
            }
            catch(Exception ex) { }
            //create roles

            if (!_roleManager.RoleExistsAsync(SD.Role_User).GetAwaiter().GetResult()) //k dung await dc
            {
                _roleManager.CreateAsync(new IdentityRole(SD.Role_User)).GetAwaiter().GetResult();
                _roleManager.CreateAsync(new IdentityRole(SD.Role_Admin)).GetAwaiter().GetResult();

                //if roles not created, create admin
                _userManager.CreateAsync(new ApplicationUser
                {
                    UserName = "admin@gm.com",

                }, "Admin123*").GetAwaiter().GetResult();

                ApplicationUser user = _db.ApplicationUsers.FirstOrDefault(u => u.Email == "admin@gm.com");
                _userManager.AddToRoleAsync(user, SD.Role_Admin).GetAwaiter().GetResult();
            }
        } 

    }
}
