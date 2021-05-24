using Domain.ApplicationUserAggregate;
using Domain.NotificationSettingAggregate;
using Infrastructure.Context;
using Infrastructure.Repositories;
using Infrastructure.Repositories.Views;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
