using System;
using System.Collections.Generic;
using System.Text;

namespace BorsukSoftware.Conical.Client
{
	public class TestRunResultsXmlDetails : ITestRunResultsXmlDetails
	{
		public int Length { get; private set; }

		public TestRunResultsXmlDetails( int length )
		{
			this.Length = length;
		}
	}
}
