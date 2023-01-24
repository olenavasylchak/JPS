using JPS.Services.DTO.DTOs.UserDTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace JPS.Services.Interfaces.Interfaces
{
	/// <summary>
	/// Graph service interface, holds methods to get information from Azure AD.
	/// </summary>
	public interface IGraphService
	{
		/// <summary>
		/// Get list of users from Azure AD.
		/// </summary>
		/// <returns>Graph collection of users.</returns>
		public Task<IEnumerable<UserDTO>> GetListOfUsersAsync();

		/// <summary>
		/// Get number of users.
		/// </summary>
		/// <returns>Number of users.</returns>
		public Task<int> GetNumberOfUsersAsync();
	}
}
