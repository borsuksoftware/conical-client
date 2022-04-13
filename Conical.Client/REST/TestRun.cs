using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace BorsukSoftware.Conical.Client.REST
{
	public class TestRun : ITestRun
	{
        #region Data Model

        public IApiService ApiService { get; private set; }

        public int ID { get; private set; }

        public ITestRunSet TestRunSet { get; private set; }

        public string Name { get; private set; }

        public string TestType { get; private set; }

        public string Description { get; private set; }

        public TestRunStatus Status { get; private set; }

        #endregion

        public TestRun(IApiService apiService,
            ITestRunSet testRunSet,
            int id,
            string name,
            string description,
            string testType,
            TestRunStatus status)
        {
            if (apiService == null)
                throw new ArgumentNullException(nameof(apiService));

            this.ApiService = apiService;
            this.TestRunSet = testRunSet;
            this.ID = id;
            this.Name = name;
            this.Description = description;
            this.TestType = testType;
            this.Status = status;

        }

        #region Read Values

        public async Task<ITestRunResultsXmlDetails> GetResultsXmlDetails()
        {
            var rawDetails = await this.ApiService.ProductTestRunSetTestRunResultsXmlDetails(this.TestRunSet.Product, this.TestRunSet.ID, this.ID);

            if (!rawDetails.present)
                return null;

            var output = new TestRunResultsXmlDetails(rawDetails.length.Value);
            return output;
        }

        public async Task<string> GetResultsXml()
        {
            var rawString = await this.ApiService.ProductTestRunSetTestRunResultsXmlRaw(this.TestRunSet.Product, this.TestRunSet.ID, this.ID);
            return rawString;
        }

        public async Task<string> GetResultsJson()
        {
            var rawString = await this.ApiService.ProductTestRunSetTestRunResultsJsonRaw(this.TestRunSet.Product, this.TestRunSet.ID, this.ID);
            return rawString;
        }

        public async Task<ITestRunResultsJsonDetails> GetResultsJsonDetails()
        {
            var rawDetails = await this.ApiService.ProductTestRunSetTestRunResultsJsonDetails(this.TestRunSet.Product, this.TestRunSet.ID, this.ID);

            if (!rawDetails.present)
                return null;

            var output = new TestRunResultsJsonDetails(rawDetails.length.Value);
            return output;
        }

        public async Task<ITestRunResultsTextDetails> GetResultsTextDetails()
        {
            var rawDetails = await this.ApiService.ProductTestRunSetTestRunResultsTextDetails(this.TestRunSet.Product, this.TestRunSet.ID, this.ID);

            if (!rawDetails.present)
                return null;

            var output = new TestRunResultsTextDetails(rawDetails.length.Value);
            return output;
        }

        public async Task<string> GetResultsText()
        {
            var rawString = await this.ApiService.ProductTestRunSetTestRunResultsTextRaw(this.TestRunSet.Product, this.TestRunSet.ID, this.ID);
            return rawString;
        }

        public async Task<IReadOnlyCollection<IAssemblyDetails>> GetDotNetAssemblies()
        {
            var rawResults = await this.ApiService.ProductTestRunSetTestRunAssemblies(this.TestRunSet.Product, this.TestRunSet.ID, this.ID);

            var output = rawResults.Select(assembly => new AssemblyDetails(assembly.name, assembly.architecture, assembly.version, assembly.culture, assembly.publicToken, assembly.path, assembly.timeStamp)).ToList();

            return output;
        }

        public async Task<ISimpleMemorySnapshot> GetSimpleMemorySnapshot()
        {
            var rawDetails = await this.ApiService.ProductTestRunSetTestRunSimpleMemorySnapshot(this.TestRunSet.Product, this.TestRunSet.ID, this.ID);

            var output = new SimpleMemorySnapshot(
                new MemorySnapshot(
                    rawDetails.start?.workingSet,
                    rawDetails.start?.virtualMemorySize,
                    rawDetails.start?.nonpagedSystemMemorySize,
                    rawDetails.start?.pagedMemorySize,
                    rawDetails.start?.pagedSystemMemorySize,
                    rawDetails.start?.peakPagedMemorySize,
                    rawDetails.start?.peakVirtualMemorySize,
                    rawDetails.start?.peakWorkingSet,
                    rawDetails.start?.privateMemorySize),
                new MemorySnapshot(
                    rawDetails.end?.workingSet,
                    rawDetails.end?.virtualMemorySize,
                    rawDetails.end?.nonpagedSystemMemorySize,
                    rawDetails.end?.pagedMemorySize,
                    rawDetails.end?.pagedSystemMemorySize,
                    rawDetails.end?.peakPagedMemorySize,
                    rawDetails.end?.peakVirtualMemorySize,
                    rawDetails.end?.peakWorkingSet,
                    rawDetails.end?.privateMemorySize)
                );

            return output;
        }

        public async Task<IReadOnlyList<string>> GetLogMessages()
        {
            var model = await this.ApiService.ProductTestRunSetTestRunLogsMessages(this.TestRunSet.Product, this.TestRunSet.ID, this.ID);
            return model.messages;
        }

        public async Task<IReadOnlyCollection<IAdditionalFile>> GetAdditionalFiles()
        {
            var model = await this.ApiService.ProductTestRunSetTestRunAdditionalFiles(this.TestRunSet.Product, this.TestRunSet.ID, this.ID);
            var output = model.Select(m => new TestRunAdditionalFile(this.ApiService, this.TestRunSet, this.ID, m.filename, m.description, m.filesize)).ToList();
            return output;
        }

        public async Task<IReadOnlyCollection<Client.ExternalLink>> GetExternalLinks()
        {
            var model = await this.ApiService.ProductTestRunSetTestRunExternalLinks(this.TestRunSet.Product, this.TestRunSet.ID, this.ID);
            var output = model.Select(l => new Client.ExternalLink(l.name, l.url, l.description)).ToList();
            return output;
        }

        #endregion

        #region Populate values

        public Task PublishSimpleMemorySnapshot(ISimpleMemorySnapshot simpleMemorySnapshot)
        {
            if (simpleMemorySnapshot == null)
                throw new ArgumentNullException(nameof(simpleMemorySnapshot));

            var model = new SimpleMemorySnapshotModel
            {
                start = new MemorySnapshotModel
                {
                    nonpagedSystemMemorySize = simpleMemorySnapshot.Start.NonpagedSystemMemorySize,
                    pagedMemorySize = simpleMemorySnapshot.Start.PagedMemorySize,
                    pagedSystemMemorySize = simpleMemorySnapshot.Start.PagedSystemMemorySize,
                    peakPagedMemorySize = simpleMemorySnapshot.Start.PeakPagedMemorySize,
                    peakVirtualMemorySize = simpleMemorySnapshot.Start.PeakVirtualMemorySize,
                    peakWorkingSet = simpleMemorySnapshot.Start.PeakWorkingSet,
                    privateMemorySize = simpleMemorySnapshot.Start.PrivateMemorySize,
                    virtualMemorySize = simpleMemorySnapshot.Start.VirtualMemorySize,
                    workingSet = simpleMemorySnapshot.Start.WorkingSet,
                },
                end = new MemorySnapshotModel
                {
                    nonpagedSystemMemorySize = simpleMemorySnapshot.End.NonpagedSystemMemorySize,
                    pagedMemorySize = simpleMemorySnapshot.End.PagedMemorySize,
                    pagedSystemMemorySize = simpleMemorySnapshot.End.PagedSystemMemorySize,
                    peakPagedMemorySize = simpleMemorySnapshot.End.PeakPagedMemorySize,
                    peakVirtualMemorySize = simpleMemorySnapshot.End.PeakVirtualMemorySize,
                    peakWorkingSet = simpleMemorySnapshot.End.PeakWorkingSet,
                    privateMemorySize = simpleMemorySnapshot.End.PrivateMemorySize,
                    virtualMemorySize = simpleMemorySnapshot.End.VirtualMemorySize,
                    workingSet = simpleMemorySnapshot.End.WorkingSet,
                }
            };

            return this.ApiService.UploadPublishTestRunSimpleMemorySnapshot(this.TestRunSet.Product, 
                this.TestRunSet.ID, 
                this.ID,
                model);
        }

        public Task PublishTestRunAssemblies(IReadOnlyCollection<IAssemblyDetails> assemblies)
        {
            if (assemblies == null)
                throw new ArgumentNullException(nameof(assemblies));

            var body = assemblies.Select(orig => new TestRunAssemblyModel
            {
                architecture = orig.Architecture,
                culture = orig.Culture,
                name = orig.Culture,
                path = orig.Path,
                publicToken = orig.PublicToken,
                timeStamp = orig.TimeStamp,
                version = orig.Version
            }).ToArray();

            return this.ApiService.UploadPublishTestRunAssemblies(this.TestRunSet.Product,
                this.TestRunSet.ID,
                this.ID,
                body);
        }

        public async Task PublishTestRunAdditionalFile(string fileName, string description, Stream file)
        {
            if (string.IsNullOrEmpty(fileName))
                throw new ArgumentNullException(nameof(fileName));

            if (file == null)
                throw new ArgumentNullException(nameof(file));

            var bytes = new byte[file.Length];
            await file.ReadAsync(bytes, 0, bytes.Length);
            await this.ApiService.UploadPublishTestRunAdditionalFile(this.TestRunSet.Product, this.TestRunSet.ID, this.ID, fileName, description, bytes, fileName, null); ;
        }

        public Task PublishTestRunLogMessages(IEnumerable<string> logMessages)
        {
            if (logMessages == null)
                throw new ArgumentNullException(nameof(logMessages));

            var body = logMessages.ToArray();

            return this.ApiService.UploadPublishTestRunLogMessages(this.TestRunSet.Product,
                this.TestRunSet.ID,
                this.ID,
                body);
        }

        public async Task PublishTestRunResultsXml(string resultsXml)
        {
            if (string.IsNullOrEmpty(resultsXml))
                throw new ArgumentNullException(nameof(resultsXml));

            await this.ApiService.UploadPublishTestRunResults(this.TestRunSet.Product,
                this.TestRunSet.ID,
                this.ID,
                TestRunResultTypes.xml,
                resultsXml);
        }

        public async Task PublishTestRunResultsJson(string resultsJson)
        {
            if (string.IsNullOrEmpty(resultsJson))
                throw new ArgumentNullException(nameof(resultsJson));

            await this.ApiService.UploadPublishTestRunResults(this.TestRunSet.Product,
                this.TestRunSet.ID,
                this.ID,
                TestRunResultTypes.jSon,
                resultsJson);
        }

        public async Task PublishTestRunResultsText(string resultsText)
        {
            if (string.IsNullOrEmpty(resultsText))
                throw new ArgumentNullException(nameof(resultsText));

            await this.ApiService.UploadPublishTestRunResults(this.TestRunSet.Product,
                this.TestRunSet.ID,
                this.ID,
                TestRunResultTypes.text,
                resultsText);
        }

        public async Task PublishTestRunResultsCsv(string csvData)
        {
            if (string.IsNullOrEmpty(csvData))
                throw new ArgumentNullException(nameof(csvData));

            await this.ApiService.UploadPublishTestRunXsvResults(this.TestRunSet.Product,
                this.TestRunSet.ID,
                this.ID,
                XsvStyle.csv,
                csvData);
        }

        public async Task PublishTestRunResultsTsv(string tsvData)
        {
            if (string.IsNullOrEmpty(tsvData))
                throw new ArgumentNullException(nameof(tsvData));

            await this.ApiService.UploadPublishTestRunXsvResults(this.TestRunSet.Product,
                this.TestRunSet.ID,
                this.ID,
                XsvStyle.tsv,
                tsvData);
        }

        public async Task PublishTestRunExternalLinks(IReadOnlyCollection<Client.ExternalLink> externalLinks)
        {
            if (externalLinks == null)
                throw new ArgumentNullException(nameof(externalLinks));

            await this.ApiService.UploadPublishTestRunExternalLinks(this.TestRunSet.Product,
                this.TestRunSet.ID,
                this.ID,
                new UploadExternalLinksModel
                {
                    externalLinks = externalLinks.Select(l => new ExternalLink { name = l.Name, url = l.Url, description = l.Description }).ToArray()
                });
        }

        #endregion
    }
}
