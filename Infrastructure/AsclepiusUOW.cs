using Infrastructure.Context;
using Infrastructure.Repositories;
using Microsoft.AspNetCore.Identity;

namespace Infrastructure
{
    public class AsclepiusUOW : IAsclepiusUOW
    {
        private AsclepiusContext Context { get; }
        public PatientRepo PatientRepo { get; set; }

        public AsclepiusUOW(AsclepiusContext _context, UserManager<ApplicationUser> userManager)
        {
            this.Context = _context;
            this.PatientRepo = new PatientRepo(Context);
        }

        public AsclepiusUOW(AsclepiusContext _context)
        {
            this.Context = _context;
            this.PatientRepo = new PatientRepo(Context);
        }

        public void SaveChanges()
        {
            Context.SaveChanges();
        }
    }
}