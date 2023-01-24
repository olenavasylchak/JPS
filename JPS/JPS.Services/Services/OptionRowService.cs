using AutoMapper;
using JPS.Domain.Entities.Entities;
using JPS.Infrastructure.Context;
using JPS.Services.Constants;
using JPS.Services.DTO.DTOs.OptionRowDTOs;
using JPS.Services.DTO.DTOs.OptionRowDTOs.UpdateDTOs;
using JPS.Services.Enums;
using JPS.Services.Exceptions;
using JPS.Services.Helpers;
using JPS.Services.Interfaces.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JPS.Services.Services
{
	/// <summary>
	/// Service fot the row entity, contains bl and validation.
	/// </summary>
	public class OptionRowService : IOptionRowService
	{
		private readonly JPSContext _context;
		private readonly IMapper _mapper;

		public OptionRowService(JPSContext context, IMapper mapper)
		{
			_context = context;
			_mapper = mapper;
		}

		/// <inheritdoc cref="IOptionRowService"/>
		public async Task<OptionRowDTO> CreateOptionRowAsync(CreateOptionRowDTO createOptionRowDTO)
		{
			var questionEntity = await _context.Questions
				.Include(question => question.OptionRows)
				.Include(question => question.Answers)
				.SingleOrDefaultAsync(question => question.Id == createOptionRowDTO.QuestionId);

			ValidationHelper.ValidateDoesItemExist(
				questionEntity, ExceptionMessageConstants.CreateRowWithNonexistentQuestionMessage);
			ValidationHelper.ValidateQuestionHasNotAnswer(questionEntity);
			await ValidateIsQuestionGridType(createOptionRowDTO.QuestionId);
			await ValidateOrderDoesNotRepeat(createOptionRowDTO.Order, createOptionRowDTO.QuestionId);

			var optionRowEntity = _mapper.Map<OptionRowEntity>(createOptionRowDTO);
			await _context.OptionRows.AddAsync(optionRowEntity);
			await _context.SaveChangesAsync();

			var optionRowDTO = _mapper.Map<OptionRowDTO>(optionRowEntity);
			return optionRowDTO;
		}

		/// <inheritdoc cref="IOptionRowService"/>
		public async Task<OptionRowDTO> UpdateOptionRowTextAsync(UpdateOptionRowTextDTO updateOptionRowTextDTO, int id)
		{
			var questionEntity = await _context.Questions
				.Include(question => question.OptionRows)
				.Include(question => question.Answers)
				.FirstOrDefaultAsync(question => question.OptionRows.Any(row => row.Id == id));

			ValidationHelper.ValidateDoesItemExist(
				questionEntity, ExceptionMessageConstants.RowNotFoundMessage);
			ValidationHelper.ValidateQuestionHasNotAnswer(questionEntity);

			var optionRowEntityToUpdate = questionEntity.OptionRows.SingleOrDefault(row => row.Id == id);

			ValidationHelper.ValidateDoesItemExist(
				optionRowEntityToUpdate, ExceptionMessageConstants.UpdateNonexistentRowMessage);

			optionRowEntityToUpdate.Text = updateOptionRowTextDTO.Text;
			await _context.SaveChangesAsync();

			var updatedOptionRowDTO = _mapper.Map<OptionRowDTO>(optionRowEntityToUpdate);
			return updatedOptionRowDTO;
		}

		/// <inheritdoc cref="IOptionRowService"/>
		public async Task<OptionRowDTO> UpdateOptionRowImageAsync(UpdateOptionRowImageDTO updateOptionRowImageDTO, int id)
		{
			var questionEntity = await _context.Questions
				.Include(question => question.OptionRows)
				.Include(question => question.Answers)
				.FirstOrDefaultAsync(question => question.OptionRows.Any(row => row.Id == id));

			ValidationHelper.ValidateDoesItemExist(
				questionEntity, ExceptionMessageConstants.RowNotFoundMessage);
			ValidationHelper.ValidateQuestionHasNotAnswer(questionEntity);

			var optionRowEntityToUpdate = questionEntity.OptionRows.SingleOrDefault(row => row.Id == id);

			ValidationHelper.ValidateDoesItemExist(
				optionRowEntityToUpdate, ExceptionMessageConstants.UpdateNonexistentRowMessage);

			optionRowEntityToUpdate.ImageUrl = updateOptionRowImageDTO.ImageUrl;
			await _context.SaveChangesAsync();

			var updatedOptionRowDTO = _mapper.Map<OptionRowDTO>(optionRowEntityToUpdate);
			return updatedOptionRowDTO;
		}

		/// <inheritdoc/>
		public async Task<IEnumerable<OptionRowDTO>> UpdateOptionRowsOrderAsync(
			IEnumerable<UpdateOptionRowOrderDTO> optionRowDTOs)
		{
			var optionRowsToBeUpdatedIds = optionRowDTOs.Select(row => row.Id).ToList();

			ValidationHelper.ValidateContainsCollectionDuplicates(optionRowsToBeUpdatedIds,
				ExceptionMessageConstants.IdDuplicatedMessage);
			ValidationHelper.ValidateContainsCollectionDuplicates(
				optionRowDTOs.Select(row => row.Order), ExceptionMessageConstants.OrderDuplicatedMessage);
			await ValidateAreAllOptionRowsExist(optionRowsToBeUpdatedIds);

			var firstOptionRowId = optionRowsToBeUpdatedIds.First();
			var questionEntity = await _context.Questions
				.Include(question => question.Answers)
				.Include(question => question.OptionRows)
				.SingleOrDefaultAsync(question => question.OptionRows
					.Any(row => row.Id == firstOptionRowId));

			ValidationHelper.ValidateQuestionHasNotAnswered(questionEntity);
			ValidationHelper.ValidateAreListsCountsEqual(questionEntity.OptionRows, optionRowDTOs,
				ExceptionMessageConstants.QuestionContainsLessOrMoreRows);
			ValidateAllOptionRowsBelongSameQuestion(questionEntity, optionRowDTOs);

			questionEntity.OptionRows.ForEach(rowEntity => rowEntity.Order = optionRowDTOs
				.First(rowDTO => rowEntity.Id == rowDTO.Id).Order);
			await _context.SaveChangesAsync();

			var updatedOptionRows = _mapper.Map<IEnumerable<OptionRowDTO>>(questionEntity.OptionRows);
			return updatedOptionRows;
		}

		/// <inheritdoc cref="IOptionRowService"/>
		public async Task DeleteOptionRowAsync(int id)
		{
			var questionEntity = await _context.Questions
				.Include(question => question.OptionRows)
				.Include(question => question.Answers)
				.FirstOrDefaultAsync(question => question.OptionRows.Any(row => row.Id == id));

			ValidationHelper.ValidateDoesItemExist(
				questionEntity, ExceptionMessageConstants.RowNotFoundMessage);
			ValidationHelper.ValidateQuestionHasNotAnswer(questionEntity);

			var optionRowEntity = questionEntity.OptionRows.SingleOrDefault(row => row.Id == id);

			ValidationHelper.ValidateDoesItemExist(
				optionRowEntity, ExceptionMessageConstants.UpdateNonexistentRowMessage);

			_context.OptionRows.Remove(optionRowEntity);
			await _context.SaveChangesAsync();
		}

		private void ValidateAllOptionRowsBelongSameQuestion(QuestionEntity questionEntity,
			IEnumerable<UpdateOptionRowOrderDTO> optionRowDTOs)
		{
			var areRowsForSeveralQuestions = optionRowDTOs
				.Any(optionRow =>
					!questionEntity.OptionRows
						.Select(option => option.Id).Contains(optionRow.Id));

			if (areRowsForSeveralQuestions)
			{
				throw new ArgumentException(
					ExceptionMessageConstants.InvalidOptionsToUpdateOrdersMessage);
			}
		}

		private async Task ValidateIsQuestionGridType(int questionId)
		{
			var isQuestionGridType = await _context.Questions
				.AnyAsync(question => (question.QuestionTypeId == (int)QuestionTypes.CheckboxGrid
									   || question.QuestionTypeId == (int)QuestionTypes.MultipleChoiceGrid) &&
									  question.Id == questionId);

			if (!isQuestionGridType)
			{
				throw new InvalidOperationException(
					ExceptionMessageConstants.CreateRowToWrongQuestionTypeMessage);

			}
		}

		private async Task ValidateOrderDoesNotRepeat(int order, int questionId)
		{
			var questionHasRowOrder = await _context.OptionRows
					.Where(row => row.QuestionId == questionId)
					.AnyAsync(row => row.Order == order);
			if (questionHasRowOrder)
			{
				throw new ArgumentException(ExceptionMessageConstants.CreateRowWithExistedOrderMessage);
			}
		}

		private async Task ValidateAreAllOptionRowsExist(IEnumerable<int> rowIds)
		{
			var dbRowIdsCount = await _context.OptionRows.CountAsync(row => rowIds.Contains(row.Id));
			if (dbRowIdsCount != rowIds.Count())
			{
				throw new NotFoundException(ExceptionMessageConstants.RowNotFoundMessage);
			}
		}
	}
}
