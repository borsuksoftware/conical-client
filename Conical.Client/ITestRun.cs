using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace BorsukSoftware.Conical.Client
{
	public interface ITestRun
	{
		ITestRunSet TestRunSet { get; }

		int ID { get; }

		string Name { get; }

		string TestType { get; }

		string Description { get; }

		TestRunStatus Status { get; }

		#region Results XML / Text / Json Code

		Task<ITestRunResultsXmlDetails> GetResultsXmlDetails();

		Task<string> GetResultsJson();

		Task<ITestRunResultsJsonDetails> GetResultsJsonDetails();

		Task<string> GetResultsXml();

		Task<ITestRunResultsTextDetails> GetResultsTextDetails();

		Task<string> GetResultsText();

		#endregion

		#region DotNet Assemblies

		Task<IReadOnlyCollection<IAssemblyDetails>> GetDotNetAssemblies();

        #endregion

        #region Memory

        Task<ISimpleMemorySnapshot> GetSimpleMemorySnapshot();

		#endregion

		Task<IReadOnlyList<string>> GetLogMessages();

		Task<IReadOnlyCollection<IAdditionalFile>> GetAdditionalFiles();

		Task<IReadOnlyCollection<ExternalLink>> GetExternalLinks();

        #region Upload functionality

        Task PublishSimpleMemorySnapshot(ISimpleMemorySnapshot simpleMemorySnapshot);

		Task PublishTestRunAssemblies(IReadOnlyCollection<IAssemblyDetails> assemblies);

		Task PublishTestRunAdditionalFile(string fileName, string description, Stream file);

		Task PublishTestRunLogMessages(IEnumerable<string> logMessages);

		Task PublishTestRunResultsXml(string resultsXml);

		Task PublishTestRunResultsJson(string resultsJson);

		Task PublishTestRunResultsText(string resultsText);

		Task PublishTestRunResultsCsv(string csvData);

		Task PublishTestRunResultsTsv(string tsvData);

		Task PublishTestRunExternalLinks(IReadOnlyCollection<ExternalLink> externalLinks);

		#endregion
	}
}
