using System;
using System.Collections.Generic;
using System.Text;

namespace BorsukSoftware.Conical.Client
{
	/// <summary>
	/// Enum detailing the status of a test run set
	/// </summary>
	public enum TestRunSetStatus
	{
		/// <summary>
		/// The test run set is open for data publishing
		/// </summary>
		Publishing = 0,

		/// <summary>
		/// The standard status for a test run set post publishing
		/// </summary>
		Standard = 1,

		/// <summary>
		/// The test run set has been locked and can only be deleted / changed by users with additional permissions
		/// </summary>
		Locked = 2,

		/// <summary>
		/// The test run set has been marked for deletion
		/// </summary>
		RecycleBin = 3,
	}
}
