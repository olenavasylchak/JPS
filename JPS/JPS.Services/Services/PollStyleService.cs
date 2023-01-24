using AutoMapper;
using JPS.Infrastructure.Context;
using JPS.Services.Constants;
using JPS.Services.DTO.DTOs.PollStyleDTOs;
using JPS.Services.DTO.DTOs.PollStyleDTOs.UpdateDTOs;
using JPS.Services.Helpers;
using JPS.Services.Interfaces.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace JPS.Services.Services
{
	/// <summary>
	/// Implements IPollStyleService interface methods. 
	/// </summary>
	public class PollStyleService: IPollStyleService
	{
		private readonly JPSContext _context;
		private readonly IMapper _mapper;

		public PollStyleService(JPSContext context, IMapper mapper)
		{
			_context = context;
			_mapper = mapper;
		}

		/// <inheritdoc/>			
		public async Task<PollStyleDTO> UpdatePollFontAsync(int id, UpdatePollFontDTO pollFontDTO)
		{
			var pollEntity = await _context.Polls
				.Include(poll => poll.PollStyle)
				.SingleOrDefaultAsync(poll => poll.Id == id);

			ValidationHelper.ValidateDoesItemExist(
				pollEntity, ExceptionMessageConstants.NotFoundObjectMessage);

			var pollStyleEntity = pollEntity.PollStyle;
			pollStyleEntity.Font = pollFontDTO.Font;
			await _context.SaveChangesAsync();

			var updatedPollStyleDTO = _mapper.Map<PollStyleDTO>(pollStyleEntity);

			return updatedPollStyleDTO;
		}

		/// <inheritdoc/>			
		public async Task<PollStyleDTO> UpdatePollThemeColorAsync(int id, UpdatePollThemeColorDTO pollThemeColorDTO)
		{
			var pollEntity = await _context.Polls
				.Include(poll => poll.PollStyle)
				.SingleOrDefaultAsync(poll => poll.Id == id);

			ValidationHelper.ValidateDoesItemExist(
				pollEntity, ExceptionMessageConstants.NotFoundObjectMessage);

			var pollStyleEntity = pollEntity.PollStyle;
			pollStyleEntity.ThemeColor = pollThemeColorDTO.ThemeColor;
			await _context.SaveChangesAsync();

			var updatedPollStyleDTO = _mapper.Map<PollStyleDTO>(pollStyleEntity);

			return updatedPollStyleDTO;
		}

		/// <inheritdoc/>			
		public async Task<PollStyleDTO> UpdatePollOpacityAsync(int id, UpdatePollOpacityDTO pollOpacityDTO)
		{
			var pollEntity = await _context.Polls
				.Include(poll => poll.PollStyle)
				.SingleOrDefaultAsync(poll => poll.Id == id);

			ValidationHelper.ValidateDoesItemExist(
				pollEntity, ExceptionMessageConstants.NotFoundObjectMessage);

			var pollStyleEntity = pollEntity.PollStyle;
			pollStyleEntity.Opacity = pollOpacityDTO.Opacity;
			await _context.SaveChangesAsync();

			var updatedPollStyleDTO = _mapper.Map<PollStyleDTO>(pollStyleEntity);

			return updatedPollStyleDTO;
		}

		/// <inheritdoc/>			
		public async Task<PollStyleDTO> UpdatePollImageAsync(int id, UpdatePollImageDTO pollImageDTO)
		{
			var pollEntity = await _context.Polls
				.Include(poll => poll.PollStyle)
				.SingleOrDefaultAsync(poll => poll.Id == id);

			ValidationHelper.ValidateDoesItemExist(
				pollEntity, ExceptionMessageConstants.NotFoundObjectMessage);

			var pollStyleEntity = pollEntity.PollStyle;
			pollStyleEntity.ImageUrl = pollImageDTO.ImageUrl;
			await _context.SaveChangesAsync();

			var updatedPollStyleDTO = _mapper.Map<PollStyleDTO>(pollStyleEntity);

			return updatedPollStyleDTO;
		}

		/// <inheritdoc/>			
		public async Task<PollStyleDTO> UpdatePollImageCoordinatesAsync(int id, UpdatePollImageCoordinatesDTO pollImageCoordinatesDTO)
		{
			var pollEntity = await _context.Polls
				.Include(poll => poll.PollStyle)
				.SingleOrDefaultAsync(poll => poll.Id == id);

			ValidationHelper.ValidateDoesItemExist(
				pollEntity, ExceptionMessageConstants.NotFoundObjectMessage);

			var pollStyleEntity = pollEntity.PollStyle;
			pollStyleEntity.ImageXCoordinate = pollImageCoordinatesDTO.ImageXCoordinate;
			pollStyleEntity.ImageYCoordinate = pollImageCoordinatesDTO.ImageYCoordinate;
			await _context.SaveChangesAsync();

			var updatedPollStyleDTO = _mapper.Map<PollStyleDTO>(pollStyleEntity);

			return updatedPollStyleDTO;
		}
	}
}