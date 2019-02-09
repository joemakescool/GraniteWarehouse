using System;
using System.Collections.Generic;
using System.Text;
using GraniteWarehouse.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace GraniteWarehouse.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        //give ablity to link to database behind the scences Mapping model to physcial talbe in database

        public DbSet<ProductTypes> ProductTypes { get; set; } //give ablity to link to database behind the scences Mapping model to physcial talbe in database
        public DbSet<SpecialTags> SpecialTags { get; set; } // link special tags to database behind the scences
        public DbSet<Products> Products { get; set; } //update?
    }
}
