using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BorsukSoftware.Conical.Client.REST
{
    /// <summary>
    /// Standard implementation of <see cref="IProduct"/>
    /// </summary>
	public class Product : IProduct
    {
        #region Data Model

        public IApiService ApiService { get; }

        public string Name { get; private set; }

        public string Description { get; private set; }

        public IReadOnlyCollection<string> Aliases { get; private set; }

        public Client.ProductStatus Status { get; private set; }

        #endregion

        #region Construction Logic

        public Product(IApiService apiService, string name, string description, IReadOnlyCollection<string> aliases, Client.ProductStatus status)
        {
            if (apiService == null)
                throw new ArgumentNullException(nameof(apiService));

            if (string.IsNullOrEmpty(name))
                throw new ArgumentNullException(nameof(name));

            this.ApiService = apiService;
            this.Name = name;
            this.Description = description;
            this.Aliases = aliases ?? Array.Empty<string>();
            this.Status = status;
        }

        #endregion

        public async Task<IReadOnlyCollection<ITestRunType>> GetTestTypes()
        {
            var testRunTypes = await this.ApiService.ProductTestRunTypes(this.Name);

            var output = testRunTypes.Select(trt =>
                new TestRunType(
                    this.ApiService,
                    this.Name,
                    trt.name,
                    trt.description,
                    trt.components.Select(x => x.name).ToList())).
                    ToList();
            return output;
        }

        public async Task<IReadOnlyCollection<string>> GetAvailableComponents()
        {
            var raw = await this.ApiService.ProductComponents(this.Name);

            var output = raw.Select(c => c.name).ToList();
            return output;
        }

        public async Task<ITestRunType> CreateTestRunType(string testRunTypeName, string testRunTypeDescription, string[] components, System.Drawing.Image image)
        {
            if (string.IsNullOrEmpty(testRunTypeName))
                throw new ArgumentNullException(testRunTypeName);

            if (components == null)
                components = Array.Empty<string>();

            // TODO - Update the API to return the object here
            await this.ApiService.ProductCreateTestRunType(this.Name, new CreateTestRunTypeModel
            {
                components = components,
                description = testRunTypeDescription,
                name = testRunTypeName
            });

            if (image != null)
            {
                var imageBytes = RESTUtils.ImageToByteArray(image, System.Drawing.Imaging.ImageFormat.Png);

                await this.ApiService.ProductTestRunTypeCustomImagePut(this.Name,
                    testRunTypeName,
                    imageBytes,
                    "image.png",
                    "image/png");
            }

            var output = new TestRunType(
                this.ApiService,
                this.Name,
                testRunTypeName,
                testRunTypeDescription,
                components);

            return output;
        }

        public async Task<ITestRunSet> CreateTestRunSet(string testRunSetName,
            string testRunSetDescription,
            DateTime refDate,
            DateTime runDate,
            IReadOnlyCollection<string> tags)
        {
            if (string.IsNullOrEmpty(testRunSetName))
                throw new ArgumentNullException(nameof(testRunSetName));

            var result = await this.ApiService.UploadCreateTestRunSet(this.Name,
                testRunSetName,
                testRunSetDescription,
                refDate,
                runDate,
                tags?.ToArray());

            var testRunSet = new TestRunSet(this.ApiService,
                result.product,
                result.id,
                result.name,
                result.description,
                result.status.ConvertToClientTestRunSetStatus(),
                result.refDate,
                result.runDate,
                result.creator,
                result.tags);

            return testRunSet;
        }

        public async Task<ITestRunSet> GetTestRunSet(int id)
        {
            var details = await this.ApiService.ProductTestRunSetSummary(this.Name, id);

            var output = new TestRunSet(this.ApiService, this.Name, details.id, details.name, details.description, details.status.ConvertToClientTestRunSetStatus(), details.refDate, details.runDate, details.creator, details.tags);
            return output;
        }

        #region Test Run Type Image Code

        public async Task SetDefaultTestRunTypeImage(System.Drawing.Image image)
        {
            if (image == null)
            {
                await this.ApiService.ProductDefaultTestRunTypeImageDelete(this.Name);
                return;
            }

            var imageBytes = RESTUtils.ImageToByteArray(image, System.Drawing.Imaging.ImageFormat.Png);
            await this.ApiService.ProductDefaultTestRunTypeImagePut(this.Name, imageBytes, "image.png", "image/png");
        }

        public async Task<System.Drawing.Image> GetDefaultTestRunTypeImage()
        {
            var imageDetails = await this.ApiService.ProductDefaultTestRunTypeImageDetails(this.Name);
            if (imageDetails == null)
                return null;

            using (var imageStream = await this.ApiService.ProductDefaultTestRunTypeImageGetStream(this.Name))
            {
                var image = System.Drawing.Image.FromStream(imageStream);
                return image;
            }
        }

        #endregion

        #region Rename code

        public async Task<(bool canRename, string validationError)> CanRename(string newName, bool keepOldNameAsAlias)
        {
            if (string.IsNullOrEmpty(newName))
                return (false, "A valid name must be specified");

            var response = await this.ApiService.ProductValidateRename(this.Name, newName, keepOldNameAsAlias);

            return (response.validated, response.validationError);
        }

        public async Task Rename(string newName, bool keepOldNameAsAlias)
        {
            if (string.IsNullOrEmpty(newName))
                throw new ArgumentNullException(nameof(newName));

            var response = await this.ApiService.ProductRename(this.Name, newName, keepOldNameAsAlias);

            this.Name = response.name;
            this.Description = response.description;
            this.Aliases = response.aliases ?? Array.Empty<string>();
        }

        #endregion

        #region Alias code

        public async Task<(bool canUpdateAliases, string validationError)> CanUpdateAliases(IReadOnlyCollection<string> aliasesToRemove, IReadOnlyCollection<string> aliasesToAdd)
        {
            var response = await this.ApiService.ProductValidateUpdateAliases(this.Name, new UpdateProductAliasesModel
            {
                aliasesToAdd = aliasesToAdd?.ToArray(),
                aliasesToRemove = aliasesToRemove?.ToArray()
            });

            return (response.validated, response.validationError);
        }

        public async Task UpdateAliases(IReadOnlyCollection<string> aliasesToRemove, IReadOnlyCollection<string> aliasesToAdd)
        {
            var response = await this.ApiService.ProductUpdateAliases(this.Name, new UpdateProductAliasesModel
            {
                aliasesToAdd = aliasesToAdd?.ToArray(),
                aliasesToRemove = aliasesToRemove?.ToArray()
            });

            this.Name = response.name;
            this.Description = response.description;
            this.Aliases = response.aliases ?? Array.Empty<string>();
        }

        #endregion
    }
}
