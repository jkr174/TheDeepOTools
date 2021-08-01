using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using TheDeepOWebApp.Models;

namespace TheDeepOWebApp.Data
{
    public class ApplicationDbContext 
        : IdentityDbContext<AppUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Inventory> Inventory { get; set; }
        public UserState State { get; set; }
        public DbSet<RepairTicket> RepairTickets { get; set; }
        public DbSet<RepairTicketMessage> RepairTicketMessages { get; set; }
    }
}
