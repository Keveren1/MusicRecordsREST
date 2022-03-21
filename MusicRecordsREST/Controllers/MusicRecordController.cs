using Microsoft.AspNetCore.Mvc;
using MusicRecordsREST.Manager;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Http;
using MusicRecordsREST.Models;


namespace MusicRecordsREST.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    public class MusicRecordController : Controller
    {
        private MusicRecordManager _recordManager = new MusicRecordManager();

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpGet]
        public ActionResult<IEnumerable<MusicRecordManager>> Get([FromQuery] string title, [FromQuery] string artist,
            [FromQuery] int duration, [FromQuery] int publicationYear)
        {
            IEnumerable<MusicRecordsData>
                musicRecords = _recordManager.GetAll(title, artist, duration, publicationYear);
            return Ok(musicRecords);
            //if(musicRecords.Count() <= 0)
        }


    }
}