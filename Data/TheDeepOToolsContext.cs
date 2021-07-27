using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TheDeepOTools.Models;

namespace TheDeepOTools.Data
{
    public class TheDeepOToolsContext : DbContext
    {
        public TheDeepOToolsContext (DbContextOptions<TheDeepOToolsContext> options)
            : base(options)
        {
        }

        public DbSet<TheDeepOTools.Models.Inventory> Inventory { get; set; }

        public DbSet<TheDeepOTools.Models.RepairTicket> RepairTicket { get; set; }

        public DbSet<TheDeepOTools.Models.RepairTicketMessage> RepairTicketMessage { get; set; }
    }
}
