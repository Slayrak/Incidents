using System;
using System.Collections.Generic;
using System.Text;

using Microsoft.EntityFrameworkCore;

using Incidents.Domain;
using Incidents.Domain.Entities;

namespace Incidents.Infrastructure
{
    public class IncidentsDbContext : DbContext
    {
        public IncidentsDbContext(DbContextOptions<IncidentsDbContext> dbContextOptions)
            : base(dbContextOptions)
        { }

        public DbSet<Account> Accounts { get; set; }

        public DbSet<Incident> Incidents { get; set; }

        public DbSet<Contact> Contacts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Account>()
                .HasIndex(x => x.AccountName)
                .IsUnique();

            modelBuilder.Entity<Contact>()
                .HasIndex(x => x.Email)
                .IsUnique();

            modelBuilder.Entity<Incident>()
                .HasKey(x => x.IncidentName);

            modelBuilder.Entity<Account>()
                .HasMany(x => x.Contacts)
                .WithOne(x => x.Account);

            modelBuilder.Entity<Incident>()
                .HasMany(x => x.Accounts)
                .WithOne(x => x.Incident);

        }
    }
}
