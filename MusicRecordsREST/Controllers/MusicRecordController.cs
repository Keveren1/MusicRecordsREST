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

        private MusicRecordDBManager _recordManager;

        public MusicRecordController(MusicRecordContext context)
        {
            _recordManager = new MusicRecordDBManager(context);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpGet]
        public ActionResult<IEnumerable<MusicRecordManager>> Get([FromQuery] string? title, [FromQuery] string? artist,
            [FromQuery] int? duration, [FromQuery] int? publicationYear)
        {
            IEnumerable<MusicRecordsData>
                musicRecords = _recordManager.GetAll(title, artist, duration, publicationYear);
            if (musicRecords.Count() <= 0)
            {
                return NotFound();
            }
            else
            {
                return Ok(musicRecords);
            }
            //if(musicRecords.Count() <= 0)
        }
    }
}