using AutoMapper;
using JPS.Services.DTO.DTOs.UserDTOs;
using JPS.Services.Interfaces.Interfaces;
using JPS.Services.Interfaces.ModelInterfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Graph;
using Microsoft.Identity.Client;
using System.Collections.Generic;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace JPS.Services.Services
{
	/// <summary>
	/// Implements IGraphService interface methods. 
	/// </summary>
	public class GraphService : IGraphService
	{
		GraphServiceClient _graphServiceClient;
		private readonly IMapper _mapper;

		public GraphService(IAzureAdOptions azureOptions, IConfiguration config, IMapper mapper)
		{
			config.Bind(ServiceConstants.AzureAdSection, azureOptions);

			var scopes = new string[] { ServiceConstants.DefaultScopeString };

			var confidentialClient = ConfidentialClientApplicationBuilder
				.Create(azureOptions.ClientId)
				.WithAuthority($"{azureOptions.Instance}{azureOptions.TenantId}")
				.WithClientSecret(azureOptions.ClientSecret)
				.Build();

			_graphServiceClient = new GraphServiceClient(new DelegateAuthenticationProvider(
				async (requestMessage) =>
				{
					var authResult = await confidentialClient
						.AcquireTokenForClient(scopes)
						.ExecuteAsync();

					requestMessage.Headers.Authorization =
						new AuthenticationHeaderValue(ServiceConstants.BearerString, authResult.AccessToken);
				})
				);

			_mapper = mapper;
		}

		///<inheritdoc/>
		public async Task<IEnumerable<UserDTO>> GetListOfUsersAsync()
		{
			var usersPage = await _graphServiceClient.Users.Request().GetAsync();

			var users = usersPage.CurrentPage as List<User>;

			while (usersPage.NextPageRequest != null)
			{
				usersPage = await usersPage.NextPageRequest.GetAsync();
				users.AddRange(usersPage.CurrentPage);
			}

			var userDTOs = _mapper.Map<IEnumerable<UserDTO>>(users);

			return userDTOs;
		}

		///<inheritdoc/>
		public async Task<int> GetNumberOfUsersAsync()
		{
			var users = await _graphServiceClient.Users.Request().GetAsync();

			int numberOfUsers = users.Count;

			while (users.NextPageRequest != null)
			{
				users = await users.NextPageRequest.GetAsync();
				numberOfUsers += users.Count;
			}

			return numberOfUsers;
		}
	}
}
