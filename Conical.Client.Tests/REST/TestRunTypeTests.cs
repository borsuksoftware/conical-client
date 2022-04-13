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
    public class TestRunTypeTests
    {
        [InlineData(new object[] { null })]
        [InlineData(new object[] { new string[0] })]
        [InlineData(new object[] { new string[] { "resultsxml" } })]
        [Theory]
        public async Task UpdateComponents(string[] newComponents)
        {
            var productName = "FOCS";
            var apiServiceMock = new Mock<IApiService>(MockBehavior.Strict);

            var trtName = "Market";
            var trtDescription = "Sample test type";
            var trtInitialComponents = new[] { "resultsxml", "externallinks", "additionalfiles" };

            var testRunType = new TestRunType(apiServiceMock.Object, productName, trtName, trtDescription, trtInitialComponents);


            apiServiceMock.Setup(x => x.ProductTestRunTypeUpdateComponents(productName, trtName, It.IsAny<string[]>())).
                Callback((string _, string _, string[] requestNewComponents) =>
                {
                    requestNewComponents.Should().BeEquivalentTo(newComponents ?? Array.Empty<string>());
                }).
                Returns(Task.CompletedTask).
                Verifiable();

            await testRunType.UpdateComponents(newComponents);

            testRunType.Components.Should().BeEquivalentTo(newComponents ?? Array.Empty<string>());
        }

        [Fact(Skip = "TODO")]
        public void CustomImageTests()
        { }
    }
}
