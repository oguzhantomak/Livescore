using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Livescore.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Livescore.Data.Concreate
{
    public class LiveScoreContext : DbContext
    {
        public LiveScoreContext()
        {

        }

        public LiveScoreContext(DbContextOptions<LiveScoreContext> options)
            : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            //builder.Entity<Match>()
            //    .HasOne(p => p.Round)
            //    .WithMany(b => b.Matches)
            //    .HasForeignKey(p => p.RoundId);

            //builder.Entity<Match>()
            //    .HasOne(p => p.Status)
            //    .WithMany(b => b.Matches)
            //    .HasForeignKey(p => p.StatusId);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                IConfigurationRoot configuration = new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile("appsettings.json")
                    .Build();
                var connectionString = configuration.GetConnectionString("Default");
                optionsBuilder.UseNpgsql(connectionString);
            }
        }

        public DbSet<Match> Matches { get; set; }
        public DbSet<Round> Rounds { get; set; }
        public DbSet<Score> Scores { get; set; }
        public DbSet<Stage> Stages { get; set; }
        public DbSet<Status> Status { get; set; }
        public DbSet<Team> Teams { get; set; }
        public DbSet<Times> Times { get; set; }
        public DbSet<Tournament> Tournaments { get; set; }
    }
}
