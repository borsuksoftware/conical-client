using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace BorsukSoftware.Conical.Client.REST
{
    public class TestRunAdditionalFile : IAdditionalFile
    {
        #region Data Model

        public IApiService ApiService { get; }

        public ITestRunSet TestRunSet { get; }

        public int TestRunID { get; }

        public string Name { get; }

        public string Description { get; }

        public long FileSize { get; }

        #endregion

        public TestRunAdditionalFile( IApiService apiService, ITestRunSet testRunSet, int testRunID, string name, string description, long fileSize)
        {
            if (apiService == null)
                throw new ArgumentNullException(nameof(apiService));

            if (testRunSet == null)
                throw new ArgumentNullException(nameof(testRunSet));

            if (string.IsNullOrEmpty(name))
                throw new ArgumentNullException(nameof(name));

            this.ApiService = apiService;
            this.TestRunSet = testRunSet;
            this.TestRunID = testRunID;
            this.Name = name;
            this.Description = description;
            this.FileSize = fileSize;
        }

        #region IAdditionalFile Members
        public async Task<Stream> GetFileContents()
        {
            var stream = await this.ApiService.ProductTestRunSetTestRunAdditionalFileStream(
                this.TestRunSet.Product, 
                this.TestRunSet.ID, 
                this.TestRunID, 
                this.Name);
            return stream;
        }

        #endregion
    }
}
