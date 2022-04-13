using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BorsukSoftware.Conical.Client
{
	/// <summary>
	/// Interface representing an access layer to a Conical instance
	/// </summary>
	public interface IAccessLayer
	{
		/// <summary>
		/// Create a new product in this instance
		/// </summary>
		/// <param name="productName">The name of the product to be created</param>
		/// <param name="description">A brief description of the product to be created</param>
		/// <param name="aliases">An optional set of aliases for this product</param>
		/// <param name="additionalRolePrivileges">An optional set of additional privileges for this product which should be granted to existing roles</param>
		/// <param name="additionalRoles">An optional set of additional roles which should be created on the server for this product</param>
		/// <param name="productImage">An optional image which should be used for this newly created product</param>
		/// <returns>The newly created product</returns>
		Task<IProduct> CreateProduct(
			string productName, 
			string description, 
			IReadOnlyCollection<string> aliases = null,
			IReadOnlyCollection<(string RoleName, ProductPrivilege AdditionalPrivilege)> additionalRolePrivileges = null,
			IReadOnlyCollection<(string RoleName, string RoleDescription, IReadOnlyCollection<string> InitialGroups, IReadOnlyCollection<string> InitialUsers, IReadOnlyCollection<Client.ProductPrivilege> ProductPrivileges)> additionalRoles = null,
			System.Drawing.Image productImage = null);

		/// <summary>
		/// Get the named product 
		/// </summary>
		/// <param name="name"></param>
		/// <returns>The product</returns>
		/// <exception cref="InvalidOperationException">Thrown if the product doesn't exist in the server or the user doesn't have access to it</exception>
		Task<IProduct> GetProduct(string name);

		/// <summary>
		/// Get all of the supported products that the user has access to on the server
		/// </summary>
		/// <returns>The set of products that the user has access to on the server</returns>
		Task<IReadOnlyCollection<IProduct>> GetProducts();

		/// <summary>
		/// Search the available test run sets for this instance according to the given specification
		/// </summary>
		/// <param name="products"></param>
		/// <param name="statuses">Optional set of statuses to filter on</param>
		/// <param name="name"></param>
		/// <param name="description"></param>
		/// <param name="creator"></param>
		/// <param name="minRefDate"></param>
		/// <param name="maxRefDate"></param>
		/// <param name="minRunDate"></param>
		/// <param name="maxRunDate"></param>
		/// <param name="tags"></param>
		/// <returns></returns>
		Task<ITestRunSetSearchResults> SearchTestRunSets(IReadOnlyCollection<string> products, 
			IReadOnlyCollection<TestRunSetStatus> statuses,
			string name, 
			string description, 
			string creator, 
			DateTime? minRefDate, 
			DateTime? maxRefDate, 
			DateTime? minRunDate, 
			DateTime? maxRunDate, 
			IReadOnlyCollection<string> tags);

	}
}
