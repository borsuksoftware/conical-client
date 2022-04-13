using System;
using System.Collections.Generic;
using System.Text;

namespace BorsukSoftware.Conical.Client
{
	public class MemorySnapshot : IMemorySnapshot
	{
		#region IMemorySnapshot Members

		public long? WorkingSet { get; private set; }

		public long? VirtualMemorySize { get; private set; }

		public long? NonpagedSystemMemorySize { get; private set; }

		public long? PagedMemorySize { get; private set; }

		public long? PagedSystemMemorySize { get; private set; }

		public long? PeakPagedMemorySize { get; private set; }

		public long? PeakVirtualMemorySize { get; private set; }

		public long? PeakWorkingSet { get; private set; }

		public long? PrivateMemorySize { get; private set; }

		#endregion

		public MemorySnapshot(
			long? workingSet,
			long? virtualMemorySize,
			long? nonpagedSystemMemorySize,
			long? pagedMemorySize,
			long? pagedSystemMemorySize,
			long? peakPagedMemorySize,
			long? peakVirtualMemorySize,
			long? peakWorkingSet,
			long? privateMemorySize )
		{
			this.WorkingSet = workingSet;
			this.VirtualMemorySize = virtualMemorySize;
			this.NonpagedSystemMemorySize = nonpagedSystemMemorySize;
			this.PagedMemorySize = pagedMemorySize;
			this.PagedSystemMemorySize = pagedSystemMemorySize;
			this.PeakPagedMemorySize = peakPagedMemorySize;
			this.PeakVirtualMemorySize = peakVirtualMemorySize;
			this.PeakWorkingSet = peakWorkingSet;
			this.PrivateMemorySize = privateMemorySize;
		}

		public static MemorySnapshot SnapshotProcess()
		{
			var process = System.Diagnostics.Process.GetCurrentProcess();

			var toReturn = new MemorySnapshot(
				workingSet: process.WorkingSet64,
				virtualMemorySize: process.VirtualMemorySize64,
				nonpagedSystemMemorySize: process.NonpagedSystemMemorySize64,
				pagedMemorySize: process.PagedMemorySize64,
				pagedSystemMemorySize: process.PagedSystemMemorySize64,
				peakPagedMemorySize: process.PeakPagedMemorySize64,
				peakVirtualMemorySize: process.PeakVirtualMemorySize64,
				peakWorkingSet: process.PeakWorkingSet64,
				privateMemorySize: process.PrivateMemorySize64 );

			return toReturn;

		}
	}
}
