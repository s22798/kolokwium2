using kolokwium2.Services.AlbumService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace kolokwium2.Controllers
{
    [Route("api/albums")]
    [ApiController]
    public class AlbumController : ControllerBase
    {
        private readonly IAlbumDbService _albumdbService;
        public AlbumController(IAlbumDbService albumdbService)
        {
            _albumdbService = albumdbService;
        }

        [HttpGet("{idAlbum}")]
        public async Task<IActionResult> GetAlbumAndTracks(int idAlbum)
        {
            if (!await _albumdbService.IfAlbumExists(idAlbum)) return NotFound("Album not fuond");
            var alb = _albumdbService.GetAlbum(idAlbum);
            return Ok(alb);
        }


    }
}
