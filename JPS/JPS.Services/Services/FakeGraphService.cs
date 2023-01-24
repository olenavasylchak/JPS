using JPS.Services.DTO.DTOs.UserDTOs;
using JPS.Services.Interfaces.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace JPS.Services.Services
{
	/// <inheritdoc/>
	public class FakeGraphService : IGraphService
	{
		private List<UserDTO> fakeUsers = new List<UserDTO>
		{
			new UserDTO() { Name = "Danyil Malko", Id = "1", Mail = "danyil.malko@gmail.com" },
			new UserDTO() { Name = "Bohdan Stelmashchuk", Id = "100", Mail = "bodiastel123@gmail.com" },
			new UserDTO() { Name = "Volodymyr Shonbin", Id = "101", Mail = "shonbin.volodymyr@gmail.com" },
			new UserDTO() { Name = "Olena Vasylchak", Id = "102", Mail = "olenavasylchak@gmail.com" },
			new UserDTO() { Name = "Danyil Denysovich", Id = "103", Mail = "danikmal@ukr.net" },
			new UserDTO() { Name = "Taras Pelyno", Id = "104", Mail = "tarasfall@gmail.com" },
		};

		/// <inheritdoc/>
		public async Task<IEnumerable<UserDTO>> GetListOfUsersAsync()
		{
			return fakeUsers;
		}

		/// <inheritdoc/>
		public async Task<int> GetNumberOfUsersAsync()
		{
			return fakeUsers.Count;
		}
	}
}
