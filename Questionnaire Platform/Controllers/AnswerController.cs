using Microsoft.AspNetCore.Mvc;
using Questionnaire.Api.Filters;
using Questionnaire.Core.Abstractions.Services;
using Questionnaire.Core.Dto;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Questionnaire.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnswerController : ControllerBase
    {
        private readonly IAnswerService _answerService;

        public AnswerController(IAnswerService answerService)
        {
            _answerService = answerService;
        }

        [HttpGet("all/{questionId}")]
        public ICollection<AnswerWithIdDto> Get(int questionId)
        {
            return _answerService.GetAllAnswers(questionId);
        }

        [HttpGet("{id}")]
        [ElementNotFound]
        public async Task<AnswerWithIdDto> GetById(int id)
        {
            return await _answerService.GetAnswerByIdAsync(id);
        }

        [HttpPost]
        public async Task<AnswerWithIdDto> Post([FromBody] AnswerWithoutIdDto answer)
        {
            return await _answerService.AddAnswerAsync(answer);
        }

        [HttpPut]
        public async Task<AnswerWithIdDto> Put([FromBody] AnswerWithIdDto answer)
        {
            return await _answerService.UpdateAnswerAsync(answer);
        }

        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            await _answerService.DeleteAnswerAsync(id);
        }
    }
}
