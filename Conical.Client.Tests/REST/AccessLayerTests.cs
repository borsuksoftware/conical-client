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
    public class AccessLayerTests
    {
        [Fact]
        public async Task GetProducts()
        {
            var apiServiceMock = new Mock<IApiService>(MockBehavior.Strict);
            var accessLayer = new AccessLayer(apiServiceMock.Object);

            var expectedProducts = new ProductModel[]
            {
                new ProductModel { name = "product 1", aliases = null, description = "Here's a description 1", status = ProductStatus.standard},
                new ProductModel { name = "product 2", aliases = Array.Empty<string>(), description = "Here's a description 2", status = ProductStatus.archived},
                new ProductModel { name = "product 3", aliases = new string [] { "alias#1" }, description = "Here's a description 3", status = ProductStatus.recycleBin},
                new ProductModel { name = "product 4", aliases = new string [] { "alias#2", "alias#3" }, description = "Here's a description 4", status = ProductStatus.standard},
            };
            apiServiceMock.Setup(x => x.Products()).ReturnsAsync(expectedProducts);

            var products = await accessLayer.GetProducts();

            Assert.Equal(4, products.Count);

            var product1 = products.SingleOrDefault(p => p.Name == expectedProducts[0].name);
            Assert.NotNull(product1);
            Assert.Equal(expectedProducts[0].description, product1.Description);
            Assert.Empty(product1.Aliases);
            Assert.Equal(Client.ProductStatus.Standard, product1.Status);

            var product2 = products.SingleOrDefault(p => p.Name == expectedProducts[1].name);
            Assert.NotNull(product2);
            Assert.Equal(expectedProducts[1].description, product2.Description);
            Assert.Empty(product2.Aliases);
            Assert.Equal(Client.ProductStatus.Archived, product2.Status);

            var product3 = products.SingleOrDefault(p => p.Name == expectedProducts[2].name);
            Assert.NotNull(product3);
            Assert.Equal(expectedProducts[2].description, product3.Description);
            product3.Aliases.Should().BeEquivalentTo(expectedProducts[2].aliases);
            Assert.Equal(Client.ProductStatus.RecycleBin, product3.Status);

            var product4 = products.SingleOrDefault(p => p.Name == expectedProducts[3].name);
            Assert.NotNull(product4);
            Assert.Equal(expectedProducts[3].description, product4.Description);
            product4.Aliases.Should().BeEquivalentTo(expectedProducts[3].aliases);
            Assert.Equal(Client.ProductStatus.Standard, product4.Status);
        }


        public static IEnumerable<object[]> GetProduct_Success_Data
        {
            get
            {
                yield return new object[]
                {
                    new ProductModel
                    {
                        name = "product 1",
                        aliases = null,
                        description = "Here is a description",
                        status = ProductStatus.standard
                    }
                };

                yield return new object[]
                {
                    new ProductModel
                    {
                        name = "product 1",
                        aliases = Array.Empty<string>(),
                        description = "Here is a description",
                        status = ProductStatus.standard
                    }
                };

                yield return new object[]
                {
                    new ProductModel
                    {
                        name = "product 1",
                        aliases = new [] { "Billy", "Bob" },
                        description = "Here is a description",
                        status = ProductStatus.archived
                    }
                };
            }
        }

        [MemberData(nameof(GetProduct_Success_Data))]
        [Theory]
        public async Task GetProduct_Success(REST.ProductModel productModel)
        {
            var apiServiceMock = new Mock<IApiService>(MockBehavior.Strict);
            var accessLayer = new AccessLayer(apiServiceMock.Object);

            apiServiceMock.Setup(x => x.Product(productModel.name)).ReturnsAsync(productModel);

            var clientProduct = await accessLayer.GetProduct(productModel.name);
            Assert.NotNull(clientProduct);

            Assert.Equal(productModel.name, clientProduct.Name);
            Assert.Equal(productModel.description, clientProduct.Description);
            Assert.Equal(productModel.status.ConvertToClientProductStatus(), clientProduct.Status);
            clientProduct.Aliases.Should().BeEquivalentTo(productModel.aliases ?? Array.Empty<string>());
        }

        [Fact]
        public async Task GetProduct_Failing()
        {
            var apiServiceMock = new Mock<IApiService>(MockBehavior.Strict);
            var accessLayer = new AccessLayer(apiServiceMock.Object);

            apiServiceMock.Setup(x => x.Product(It.IsAny<string>())).ThrowsAsync(new InvalidOperationException());

            await Assert.ThrowsAsync<InvalidOperationException>(async () => { await accessLayer.GetProduct("James"); });
        }


        public static IEnumerable<object[]> CreateProduct_Success_Data
        {
            get
            {
                yield return new object[]
                {
                    "FOCS",
                    "FOCS is cool",
                    null,
                    null,
                    null,
                    null
                };

                yield return new object[]
                {
                    "FOCS",
                    "FOCS is cool",
                    new string [] { "FACS", "FOX" },
                    null,
                    null,
                    null
                };

                yield return new object[]
                {
                    "FOCS",
                    "FOCS is cool",
                    null,
                    new (string RoleName, Client.ProductPrivilege AdditionalPrivilege)[] {
                        ("rRambo", Client.ProductPrivilege.Commenter),
                        ("rRambo", Client.ProductPrivilege.AuditTrail),
                        ("rDonkey", Client.ProductPrivilege.Publisher)
                    },
                    null,
                    null
                };

                yield return new object[]
                {
                    "FOCS",
                    "FOCS is cool",
                    null,
                    null,
                    new (string RoleName, string RoleDescription, IReadOnlyCollection<string> InitialGroups, IReadOnlyCollection<string> InitialUsers, IReadOnlyCollection<Client.ProductPrivilege> ProductPrivileges) []
                    {
                        ( "rFOCSUploader1", "A new role for FOCS", null, new string [] { "autoUploader" }, new [] { Client.ProductPrivilege.Publisher }),
                        ( "rFOCSUploader2", "A new role for FOCS", new string [] { "uploaders" }, new string [] { "autoUploader" }, new [] { Client.ProductPrivilege.Publisher }),
                        ( "rFOCSUploader3", "A new role for FOCS", null, null, new [] { Client.ProductPrivilege.Publisher })
                    },
                    null
                };
            }
        }

        [MemberData(nameof(CreateProduct_Success_Data))]
        [Theory]
        public async Task CreateProduct_Success(
            string productName,
            string productDescription,
            IReadOnlyCollection<string> aliases,
            IReadOnlyCollection<(string RoleName, Client.ProductPrivilege AdditionalPrivilege)> additionalRolePrivileges,
            IReadOnlyCollection<(string RoleName, string RoleDescription, IReadOnlyCollection<string> InitialGroups, IReadOnlyCollection<string> InitialUsers, IReadOnlyCollection<Client.ProductPrivilege> ProductPrivileges)> additionalRoles,
            System.Drawing.Image image)
        {
            var apiServiceMock = new Mock<IApiService>(MockBehavior.Strict);
            var accessLayer = new AccessLayer(apiServiceMock.Object);

            // TODO - Add additional roles...

            apiServiceMock.Setup(x => x.ProductsValidateCreateProduct(It.IsAny<CreateProductModel>())).ReturnsAsync((CreateProductModel request) =>
            {
                Assert.Equal(productName, request.name);
                Assert.Equal(productDescription, request.description);
                if (request.aliases == null)
                    Assert.Null(aliases);
                else
                    request.aliases.Should().BeEquivalentTo(aliases ?? Array.Empty<string>());

                if (request.additionalRolePrivileges == null)
                    Assert.Null(additionalRolePrivileges);
                else
                    request.additionalRolePrivileges.Should().BeEquivalentTo(additionalRolePrivileges.Select(arp => new RoleProductPrivilegeTuple { role = arp.RoleName, privilege = arp.AdditionalPrivilege.ConvertToApiProductPrivilege() }));

                if (request.additionalRoles == null)
                    Assert.Null(additionalRoles);
                else
                    request.additionalRoles.Should().BeEquivalentTo(additionalRoles.Select(ar => new AdditionalRoleDetailsModel
                    {
                        name = ar.RoleName,
                        description = ar.RoleDescription,
                        initialGroups = ar.InitialGroups?.ToArray() ?? Array.Empty<string>(),
                        initialUsers = ar.InitialUsers?.ToArray() ?? Array.Empty<string>(),
                        productPrivileges = ar.ProductPrivileges?.Select(pp => pp.ConvertToApiProductPrivilege())?.ToArray()
                    }));

                return new ValidateCreateProductModel
                {
                    validated = true
                };
            }).Verifiable();

            apiServiceMock.Setup(x => x.ProductsCreateProduct(It.IsAny<CreateProductModel>())).ReturnsAsync((CreateProductModel request) =>
            {

                Assert.Equal(productName, request.name);
                Assert.Equal(productDescription, request.description);
                if (request.aliases == null)
                    Assert.Null(aliases);
                else
                    request.aliases.Should().BeEquivalentTo(aliases ?? Array.Empty<string>());

                if (request.additionalRolePrivileges == null)
                    Assert.Null(additionalRolePrivileges);
                else
                    request.additionalRolePrivileges.Should().BeEquivalentTo(additionalRolePrivileges.Select(arp => new RoleProductPrivilegeTuple { role = arp.RoleName, privilege = arp.AdditionalPrivilege.ConvertToApiProductPrivilege() }));

                if (request.additionalRoles == null)
                    Assert.Null(additionalRoles);
                else
                    request.additionalRoles.Should().BeEquivalentTo(additionalRoles.Select(ar => new AdditionalRoleDetailsModel
                    {
                        name = ar.RoleName,
                        description = ar.RoleDescription,
                        initialGroups = ar.InitialGroups?.ToArray() ?? Array.Empty<string>(),
                        initialUsers = ar.InitialUsers?.ToArray() ?? Array.Empty<string>(),
                        productPrivileges = ar.ProductPrivileges?.Select(pp => pp.ConvertToApiProductPrivilege())?.ToArray()
                    }));

                var productModel = new ProductModel
                {
                    name = request.name,
                    aliases = request.aliases ?? Array.Empty<string>(),
                    description = request.description,
                    status = ProductStatus.standard
                };

                return productModel;
            }).Verifiable();

            var product = await accessLayer.CreateProduct(productName,
                productDescription,
                aliases,
                additionalRolePrivileges,
                additionalRoles,
                image);

            Assert.NotNull(product);
            Assert.Equal(productName, product.Name);
            Assert.Equal(productDescription, product.Description);
            Assert.Equal(aliases ?? Array.Empty<string>(), product.Aliases);
            Assert.Equal(Client.ProductStatus.Standard, product.Status);

            apiServiceMock.Verify();
        }

        public static IEnumerable<object[]> SearchTestRunSets_Data
        {
            get
            {
                yield return new object[] {
                    new SearchTestRunSetCriteriaModel
                    {
                        products = new string[] { "product1", "prod2" },
                        statuses = new[] { TestRunSetStatus.standard, TestRunSetStatus.locked },
                        name = "Hulla",
                        description = "Balloooooo",
                        creator = "MrDonkey",
                    }
                };

                yield return new object[] {
                    new SearchTestRunSetCriteriaModel
                    {
                        tags = new [] { "ci" }
                    }
                };

                yield return new object[] {
                    new SearchTestRunSetCriteriaModel
                    {
                        products = new string[] { "product1" },
                        statuses = new[] { TestRunSetStatus.standard, TestRunSetStatus.locked },
                        minRefDate = new DateTime( 2022, 01, 01),
                        minRunDate = new DateTime( 2022, 01, 02, 17, 05, 02)
                    }
                };

                yield return new object[] {
                    new SearchTestRunSetCriteriaModel
                    {
                        products = new string[] { "product1" },
                        statuses = new[] { TestRunSetStatus.standard, TestRunSetStatus.locked },
                        maxRefDate = new DateTime( 2022, 01, 01),
                        maxRunDate = new DateTime( 2022, 01, 02, 17, 05, 02)
                    }
                };

            }
        }

        [MemberData(nameof(SearchTestRunSets_Data))]
        [Theory]
        public async Task SearchTestRunSets(SearchTestRunSetCriteriaModel expectedRequest)
        {
            var apiServiceMock = new Mock<IApiService>(MockBehavior.Strict);
            var accessLayer = new AccessLayer(apiServiceMock.Object);

            var expectedTRSSM = new TestRunSetSummaryModel
            {
                product = "Bob",
                name = "Billy",
                description = "Twinkle",
                creator = "donkey",
                erroringTestRuns = 1,
                failedTestRuns = 3,
                id = 17,
                refDate = new DateTime(2022, 01, 21),
                runDate = new DateTime(2022, 01, 21, 19, 34, 1),
                status = TestRunSetStatus.standard,
                successfulTestRuns = 7,
                tags = new[] { "ci" },
                unknownTestRuns = 9
            };

            apiServiceMock.Setup(x => x.SearchTestRunSet(It.IsAny<SearchTestRunSetCriteriaModel>())).ReturnsAsync((SearchTestRunSetCriteriaModel searchCriteria) =>
                {
                    searchCriteria.products.Should().BeEquivalentTo(expectedRequest.products);

                    if (expectedRequest.statuses == null)
                        Assert.Null(searchCriteria.statuses);
                    else
                        searchCriteria.statuses.Should().BeEquivalentTo(expectedRequest.statuses);

                    Assert.Equal(expectedRequest.name, searchCriteria.name);
                    Assert.Equal(expectedRequest.description, searchCriteria.description);
                    Assert.Equal(expectedRequest.creator, searchCriteria.creator);
                    Assert.Equal(expectedRequest.minRefDate, searchCriteria.minRefDate);
                    Assert.Equal(expectedRequest.maxRefDate, searchCriteria.maxRefDate);
                    Assert.Equal(expectedRequest.minRunDate, searchCriteria.minRunDate);
                    Assert.Equal(expectedRequest.maxRunDate, searchCriteria.maxRunDate);

                    if (expectedRequest.tags == null)
                        Assert.Null(searchCriteria.tags);
                    else
                        searchCriteria.tags.Should().BeEquivalentTo(expectedRequest.tags);

                    var results = new TestRunSetSearchResultsModel()
                    {
                        criteria = searchCriteria,
                        results = new TestRunSetSummaryModel[] { expectedTRSSM }
                    };
                    return results;
                }).Verifiable();

            var searchResults = await accessLayer.SearchTestRunSets(
                expectedRequest.products,
                expectedRequest.statuses?.Select(s => s.ConvertToClientTestRunSetStatus())?.ToList(),
                expectedRequest.name,
                expectedRequest.description,
                expectedRequest.creator,
                expectedRequest.minRefDate,
                expectedRequest.maxRefDate,
                expectedRequest.minRunDate,
                expectedRequest.maxRunDate,
                expectedRequest.tags);

            Assert.NotNull(searchResults.Results);
            Assert.Single(searchResults.Results);

            var clientTRSSM = searchResults.Results.First();
            Assert.Equal(expectedTRSSM.product, clientTRSSM.Product);
            Assert.Equal(expectedTRSSM.id, clientTRSSM.ID);
            Assert.Equal(expectedTRSSM.name, clientTRSSM.Name);
            Assert.Equal(expectedTRSSM.description, clientTRSSM.Description);
            Assert.Equal(expectedTRSSM.creator, clientTRSSM.Creator);
            Assert.Equal(expectedTRSSM.runDate, clientTRSSM.RunDate);
            Assert.Equal(expectedTRSSM.refDate, clientTRSSM.RefDate);
            clientTRSSM.Tags.Should().BeEquivalentTo(expectedTRSSM.tags);
            Assert.Equal(expectedTRSSM.status.ConvertToClientTestRunSetStatus(), clientTRSSM.Status);

            apiServiceMock.Verify();
        }
    }
}
