using BeautyStudio.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeautyStudio.Infrastructure.Persistence
{
    public class BeautyStudioDbContext : DbContext
    {
        public DbSet<Domain.Entities.BeautyStudio> BeautyStudios { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Visit> Visits { get; set; }
        public DbSet<Client> Clients { get; set; }

        public BeautyStudioDbContext(DbContextOptions<BeautyStudioDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Domain.Entities.BeautyStudio>(entity =>
            {
                entity.Property(s => s.Name)
                .HasMaxLength(80);

                entity.Property(s => s.EncodedName)
                .HasMaxLength(80);

                entity.HasOne(s => s.Owner)
                .WithMany(o => o.OwnStudios)
                .HasForeignKey(s => s.OwnerId)
                .OnDelete(DeleteBehavior.NoAction);

                entity.HasMany(s => s.Employees)
                .WithMany(e => e.StudiosWhereWorks);
            });

            modelBuilder.Entity<Client>(entity =>
            {
                entity.Property(c => c.FirstName)
                .HasMaxLength(80);

                entity.Property(c => c.LastName)
                .HasMaxLength(80);

                entity.Property(c => c.PhoneNumber)
                .HasMaxLength(15);

                entity.HasOne(c => c.BeautyStudio)
                .WithMany(s => s.Clients)
                .HasForeignKey(c => c.BeautyStudioId);
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.Property(r => r.Name)
                .HasColumnType("varchar(50)");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasIndex(u => u.Login, "login_UNIQUE")
                .IsUnique();

                entity.HasIndex(u => u.Email, "email_UNIQUE")
                .IsUnique();

                entity.Property(u => u.FirstName)
                .HasMaxLength(80);

                entity.Property(u => u.LastName)
                .HasMaxLength(80);

                entity.Property(u => u.PhoneNumber)
                .HasMaxLength(15);

                entity.Property(u => u.Login)
                .HasMaxLength(80);

                entity.Property(u => u.Email)
                .HasMaxLength(80);

                entity.Property(u => u.Password)
                .HasColumnType("varchar(255)");

                entity.HasMany(u => u.Roles)
                .WithMany(r => r.Users);

            });

            modelBuilder.Entity<Visit>(entity =>
            {
                entity.HasOne(v => v.Beautician)
                .WithMany(b => b.AssignedVisits)
                .HasForeignKey(v => v.BeauticianId);

                entity.HasOne(v => v.BeautyStudio)
                .WithMany(s => s.Visits)
                .HasForeignKey(v => v.BeautyStudioId);

                entity.HasOne(v => v.Client)
                .WithMany(c => c.Visits)
                .HasForeignKey(v => v.ClientId)
                .OnDelete(DeleteBehavior.NoAction);
            });
        }

    }
}
