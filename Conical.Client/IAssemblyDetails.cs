using System;
using System.Collections.Generic;
using System.Text;

namespace BorsukSoftware.Conical.Client
{
	public interface IAssemblyDetails
	{
		string Name { get; }

		string Architecture { get; }

		string Version { get; }

		string Culture { get; }

		byte [] PublicToken { get; }

		string Path { get; }

		DateTime TimeStamp { get; }
	}
}
