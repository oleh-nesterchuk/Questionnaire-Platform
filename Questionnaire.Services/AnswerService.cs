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
    public class AnswerService : IAnswerService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public AnswerService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<AnswerWithIdDto> GetAnswerByIdAsync(int id)
        {
            var answer = await _unitOfWork.AnswerRepository.GetByIdAsync(id);
            if (answer == null)
            {
                throw new ElementNotFoundException($"Answer with id {id} has not been found.");
            }

            var dto = _mapper.Map<AnswerWithIdDto>(answer);

            return dto;
        }

        public ICollection<AnswerWithIdDto> GetAllAnswers(int questionId)
        {
            var answers = _unitOfWork.AnswerRepository.GetAll(questionId);
            var dtos = _mapper.Map<ICollection<AnswerWithIdDto>>(answers);

            return dtos;
        }

        public async Task<AnswerWithIdDto> AddAnswerAsync(AnswerWithoutIdDto dto)
        {
            var answer = _mapper.Map<Answer>(dto);
            var answerWithId = await _unitOfWork.AnswerRepository.AddAsync(answer);

            await _unitOfWork.SaveChangesAsync();

            var dtoWithId = _mapper.Map<AnswerWithIdDto>(answerWithId);

            return dtoWithId;
        }

        public async Task<AnswerWithIdDto> UpdateAnswerAsync(AnswerWithIdDto dto)
        {
            var answer = _mapper.Map<Answer>(dto);

            await _unitOfWork.AnswerRepository.UpdateAsync(answer);
            await _unitOfWork.SaveChangesAsync();

            return dto;
        }
        
        public async Task DeleteAnswerAsync(int id)
        {
            _unitOfWork.AnswerRepository.DeleteById(id);

            await _unitOfWork.SaveChangesAsync();
        }
    }
}
