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
    public class QuestionnaireController : ControllerBase
    {
        private readonly IQuestionnaireService _questionnaireService;

        public QuestionnaireController(IQuestionnaireService questionnaireService)
        {
            _questionnaireService = questionnaireService;
        }

        [HttpGet]
        public ICollection<QuestionnaireInfoDto> Get()
        {
            return _questionnaireService.GetAllQuestionnaires();
        }

        [HttpGet("{id}")]
        [ElementNotFound]
        public async Task<FullQuestionnaireDto> Get(int id)
        {
            return await _questionnaireService.GetFullQuestionnaireByIdAsync(id);
        }

        [HttpPost]
        public async Task<QuestionnaireInfoDto> Post([FromBody] FullQuestionnaireDto questionnaireDto)
        {
            return await _questionnaireService.AddQuestionnaireAsync(questionnaireDto);
        }

        [HttpPut]
        public async Task<QuestionnaireInfoDto> Put([FromBody] QuestionnaireInfoDto questionnaireDto)
        {
            return await _questionnaireService.UpdateQuestionnaireAsync(questionnaireDto);
        }

        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            await _questionnaireService.DeleteQuestionnaireAsync(id);
        }
    }
}
