using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace kolokwium2.Models
{
    public class MainDbContext : DbContext
    {
        public MainDbContext(DbContextOptions options) : base(options)
        {
        }

        protected MainDbContext()
        {
        }

        public DbSet<Album> Albums { get; set; }
        public DbSet<Musician> Musicians { get; set; }
        public DbSet<MusicianTrack> MusicianTracks { get; set; }
        public DbSet<MusicLabel> MusicLabels { get; set; }
        public DbSet<Track> Tracks { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Album>(a =>
            {
                a.HasKey(e => e.IdAlbum);
                a.Property(e => e.AlbumName).IsRequired().HasMaxLength(30);
                a.Property(e => e.PublishDate).IsRequired();

                a.HasOne(e => e.MusicLabel).WithMany(e => e.Albums).HasForeignKey(e => e.IdMusicLabel);

                a.HasData(new Album { IdAlbum = 1, AlbumName = "Hall of fame", PublishDate = DateTime.Parse("2020-05-03"), IdMusicLabel = 1 });
            });

            modelBuilder.Entity<MusicLabel>(m =>
            {
                m.HasKey(e => e.IdMusicLabel);
                m.Property(e => e.Name).IsRequired().HasMaxLength(50);

                m.HasData(new MusicLabel { IdMusicLabel = 1, Name = "Capalot" });
            });

            modelBuilder.Entity<Track>(t =>
            {
                t.HasKey(e => e.IdTrack);
                t.Property(e => e.TrackName).IsRequired().HasMaxLength(20);
                t.Property(e => e.Duration).IsRequired();

                t.HasOne(e => e.Album).WithMany(e => e.Tracks).HasForeignKey(e => e.IdMusicAlbum);

                t.HasData(new Track { IdTrack = 1, TrackName = "33", Duration = 3, IdMusicAlbum = 1 },
                   new Track { IdTrack = 2, TrackName = "21", Duration = 3, IdMusicAlbum = 1 });
            });

            modelBuilder.Entity<MusicianTrack>(m =>
            {
                m.HasKey(e => new { e.IdMusician, e.IdTrack });

                m.HasOne(e => e.Musician).WithMany(e => e.MusicianTracks).HasForeignKey(e => e.IdMusician);
                m.HasOne(e => e.Track).WithMany(e => e.MusicianTracks).HasForeignKey(e => e.IdTrack).IsRequired(false);

                m.HasData(new MusicianTrack { IdTrack = 1, IdMusician = 1 });
            });

            modelBuilder.Entity<Musician>(m =>
            {
                m.HasKey(e => e.IdMusician);
                m.Property(e => e.FirstName).IsRequired().HasMaxLength(30);
                m.Property(e => e.LastName).IsRequired().HasMaxLength(50);
                m.Property(e => e.NickName).HasMaxLength(20);

                m.HasData(new Musician { IdMusician = 1, FirstName = "Taurus", LastName = "Bartlett", NickName = "Polo G" });
            });
        }
    }
}
