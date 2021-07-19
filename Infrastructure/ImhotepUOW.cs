using Infrastructure.Context;
using Infrastructure.Repositories;
using Microsoft.AspNetCore.Identity;

namespace Infrastructure
{
    public class ImhotepUOW : IImhotepUOW
    {
        private ImhotepContext Context { get; }
        public PatientRepo PatientRepo { get; set; }

        public ImhotepUOW(ImhotepContext _context, UserManager<ApplicationUser> userManager)
        {
            this.Context = _context;
            this.PatientRepo = new PatientRepo(Context);
        }

        public ImhotepUOW(ImhotepContext _context)
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