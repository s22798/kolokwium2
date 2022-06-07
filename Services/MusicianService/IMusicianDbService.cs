using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace kolokwium2.Services.MusicianService
{
    public interface IMusicianDbService
    {
        Task DeleteMusician(int idMusician);
        Task<bool> IfMusiciansTrackInAnyAlbum(int idMusician);
    }
}
