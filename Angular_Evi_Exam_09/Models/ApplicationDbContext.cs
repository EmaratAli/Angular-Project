using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Angular_Evi_Exam_09.Models
{
    public class ApplicationDbContext:IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        public DbSet<Product>  Products { get; set; }
    }
    //public class ApplicationDbSecurityContext : IdentityDbContext
    //{
    //    public ApplicationDbSecurityContext(DbContextOptions<ApplicationDbSecurityContext> options) : base(options)
    //    {

    //    }
    //}
}
