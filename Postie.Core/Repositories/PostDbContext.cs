﻿using Microsoft.EntityFrameworkCore;
using Postie.Core.Models;

namespace Postie.Core.Repositories
{
    public class PostDbContext : DbContext
    {
        public DbSet<Post> Posts { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=localhost;Database=car_rental_efdb;Integrated Security=True;TrustServerCertificate=true;");
        }
    }
}
