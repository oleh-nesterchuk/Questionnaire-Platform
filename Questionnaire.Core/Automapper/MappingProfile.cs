using AutoMapper;
using Questionnaire.Core.Dto;
using Questionnaire.Core.Entities;

namespace Questionnaire.Core.Automapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Entities.Questionnaire, QuestionnaireInfoDto>().ReverseMap();
            CreateMap<Entities.Questionnaire, FullQuestionnaireDto>().ReverseMap();

            CreateMap<Question, QuestionWithIdDto>().ReverseMap();
            CreateMap<Question, QuestionWithoutIdDto>().ReverseMap();

            CreateMap<Answer, AnswerWithIdDto>().ReverseMap();
        }
    }
}
