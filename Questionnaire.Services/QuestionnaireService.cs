using AutoMapper;
using Questionnaire.Core.Abstractions;
using Questionnaire.Core.Abstractions.Services;
using Questionnaire.Core.Dto;
using Questionnaire.Core.Exceptions;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Questionnaire.Services
{
    public class QuestionnaireService : IQuestionnaireService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public QuestionnaireService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<FullQuestionnaireDto> GetFullQuestionnaireByIdAsync(int id)
        {
            var questionnaire = await _unitOfWork.QuestionnaireRepository.GetByIdAsync(id);
            if (questionnaire == null)
            {
                throw new ElementNotFoundException($"Questionnaire with id {id} has not been found.");
            }

            var dto = _mapper.Map<FullQuestionnaireDto>(questionnaire);

            return dto;
        }

        public ICollection<QuestionnaireInfoDto> GetAllQuestionnaires()
        {
            var questionnaires = _unitOfWork.QuestionnaireRepository.GetAll();
            var dtos = _mapper.Map<ICollection<QuestionnaireInfoDto>>(questionnaires);

            return dtos;
        }

        public async Task<QuestionnaireInfoDto> AddQuestionnaireAsync(FullQuestionnaireDto dto)
        {
            var questionnaireToAdd = _mapper.Map<Core.Entities.Questionnaire>(dto);

            var addedQuestionnaire = await _unitOfWork.QuestionnaireRepository.AddAsync(questionnaireToAdd);

            var dtoToReturn = _mapper.Map<QuestionnaireInfoDto>(addedQuestionnaire);

            await _unitOfWork.SaveChangesAsync();

            return dtoToReturn;
        }

        public async Task<QuestionnaireInfoDto> UpdateQuestionnaireAsync(QuestionnaireInfoDto dto)
        {
            var questionnaire = _mapper.Map<Core.Entities.Questionnaire>(dto);

            await _unitOfWork.QuestionnaireRepository.UpdateAsync(questionnaire);
            await _unitOfWork.SaveChangesAsync();

            return dto;
        }

        public async Task DeleteQuestionnaireAsync(int id)
        {
            _unitOfWork.QuestionnaireRepository.DeleteById(id);

            await _unitOfWork.SaveChangesAsync();
        }
    }
}
