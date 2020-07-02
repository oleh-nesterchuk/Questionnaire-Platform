using AutoMapper;
using Questionnaire.Core.Abstractions;
using Questionnaire.Core.Abstractions.Services;
using Questionnaire.Core.Dto;
using Questionnaire.Core.Entities;
using Questionnaire.Core.Exceptions;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Questionnaire.Services
{
    public class QuestionService : IQuestionService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public QuestionService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<QuestionWithIdDto> GetFullQuestionByIdAsync(int id)
        {
            var question = await _unitOfWork.QuestionRepository.GetByIdAsync(id);
            if (question == null)
            {
                throw new ElementNotFoundException($"Question with id {id} has not been found.");
            }

            var dto = _mapper.Map<QuestionWithIdDto>(question);

            return dto;
        }

        public ICollection<QuestionWithIdDto> GetAllQuestions(int questionnaireId)
        {
            var questions = _unitOfWork.QuestionRepository.GetAll(questionnaireId);
            var dtos = _mapper.Map<ICollection<QuestionWithIdDto>>(questions);

            return dtos;
        }

        public async Task<QuestionWithIdDto> AddQuestionAsync(QuestionWithoutIdDto dto)
        {
            var question = _mapper.Map<Question>(dto);
            var questionWithId = await _unitOfWork.QuestionRepository.AddAsync(question);

            await _unitOfWork.SaveChangesAsync();

            var dtoWithId = _mapper.Map<QuestionWithIdDto>(questionWithId);

            return dtoWithId;
        }

        public async Task<QuestionWithIdDto> UpdateQuestionAsync(QuestionWithIdDto dto)
        {
            var question = _mapper.Map<Question>(dto);

            await _unitOfWork.QuestionRepository.UpdateAsync(question);
            await _unitOfWork.SaveChangesAsync();

            return dto;
        }

        public async Task DeleteQuestionAsync(int id)
        {
            _unitOfWork.QuestionRepository.DeleteById(id);

            await _unitOfWork.SaveChangesAsync();
        }
    }
}
