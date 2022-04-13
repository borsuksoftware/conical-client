using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace BorsukSoftware.Conical.Client.REST
{
    public class TestRunSetAdditionalFile : IAdditionalFile
    {
        #region Data Model

        public IApiService ApiService { get; }

        public ITestRunSet TestRunSet { get; }

        public string Name { get; }

        public string Description { get; }

        public long FileSize { get; }

        #endregion

        public TestRunSetAdditionalFile( IApiService apiService, ITestRunSet testRunSet, string name, string description, long fileSize)
        {
            if (apiService == null)
                throw new ArgumentNullException(nameof(apiService));

            if (testRunSet == null)
                throw new ArgumentNullException(nameof(testRunSet));

            if (string.IsNullOrEmpty(name))
                throw new ArgumentNullException(nameof(name));

            this.ApiService = apiService;
            this.TestRunSet = testRunSet;
            this.Name = name;
            this.Description = description;
            this.FileSize = fileSize;
        }

        #region IAdditionalFile Members
        public async Task<Stream> GetFileContents()
        {
            var stream = await this.ApiService.ProductTestRunSetAdditionalFileStream(
                this.TestRunSet.Product, 
                this.TestRunSet.ID, 
                this.Name);
            return stream;
        }

        #endregion
    }
}
