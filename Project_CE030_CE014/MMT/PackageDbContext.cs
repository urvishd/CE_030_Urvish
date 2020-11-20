using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MMT.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MMT
{
    public class PackageDbContext:IdentityDbContext<IdentityUser>
    {
        public PackageDbContext(DbContextOptions<PackageDbContext> options)
            : base(options)
        {

        }
        public DbSet<packages> Packages { get; set; }

        public DbSet<ApplicationUser> applicationUsers { get; set; }

        public DbSet<Dcard> Cards { get; set; }
        public DbSet<Netbanking> Netbankings { get; set; }

        public DbSet<Booking> Bookings { get; set; }
    }
}
