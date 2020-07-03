using Microsoft.AspNetCore.Mvc;
using Questionnaire.Core.Abstractions.Services;
using Questionnaire.Core.Dto;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Questionnaire.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuestionController : ControllerBase
    {
        private readonly IQuestionService _questionService;

        public QuestionController(IQuestionService questionService)
        {
            _questionService = questionService;
        }

        [HttpGet("all/{questionnaireId}")]
        public ICollection<QuestionWithIdDto> Get(int questionnaireId)
        {
            return _questionService.GetAllQuestions(questionnaireId);
        }

        [HttpGet("{id}")]
        public async Task<QuestionWithIdDto> GetById(int id)
        {
            return await _questionService.GetFullQuestionByIdAsync(id);
        }

        [HttpPost]
        public async Task<QuestionWithIdDto> Post([FromBody] QuestionWithoutIdDto question)
        {
            return await _questionService.AddQuestionAsync(question);
        }

        [HttpPut]
        public async Task<QuestionWithIdDto> Post([FromBody] QuestionWithIdDto question)
        {
            return await _questionService.UpdateQuestionAsync(question);
        }

        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            await _questionService.DeleteQuestionAsync(id);
        }
    }
}
