using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MyChat.Domain.Model;
namespace MyChat.Server.Infrastructure
{
    public class AppDbContext: DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options){}

        public virtual DbSet<Message> Messages { get; set; }
        public virtual DbSet<Room> Rooms { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            // ===========
            // # MESSAGE #
            // ===========
            modelBuilder.Entity<Message>().ToTable("Messages");
            modelBuilder.Entity<Message>().HasKey(p => p.id);
            modelBuilder.Entity<Message>()
            .Property(p => p.id)
            .ValueGeneratedOnAdd();

            // ========
            // # ROOM #
            // ========
            modelBuilder.Entity<Room>().ToTable("Rooms");
            modelBuilder.Entity<Room>().HasKey(p => p.id);
            modelBuilder.Entity<Room>()
            .Property(p => p.id)
            .ValueGeneratedOnAdd();

            modelBuilder.Entity<Room>()
            .HasMany(r => r.messages)
            .WithOne(r => r.room);

            modelBuilder.Entity<Room>()
            .HasMany(r => r.users)
            .WithOne(r => r.room);


            // ========
            // # USER #
            // ========
            modelBuilder.Entity<User>().ToTable("Users");
            modelBuilder.Entity<User>().HasKey(p => p.id);
            modelBuilder.Entity<User>()
            .Property(p => p.id)
            .ValueGeneratedOnAdd();

            modelBuilder.Entity<User>()
            .HasMany(r => r.messages)
            .WithOne(r => r.user);
        }
    }
}

