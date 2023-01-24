namespace JPS.Services.Interfaces.Interfaces
{
	/// <summary>
	/// Service interface for getting claims.
	/// </summary>
	public interface IUsersClaimsAccessorService
	{
		/// <summary>
		/// Contains name claim.
		/// </summary>
		public string Name { get; }

		/// <summary>
		/// Contains user id claim. 
		/// </summary>
		public string UserId { get; }		
	}
}
