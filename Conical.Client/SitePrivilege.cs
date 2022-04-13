using System;
using System.Collections.Generic;
using System.Text;

namespace BorsukSoftware.Conical.Client
{
	/// <summary>
	/// Enum detailing the privilieges available to a user at a site level
	/// </summary>
	public enum SitePrivilege
	{
		AnonymousUserAll,
		AnonymousUserEnable,
		AnonymousUserEdit,
		AnonymousUserView,
		UsersAll,
		UsersCreate,
		UsersDelete,
		UsersEdit,
		UsersView,
		GroupsAll,
		GroupsCreate,
		GroupsDelete,
		GroupsEdit,
		GroupsView,
		RolesAll,
		RolesDelete,
		RolesCreate,
		RolesEdit,
		RolesView,
		ProductsAdmin,
		ProductsCreate,
		ProductsConfigurator,
		ProductsDelete,
		ProductsPublisher,
		ProductsViewer,
		ProductsAuditTrail,
		ProductsCommenter,
		ProductsCommentsAdmin,
		ProductsTestRunSetDeleter,
		ErrorsAll,
		ErrorsView,
		ErrorsClose,
		SuperUser,
		FrontPageConfigurator,
		ServerMetrics
	}
}
