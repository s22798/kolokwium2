using kolokwium2.Models;
using kolokwium2.Models.DTO;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace kolokwium2.Services.AlbumService
{
    public class AlbumDbService : IAlbumDbService
    {
        private readonly MainDbContext _mainDbContext;
        public AlbumDbService(MainDbContext mainDbContext)
        {
            _mainDbContext = mainDbContext;
        }
        public async Task<AlbumModelDto> GetAlbum(int idAlbum)
        {
            return await _mainDbContext.Albums.Where(e => e.IdAlbum == idAlbum)
                .Select(e => new AlbumModelDto
                {
                    AlbumName = e.AlbumName,
                    PublishDate = e.PublishDate,
                    TrackModels = e.Tracks.Select(e => new TrackModelDto { TrackName = e.TrackName, Duration = e.Duration }).OrderBy(e => e.Duration).ToList()
                }).FirstAsync(); 
        }

        public async Task<bool> IfAlbumExists(int idAlbum)
        {
            return await _mainDbContext.Albums.Where(e => e.IdAlbum == idAlbum).AnyAsync();
        }
    }
}
