using System;
using System.Collections.Generic;
using System.Text;

namespace BorsukSoftware.Conical.Client
{
	public interface IMemorySnapshot
	{
		long? WorkingSet { get; }
		long? VirtualMemorySize { get; }
		long? NonpagedSystemMemorySize { get; }
		long? PagedMemorySize { get; }
		long? PagedSystemMemorySize { get; }
		long? PeakPagedMemorySize { get; }
		long? PeakVirtualMemorySize { get; }
		long? PeakWorkingSet { get; }
		long? PrivateMemorySize { get; }
	}
}
