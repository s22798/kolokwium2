using kolokwium2.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace kolokwium2.Services.MusicianService
{
    public class MusicianDbService : IMusicianDbService
    {
        private readonly MainDbContext _mainDbContext;
        public MusicianDbService(MainDbContext mainDbContext)
        {
            _mainDbContext = mainDbContext;
        }
        public async Task DeleteMusician(int idMusician)
        {
            using var transaction = _mainDbContext.Database.BeginTransaction();

            try
            {
                var mus = new Musician() { IdMusician = idMusician };
                _mainDbContext.Attach(mus);
                _mainDbContext.Remove(mus);

                await _mainDbContext.SaveChangesAsync();

                var mus2 = new MusicianTrack { IdMusician = idMusician };
                _mainDbContext.Attach(mus2);
                _mainDbContext.Remove(mus);

                await _mainDbContext.SaveChangesAsync();

                transaction.Commit();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString()) ;
            }
        }

        public async Task<bool> IfMusicianExists(int idMusician)
        {
            return await _mainDbContext.Musicians.Where(e=> e.IdMusician == idMusician).AnyAsync();
        }

        public async Task<bool> IfMusiciansTrackInAnyAlbum(int idMusician)
        {
            return await _mainDbContext.Tracks.Where(e => e.IdTrack == e.MusicianTracks.FirstOrDefault(e => e.IdMusician == idMusician).IdTrack).AnyAsync();
        }
    }
}
