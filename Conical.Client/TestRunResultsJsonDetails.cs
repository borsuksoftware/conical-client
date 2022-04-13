using System;
using System.Collections.Generic;
using System.Text;

namespace BorsukSoftware.Conical.Client
{
	public class TestRunResultsJsonDetails : ITestRunResultsJsonDetails
	{
		public int Length { get; private set; }

		public TestRunResultsJsonDetails( int length )
		{
			this.Length = length;
		}
	}
}
