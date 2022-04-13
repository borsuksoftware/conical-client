using System;
using System.Collections.Generic;
using System.Text;

namespace BorsukSoftware.Conical.Client
{
	public class TestRunResultsTextDetails : ITestRunResultsTextDetails
	{
		public int Length { get; private set; }

		public TestRunResultsTextDetails( int length )
		{
			this.Length = length;
		}
	}
}
