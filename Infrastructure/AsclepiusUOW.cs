using Infrastructure.Context;
using Microsoft.AspNetCore.Identity;

namespace Infrastructure
{
    public class AsclepiusUOW : IAsclepiusUOW
    {
        private AsclepiusContext Context { get; }  
        //public LookupRepository LookupRep { get; }
      
      

        public AsclepiusUOW(AsclepiusContext _context, UserManager<ApplicationUser> userManager)
        {
            this.Context = _context;
        }
        public AsclepiusUOW(AsclepiusContext _context)
        {
            this.Context = _context;
        }
        public void SaveChanges()
        {
            Context.SaveChanges();
        }
    }
}
