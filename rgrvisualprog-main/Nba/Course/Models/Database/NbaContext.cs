using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Course.Models.Database
{
    public partial class NbaContext : DbContext
    {
        public NbaContext()
        {
        }

        public NbaContext(DbContextOptions<NbaContext> options)
            : base(options)
        {
        }

        public virtual DbSet<City> Cities { get; set; } = null!;
        public virtual DbSet<Club> Clubs { get; set; } = null!;
        public virtual DbSet<Conferen> Conferens { get; set; } = null!;
        public virtual DbSet<Division> Divisions { get; set; } = null!;
        public virtual DbSet<Match> Matches { get; set; } = null!;
        public virtual DbSet<Player> Players { get; set; } = null!;
        public virtual DbSet<StatsMatch> StatsMatches { get; set; } = null!;
        public virtual DbSet<StatsPlayerInMatch> StatsPlayerInMatches { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlite("Data Source=C:\\Users\\flexs\\OneDrive\\Рабочий стол\\Nba\\Course\\Nba.db");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<City>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("City");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("ID");

            });

            modelBuilder.Entity<Club>(entity =>
            {
                entity.ToTable("Club");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("ID");


                entity.Property(e => e.CityId).HasColumnName("City ID");

                entity.Property(e => e.DivisionId).HasColumnName("Division ID");

                entity.Property(e => e.ManagerId).HasColumnName("Manager ID");

                entity.Property(e => e.PlayerId).HasColumnName("Player ID");

                entity.Property(e => e.PresidentId).HasColumnName("President ID");

                entity.Property(e => e.StatsMatchId).HasColumnName("Stats match ID");

                entity.HasOne(d => d.DivisionNavigation)
                    .WithMany(p => p.Clubs)
                    .HasForeignKey(d => d.DivisionId);

                entity.HasOne(d => d.Player)
                    .WithMany(p => p.Clubs)
                    .HasForeignKey(d => d.PlayerId);

                entity.HasOne(d => d.StatsMatch)
                    .WithMany(p => p.Clubs)
                    .HasForeignKey(d => d.StatsMatchId);
            });

            modelBuilder.Entity<Conferen>(entity =>
            {
                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("ID");

            });

            modelBuilder.Entity<Division>(entity =>
            {
                entity.ToTable("Division");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("ID");

                entity.Property(e => e.ConfId).HasColumnName("Conf ID");

                entity.HasOne(d => d.Conf)
                    .WithMany(p => p.Divisions)
                    .HasForeignKey(d => d.ConfId);
            });

            modelBuilder.Entity<Match>(entity =>
            {
                entity.ToTable("Match");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("ID");

                entity.Property(e => e.Date).HasColumnType("DATE");

                entity.Property(e => e.PlayerId).HasColumnName("Player ID");

                entity.Property(e => e.StatsMatchId).HasColumnName("Stats match ID");

                entity.HasOne(d => d.Player)
                    .WithMany(p => p.Matches)
                    .HasForeignKey(d => d.PlayerId);

                entity.HasOne(d => d.StatsMatch)
                    .WithMany(p => p.Matches)
                    .HasForeignKey(d => d.StatsMatchId);
            });

            modelBuilder.Entity<Player>(entity =>
            {
                entity.ToTable("Player");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("ID");

                entity.Property(e => e.Colleges)
                    .HasColumnName("Colleges ");

                entity.Property(e => e.DateOfBirth)
                    .HasColumnType("DATE")
                    .HasColumnName("Date of Birth");

                entity.Property(e => e.HighSchool)
                    .HasColumnName("High School");

                entity.Property(e => e.StatsPlayerInMatchId).HasColumnName("Stats player in match ID");

                entity.HasOne(d => d.StatsPlayerInMatch)
                    .WithMany(p => p.Players)
                    .HasForeignKey(d => d.StatsPlayerInMatchId);
            });

            modelBuilder.Entity<StatsMatch>(entity =>
            {
                entity.ToTable("Stats match");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("ID");

                entity.Property(e => e.A4f)
                    .HasColumnType("DOUBLE")
                    .HasColumnName("A4F");

                entity.Property(e => e.APtsGm)
                    .HasColumnType("DOUBLE")
                    .HasColumnName("aPTS/GM");

                entity.Property(e => e.Conf)
                    .HasColumnName("CONF");

                entity.Property(e => e.Cons)
                    .HasColumnType("DOUBLE")
                    .HasColumnName("CONS");

                entity.Property(e => e.Deff)
                    .HasColumnType("DOUBLE")
                    .HasColumnName("DEFF");

                entity.Property(e => e.Division)
                    .HasColumnName("DIVISION");

                entity.Property(e => e.Ediff)
                    .HasColumnType("DOUBLE")
                    .HasColumnName("EDIFF");

                entity.Property(e => e.Gp)
                    .HasColumnType("DOUBLE")
                    .HasColumnName("GP");

                entity.Property(e => e.Oeff)
                    .HasColumnType("DOUBLE")
                    .HasColumnName("OEFF");

                entity.Property(e => e.Pace)
                    .HasColumnType("DOUBLE")
                    .HasColumnName("PACE");

                entity.Property(e => e.PtsDiff)
                    .HasColumnType("DOUBLE")
                    .HasColumnName("PTS DIFF");

                entity.Property(e => e.PtsGm)
                    .HasColumnType("DOUBLE")
                    .HasColumnName("PTS/GM");

                entity.Property(e => e.RSos)
                    .HasColumnType("DOUBLE")
                    .HasColumnName("rSOS");

                entity.Property(e => e.Sar)
                    .HasColumnType("DOUBLE")
                    .HasColumnName("SAR");

                entity.Property(e => e.Sos)
                    .HasColumnType("DOUBLE")
                    .HasColumnName("SOS");

                entity.Property(e => e.Win)
                    .HasColumnType("DOUBLE")
                    .HasColumnName("WIN%");
            });

            modelBuilder.Entity<StatsPlayerInMatch>(entity =>
            {
                entity.ToTable("Stats player in match");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("ID");

                entity.Property(e => e.Age)
                    .HasColumnType("DOUBLE")
                    .HasColumnName("AGE");

                entity.Property(e => e.Ft)
                    .HasColumnType("DOUBLE")
                    .HasColumnName("FT%");

                entity.Property(e => e.Fta)
                    .HasColumnType("DOUBLE")
                    .HasColumnName("FTA");

                entity.Property(e => e.Gp)
                    .HasColumnType("DOUBLE")
                    .HasColumnName("GP");

                entity.Property(e => e.MatchId).HasColumnName("Match ID");

                entity.Property(e => e.Min)
                    .HasColumnType("DOUBLE")
                    .HasColumnName("MIN%");

                entity.Property(e => e.Mpg)
                    .HasColumnType("DOUBLE")
                    .HasColumnName("MPG");

                entity.Property(e => e.Pos)
                    .HasColumnName("POS");

                entity.Property(e => e.To)
                    .HasColumnType("DOUBLE")
                    .HasColumnName("TO%");

                entity.Property(e => e.Usg)
                    .HasColumnType("DOUBLE")
                    .HasColumnName("USG%");

                entity.HasOne(d => d.Match)
                    .WithMany(p => p.StatsPlayerInMatches)
                    .HasForeignKey(d => d.MatchId);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
