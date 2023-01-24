using AutoMapper;
using JPS.API.IoC.MapperProfile.AnswerConverter;
using JPS.Domain.Entities.Entities;
using JPS.Services.DTO.DTOs.AnswerDTOs.CreateDTOs;
using JPS.Services.DTO.DTOs.CategoryDTOs;
using JPS.Services.DTO.DTOs.CreatePollWithAllQuestionsDTOs;
using JPS.Services.DTO.DTOs.OptionDTOs;
using JPS.Services.DTO.DTOs.OptionRowDTOs;
using JPS.Services.DTO.DTOs.PollDTOs;
using JPS.Services.DTO.DTOs.PollStyleDTOs;
using JPS.Services.DTO.DTOs.QuestionDTOs;
using JPS.Services.DTO.DTOs.QuestionSectionDTOs;

namespace JPS.API.IoC.MapperProfile
{
	/// <summary>
	/// Mapper profile for Domain models.
	/// </summary>
	public class DomainMapperProfile : Profile
	{
		public DomainMapperProfile()
		{
			// Questions
			CreateMap<QuestionDTO, QuestionEntity>()
				.ForMember(dest => dest.PrototypeQuestionId, opt => opt.Ignore())
				.ForMember(dest => dest.PrototypeQuestion, opt => opt.Ignore())
				.ForMember(dest => dest.QuestionClones, opt => opt.Ignore())
				.ForMember(dest => dest.QuestionSection, opt => opt.Ignore())
				.ForMember(dest => dest.QuestionType, opt => opt.Ignore());
			CreateMap<CreateQuestionDTO, QuestionEntity>()
				.ForMember(dest => dest.Id, opt => opt.Ignore())
				.ForMember(dest => dest.PrototypeQuestion, opt => opt.Ignore())
				.ForMember(dest => dest.PrototypeQuestionId, opt => opt.Ignore())
				.ForMember(dest => dest.QuestionClones, opt => opt.Ignore())
				.ForMember(dest => dest.QuestionSection, opt => opt.Ignore())
				.ForMember(dest => dest.QuestionType, opt => opt.Ignore())
				.ForMember(dest => dest.Options, opt => opt.Ignore())
				.ForMember(dest => dest.OptionRows, opt => opt.Ignore())
				.ForMember(dest => dest.Answers, opt => opt.Ignore());

			// QuestionSections
			CreateMap<CreateQuestionSectionDTO, QuestionSectionEntity>()
				.ForMember(dest => dest.Id, opt => opt.Ignore())
				.ForMember(dest => dest.Poll, opt => opt.Ignore())
				.ForMember(dest => dest.Questions, opt => opt.Ignore());

			// Polls
			CreateMap<PollDTO, PollEntity>()
				.ForMember(dest => dest.StartPollJobId, opt => opt.Ignore())
				.ForMember(dest => dest.EndPollJobId, opt => opt.Ignore())
				.ForMember(dest => dest.InProgressPollJobId, opt => opt.Ignore())
				.ForMember(dest => dest.Category, opt => opt.Ignore());
			CreateMap<CreatePollDTO, PollEntity>()
				.ForMember(dest => dest.Id, opt => opt.Ignore())
				.ForMember(dest => dest.StartPollJobId, opt => opt.Ignore())
				.ForMember(dest => dest.EndPollJobId, opt => opt.Ignore())
				.ForMember(dest => dest.InProgressPollJobId, opt => opt.Ignore())
				.ForMember(dest => dest.Category, opt => opt.Ignore())
				.ForMember(dest => dest.CreatedAt, opt => opt.Ignore())
				.ForMember(dest => dest.QuestionSections, opt => opt.Ignore());

			// PollStyle
			CreateMap<PollStyleDTO, PollStyleEntity>();

			// Answers
			CreateMap<PollAnswersDTO, AnswerEntity>().ConvertUsing(typeof(AnswerEntityConverter));
			CreateMap<CreateTimeAnswerDTO, TimeAnswerEntity>()
				.ForMember(dest => dest.Answer, opt => opt.Ignore())
				.ForMember(dest => dest.AnswerId, opt => opt.Ignore());
			CreateMap<CreateFileAnswerDTO, FileAnswerEntity>()
				.ForMember(dest => dest.Answer, opt => opt.Ignore())
				.ForMember(dest => dest.AnswerId, opt => opt.Ignore());
			CreateMap<CreateDateAnswerDTO, DateAnswerEntity>()
				.ForMember(dest => dest.Answer, opt => opt.Ignore())
				.ForMember(dest => dest.AnswerId, opt => opt.Ignore());
			CreateMap<CreateParagraphAnswerDTO, ParagraphAnswerEntity>()
				.ForMember(dest => dest.Answer, opt => opt.Ignore())
				.ForMember(dest => dest.AnswerId, opt => opt.Ignore());
			CreateMap<CreateTextAnswerDTO, TextAnswerEntity>()
				.ForMember(dest => dest.Answer, opt => opt.Ignore())
				.ForMember(dest => dest.AnswerId, opt => opt.Ignore());
			CreateMap<CreatePollOptionAnswerDTO, OptionAnswerEntity>()
				.ForMember(dest => dest.Answer, opt => opt.Ignore())
				.ForMember(dest => dest.AnswerId, opt => opt.Ignore())
				.ForMember(dest => dest.Id, opt => opt.Ignore())
				.ForMember(dest => dest.Option, opt => opt.Ignore())
				.ForMember(dest => dest.OptionRow, opt => opt.Ignore());

			// Categories
			CreateMap<CategoryDTO, CategoryEntity>()
				.ForMember(dest => dest.Categories, opt => opt.MapFrom(src => src.Children))
				.ForMember(dest => dest.Category, opt => opt.MapFrom(src => src.ParentCategory));

			//Options
			CreateMap<CreateOptionDTO, OptionEntity>()
				.ForMember(dest => dest.Id, opt => opt.Ignore())
				.ForMember(dest => dest.Question, opt => opt.Ignore())
				.ForMember(dest => dest.OptionAnswers, opt => opt.Ignore());

			//Rows
			CreateMap<CreateOptionRowDTO, OptionRowEntity>()
				.ForMember(dest => dest.Id, opt => opt.Ignore())
				.ForMember(dest => dest.Question, opt => opt.Ignore())
				.ForMember(dest => dest.OptionAnswers, opt => opt.Ignore());

			//PollsWithAllQuestions
			CreateMap<CreatePollWithQuestionSectionsDTO, PollEntity>()
				.ForMember(dest => dest.Id, opt => opt.Ignore())
				.ForMember(dest => dest.StartPollJobId, opt => opt.Ignore())
				.ForMember(dest => dest.EndPollJobId, opt => opt.Ignore())
				.ForMember(dest => dest.InProgressPollJobId, opt => opt.Ignore())
				.ForMember(dest => dest.Category, opt => opt.Ignore())
				.ForMember(dest => dest.CreatedAt, opt => opt.Ignore());
			CreateMap<CreateQuestionSectionWithQuestionsDTO, QuestionSectionEntity>()
				.ForMember(dest => dest.Id, opt => opt.Ignore())
				.ForMember(dest => dest.PollId, opt => opt.Ignore())
				.ForMember(dest => dest.Poll, opt => opt.Ignore());
			CreateMap<CreateQuestionsDTO, QuestionEntity>()
				.ForMember(dest => dest.Id, opt => opt.Ignore())
				.ForMember(dest => dest.QuestionSectionId, opt => opt.Ignore())
				.ForMember(dest => dest.PrototypeQuestion, opt => opt.Ignore())
				.ForMember(dest => dest.PrototypeQuestionId, opt => opt.Ignore())
				.ForMember(dest => dest.QuestionClones, opt => opt.Ignore())
				.ForMember(dest => dest.QuestionType, opt => opt.Ignore())
				.ForMember(dest => dest.QuestionSection, opt => opt.Ignore())
				.ForMember(dest => dest.Answers, opt => opt.Ignore());
			CreateMap<CreateOptionForQuestionDTO, OptionEntity>()
				.ForMember(dest => dest.Id, opt => opt.Ignore())
				.ForMember(dest => dest.Question, opt => opt.Ignore())
				.ForMember(dest => dest.QuestionId, opt => opt.Ignore())
				.ForMember(dest => dest.OptionAnswers, opt => opt.Ignore());
			CreateMap<CreateOptionRowForQuestionDTO, OptionRowEntity>()
				.ForMember(dest => dest.Id, opt => opt.Ignore())
				.ForMember(dest => dest.Question, opt => opt.Ignore())
				.ForMember(dest => dest.QuestionId, opt => opt.Ignore())
				.ForMember(dest => dest.OptionAnswers, opt => opt.Ignore());
		}
	}
}