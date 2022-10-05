using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Assignment4.Managers;
using Assignment4.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Assignment4.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FootballPlayersController : ControllerBase
    {
        private readonly FootballPlayersManager _manager = new FootballPlayersManager();

        // GET: api/<FootballPlayersController>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpGet]
        public ActionResult<FootballPlayer> Get()
        {
            List<FootballPlayer> list = _manager.GetAll();
            if (list == null) return NotFound("No players");
            return Ok(list);
        }

        // GET api/<FootballPlayersController>/5
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpGet("{id}")]
        public ActionResult<FootballPlayer> Get(int id)
        {
            FootballPlayer player = _manager.GetById(id);
            if (player == null) return NotFound("No such player. id: " + id);
            return Ok(player);
        }

        // POST api/<FootballPlayersController>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpPost]
        public ActionResult<FootballPlayer> Post([FromBody] FootballPlayer value)
        {
            FootballPlayer player = _manager.Add(value);
            if (player == null) return NotFound("No player to add");
            return Ok(player);

        }

        // PUT api/<FootballPlayersController>/5
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpPut("{id}")]
        public ActionResult<FootballPlayer> Put(int id, [FromBody] FootballPlayer value)
        {
            FootballPlayer player = _manager.Update(id, value);
            if (player == null) return NotFound("No value to update");
            return Ok(player);
        }

        // DELETE api/<FootballPlayersController>/5
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpDelete("{id}")]
        public ActionResult<FootballPlayer> Delete(int id)
        {
            FootballPlayer player = _manager.Delete(id);
            if (player == null) return NotFound("No player to delete");
            return Ok(player);
        }
    }
}
