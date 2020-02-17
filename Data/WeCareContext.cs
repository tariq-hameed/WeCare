using Microsoft.EntityFrameworkCore;
using System;
using WeCare.Data.Entities;

namespace WeCare.Data
{
    public class WeCareContext : DbContext
    {
        public DbSet<Patient> Patient { get; set; }

        public DbSet<Journal> Journal { get; set; }

        public WeCareContext(DbContextOptions<WeCareContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            var patient = new Patient(1, "Frans", "Engström", "890101-2010");

            builder.Entity<Patient>()
                .HasData(patient);

            var journal = new Journal(1, patient.Id);

            builder.Entity<Journal>()
                .HasData(journal);

            var journalEntry1 = new JournalEntry(1, @"
                Patient feels uneasy and restless. Administered 5 ml of valium.
            ", new DateTime(2020, 1, 3, 12, 15, 0), journal.Id);

            builder.Entity<JournalEntry>()
                .HasData(journalEntry1);

            var journalEntry2 = new JournalEntry(2, @"
                Patient complaining about not being able to sleep.
            ", new DateTime(2020, 1, 14, 8, 30, 0), journal.Id);

            builder.Entity<JournalEntry>()
                .HasData(journalEntry2);

            var journalEntry3 = new JournalEntry(3, @"
                Patient returns for checkup, feeling much better now.
            ", new DateTime(2020, 1, 23, 15, 15, 0), journal.Id);

            builder.Entity<JournalEntry>()
                .HasData(journalEntry3);
        }
    }
}

