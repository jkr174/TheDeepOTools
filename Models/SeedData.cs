using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using TheDeepOTools.Data;
using TheDeepOTools.Models;

namespace TheDeepOTools.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new TheDeepOToolsContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<TheDeepOToolsContext>>()))
            {
                if (context.RepairTicket.Any())
                {
                    return;
                }
                context.RepairTicket.AddRange(
                    new RepairTicket
                    {
                        Title = "TitleTest1",
                        Description = "DescTest1",
                        TicketState = "Open",
                        OwnerId = "UserTest1"
                    },
                    new RepairTicket
                    {
                        Title = "TitleTest2",
                        Description = "DescTest2",
                        TicketState = "Closed",
                        OwnerId = "UserTest2"
                    }
                    );
                context.SaveChanges();
                
                if (context.Inventory.Any())
                {
                    return;
                }
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
}