using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using Lab1.Models;
namespace Lab1.Data
{
    public class ApplicationContext: DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {
        }
        public DbSet<UserModel> Users { get; set; }
        public DbSet<Department> Departments { get; set; }

    }
}
