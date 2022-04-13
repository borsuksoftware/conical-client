using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace BorsukSoftware.Conical.Client.REST
{
    /// <summary>
    /// Standard implementation of <see cref="IAccessLayer"/> based off being in communication with the standard REST api
    /// </summary>
    public class AccessLayer : IAccessLayer
    {
        #region Data Model

        private IApiService _apiService;

        #endregion

        #region Constructors

        /// <summary>
        /// Construct a fresh instance based off a given base URL with optional access token
        /// </summary>
        /// <param name="baseUrl">The URL to use as a base</param>
        /// <param name="accessToken">Optional personal access token for this instance</param>
        /// <exception cref="ArgumentNullException">If <paramref name="baseUrl"/> isn't supplied</exception>
        public AccessLayer(string baseUrl, string accessToken = null)
        {
            if (string.IsNullOrEmpty(baseUrl))
                throw new ArgumentNullException(nameof(baseUrl));

            var httpClient = new System.Net.Http.HttpClient()
            {
                BaseAddress = new Uri(baseUrl)
            };

            if (!string.IsNullOrEmpty(accessToken))
                httpClient.DefaultRequestHeaders.Add("Authorization", $"Bearer {accessToken}");


            var apiService = new ApiService(httpClient);

            this._apiService = apiService;
        }

        /// <summary>
        /// Construct a fresh instance based off the underlying API access layer
        /// </summary>
        /// <param name="apiService">The access component to use</param>
        /// <exception cref="ArgumentNullException">If <paramref name="apiService"/> isn't specified</exception>
        public AccessLayer(IApiService apiService)
        {
            if (apiService == null)
                throw new ArgumentNullException(nameof(apiService));

            this._apiService = apiService;
        }

        #endregion

        #region IAccessLayer functionality

        public async Task<IReadOnlyCollection<IProduct>> GetProducts()
        {
            var rawResults = await _apiService.Products();

            var output = rawResults.Select(p => new Product(this._apiService, p.name, p.description, p.aliases, p.status.ConvertToClientProductStatus())).ToList();
            return output;
        }

        public async Task<IProduct> GetProduct(string name)
        {
            var rawDetails = await _apiService.Product(name);
            var output = new Product(this._apiService, rawDetails.name, rawDetails.description, rawDetails.aliases, rawDetails.status.ConvertToClientProductStatus());
            return output;
        }

        public async Task<IProduct> CreateProduct(
            string productName,
            string description,
            IReadOnlyCollection<string> aliases = null,
            IReadOnlyCollection<(string RoleName, Client.ProductPrivilege AdditionalPrivilege)> additionalRolePrivileges = null,
            IReadOnlyCollection<(string RoleName, string RoleDescription, IReadOnlyCollection<string> InitialGroups, IReadOnlyCollection<string> InitialUsers, IReadOnlyCollection<Client.ProductPrivilege> ProductPrivileges)> additionalRoles = null,
            System.Drawing.Image image = null)
        {
            var body = new CreateProductModel
            {
                name = productName,
                description = description,
            };

            if (aliases != null)
                body.aliases = aliases.ToArray();

            if (additionalRolePrivileges != null)
                body.additionalRolePrivileges = additionalRolePrivileges.Select(arp => new RoleProductPrivilegeTuple { role = arp.RoleName, privilege = arp.AdditionalPrivilege.ConvertToApiProductPrivilege() }).ToArray();

            if (additionalRoles != null)
                body.additionalRoles = additionalRoles.Select(ar => new AdditionalRoleDetailsModel
                {
                    name = ar.RoleName,
                    description = ar.RoleDescription,
                    initialGroups = ar.InitialGroups?.ToArray() ?? Array.Empty<string>(),
                    initialUsers = ar.InitialUsers?.ToArray() ?? Array.Empty<string>(),
                    productPrivileges = ar.ProductPrivileges?.Select(pp => pp.ConvertToApiProductPrivilege())?.ToArray()
                }).ToArray();

            try
            {
                var validationResult = await this._apiService.ProductsValidateCreateProduct(body);
                if (!validationResult.validated)
                    throw new InvalidOperationException($"Validation failed - {validationResult.validationError}");
            }
            catch
            {
                throw new InvalidOperationException("Unable to validate product create model");

            }

            var rawProduct = await this._apiService.ProductsCreateProduct(body);

            // TODO - Handle the image provider... (What's this the image for? Test run types or normal)

            var product = new Product(this._apiService, rawProduct.name, rawProduct.description, rawProduct.aliases, rawProduct.status.ConvertToClientProductStatus());
            return product;
        }

        public async Task<ITestRunSetSearchResults> SearchTestRunSets(
            IReadOnlyCollection<string> products,
            IReadOnlyCollection<Client.TestRunSetStatus> statuses,
            string name,
            string description,
            string creator,
            DateTime? minRefDate,
            DateTime? maxRefDate,
            DateTime? minRunDate,
            DateTime? maxRunDate,
            IReadOnlyCollection<string> tags)
        {
            var model = new SearchTestRunSetCriteriaModel()
            {
                creator = creator,
                description = description,
                name = name,
                products = products?.ToArray(),
                minRefDate = minRefDate,
                maxRefDate = maxRefDate,
                minRunDate = minRunDate,
                maxRunDate = maxRunDate,
                statuses = statuses?.Select(s => s.ConvertToApiTestRunSetStatus())?.ToArray(),
                tags = tags?.ToArray(),
            };

            var sourceResults = await _apiService.SearchTestRunSet(model);

            var output = new TestRunSetSearchResults(sourceResults.results.Select(x => new TestRunSetSummary(this._apiService, x.product, x.id, x.name, x.description, x.status.ConvertToClientTestRunSetStatus(), x.refDate, x.runDate, x.creator, x.tags)));

            return output;
        }

        #endregion
    }
}
