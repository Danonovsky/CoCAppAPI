using DbLibrary.Models.Character;
using DbLibrary.Models.Characteristic;
using DbLibrary.Models.Game;
using DbLibrary.Models.Item;
using DbLibrary.Models.Skill;
using DbLibrary.Models.User;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DbLibrary.DAL
{
    public class CoCDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Game> Games { get; set; }
        public DbSet<GamePlayer> GamePlayers { get; set; }
        public DbSet<Character> Characters { get; set; }
        public DbSet<DefaultCharacteristic> DefaultCharacteristics { get; set; }
        public DbSet<Characteristic> Characteristics { get; set; }
        public DbSet<DefaultSkill> DefaultSkills { get; set; }
        public DbSet<Skill> Skills { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<ItemAttributeValue> ItemAttributeValues { get; set; }
        public DbSet<ItemType> ItemTypes { get; set; }
        public DbSet<ItemTypeAttribute> ItemTypeAttributes { get; set; }


        public CoCDbContext(DbContextOptions<CoCDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            /*modelBuilder.Entity<GamePlayer>()
                .HasOne(e => e.User)
                .WithMany(e => e.GamePlayers)
                .HasForeignKey(x => x.UserId)
                .OnDelete(DeleteBehavior.NoAction);*/
            foreach(var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            {
                relationship.DeleteBehavior = DeleteBehavior.Restrict;
            }
        }
    }
}
