using AutoMapper;
using Azure.Storage;
using Azure.Storage.Blobs.Models;
using Azure.Storage.Sas;
using JPS.Domain.Entities.Entities;
using JPS.Infrastructure.Context;
using JPS.Services.Constants;
using JPS.Services.DTO.DTOs.CreatePollWithAllQuestionsDTOs;
using JPS.Services.DTO.DTOs.PollDTOs;
using JPS.Services.DTO.DTOs.UtilsDTO;
using JPS.Services.Interfaces.Interfaces;
using JPS.Services.Interfaces.ModelInterfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JPS.Services.Services
{
	/// <summary>
	/// Implements IUtilsService interface methods.
	/// Contains method to create poll with all questions.
	/// </summary>
	public class UtilsService : IUtilsService
	{
		private readonly JPSContext _context;
		private readonly IMapper _mapper;
		private readonly IAzureBlobStorageOptions _blobStorageOptions;

		public UtilsService(JPSContext context, IMapper mapper, 
			IAzureBlobStorageOptions blobStorageOptions)
		{
			_context = context;
			_mapper = mapper;
			_blobStorageOptions = blobStorageOptions;

		}

		public BlobStorageCredentialsDTO GenerateSasTokenForBlobStorage()
		{
			var key = _blobStorageOptions.AccountKey;
			var sharedKeyCredentials = new StorageSharedKeyCredential(_blobStorageOptions.AccountName, key);
			var sasBuilder = new AccountSasBuilder()
			{
				StartsOn = DateTimeOffset.UtcNow,
				ExpiresOn = DateTimeOffset.UtcNow.AddMinutes(5),
				Services = AccountSasServices.Blobs,
				ResourceTypes = AccountSasResourceTypes.All,
				Protocol = SasProtocol.Https
			};
			sasBuilder.SetPermissions(AccountSasPermissions.All);

			var sasToken = sasBuilder.ToSasQueryParameters(sharedKeyCredentials).ToString();
			var credentials = new BlobStorageCredentialsDTO { 
				StorageUri = _blobStorageOptions.BlobUri,
				StorageAccessToken = sasToken
			};

			return credentials;
		}

		/// <inheritdoc/>
		public async Task<PollDTO> CreatePollWithQuestionsAsync(CreatePollWithQuestionSectionsDTO createPollDTO)
		{
			var pollEntity = _mapper.Map<PollEntity>(createPollDTO);

			await ValidateDoesCategoryExistAsync(createPollDTO.CategoryId);

			await _context.Polls.AddAsync(pollEntity);
			await _context.SaveChangesAsync();
			var pollDTO = _mapper.Map<PollDTO>(pollEntity);
			return pollDTO;
		}

		/// <inheritdoc/>
		public async Task DeleteUserPollAnswersAsync(string userId, int pollId)
		{
			var answerEntities = await _context.Answers
				.Include(answer => answer.OptionAnswers)
				.Include(answer => answer.TextAnswer)
				.Include(answer => answer.TimeAnswer)
				.Include(answer => answer.ParagraphAnswer)
				.Include(answer => answer.DateAnswer)
				.Include(answer => answer.FileAnswer)
				.Where(answers => answers.UserId == userId && answers.Question.QuestionSection.PollId == pollId)
				.ToListAsync();

			var textAnswers = answerEntities.Where(answer => answer.TextAnswer != null)
				.Select(answer => answer.TextAnswer).ToList();
			_context.TextAnswers.RemoveRange(textAnswers);

			var paragraphAnswers = answerEntities.Where(answer => answer.ParagraphAnswer != null)
				.Select(answer => answer.ParagraphAnswer).ToList();
			_context.ParagraphAnswers.RemoveRange(paragraphAnswers);

			var timeAnswers = answerEntities.Where(answer => answer.TimeAnswer != null)
				.Select(answer => answer.TimeAnswer).ToList();
			_context.TimeAnswers.RemoveRange(timeAnswers);

			var dateAnswers = answerEntities.Where(answer => answer.DateAnswer != null)
				.Select(answer => answer.DateAnswer).ToList();
			_context.DateAnswers.RemoveRange(dateAnswers);

			var fileAnswers = answerEntities.Where(answer => answer.FileAnswer != null)
				.Select(answer => answer.FileAnswer).ToList();
			_context.FileAnswers.RemoveRange(fileAnswers);

			var optionAnswers = answerEntities.Where(answer => answer.OptionAnswers.Any())
				.SelectMany(answer => answer.OptionAnswers).ToList();
			_context.OptionAnswers.RemoveRange(optionAnswers);

			_context.Answers.RemoveRange(answerEntities);

			await _context.SaveChangesAsync();
		}

		private async Task ValidateDoesCategoryExistAsync(int? categoryId)
		{
			if (categoryId != null)
			{
				var doesCategoryExist = await _context.Categories
					.AnyAsync(category => category.Id == categoryId);

				if (!doesCategoryExist)
				{
					throw new ArgumentException(ExceptionMessageConstants.InvalidCategoryIdMessage);
				}
			}
		}
	}
}
