using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xunit;

namespace BorsukSoftware.Conical.Client.TDD
{
    public class Tests
    {

        [Fact(Skip = "Development Only")]
        public async void DownloadData()
        {
            var access = new REST.AccessLayer("https://localhost:44316");

            var product = await access.GetProduct("demo");

            var testRunSet = await product.GetTestRunSet(15);
            var testRuns = await testRunSet.GetTestRuns();

            var testRun = testRuns.FirstOrDefault(tr => tr.ID == 3010);
            Assert.NotNull(testRun);

            var logMessages = await testRun.GetLogMessages();
            var additionalFileDetails = await testRun.GetAdditionalFiles();

            Assert.NotNull(logMessages);
            Assert.NotNull(additionalFileDetails);

            Assert.NotEmpty(additionalFileDetails);

            var additionalFile = additionalFileDetails.FirstOrDefault();
            using (var stream = await additionalFile.GetFileContents())
            {
                using (var outputStream = new System.IO.FileStream($@"C:\Temp\{additionalFile.Name}", System.IO.FileMode.Create, System.IO.FileAccess.Write))
                    await stream.CopyToAsync(outputStream);
            }

            Assert.True(true);
        }
    }
}
