using System;
using System.Collections.Generic;
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
    public class QuestionController : ControllerBase
    {
        readonly IQuestionRepository _repository;

        public QuestionController(IQuestionRepository repository) => _repository = repository;


        [HttpGet()]
        [ProducesResponseType(typeof(List<QuestionDto>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetGame([FromQuery] List<Guid> ids)
            => base.Ok((await _repository.GetAsync(ids)).AsDto());

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status202Accepted)]
        public async Task<IActionResult> CheckAnswer(Answer answer) 
            => Accepted(_repository.CheckAsync(answer));

        [HttpPost("AddQuestion")]
        [ProducesResponseType(StatusCodes.Status202Accepted)]
        public async Task<IActionResult> AddQuestion(Question question)
        {
            await _repository.AddAsync(question);
            return Accepted();
        } 

    }
}
