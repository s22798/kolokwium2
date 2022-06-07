using kolokwium2.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace kolokwium2.Services.AlbumService
{
    public interface IAlbumDbService
    {
        Task<AlbumModelDto> GetAlbum(int idAlbum);
        Task<bool> IfAlbumExists(int idAlbum);
    }
}
