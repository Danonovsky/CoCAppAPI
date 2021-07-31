using DbLibrary.Models.User;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DbLibrary.DAL
{
    public class CoCDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        public CoCDbContext(DbContextOptions<CoCDbContext> options) : base(options) { }
    }
}
