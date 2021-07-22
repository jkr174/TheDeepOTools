using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TheDeepOWebApp.Models
{
    public class RepairTicket
    {
        [Key]
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        private int charLimit = 10;
        public string DescLimit
        {
            get
            {
                if (Description.Length > charLimit)
                    return Description.Substring(0, charLimit) + "...";
                else
                    return Description;
            }
        }
        public string TitleLimit
        {
            get
            {
                if (Title.Length > charLimit)
                    return Description.Substring(0, charLimit) + "...";
                else
                    return Title;
            }
        }
        public TicketState State { get; set; }
        public string OwnerId { get; set; }
        public ApplicationUser Owner { get; set; }
        public IEnumerable<RepairTicketMessage> Messages { get; set; }
    }
}
