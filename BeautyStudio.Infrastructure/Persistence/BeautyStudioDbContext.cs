using BeautyStudio.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeautyStudio.Infrastructure.Persistence
{
    public class BeautyStudioDbContext : IdentityDbContext
    {
        public DbSet<Domain.Entities.BeautyStudio> BeautyStudios { get; set; }
        public DbSet<Visit> Visits { get; set; }
        public DbSet<Client> Clients { get; set; }

        public BeautyStudioDbContext(DbContextOptions<BeautyStudioDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Domain.Entities.BeautyStudio>(entity =>
            {
                entity.Property(s => s.Name)
                .HasMaxLength(80);

                entity.Property(s => s.EncodedName)
                .HasMaxLength(80);

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

            modelBuilder.Entity<Visit>(entity =>
            {
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
