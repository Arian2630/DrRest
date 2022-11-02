using DrRest.Managers;
using DrRest.Models;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace DrRest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MusicController : Controller
    {
        private readonly MusicManager _manager = new MusicManager();

        [HttpGet]
        public IEnumerable<Music> Get(string? searchString)
        {
            return _manager.GetAll(searchString);
        }
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpGet("{id}")]
        public ActionResult<Music> Get(int id)
        {
            Music musics = _manager.GetById(id);
            if (musics == null) return NotFound("Id does not match a song" + id);
            return Ok(musics);
        }
        [HttpPost]
        
        public ActionResult<Music> Post([FromBody] Music value)
        {
            Music musics = _manager.Add(value);
            if (musics == null) return NotFound("The server successfully processed the request, and is not returning any content.");
            return Ok(musics);
        }
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public Music Put(int id, [FromBody] Music value)
        {
            //if (_manager.GetAll().Select(v => v.Id).Contains(id))
            //{
            //    _manager.Update(id, value);
            //    return Ok("Song Updated");
            //}
            //else
            //{
            //    return NotFound();
            //}
            return _manager.Update(id, value);
        }
        [HttpDelete("{id}")]
        
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public ActionResult<Music> Delete(int id)
        { 
            Music musics = _manager.GetById(id);
            if (musics == null) return NotFound("Id does not match a song" + id);
             _manager.Delete(id); 
            return Ok("Song Deleted");
        }

    }
}
