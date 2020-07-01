using AutoMapper;
using Questionnaire.Core.Dto;

namespace Questionnaire.Core.Automapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Entities.Questionnaire, QuestionnaireInfoDto>().ReverseMap();
            CreateMap<Entities.Questionnaire, FullQuestionnaireDto>().ReverseMap();
        }
    }
}
