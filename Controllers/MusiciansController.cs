using kolokwium2.Services.MusicianService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace kolokwium2.Controllers
{
    [Route("api/musicians")]
    [ApiController]
    public class MusiciansController : ControllerBase
    {
        public readonly IMusicianDbService _musicianDbService;

        public MusiciansController(IMusicianDbService musicianDbService)
        {
            _musicianDbService = musicianDbService;
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteMusician(int idMusic)
        {
            if (!await _musicianDbService.IfMusiciansTrackInAnyAlbum(idMusic)) return BadRequest();
            await _musicianDbService.DeleteMusician(idMusic);
            return Ok("Deleted musician");
        }
    }
}
