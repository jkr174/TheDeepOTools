/* Name:    Jovany Romo
 * Date:    7/5/2021
 * Summary: Seed class in order to seed the web application with data instead of being empty.
 * 
 * Inputs:  When the application is first initalized.
 * Outputs: Loads the database with pre-loaded data.
 */
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;
using System.Threading.Tasks;
using TheDeepOTools.Models;

namespace TheDeepOTools.Data
{
    public static class ContextSeed
    {
        /// <summary>
        /// In the Program class, this method is called upon to add a repair ticket along with items in the inventory database.
        /// </summary>
        /// <param name="serviceProvider"></param>
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new ApplicationDbContext(
                serviceProvider.GetRequiredService<DbContextOptions<ApplicationDbContext>>()))
            {
                if (context.RepairTicket.Any())
                {
                    return;
                }
                else
                {
                    context.RepairTicket.AddRange(
                        new RepairTicket
                        {
                            Title = "CB-CR-MAKITA-1",
                            Description = "This item has many issues and needs to be fixed.",
                            TicketState = "Open",
                            OwnerId = "romo17410@gmail.com",
                            Owner = "Jovany"
                        });
                }
                if (context.Inventory.Any())
                {
                    return;
                }
                else
                {
                    context.Inventory.AddRange(
                    new Inventory
                    {
                        ItemName = "Makita 36V Cordless Chainsaw 14 inch",
                        ItemIdentifier = "CT-CS-M36V-1",
                        Description = "A chainsaw for cuitting down trees.",
                        Category = "Cutters", //Category 1
                        Price = 48.00m, //Per Day
                        OnHandQty = 1,
                        OutQty = 0,
                        TotalQty = 1
                    },
                    new Inventory
                    {
                        ItemName = "Makita Breaker",
                        ItemIdentifier = "BK-MBKER-1",
                        Description = "Jackhammers, the combination of a hammer and a chisel.",
                        Category = "Breakers", //Category 2
                        Price = 91.00m, //Per Day
                        OnHandQty = 1,
                        OutQty = 0,
                        TotalQty = 1
                    },
                    new Inventory
                    {
                        ItemName = "Honda 6500 Watt Generator",
                        ItemIdentifier = "GN-HA-6500GEN-1",
                        Description = "In case of an emergency, so you're not out of power.",
                        Category = "Generators", //Category 3
                        Price = 85.00m, //Per Day
                        OnHandQty = 1,
                        OutQty = 0,
                        TotalQty = 1
                    },
                    new Inventory
                    {
                        ItemName = "Automatic Drain Cleaner 100' X 5/8 inches",
                        ItemIdentifier = "DC-AD-CLEANER100-1",
                        Description = "Got something stuck in your pipe system? Look no more.",
                        Category = "Drain Cleaners", //Category 4
                        Subcategory = "75 ft", //Subcategorized by size and length
                        Price = 96.00m, //Per Day
                        OnHandQty = 1,
                        OutQty = 0,
                        TotalQty = 1
                    },
                    new Inventory
                    {
                        ItemName = "DeWalt 20V Framer Nail Gun",
                        ItemIdentifier = "NG-EG-DEWALT20VFRAMER-1",
                        Description = "Flat-packed 35,000-seat stadium",
                        Category = "Air Compressors & Nail Guns", //Category 5
                        Subcategory = "Eletric Nail Guns",
                        Price = 29.00m, //Per Day
                        OnHandQty = 1,
                        OutQty = 0,
                        TotalQty = 1
                    },
                    new Inventory
                    {
                        ItemName = "Mi-T-M Eletric Pressure Washer",
                        ItemIdentifier = "PW-MIELETRIC-1",
                        Description = "Can be used to quickly clean your house.",
                        Category = "Pressure Washers", //Category 10
                        Subcategory = "1400 PSI", //Subcategorized by Pressure
                        Price = 39.00m, //Per Day
                        OnHandQty = 1,
                        OutQty = 0,
                        TotalQty = 1
                    },
                    new Inventory
                    {
                        ItemName = "Makita Backpack Blower",
                        ItemIdentifier = "LB-MAKITABLOWER-1",
                        Description = "Get rid of those pesky leaves.",
                        Category = "Leafblowers", // Category 8
                        Price = 44.00m,
                        OnHandQty = 1,
                        OutQty = 0,
                        TotalQty = 1
                    },
                    new Inventory
                    {
                        ItemName = "Clarke American Sanders Floor Maintainer",
                        ItemIdentifier = "FL-FP-AMERICANMAINTAINER-1",
                        Description = "Have your floor looking shiny.",
                        Category = "Floor Cleaners", // Category 9
                        Subcategory = "Floor Polishers",
                        Price = 61.00m,
                        OnHandQty = 1,
                        OutQty = 0,
                        TotalQty = 1
                    },
                    new Inventory
                    {
                        ItemName = "19ft Scissor Lift",
                        ItemIdentifier = "LE-AE-SCISSORLIFT-1",
                        Description = "How to give someone a fear of heights.",
                        Category = "Large Eqiupment", // Category 10
                        Subcategory = "Ariel Equipment",
                        Price = 159.00m, // PerDay
                        OnHandQty = 1,
                        OutQty = 0,
                        TotalQty = 1
                    }
                    );
                    context.SaveChanges();
                }
            }
        }

        /// <summary>
        /// Seeds the application with default roles.
        /// </summary>
        /// <param name="roleManager"></param>
        /// <returns>
        /// The web application now has default roles.
        /// </returns>
        public static async Task SeedRolesAsync(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            await roleManager.CreateAsync(new IdentityRole(Enums.Roles.Manager.ToString()));
            await roleManager.CreateAsync(new IdentityRole(Enums.Roles.Admin.ToString()));
            await roleManager.CreateAsync(new IdentityRole(Enums.Roles.FloorAssoicate.ToString()));
            await roleManager.CreateAsync(new IdentityRole(Enums.Roles.RepairTech.ToString()));
        }

        /// <summary>
        /// Seeds the "super user"
        /// </summary>
        /// <param name="userManager">Uses the application user class for identity.</param>
        /// <returns>
        /// Seeds the applcation with a default "SuperAdmin" user.
        /// </returns>
        public static async Task SeedSuperAdminAsync(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            //Seed Default User
            var defaultUser = new ApplicationUser
            {
                UserName = "admin",
                Email = "superadmin@gmail.com",
                FirstName = "Jovany",
                LastName = "Romo",
                EmailConfirmed = true,
                PhoneNumberConfirmed = true
            };
            if (userManager.Users.All(u => u.Id != defaultUser.Id))
            {
                var user = await userManager.FindByEmailAsync(defaultUser.Email);
                if (user == null)
                {
                    await userManager.CreateAsync(defaultUser, "Jr@38257");
                    await userManager.AddToRoleAsync(defaultUser, Enums.Roles.FloorAssoicate.ToString());
                    await userManager.AddToRoleAsync(defaultUser, Enums.Roles.Manager.ToString());
                    await userManager.AddToRoleAsync(defaultUser, Enums.Roles.Admin.ToString());
                    await userManager.AddToRoleAsync(defaultUser, Enums.Roles.RepairTech.ToString());
                }

            }
        }
    }
}
