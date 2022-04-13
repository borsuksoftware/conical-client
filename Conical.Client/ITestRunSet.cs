using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BorsukSoftware.Conical.Client
{
	public interface ITestRunSet
	{
        int ID { get; }

		string Name { get; }

		string Description { get; }

		TestRunSetStatus Status { get; }

		DateTime RefDate { get; }

		DateTime RunDate { get; }

		string Product { get; }

		string Creator { get; }

		IReadOnlyCollection<string> Tags { get; }

		Task<IReadOnlyCollection<ITestRun>> GetTestRuns();

		/// <summary>
		/// Create a new test run in this set
		/// </summary>
		/// <remarks>Note that depending upon permissions / state of the underlying, this can fail</remarks>
		/// <param name="testRunType"></param>
		/// <param name="testRunName"></param>
		/// <param name="testRunDescription"></param>
		/// <param name="testStatus"></param>
		/// <returns></returns>
		Task<ITestRun> CreateTestRun(string testRunName, string testRunDescription, string testRunType, TestRunStatus testStatus);

		/// <summary>
		/// Gets the audit trail for the set
		/// </summary>
		/// <returns>The audit trail for the set</returns>
		Task<ITestRunSetAuditTrail> GetAuditTrail();

		Task SetStatus(TestRunSetStatus status);

		Task<IReadOnlyCollection<IAdditionalFile>> GetAdditionalFiles();

		Task<IReadOnlyCollection<ExternalLink>> GetExternalLinks();

		Task PublishAdditionalFile(string fileName, string description, System.IO.Stream file);
		Task PublishExternalLinks(IReadOnlyCollection<ExternalLink> externalLinks);
	}
}
