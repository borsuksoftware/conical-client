using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BorsukSoftware.Conical.Client.REST
{
    public class TestRunSet : ITestRunSet
    {
        #region Data Model
        public IApiService ApiService { get; }

        public string Product { get; }

        public int ID { get; }

        public string Name { get; }

        public string Description { get; }

        public Client.TestRunSetStatus Status { get; private set; }

        public DateTime RefDate { get; }

        public DateTime RunDate { get; }

        public string Creator { get; }

        public IReadOnlyCollection<string> Tags { get; }

        #endregion

        #region Construction Logic

        public TestRunSet(IApiService apiService,
            string product,
            int id,
            string name,
            string description,
            Client.TestRunSetStatus status,
            DateTime refDate,
            DateTime runDate,
            string creator,
            IReadOnlyCollection<string> tags)
        {
            if (apiService == null)
                throw new ArgumentNullException(nameof(apiService));

            this.ApiService = apiService;
            this.ID = id;
            this.Name = name;
            this.Description = description;
            this.RefDate = refDate;
            this.RunDate = runDate;
            this.Status = status;
            this.Product = product;
            this.Creator = creator;
            this.Tags = tags;
        }

        #endregion

        #region ITestRunSet Members

        public async Task<IReadOnlyCollection<ITestRun>> GetTestRuns()
        {
            var rawResults = await this.ApiService.ProductTestRunSetTestRuns(this.Product, this.ID);

            var output = rawResults.Select(trm => new TestRun(this.ApiService, this, trm.id, trm.name, trm.description, trm.testType, trm.status.ConvertToTestRunStatus())).ToList();
            return output;
        }

        public async Task<ITestRun> CreateTestRun(
            string testRunName, 
            string testRunDescription,
            string testRunType,
            TestRunStatus testStatus)
        {
            var raw = await this.ApiService.UploadCreateTestRun(this.Product, this.ID, testRunName, testRunDescription, testRunType, testStatus.ConvertToTestStatus());

            // TODO - Update the API to return more data
            var output = new TestRun(this.ApiService, this, raw.id, testRunName, testRunDescription, testRunType, testStatus);
            return output;
        }

        public async Task<ITestRunSetAuditTrail> GetAuditTrail()
        {
            var raw = await this.ApiService.ProductTestRunSetAuditTrail(this.Product, this.ID);

            var output = new TestRunSetAuditTrail(raw.messages.Select(m => new Client.TestRunSetAuditTrailMessage()
            {
                Message = m.message,
                Product = m.product,
                TestRunID = m.testRunID,
                TestRunSetID = m.testRunSetID,
                TimeStamp = m.timestamp,
                User = m.user
            }));

            return output;
        }

        public async Task SetStatus(Client.TestRunSetStatus status)
		{
            REST.TestRunSetStatus apiStatus = status.ConvertToApiTestRunSetStatus();

            await this.ApiService.ProductTestRunSetUpdateStatus(this.Product, this.ID, apiStatus);

            this.Status = status;
		}

        public async Task PublishAdditionalFile(string fileName, string description, System.IO.Stream file)
        {
            if (string.IsNullOrEmpty(fileName))
                throw new ArgumentNullException(nameof(fileName));

            if (file == null)
                throw new ArgumentNullException(nameof(file));

            var bytes = new byte[file.Length];
            await file.ReadAsync(bytes, 0, bytes.Length);
            await this.ApiService.UploadPublishTestRunSetAdditionalFile(this.Product, this.ID, fileName, description, bytes, fileName, null);
        }

        public async Task PublishExternalLinks(IReadOnlyCollection<Client.ExternalLink> externalLinks)
        {
            if (externalLinks == null)
                throw new ArgumentNullException(nameof(externalLinks));

            await this.ApiService.UploadPublishTestRunSetExternalLinks(this.Product,
                this.ID,
                new UploadExternalLinksModel
                {
                    externalLinks = externalLinks.Select(l => new ExternalLink { name = l.Name, url = l.Url, description = l.Description }).ToArray()
                });
        }

        public async Task<IReadOnlyCollection<Client.ExternalLink>> GetExternalLinks()
        {
            var model = await this.ApiService.ProductTestRunSetExternalLinks(this.Product, this.ID);

            var output = model.Select(l => new Client.ExternalLink(l.name, l.url, l.description)).ToList();
            return output;
        }

        public async Task<IReadOnlyCollection<IAdditionalFile>> GetAdditionalFiles()
        {
            var model = await this.ApiService.ProductTestRunSetAdditionalFiles(this.Product, this.ID);
            var output = model.Select(m => new TestRunAdditionalFile(this.ApiService, this, this.ID, m.filename, m.description, m.filesize)).ToList();
            return output;
        }

        #endregion
    }
}
