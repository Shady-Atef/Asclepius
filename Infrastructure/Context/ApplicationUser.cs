using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace Infrastructure.Context
{
    public class ApplicationUser : IdentityUser<long>
    {
        public bool IsDeleted { get; private set; }

        [ConcurrencyCheck]
        public long Version { get; set; }
    }
}