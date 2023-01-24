using AutoMapper;
using JPS.API.ViewModels.ViewModels.AnswerViewModels;
using JPS.API.ViewModels.ViewModels.AnswerViewModels.GroupedAnswersViewModel;
using JPS.API.ViewModels.ViewModels.CategoryViewModels;
using JPS.API.ViewModels.ViewModels.CreatePollWithAllQuestionsViewModels;
using JPS.API.ViewModels.ViewModels.OptionRowViewModels;
using JPS.API.ViewModels.ViewModels.OptionRowViewModels.UpdateViewModels;
using JPS.API.ViewModels.ViewModels.OptionViewModels;
using JPS.API.ViewModels.ViewModels.PollStyleViewModels;
using JPS.API.ViewModels.ViewModels.PollViewModels;
using JPS.API.ViewModels.ViewModels.PollViewModels.AnalyticsViewModels;
using JPS.API.ViewModels.ViewModels.PollViewModels.PollsWithContainedSectionsQuestionsViewModels;
using JPS.API.ViewModels.ViewModels.QuestionSectionViewModels;
using JPS.API.ViewModels.ViewModels.QuestionViewModels;
using JPS.Common;
using JPS.Services.DTO.DTOs.AnswerDTOs;
using JPS.Services.DTO.DTOs.AnswerDTOs.GetAnonymousDTOs;
using JPS.Services.DTO.DTOs.AnswerDTOs.GroupedAnswerDTOs;
using JPS.Services.DTO.DTOs.CategoryDTOs;
using JPS.Services.DTO.DTOs.CreatePollWithAllQuestionsDTOs;
using JPS.Services.DTO.DTOs.OptionDTOs;
using JPS.Services.DTO.DTOs.OptionRowDTOs;
using JPS.Services.DTO.DTOs.OptionRowDTOs.UpdateDTOs;
using JPS.Services.DTO.DTOs.PollDTOs;
using JPS.Services.DTO.DTOs.PollDTOs.AnalyticsDTOs;
using JPS.Services.DTO.DTOs.PollStyleDTOs;
using JPS.Services.DTO.DTOs.QuestionDTOs;
using JPS.Services.DTO.DTOs.QuestionSectionDTOs;

namespace JPS.API.IoC.MapperProfile
{
	/// <summary>
	/// Mapper profile for ViewModels.
	/// </summary>
	public class APIMapperProfile : Profile
	{
		public APIMapperProfile()
		{
			// Mapper settings
			AllowNullCollections = true;

			// Polls
			CreateMap<PollDTO, PollWithSectionsViewModel>();
			CreateMap<PollDTO, PollViewModel>();
			CreateMap<AnonymousPollDTO, PollWithSectionsViewModel>()
				.ForMember(dest => dest.QuestionSections,
					opt => opt.MapFrom(src => src.AnonymousQuestionSections));

			//PollStyle
			CreateMap<PollStyleDTO, PollStyleViewModel>();

			// Questions
			CreateMap<QuestionDTO, QuestionViewModel>();
			CreateMap<AnonymousQuestionDTO, QuestionWithOptionsRowsViewModel>();
			CreateMap<QuestionDTO, QuestionWithOptionsRowsViewModel>();
			CreateMap<OptionRowDTO, QuestionRowViewModel>();

			// QuestionSections
			CreateMap<QuestionSectionDTO, QuestionSectionViewModel>();
			CreateMap<QuestionSectionDTO, QuestionSectionWithQuestionsViewModel>();
			CreateMap<QuestionSectionDTO, SectionWithQuestionsViewModel>();
			CreateMap<AnonymousQuestionSectionDTO, SectionWithQuestionsViewModel>();

			// Answers
			CreateMap<AnswerDTO, AnswerViewModel>();
			CreateMap<AnonymousAnswerDTO, AnswerViewModel>()
				.ForMember(dest => dest.UserId, opt => opt.Ignore());
			CreateMap<FileAnswerDTO, FileAnswerViewModel>();
			CreateMap<TextAnswerDTO, TextAnswerViewModel>();
			CreateMap<ParagraphAnswerDTO, ParagraphAnswerViewModel>();
			CreateMap<TimeAnswerDTO, TimeAnswerViewModel>();
			CreateMap<DateAnswerDTO, DateAnswerViewModel>();
			CreateMap<OptionAnswerDTO, OptionAnswerViewModel>();

			//Grouped Answers
			CreateMap<GroupedAnswerDTO, GroupedAnswerViewModel>();
			CreateMap<GroupedTextAnswerDTO, GroupedTextAnswerViewModel>();
			CreateMap<GroupedDateAnswerDTO, GroupedDateAnswerViewModel>();
			CreateMap<GroupedParagraphAnswerDTO, GroupedParagraphAnswerViewModel>();
			CreateMap<GroupedFileAnswerDTO, GroupedFileAnswerViewModel>();
			CreateMap<GroupedTimeAnswerDTO, GroupedTimeAnswerViewModel>();
			CreateMap<GroupedOptionAnswerDTO, GroupedOptionAnswerViewModel>();
			CreateMap<GroupedGridAnswerDTO, GroupedGridAnswerViewModel>();

			// Categories
			CreateMap<CategoryDTO, CategoryViewModel>().ReverseMap();
			CreateMap<CategoriesTreeAndPollsDTO, CategoriesTreeAndPollsViewModel>();

			// Options
			CreateMap<QuestionOptionDTO, QuestionOptionViewModel>();
			CreateMap<OptionDTO, OptionViewModel>();

			//Rows
			CreateMap<OptionRowDTO, OptionRowViewModel>();
			CreateMap<CreateOptionRowDTO, CreateOptionRowViewModel>();
			CreateMap<UpdateOptionRowTextDTO, UpdateOptionRowTextViewModel>();
			CreateMap<UpdateOptionRowImageDTO, UpdateOptionRowImageViewModel>();
			CreateMap<UpdateOptionRowOrderDTO, UpdateOptionRowOrderViewModel>();

			//Pagination
			CreateMap<PagedList<PollDTO>, PagedList<PollViewModel>>();
			CreateMap<PagedList<PollDTO>, PagedList<PollWithSectionsViewModel>>();

			//PollsWithAllQuestions
			CreateMap<CreatePollWithQuestionSectionsDTO, CreatePollWithQuestionSectionsViewModel>();
			CreateMap<CreateQuestionSectionWithQuestionsDTO, CreateQuestionSectionWithQuestionsViewModel>();
			CreateMap<CreateQuestionsDTO, CreateQuestionsViewModel>();
			CreateMap<CreateOptionForQuestionDTO, CreateOptionForQuestionViewModel>();
			CreateMap<CreateOptionRowForQuestionDTO, CreateOptionRowForQuestionViewModel>();

			//Analytics
			CreateMap<PollAnalyticsDTO, PollAnalyticsViewModel>();
			CreateMap<QuestionAnalyticsDTO, QuestionAnalyticsViewModel>();
			CreateMap<PollAnalyticsWithoutQuestionsDTO, PollAnalyticsWithoutQuestionsViewModel>();
			CreateMap<PollComparisonDTO, PollsComparisonViewModel>();
		}
	}
}