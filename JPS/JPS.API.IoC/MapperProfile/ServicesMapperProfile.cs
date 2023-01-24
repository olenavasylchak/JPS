using AutoMapper;
using JPS.API.ViewModels.ViewModels.AnswerViewModels.CreateViewModels;
using JPS.API.ViewModels.ViewModels.AnswerViewModels.UpdateAllAnswersInPollViewModel;
using JPS.API.ViewModels.ViewModels.CategoryViewModels;
using JPS.API.ViewModels.ViewModels.CategoryViewModels.UpdateViewModels;
using JPS.API.ViewModels.ViewModels.CreatePollWithAllQuestionsViewModels;
using JPS.API.ViewModels.ViewModels.OptionRowViewModels;
using JPS.API.ViewModels.ViewModels.OptionRowViewModels.UpdateViewModels;
using JPS.API.ViewModels.ViewModels.OptionViewModels;
using JPS.API.ViewModels.ViewModels.OptionViewModels.UpdateViewModels;
using JPS.API.ViewModels.ViewModels.PollStyleViewModels;
using JPS.API.ViewModels.ViewModels.PollStyleViewModels.UpdatePollStyleViewModels;
using JPS.API.ViewModels.ViewModels.PollViewModels;
using JPS.API.ViewModels.ViewModels.PollViewModels.UpdateViewModels;
using JPS.API.ViewModels.ViewModels.QuestionSectionViewModels;
using JPS.API.ViewModels.ViewModels.QuestionSectionViewModels.UpdateViewModels;
using JPS.API.ViewModels.ViewModels.QuestionViewModels;
using JPS.API.ViewModels.ViewModels.QuestionViewModels.UpdateViewModels;
using JPS.API.ViewModels.ViewModels.UtilsViewModels;
using JPS.Common;
using JPS.Domain.Entities.Entities;
using JPS.Services.DTO.DTOs;
using JPS.Services.DTO.DTOs.AnswerDTOs;
using JPS.Services.DTO.DTOs.AnswerDTOs.CreateDTOs;
using JPS.Services.DTO.DTOs.AnswerDTOs.GetAnonymousDTOs;
using JPS.Services.DTO.DTOs.AnswerDTOs.GroupedAnswerDTOs;
using JPS.Services.DTO.DTOs.CategoryDTOs;
using JPS.Services.DTO.DTOs.CreatePollWithAllQuestionsDTOs;
using JPS.Services.DTO.DTOs.OptionDTOs;
using JPS.Services.DTO.DTOs.OptionDTOs.UpdateDTOs;
using JPS.Services.DTO.DTOs.OptionRowDTOs;
using JPS.Services.DTO.DTOs.OptionRowDTOs.UpdateDTOs;
using JPS.Services.DTO.DTOs.PollDTOs;
using JPS.Services.DTO.DTOs.PollDTOs.AnalyticsDTOs;
using JPS.Services.DTO.DTOs.PollDTOs.UpdateDTOs;
using JPS.Services.DTO.DTOs.PollStyleDTOs;
using JPS.Services.DTO.DTOs.PollStyleDTOs.UpdateDTOs;
using JPS.Services.DTO.DTOs.QuestionDTOs;
using JPS.Services.DTO.DTOs.QuestionDTOs.UpdateDTOs;
using JPS.Services.DTO.DTOs.QuestionSectionDTOs;
using JPS.Services.DTO.DTOs.QuestionSectionDTOs.UpdateDTOs;
using JPS.Services.DTO.DTOs.UserDTOs;
using JPS.Services.DTO.DTOs.UtilsDTO;
using JPS.Services.Services._Utils;
using Microsoft.Graph;

namespace JPS.API.IoC.MapperProfile
{
	/// <summary>
	/// Mapper profile for DTOs.
	/// </summary>
	public class ServicesMapperProfile : Profile
	{
		public ServicesMapperProfile()
		{
			// Mapper settings
			AllowNullCollections = true;

			// Polls
			CreateMap<PollViewModel, PollDTO>()
				.ForMember(dest => dest.QuestionSections, opt => opt.Ignore());
			CreateMap<CreatePollViewModel, CreatePollDTO>();
			CreateMap<UpdatePollCategoryIdViewModel, UpdatePollCategoryIdDTO>();
			CreateMap<UpdatePollTitleViewModel, UpdatePollTitleDTO>();
			CreateMap<UpdatePollDescriptionViewModel, UpdatePollDescriptionDTO>();
			CreateMap<UpdatePollStartDateViewModel, UpdatePollStartDateDTO>();
			CreateMap<UpdatePollFinishDateViewModel, UpdatePollFinishDateDTO>();
			CreateMap<UpdatePollIsAnonymousViewModel, UpdatePollIsAnonymousDTO>();
			CreateMap<PollEntity, PollDTO>();
			CreateMap<PollEntity, AnonymousPollDTO>()
				.ForMember(dest => dest.QuestionSections, opt => opt.Ignore())
				.ForMember(dest => dest.AnonymousQuestionSections, opt => opt.MapFrom(src => src.QuestionSections));

			//PollStyle
			CreateMap<PollStyleEntity, PollStyleDTO>();
			CreateMap<CreatePollStyleViewModel, PollStyleDTO>()
				.ForMember(dest=>dest.PollId, opt=>opt.Ignore());
			CreateMap<UpdatePollFontViewModel, UpdatePollFontDTO>();
			CreateMap<UpdatePollThemeColorViewModel, UpdatePollThemeColorDTO>();
			CreateMap<UpdatePollOpacityViewModel, UpdatePollOpacityDTO>();
			CreateMap<UpdatePollImageViewModel, UpdatePollImageDTO>();
			CreateMap<UpdatePollImageCoordinatesViewModel, UpdatePollImageCoordinatesDTO>();	

			// Questions
			CreateMap<QuestionEntity, QuestionDTO>();
			CreateMap<QuestionEntity, AnonymousQuestionDTO>();
			CreateMap<CreateQuestionViewModel, CreateQuestionDTO>();
			CreateMap<UpdateQuestionTextViewModel, UpdateQuestionTextDTO>();
			CreateMap<UpdateQuestionIsRequiredViewModel, UpdateQuestionIsRequiredDTO>();
			CreateMap<UpdateQuestionCommentViewModel, UpdateQuestionCommentDTO>();
			CreateMap<UpdateQuestionOrderViewModel, UpdateQuestionOrderDTO>();
			CreateMap<UpdateQuestionTypeIdViewModel, UpdateQuestionTypeIdDTO>();
			CreateMap<UpdateQuestionImageUrlViewModel, UpdateQuestionImageUrlDTO>();
			CreateMap<UpdateQuestionVideoUrlViewModel, UpdateQuestionVideoUrlDTO>();
			CreateMap<UpdateQuestionCanHaveOtherOptionViewModel, UpdateQuestionCanHaveOtherOptionDTO>();

			// QuestionSections
			CreateMap<QuestionSectionViewModel, QuestionSectionDTO>()
				.ForMember(dest => dest.Questions, opt => opt.Ignore());
			CreateMap<UpdateQuestionSectionIdViewModel, UpdateQuestionSectionIdDTO>();
			CreateMap<CreateQuestionSectionViewModel, CreateQuestionSectionDTO>();
			CreateMap<QuestionSectionEntity, AnonymousQuestionSectionDTO>();
			CreateMap<QuestionSectionEntity, QuestionSectionDTO>();
			CreateMap<QuestionSectionEntity, CreateQuestionSectionDTO>();
			CreateMap<UpdateQuestionSectionTitleViewModel, UpdateQuestionSectionTitleDTO>();
			CreateMap<UpdateQuestionSectionDescriptionViewModel, UpdateQuestionSectionDescriptionDTO>();
			CreateMap<UpdateQuestionSectionOrderViewModel, UpdateQuestionSectionOrderDTO>();

			// Answers
			CreateMap<AnswerEntity, AnswerDTO>();
			CreateMap<AnswerEntity, AnonymousAnswerDTO>();
			CreateMap<TextAnswerEntity, TextAnswerDTO>();
			CreateMap<TimeAnswerEntity, TimeAnswerDTO>();
			CreateMap<DateAnswerEntity, DateAnswerDTO>();
			CreateMap<ParagraphAnswerEntity, ParagraphAnswerDTO>();
			CreateMap<FileAnswerEntity, FileAnswerDTO>();
			CreateMap<OptionAnswerEntity, OptionAnswerDTO>();

			CreateMap<CreateTimeAnswerViewModel, CreateTimeAnswerDTO>();
			CreateMap<CreateDateAnswerViewModel, CreateDateAnswerDTO>();
			CreateMap<CreateTextAnswerViewModel, CreateTextAnswerDTO>();
			CreateMap<CreateParagraphAnswerViewModel, CreateParagraphAnswerDTO>();
			CreateMap<CreatePollAnswersViewModel, CreatePollAnswersDTO>();
			CreateMap<PollAnswersViewModel, PollAnswersDTO>()
				.ForMember(dest => dest.UserId, opt => opt.Ignore());
			CreateMap<CreateOptionAnswerViewModel, CreatePollOptionAnswerDTO>()
				.ForMember(dest => dest.OptionRowId, opt => opt.Ignore());
			CreateMap<CreateGridOptionAnswerViewModel, CreatePollOptionAnswerDTO>();
			CreateMap<CreateFileAnswerViewModel, CreateFileAnswerDTO>();


			// Categories
			CreateMap<CategoryEntity, CategoryDTO>()
				.ForMember(dest => dest.Children, opt => opt.MapFrom(src => src.Categories))
				.ForMember(dest => dest.ParentCategory, opt => opt.MapFrom(src => src.Category));
			CreateMap<UpdateCategoryTitleViewModel, CategoryDTO>()
				.ForMember(dest => dest.Id, opt => opt.Ignore())
				.ForMember(dest => dest.ParentCategoryId, opt => opt.Ignore())
				.ForMember(dest => dest.ParentCategory, opt => opt.Ignore())
				.ForMember(dest => dest.CreatedAt, opt => opt.Ignore())
				.ForMember(dest => dest.Children, opt => opt.Ignore())
				.ForMember(dest => dest.Polls, opt => opt.Ignore());
			CreateMap<UpdateCategoryParentViewModel, CategoryDTO>()
				.ForMember(dest => dest.Id, opt => opt.Ignore())
				.ForMember(dest => dest.Title, opt => opt.Ignore())
				.ForMember(dest => dest.ParentCategory, opt => opt.Ignore())
				.ForMember(dest => dest.CreatedAt, opt => opt.Ignore())
				.ForMember(dest => dest.Children, opt => opt.Ignore())
				.ForMember(dest => dest.Polls, opt => opt.Ignore());
			CreateMap<UpdateCategoryParentViewModel, UpdateCategoryParentDTO>();
			CreateMap<CreateCategoryViewModel, CategoryDTO>()
				.ForMember(dest => dest.Id, opt => opt.Ignore())
				.ForMember(dest => dest.ParentCategory, opt => opt.Ignore())
				.ForMember(dest => dest.CreatedAt, opt => opt.Ignore())
				.ForMember(dest => dest.Children, opt => opt.Ignore())
				.ForMember(dest => dest.Polls, opt => opt.Ignore());

			// Options
			CreateMap<OptionEntity, QuestionOptionDTO>();
			CreateMap<OptionEntity, OptionDTO>();
			CreateMap<CreateOptionViewModel, CreateOptionDTO>();
			CreateMap<UpdateOptionTextViewModel, UpdateOptionTextDTO>();
			CreateMap<UpdateOptionImageViewModel, UpdateOptionImageDTO>();
			CreateMap<UpdateOptionOrderViewModel, UpdateOptionOrderDTO>();
			CreateMap<UpdateOptionValueViewModel, UpdateOptionValueDTO>();

			//Rows
			CreateMap<OptionRowViewModel, OptionRowDTO>();
			CreateMap<OptionRowEntity, OptionRowDTO>();
			CreateMap<CreateOptionRowViewModel, CreateOptionRowDTO>();
			CreateMap<UpdateOptionRowTextViewModel, UpdateOptionRowTextDTO>();
			CreateMap<UpdateOptionRowImageViewModel, UpdateOptionRowImageDTO>();
			CreateMap<UpdateOptionRowOrderViewModel, UpdateOptionRowOrderDTO>();

			//Pagination
			CreateMap<PaginationQuery, PaginationDTO>();
			CreateMap<PagedList<PollEntity>, PagedList<PollDTO>>();

			//PollsWithAllQuestions
			CreateMap<CreatePollWithQuestionSectionsViewModel, CreatePollWithQuestionSectionsDTO>();
			CreateMap<CreateQuestionSectionWithQuestionsViewModel, CreateQuestionSectionWithQuestionsDTO>();
			CreateMap<CreateQuestionsViewModel, CreateQuestionsDTO>();
			CreateMap<CreateOptionForQuestionViewModel, CreateOptionForQuestionDTO>();
			CreateMap<CreateOptionRowForQuestionViewModel, CreateOptionRowForQuestionDTO>();

			// Users
			CreateMap<User, UserDTO>()
				.ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.DisplayName));
				
			//Utils
			CreateMap<BlobStorageCredentialsDTO, BlobStorageCredentialsViewModel>();

			//Analyticcs
			CreateMap<PollEntity, PollAnalyticsDTO>()
				.ForMember(dest => dest.Questions, opt => opt.Ignore())
				.ForMember(dest => dest.Progress, opt => opt.Ignore());
			CreateMap<PollEntity, PollAnalyticsWithoutQuestionsDTO>()
				.ForMember(dest => dest.Progress, opt => opt.Ignore());
			CreateMap<QuestionEntity, QuestionAnalyticsDTO>()
				.ForMember(dest => dest.GroupedAnswers, opt => opt.Ignore());
			CreateMap<OptionEntity, GroupedOptionAnswerDTO>()
				.ForMember(dest =>dest.OptionAnswer, opt => opt.MapFrom(src =>src))
				.ForMember(dest => dest.Count, opt => opt.Ignore())
				.ForMember(dest => dest.PercentageToAlreadyAnswered, opt => opt.Ignore())
				.ForMember(dest => dest.PercentageToAll, opt => opt.Ignore());
		}
	}
}
