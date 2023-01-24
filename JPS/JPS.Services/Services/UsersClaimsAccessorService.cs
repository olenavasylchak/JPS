using JPS.Services.Interfaces.Interfaces;
using Microsoft.AspNetCore.Http;
using System.Linq;
using System.Security.Claims;

namespace JPS.Services.Services
{
	/// <summary>
	/// Implements IUsersClaimsAccessor service.
	/// </summary>
	public class UserClaimsAccessorService : IUsersClaimsAccessorService
	{
		private readonly IHttpContextAccessor _httpContextAccessor;

		public UserClaimsAccessorService(IHttpContextAccessor httpContextAccessor)
		{
			_httpContextAccessor = httpContextAccessor;
		}

		/// <inheritdoc/>		
		public string Name
		{
			get
			{
				return _httpContextAccessor.HttpContext.User?.Claims?
					.FirstOrDefault(claim => claim.Type == ServiceConstants.NameClaimType)?.Value;
			}
		}

		/// <inheritdoc/>		
		public string UserId
		{
			get
			{
				return _httpContextAccessor.HttpContext.User?.Claims?
					.FirstOrDefault(claim => claim.Type == ClaimTypes.NameIdentifier)?.Value;
			}
		}
	}
}