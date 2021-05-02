
using Microsoft.AspNetCore.Identity;
namespace Kadry.Db
{
    public class AppUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        //public string UserName { get; set; }
        //public string Email { get; set; }

    }
}
