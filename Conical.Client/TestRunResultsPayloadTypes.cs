using System;
using System.Collections.Generic;
using System.Text;

namespace BorsukSoftware.Conical.Client
{
	/// <summary>
	/// Enum to describe the format of the results payload
	/// </summary>
	public enum TestRunResultsPayloadTypes
	{
		/// <summary>
		/// The results are plain text
		/// </summary>
		Text = 0,

		/// <summary>
		/// The results are standard JSon
		/// </summary>
		JSon = 1,

		/// <summary>
		/// The results are XML
		/// </summary>
		XML = 2,
	}
}
