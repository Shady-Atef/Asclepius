using Domain.PatientAggregate;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Context
{
    public class ImhotepContext : IdentityDbContext<ApplicationUser, IdentityRole<long>, long>
    {
        public ImhotepContext(DbContextOptions<ImhotepContext> options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            optionsBuilder.UseLazyLoadingProxies();
        }

        public DbSet<Patient> Patient { get; set; }
    }
}