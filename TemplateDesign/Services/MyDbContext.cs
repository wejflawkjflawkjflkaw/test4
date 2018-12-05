
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
//..
using Microsoft.EntityFrameworkCore;
using Project.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace Project.Services
{
    public class MyDbContext : IdentityDbContext
    {

        protected override void OnConfiguring(DbContextOptionsBuilder option)
        {
            option.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB; 
                                Database=EFDemoDB; 
                                Trusted_Connection=True");
        }

    }
}
