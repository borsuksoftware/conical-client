using System;

using Xunit;
using Moq;

namespace BorsukSoftware.Conical.Client.REST
{
	public class RESTUtilsTests
	{
		[Fact]
		public void CheckRestTestStatusRoundTrips()
		{

			foreach( var enumValue in Enum.GetValues<TestStatus>())
			{
				var clientValue = enumValue.ConvertToTestRunStatus();
				var roundTrippedValue = clientValue.ConvertToTestStatus();

				Assert.Equal(enumValue, roundTrippedValue);
			}
		}

		[Fact]
		public void CheckRestTestRunSetStatusRoundTrips()
		{

			foreach( var enumValue in Enum.GetValues<TestRunSetStatus>())
			{
				var clientValue = enumValue.ConvertToClientTestRunSetStatus();
				var roundTrippedValue = clientValue.ConvertToApiTestRunSetStatus();

				Assert.Equal(enumValue, roundTrippedValue);
			}
		}

		[Fact]
		public void CheckRestProductStatusEnumRoundTrips()
		{
			foreach (var productStatus in Enum.GetValues<REST.ProductStatus>())
			{
				Client.ProductStatus clientProductStatus = productStatus.ConvertToClientProductStatus();
				REST.ProductStatus restProductStatusPostTransform = clientProductStatus.ConvertToApiProductStatus();

				Assert.Equal(productStatus, restProductStatusPostTransform);
			}
		}

		[Fact]
		public void CheckRestProductPrivilegesEnumRoundTrips()
		{
			foreach( var productPrivilege in Enum.GetValues<REST.ProductPrivilege>() )
			{
				Client.ProductPrivilege clientProductPrivilege = productPrivilege.ConvertToClientProductPrivilege();
				REST.ProductPrivilege restProductPrivilegePostTransform = clientProductPrivilege.ConvertToApiProductPrivilege();

				Assert.Equal(productPrivilege, restProductPrivilegePostTransform);
			}
		}

		[Fact]
		public void CheckRestSitePrivilegesEnumRoundTrips()
		{
			foreach (var sitePrivilege in Enum.GetValues<REST.SitePrivilege>())
			{
				Client.SitePrivilege clientSitePrivilege = sitePrivilege.ConvertToClientSitePrivilege();
				REST.SitePrivilege restSitePrivilegePostTransform = clientSitePrivilege.ConvertToApiSitePrivilege();

				Assert.Equal(sitePrivilege, restSitePrivilegePostTransform);
			}
		}
	}
}
