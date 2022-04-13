using System;
using System.Collections.Generic;
using System.Text;

namespace BorsukSoftware.Conical.Client
{
	/// <summary>
	/// Standard implementation of <see cref="ITestRunSetSearchResults"/>
	/// </summary>
	public class TestRunSetSearchResults : ITestRunSetSearchResults
	{
		#region ITestRunSetSearchResults Members

		public IReadOnlyCollection<ITestRunSetSummary> Results { get; private set; }

		#endregion

		public TestRunSetSearchResults( IEnumerable<ITestRunSetSummary> results )
		{
			this.Results = new List<ITestRunSetSummary>( results ?? Array.Empty<ITestRunSetSummary>() );
		}
	}
}
