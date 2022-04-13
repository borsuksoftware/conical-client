using System;
using System.Collections.Generic;
using System.Text;

namespace BorsukSoftware.Conical.Client
{
	public interface ISimpleMemorySnapshot
	{
		IMemorySnapshot Start { get; }
		IMemorySnapshot End { get; }
	}
}
