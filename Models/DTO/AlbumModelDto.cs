using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace kolokwium2.Models.DTO
{
    public class AlbumModelDto
    { 
        public string AlbumName { get; set; }
        public DateTime PublishDate { get; set; }
        public IEnumerable<TrackModelDto> TrackModels { get; set; }
    }
}
