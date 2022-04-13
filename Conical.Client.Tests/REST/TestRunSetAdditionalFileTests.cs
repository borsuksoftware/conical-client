using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Moq;
using Xunit;

namespace BorsukSoftware.Conical.Client.REST
{
    public class TestRunSetAdditionalFileTests
    {
        [Fact]
        public void Standard()
        {
            var apiServiceMock = new Mock<IApiService>(MockBehavior.Strict);
            var testRunSetMock = new Mock<ITestRunSet>(MockBehavior.Strict);

            int trID = 17;
            string fileName = "bob.png";
            string fileDescription = "Here is a description";

            var testRunAdditionalFile = new TestRunAdditionalFile(apiServiceMock.Object,
                testRunSetMock.Object,
                trID,
                fileName,
                fileDescription,
                400);

            Assert.Equal(400, testRunAdditionalFile.FileSize);
            Assert.Equal(trID, testRunAdditionalFile.TestRunID);
            Assert.Equal(fileName, testRunAdditionalFile.Name);
            Assert.Equal(fileDescription, testRunAdditionalFile.Description);
        }

        [Fact]
        public async Task Download()
        {
            string productName = "FOCS";
            int trsID = 4;
            string fileName = "bob.png";
            string fileDescription = "Here is a description";

            var apiServiceMock = new Mock<IApiService>(MockBehavior.Strict);
            var testRunSetMock = new Mock<ITestRunSet>(MockBehavior.Strict);
            testRunSetMock.Setup(x => x.Product).Returns(productName);
            testRunSetMock.Setup(x => x.ID).Returns(trsID);

            string resourceName = this.GetType().Assembly.GetManifestResourceNames().Single(n => n.EndsWith("SampleFile.txt"));
            apiServiceMock.
                Setup(x => x.ProductTestRunSetAdditionalFileStream(productName, trsID, fileName)).
                ReturnsAsync(this.GetType().Assembly.GetManifestResourceStream(resourceName)).Verifiable();

            var testRunSetAdditionalFile = new TestRunSetAdditionalFile(apiServiceMock.Object,
                testRunSetMock.Object,
                fileName,
                fileDescription,
                400);

            string expectedStringContents;
            using (var expectedStreamReader = new System.IO.StreamReader(this.GetType().Assembly.GetManifestResourceStream(resourceName)))
                expectedStringContents = expectedStreamReader.ReadToEnd();

            using (var stream = await testRunSetAdditionalFile.GetFileContents())
            {
                using (var streamReader = new System.IO.StreamReader(stream))
                {
                    var candidate = streamReader.ReadToEnd();
                    Assert.Equal(expectedStringContents, candidate);
                }
            }

            apiServiceMock.Verify();
        }
    }
}