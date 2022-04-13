using System;
using System.Collections.Generic;
using System.Text;

namespace BorsukSoftware.Conical.Client
{
	public interface ITestRunSetSearchResults
	{
		IReadOnlyCollection<ITestRunSetSummary> Results { get; }
	}
}
