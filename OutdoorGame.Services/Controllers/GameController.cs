using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OutdoorGame.Services.Application.Dto;
using OutdoorGame.Services.Core.Entity;
using OutdoorGame.Services.Core.Repositories;

namespace OutdoorGame.Services.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GameController : ControllerBase
    {
        private readonly IGameRepository _repository;

        public GameController(IGameRepository repository)
            => _repository = repository;

        [HttpGet]
        [ProducesResponseType(typeof(GamesDto), StatusCodes.Status200OK)]
        public async Task<IActionResult> Get() 
            => Ok((await _repository.Get()).AsDto());

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> Get(Guid id) 
            => Ok((await _repository.Get(id)).AsDto());

        [HttpPost("AddGame")]
        [ProducesResponseType(StatusCodes.Status202Accepted)]
        public async Task<IActionResult> AddGame(Game game)
        {
            await _repository.Add(game);
            return Accepted();
        }
    }
}
