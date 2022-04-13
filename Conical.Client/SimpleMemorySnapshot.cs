using System;
using System.Collections.Generic;
using System.Text;

namespace BorsukSoftware.Conical.Client
{
	public class SimpleMemorySnapshot : ISimpleMemorySnapshot
	{
		public IMemorySnapshot Start { get; private set; }

		public IMemorySnapshot End { get; private set; }

		public SimpleMemorySnapshot( 
			IMemorySnapshot start, 
			IMemorySnapshot end )
		{
			this.Start = start;
			this.End = end;
		}
	}
}
