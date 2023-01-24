using AutoMapper;
using JPS.Domain.Entities.Entities;
using JPS.Infrastructure.Context;
using JPS.Services.Constants;
using JPS.Services.DTO.DTOs.OptionDTOs;
using JPS.Services.DTO.DTOs.OptionDTOs.UpdateDTOs;
using JPS.Services.Enums;
using JPS.Services.Helpers;
using JPS.Services.Interfaces.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JPS.Services.Exceptions;

namespace JPS.Services.Services
{
	/// <summary>
	/// Implements IOptionService interface methods. 
	/// </summary>
	public class OptionService : IOptionService
	{
		private readonly JPSContext _context;
		private readonly IMapper _mapper;

		public OptionService(JPSContext context, IMapper mapper)
		{
			_context = context;
			_mapper = mapper;
		}

		/// <inheritdoc/>
		public async Task<OptionDTO> CreateOptionAsync(CreateOptionDTO optionDTO)
		{
			var questionEntity = await _context.Questions
				.Include(question => question.Options)
				.Include(question => question.Answers)
				.SingleOrDefaultAsync(question => question.Id == optionDTO.QuestionId);

			ValidationHelper.ValidateDoesItemExist(
				questionEntity, ExceptionMessageConstants.InvalidQuestionMessage);
			ValidateCanQuestionHaveOptions(questionEntity);
			ValidationHelper.ValidateQuestionHasNotAnswer(questionEntity);
			ValidateIsOptionOrderUnique(questionEntity.Options, optionDTO.Order);

			if (!optionDTO.Value.Equals(null))
			{
				ValidateIsQuestionOfScaleType(questionEntity);
				ValidateIsValueUnique(questionEntity.Options, optionDTO.Value);
			}

			var optionEntity = _mapper.Map<OptionEntity>(optionDTO);
			await _context.Options.AddAsync(optionEntity);
			await _context.SaveChangesAsync();
			var createdOptionDTO = _mapper.Map<OptionDTO>(optionEntity);
			return createdOptionDTO;
		}

		/// <inheritdoc/>
		public async Task<OptionDTO> UpdateOptionTextAsync(int id, UpdateOptionTextDTO optionDTO)
		{
			var questionEntity = await _context.Questions
				.Include(question => question.Options)
				.Include(question => question.Answers)
				.FirstOrDefaultAsync(question => question.Options.Any(option => option.Id == id));

			ValidationHelper.ValidateDoesItemExist(
				questionEntity, ExceptionMessageConstants.OptionNotFoundMessage);
			ValidationHelper.ValidateQuestionHasNotAnswer(questionEntity);

			var optionEntity = questionEntity.Options.SingleOrDefault(option => option.Id == id);

			ValidationHelper.ValidateDoesItemExist(
				optionEntity, ExceptionMessageConstants.UpdateNonexistentOptionMessage);

			optionEntity.Text = optionDTO.Text;
			await _context.SaveChangesAsync();
			var updatedOptionDTO = _mapper.Map<OptionDTO>(optionEntity);
			return updatedOptionDTO;
		}

		/// <inheritdoc/>
		public async Task<OptionDTO> UpdateOptionImageAsync(int id, UpdateOptionImageDTO optionDTO)
		{
			var questionEntity = await _context.Questions
				.Include(question => question.Options)
				.Include(question => question.Answers)
				.FirstOrDefaultAsync(question => question.Options.Any(option => option.Id == id));

			ValidationHelper.ValidateDoesItemExist(
				questionEntity, ExceptionMessageConstants.OptionNotFoundMessage);
			ValidationHelper.ValidateQuestionHasNotAnswer(questionEntity);

			var optionEntity = questionEntity.Options.SingleOrDefault(option => option.Id == id);

			ValidationHelper.ValidateDoesItemExist(
				optionEntity, ExceptionMessageConstants.UpdateNonexistentOptionMessage);

			optionEntity.ImageUrl = optionDTO.ImageUrl;
			await _context.SaveChangesAsync();

			var updatedOptionDTO = _mapper.Map<OptionDTO>(optionEntity);
			return updatedOptionDTO;
		}

		/// <inheritdoc/>
		public async Task<IEnumerable<OptionDTO>> UpdateOptionsOrderAsync(
			IEnumerable<UpdateOptionOrderDTO> optionDTOs)
		{
			var optionsToUpdateIds = optionDTOs.Select(option => option.Id);

			ValidationHelper.ValidateContainsCollectionDuplicates(optionsToUpdateIds,
				ExceptionMessageConstants.IdDuplicatedMessage);
			ValidationHelper.ValidateContainsCollectionDuplicates(
				optionDTOs.Select(option => option.Order), ExceptionMessageConstants.OrderDuplicatedMessage);
			await ValidateAreAllOptionsExist(optionsToUpdateIds);

			var firstOptionId = optionsToUpdateIds.First();
			var questionEntity = await _context.Questions
				.Include(question => question.Answers)
				.Include(question => question.Options)
				.FirstOrDefaultAsync(question => question.Options.Any(option => option.Id == firstOptionId));

			ValidationHelper.ValidateAreListsCountsEqual(questionEntity.Options, optionDTOs,
				ExceptionMessageConstants.QuestionContainsLessOrMoreOptions);
			ValidateAllOptionBelongSameQuestion(questionEntity, optionDTOs);
			ValidationHelper.ValidateQuestionHasNotAnswer(questionEntity);

			questionEntity.Options.ForEach(toUpdateOption => toUpdateOption.Order = optionDTOs
					.First(option => option.Id == toUpdateOption.Id).Order);

			await _context.SaveChangesAsync();
			var updatedOptionDTOs = _mapper.Map<IEnumerable<OptionDTO>>(questionEntity.Options);
			return updatedOptionDTOs;
		}

		/// <inheritdoc/>
		public async Task<OptionDTO> UpdateOptionValueAsync(int id, UpdateOptionValueDTO optionDTO)
		{
			var questionEntity = await _context.Questions
				.Include(question => question.Options)
				.Include(question => question.Answers)
				.FirstOrDefaultAsync(question => question.Options.Any(option => option.Id == id));

			ValidationHelper.ValidateDoesItemExist(
				questionEntity, ExceptionMessageConstants.OptionNotFoundMessage);
			ValidationHelper.ValidateQuestionHasNotAnswer(questionEntity);
			ValidateIsQuestionOfScaleType(questionEntity);

			ValidateIsValueUnique(questionEntity.Options, optionDTO.Value);

			var optionEntity = questionEntity.Options.SingleOrDefault(option => option.Id == id);

			optionEntity.Value = optionDTO.Value;
			await _context.SaveChangesAsync();
			var updatedOptionDTO = _mapper.Map<OptionDTO>(optionEntity);
			return updatedOptionDTO;
		}

		/// <inheritdoc/>
		public async Task DeleteOptionAsync(int id)
		{
			var questionEntity = await _context.Questions
				.Include(question => question.Options)
				.Include(question => question.Answers)
				.FirstOrDefaultAsync(question => question.Options.Any(option => option.Id == id));

			ValidationHelper.ValidateDoesItemExist(
				questionEntity, ExceptionMessageConstants.OptionNotFoundMessage);
			ValidationHelper.ValidateQuestionHasNotAnswer(questionEntity);

			var optionEntity = questionEntity.Options.SingleOrDefault(option => option.Id == id);

			_context.Remove(optionEntity);
			await _context.SaveChangesAsync();
		}

		private void ValidateCanQuestionHaveOptions(QuestionEntity questionEntity)
		{
			var questionType = questionEntity.QuestionTypeId;
			if (questionType != (int)QuestionTypes.MultipleChoice
				&& questionType != (int)QuestionTypes.CheckBoxes
				&& questionType != (int)QuestionTypes.Dropdown
				&& questionType != (int)QuestionTypes.LinearScale
				&& questionType != (int)QuestionTypes.MultipleChoiceGrid
				&& questionType != (int)QuestionTypes.CheckboxGrid)
			{
				throw new ArgumentException(ExceptionMessageConstants.InvalidQuestionOptionTypeMessage);
			}
		}

		private void ValidateIsOptionOrderUnique(IEnumerable<OptionEntity> questionOptions, int order)
		{
			var questionHasOrder = questionOptions.Any(option => option.Order == order);

			if (questionHasOrder)
			{
				throw new ArgumentException(ExceptionMessageConstants.InvalidOrderMessage);
			}
		}

		private void ValidateIsQuestionOfScaleType(QuestionEntity questionEntity)
		{
			var questionType = questionEntity.QuestionTypeId;
			if (questionType != (int)QuestionTypes.LinearScale)
			{
				throw new ArgumentException(ExceptionMessageConstants.NotScaleTypeMessage);
			}
		}

		private void ValidateIsValueUnique(IEnumerable<OptionEntity> questionOptions, decimal? value)
		{
			var questionHasValue = questionOptions.Any(option => option.Value == value);

			if (questionHasValue)
			{
				throw new ArgumentException(ExceptionMessageConstants.InvalidValueMessage);
			}
		}

		private void ValidateAllOptionBelongSameQuestion(QuestionEntity question,
			IEnumerable<UpdateOptionOrderDTO> optionsDTO)
		{
			var areOptionsForSameQuestion = question.Options
				.All(option => optionsDTO
					.Any(optionDTO => optionDTO.Id == option.Id));

			if (!areOptionsForSameQuestion)
			{
				throw new ArgumentException(ExceptionMessageConstants.InvalidOptionsToUpdateOrdersMessage);
			}
		}

		private async Task ValidateAreAllOptionsExist(IEnumerable<int> optionIds)
		{
			var dbOptionIdsCount = await _context.Options.CountAsync(option => optionIds.Contains(option.Id));
			if (dbOptionIdsCount != optionIds.Count())
			{
				throw new NotFoundException(ExceptionMessageConstants.OptionNotFoundMessage);
			}
		}
	}
}
