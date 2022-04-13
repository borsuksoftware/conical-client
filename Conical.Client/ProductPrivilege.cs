using System;
using System.Collections.Generic;
using System.Text;

namespace BorsukSoftware.Conical.Client
{
	/// <summary>
	/// Enum detailing the privileges available to a user on a product
	/// </summary>
	public enum ProductPrivilege
	{
		Admin,
		Configurator,
		TestRunSetDeleter,
		Publisher,
		Viewer,
		AuditTrail,
		Commenter,
		CommentsAdmin,
	}
}
