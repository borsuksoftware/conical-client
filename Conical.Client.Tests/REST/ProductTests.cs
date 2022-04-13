using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using FluentAssertions;
using Moq;
using Xunit;

namespace BorsukSoftware.Conical.Client.REST
{
    public class ProductTests
    {
        [Fact]
        public void Standard()
        {
            var apiServiceMockObject = new Mock<IApiService>(MockBehavior.Strict);
            string name = "FOCS";
            string description = "DESC";
            IReadOnlyCollection<string> aliases = new[] { "Billy", "Bob" };
            var product = new Product(apiServiceMockObject.Object, name, description, aliases, Client.ProductStatus.Standard);

            Assert.Equal(name, product.Name);
            Assert.Equal(description, product.Description);
            Assert.Equal(Client.ProductStatus.Standard, Client.ProductStatus.Standard);

            product.Aliases.Should().BeEquivalentTo(aliases);
        }

        [Fact]
        public async Task CanRename()
        {
            var apiServiceMockObject = new Mock<IApiService>(MockBehavior.Strict);

            apiServiceMockObject.Setup(x => x.ProductValidateRename("FOCS", "James", true)).ReturnsAsync(new ValidateRenameProductModel { validated = true }).Verifiable();

            var product = new Product(apiServiceMockObject.Object, "FOCS", "DESC", Array.Empty<string>(), Client.ProductStatus.Standard);

            var response = await product.CanRename("James", true);

            Assert.True(response.canRename);
            Assert.Null(response.validationError);

            apiServiceMockObject.Verify();
        }

        [Fact]
        public async Task Rename()
        {
            var originalName = "FOCS";
            var newName = "Billy";

            var apiServiceMockObject = new Mock<IApiService>(MockBehavior.Strict);
            apiServiceMockObject.Setup(x => x.ProductRename(originalName, newName, true)).ReturnsAsync(new ProductModel { name = newName, description = "J", aliases = Array.Empty<string>() }).Verifiable();

            var product = new Product(apiServiceMockObject.Object, originalName, "DESC", Array.Empty<string>(), Client.ProductStatus.Standard);

            await product.Rename(newName, true);

            Assert.Equal(newName, product.Name);
            apiServiceMockObject.Verify();
        }

        [InlineData(new[] { "Bonkle", "Lonkle" }, null)]
        [InlineData(null, new[] { "Bonkle", "Lonkle" })]
        [Theory]
        public async Task CanUpdateAliases(string[] aliasesToRemove, string[] aliasesToAdd)
        {
            if (aliasesToRemove == null)
                aliasesToRemove = Array.Empty<string>();

            if (aliasesToAdd == null)
                aliasesToAdd = Array.Empty<string>();

            var apiServiceMockObject = new Mock<IApiService>(MockBehavior.Strict);

            apiServiceMockObject.Setup(x => x.ProductValidateUpdateAliases("FOCS", It.IsAny<UpdateProductAliasesModel>())).
                ReturnsAsync(new ValidateUpdateProductAliasesModel { validated = true }).
                Verifiable();

            var product = new Product(apiServiceMockObject.Object, "FOCS", "DESC", Array.Empty<string>(), Client.ProductStatus.Standard);

            var response = await product.CanUpdateAliases(aliasesToRemove, aliasesToAdd);

            Assert.True(response.canUpdateAliases);
            Assert.Null(response.validationError);

            apiServiceMockObject.Verify();
        }

        [InlineData(new[] { "Bonkle", "Lonkle" }, null)]
        [InlineData(null, new[] { "Bonkle", "Lonkle" })]
        [Theory]
        public async Task UpdateAliases(string[] aliasesToRemove, string[] aliasesToAdd)
        {
            if (aliasesToRemove == null)
                aliasesToRemove = Array.Empty<string>();

            if (aliasesToAdd == null)
                aliasesToAdd = Array.Empty<string>();

            var apiServiceMockObject = new Mock<IApiService>(MockBehavior.Strict);

            apiServiceMockObject.Setup(x => x.ProductUpdateAliases("FOCS", It.IsAny<UpdateProductAliasesModel>())).
                ReturnsAsync((string name, UpdateProductAliasesModel model) =>
                {
                    model.aliasesToRemove.Should().BeEquivalentTo(aliasesToRemove);
                    model.aliasesToAdd.Should().BeEquivalentTo(aliasesToAdd);
                    var product = new ProductModel
                    {
                        name = name,
                        description = "DESC",
                        aliases = new[] { "Twonly" }
                    };

                    return product;
                }).Verifiable();

            var product = new Product(apiServiceMockObject.Object, "FOCS", "DESC", Array.Empty<string>(), Client.ProductStatus.Standard);

            await product.UpdateAliases(aliasesToRemove, aliasesToAdd);

            product.Aliases.Should().BeEquivalentTo(new[] { "Twonly" });
            apiServiceMockObject.Verify();
        }

        [Fact]
        public async Task GetTestTypes()
        {
            string productName = "FOCS";

            var testRunType = new TestRunTypeModel
            {
                name = "Market",
                description = "Market Test",
                product = productName,
                components = new TestRunTypeComponentModel[] {
                    new TestRunTypeComponentModel {  name="resultsxml"},
                    new TestRunTypeComponentModel { name = "externallinks" }
                }
            };

            var apiServiceMock = new Mock<IApiService>(MockBehavior.Strict);
            apiServiceMock.Setup(x => x.ProductTestRunTypes(productName)).ReturnsAsync(new TestRunTypeModel[] { testRunType }).Verifiable();

            var product = new Product(apiServiceMock.Object, productName, "desc", Array.Empty<string>(), Client.ProductStatus.Standard);

            var downloadedTestRunTypes = await product.GetTestTypes();

            Assert.NotNull(downloadedTestRunTypes);
            Assert.Single(downloadedTestRunTypes);

            var downloadedTestRunType = downloadedTestRunTypes.First();

            Assert.Equal(testRunType.name, downloadedTestRunType.Name);
            Assert.Equal(testRunType.description, downloadedTestRunType.Description);
            downloadedTestRunType.Components.Should().BeEquivalentTo(testRunType.components.Select(c => c.name));

            apiServiceMock.Verify();
        }

        [Fact]
        public async Task GetAvailableComponents()
        {
            string productName = "FOCS";
            var apiServiceMock = new Mock<IApiService>(MockBehavior.Strict);

            var expectedComponents = new string[] { "resultsxml", "resultsjson", "externallinks", "billy" };

            apiServiceMock.Setup(x => x.ProductComponents(productName)).
                ReturnsAsync(expectedComponents.Select(n => new ComponentDetailsModel { name = n }).ToArray()).
                Verifiable();

            var product = new Product(apiServiceMock.Object, productName, "desc", Array.Empty<string>(), Client.ProductStatus.Standard);

            var availableComponents = await product.GetAvailableComponents();

            Assert.NotNull(availableComponents);
            availableComponents.Should().BeEquivalentTo(expectedComponents);

            apiServiceMock.Verify();
        }



        // TODO - Add test for image handling
        [InlineData("na", "de", new string[] { "resultsxml", "resultsjson" }, null)]
        [InlineData("na", "de", new string[] { "resultsxml" }, null)]
        [Theory]
        public async Task CreateTestRunType(string name, string description, string[] components, System.Drawing.Image image)
        {
            string productName = "FOCS";
            var apiServiceMock = new Mock<IApiService>(MockBehavior.Strict);

            apiServiceMock.Setup(x => x.ProductCreateTestRunType(productName, It.IsAny<CreateTestRunTypeModel>())).ReturnsAsync(
                (string requestProduct, CreateTestRunTypeModel request) =>
                {
                    var result = new TestRunTypeModel
                    {
                        name = request.name,
                        description = request.description,
                        product = requestProduct,
                        customImageDetails = null,
                        components = request.components?.Select(n => new TestRunTypeComponentModel { name = n })?.ToArray()
                    };

                    return result;
                }).Verifiable();

            var product = new Product(apiServiceMock.Object, productName, "desc", Array.Empty<string>(), Client.ProductStatus.Standard);

            var response = await product.CreateTestRunType(name, description, components, image);

            Assert.NotNull(response);
            Assert.Equal(name, response.Name);
            Assert.Equal(description, response.Description);

            Assert.NotNull(response.Components);
            response.Components.Should().BeEquivalentTo(components);

            apiServiceMock.Verify();
        }

        [InlineData(null)]
        [InlineData(new object[] { new string[0] })]
        [InlineData(new object[] { new string[] { "ci", "regressiontests" } })]
        [Theory]
        public async Task CreateTestRunSet(string[] expectedTags)
        {
            string productName = "FOCS";
            var apiServiceMock = new Mock<IApiService>(MockBehavior.Strict);

            string expectedCreator = "bob";
            string trsName = "tonkle";
            string trsDescription = "lonkle";
            DateTime trsRefDate = new DateTime(2022, 01, 18);
            DateTime trsRunDate = new DateTime(2022, 01, 18, 19, 46, 31);

            apiServiceMock.Setup(x => x.UploadCreateTestRunSet(productName, trsName, trsDescription, trsRefDate, trsRunDate, It.IsAny<string[]>())).
                ReturnsAsync((string _, string _, string _, DateTime _, DateTime _, string[] requestTags) =>
                {
                    if (expectedTags == null)
                        Assert.Null(requestTags);
                    else
                        requestTags.Should().BeEquivalentTo(expectedTags);

                    return new TestRunSetSummaryModel
                    {
                        creator = expectedCreator,
                        description = trsDescription,
                        name = trsName,
                        id = 18,
                        product = productName,
                        refDate = trsRefDate,
                        runDate = trsRunDate,
                        status = TestRunSetStatus.publishing,
                        tags = requestTags ?? Array.Empty<string>()
                    };
                }).Verifiable();

            var product = new Product(apiServiceMock.Object, productName, "desc", Array.Empty<string>(), Client.ProductStatus.Standard);

            var trs = await product.CreateTestRunSet(trsName, trsDescription, trsRefDate, trsRunDate, expectedTags);

            Assert.Equal(18, trs.ID);
            Assert.Equal(productName, trs.Product);
            Assert.Equal(trsName, trs.Name);
            Assert.Equal(trsDescription, trs.Description);
            Assert.Equal(expectedCreator, trs.Creator);
            Assert.Equal(trsRefDate, trs.RefDate);
            Assert.Equal(trsRunDate, trs.RunDate);
            Assert.Equal(Client.TestRunSetStatus.Publishing, trs.Status);
            trs.Tags.Should().BeEquivalentTo(expectedTags ?? Array.Empty<string>());
        }

        [InlineData(Client.TestRunSetStatus.Standard, new string[0])]
        [InlineData(Client.TestRunSetStatus.Standard, new string[] { "tag1", "tag2" })]
        [Theory]
        public async Task GetTestRunSet(Client.TestRunSetStatus trsStatus, string[] expectedTags)
        {
            string productName = "FOCS";
            var apiServiceMock = new Mock<IApiService>(MockBehavior.Strict);

            int trsID = 17;
            string trsName = "tonkle";
            string trsDescription = "lonkle";
            string trsCreator = "bob";
            DateTime trsRefDate = new DateTime(2022, 01, 18);
            DateTime trsRunDate = new DateTime(2022, 01, 18, 19, 46, 31);

            apiServiceMock.Setup(x => x.ProductTestRunSetSummary(productName, trsID)).ReturnsAsync(new TestRunSetSummaryModel
            {
                product = productName,
                id = trsID,
                name = trsName,
                description = trsDescription,
                creator = trsCreator,
                refDate = trsRefDate,
                runDate = trsRunDate,
                status = trsStatus.ConvertToApiTestRunSetStatus(),
                tags = expectedTags,
                erroringTestRuns = 1,
                failedTestRuns = 2,
                successfulTestRuns = 3,
                unknownTestRuns = 4,
            }).Verifiable();

            var product = new Product(apiServiceMock.Object, productName, "desc", Array.Empty<string>(), Client.ProductStatus.Standard);

            var trs = await product.GetTestRunSet(trsID);

            Assert.Equal(productName, trs.Product);
            Assert.Equal(trsID, trs.ID);
            Assert.Equal(trsName, trs.Name);
            Assert.Equal(trsDescription, trs.Description);
            Assert.Equal(trsCreator, trs.Creator);
            Assert.Equal(trsRefDate, trs.RefDate);
            Assert.Equal(trsRunDate, trs.RunDate);
            Assert.Equal(trsStatus, trs.Status);
            trs.Tags.Should().BeEquivalentTo(expectedTags ?? Array.Empty<string>());

            apiServiceMock.Verify();
        }

        [Fact(Skip = "TODO")]
        public void SetDefaultTestRunTypeImage()
        {
        }

        [Fact(Skip = "TODO")]
        public void GetDefaultTestRunTypeImage()
        {
        }
    }
}
