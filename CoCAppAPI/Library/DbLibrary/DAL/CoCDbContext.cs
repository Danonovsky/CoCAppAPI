using DbLibrary.Models.Game;
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

        public DbSet<Game> Games { get; set; }

        public CoCDbContext(DbContextOptions<CoCDbContext> options) : base(options) { }
    }
}
