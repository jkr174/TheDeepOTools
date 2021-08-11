/* Name:    Jovany Romo
 * Date:    7/26/2021
 * Summary: User class to use for Identity.
 * 
 * Outputs: Get's and Set's the user's name, username, and profile picture.
 */

using Microsoft.AspNetCore.Identity;

namespace TheDeepOTools.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int UsernameChangeLimit { get; set; } = 10;
        public byte[] ProfilePicture { get; set; }
    }
}
