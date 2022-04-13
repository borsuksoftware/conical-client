using System;
using System.Collections.Generic;
using System.Text;

namespace BorsukSoftware.Conical.Client.REST
{
    /// <summary>
    /// Utils class for working with the REST API
    /// </summary>
    public static class RESTUtils
    {
        #region TestRunStatus Conversion Code

        public static TestRunStatus ConvertToTestRunStatus(this TestStatus testStatus)
        {
            switch (testStatus)
            {
                case TestStatus.exception:
                    return TestRunStatus.Exception;

                case TestStatus.failed:
                    return TestRunStatus.Failed;

                case TestStatus.passed:
                    return TestRunStatus.Passed;

                case TestStatus.unknown:
                    return TestRunStatus.Unknown;

                default:
                    throw new NotSupportedException($"Don't know how to convert '{testStatus}' to a valid TestStatus");
            }
        }

        public static TestStatus ConvertToTestStatus(this TestRunStatus testRunStatus)
        {
            switch (testRunStatus)
            {
                case TestRunStatus.Exception:
                    return TestStatus.exception;

                case TestRunStatus.Failed:
                    return TestStatus.failed;

                case TestRunStatus.Passed:
                    return TestStatus.passed;

                case TestRunStatus.Unknown:
                    return TestStatus.unknown;

                default:
                    throw new NotSupportedException($"Don't know how to convert '{testRunStatus}' into a valid enum value for the API");

            }
        } 

        #endregion

        #region TestRunSetStatus Conversion Code

        public static Client.TestRunSetStatus ConvertToClientTestRunSetStatus(this TestRunSetStatus status)
        {
            switch (status)
            {
                case TestRunSetStatus.publishing:
                    return Client.TestRunSetStatus.Publishing;

                case TestRunSetStatus.standard:
                    return Client.TestRunSetStatus.Standard;

                case TestRunSetStatus.locked:
                    return Client.TestRunSetStatus.Locked;

                case TestRunSetStatus.recycleBin:
                    return Client.TestRunSetStatus.RecycleBin;

                default:
                    throw new NotSupportedException($"Don't know how to convert '{status}' to a valid core status");
            }
        }

        public static REST.TestRunSetStatus ConvertToApiTestRunSetStatus(this Client.TestRunSetStatus status)
        {
            switch (status)
            {
                case Client.TestRunSetStatus.Publishing:
                    return TestRunSetStatus.publishing;

                case Client.TestRunSetStatus.Standard:
                    return TestRunSetStatus.standard;

                case Client.TestRunSetStatus.Locked:
                    return TestRunSetStatus.locked;

                case Client.TestRunSetStatus.RecycleBin:
                    return TestRunSetStatus.recycleBin;

                default:
                    throw new NotSupportedException($"Don't know how to convert '{status}' to a valid REST API status");
            }
        } 

        #endregion

        #region Product Status Conversion Code

        public static Client.ProductStatus ConvertToClientProductStatus( this ProductStatus productStatus)
        {
            switch( productStatus)
            {
                case ProductStatus.archived:
                    return Client.ProductStatus.Archived;

                case ProductStatus.deleting:
                    return Client.ProductStatus.Deleting;

                case ProductStatus.recycleBin:
                    return Client.ProductStatus.RecycleBin;

                case ProductStatus.standard:
                    return Client.ProductStatus.Standard;

                default:
                    throw new NotSupportedException($"Don't know how to convert '{productStatus}' to a valid Client status");
            }
        }

        public static ProductStatus ConvertToApiProductStatus(this Client.ProductStatus productStatus)
        {
            switch( productStatus )
            {
                case Client.ProductStatus.Archived:
                    return ProductStatus.archived;

                case Client.ProductStatus.Deleting:
                    return ProductStatus.deleting;

                case Client.ProductStatus.RecycleBin:
                    return ProductStatus.recycleBin;

                case Client.ProductStatus.Standard:
                    return ProductStatus.standard;

                default:
                    throw new NotSupportedException($"Don't know how to convert '{productStatus}' to a valid REST API status");
            }
        }

        #endregion

        #region Product Privilege Conversion Code

        public static REST.ProductPrivilege ConvertToApiProductPrivilege(this Client.ProductPrivilege productPrivilege)
		{
            switch( productPrivilege )
			{
                case Client.ProductPrivilege.Admin:
                    return ProductPrivilege.admin;

                case Client.ProductPrivilege.AuditTrail:
                    return ProductPrivilege.auditTrail;

                case Client.ProductPrivilege.Commenter:
                    return ProductPrivilege.commenter;

                case Client.ProductPrivilege.CommentsAdmin:
                    return ProductPrivilege.commentsAdmin;

                case Client.ProductPrivilege.Configurator:
                    return ProductPrivilege.configurator;

                case Client.ProductPrivilege.Publisher:
                    return ProductPrivilege.publisher;

                case Client.ProductPrivilege.TestRunSetDeleter:
                    return ProductPrivilege.testRunSetDeleter;

                case Client.ProductPrivilege.Viewer:
                    return ProductPrivilege.viewer;

                default:
                    throw new NotSupportedException($"Don't know how to convert '{productPrivilege}' to a valid REST API product privilege");
			}
		}


        public static Client.ProductPrivilege ConvertToClientProductPrivilege(this ProductPrivilege productPrivilege)
        {
            switch (productPrivilege)
            {
                case ProductPrivilege.admin:
                    return Client.ProductPrivilege.Admin;

                case ProductPrivilege.auditTrail:
                    return Client.ProductPrivilege.AuditTrail;

                case ProductPrivilege.commenter:
                    return Client.ProductPrivilege.Commenter;

                case ProductPrivilege.commentsAdmin:
                    return Client.ProductPrivilege.CommentsAdmin;

                case ProductPrivilege.configurator:
                    return Client.ProductPrivilege.Configurator;

                case ProductPrivilege.testRunSetDeleter:
                    return Client.ProductPrivilege.TestRunSetDeleter;

                case ProductPrivilege.publisher:
                    return Client.ProductPrivilege.Publisher;

                case ProductPrivilege.viewer:
                    return Client.ProductPrivilege.Viewer;

                default:
                    throw new NotSupportedException($"Don't know how to convert '{productPrivilege}' to a valid Client product privilege");
            }
        }

        #endregion

        #region Site Privilege Conversion Code

        public static REST.SitePrivilege ConvertToApiSitePrivilege(this Client.SitePrivilege sitePrivilege)
        {
            switch (sitePrivilege)
            {
                case Client.SitePrivilege.AnonymousUserAll:
                    return SitePrivilege.anonymousUserAll;

                case Client.SitePrivilege.AnonymousUserEdit:
                    return SitePrivilege.anonymousUserEdit;

                case Client.SitePrivilege.AnonymousUserEnable:
                    return SitePrivilege.anonymousUserEnable;

                case Client.SitePrivilege.AnonymousUserView:
                    return SitePrivilege.anonymousUserView;

                case Client.SitePrivilege.ErrorsAll:
                    return SitePrivilege.errorsAll;

                case Client.SitePrivilege.ErrorsClose:
                    return SitePrivilege.errorsClose;

                case Client.SitePrivilege.ErrorsView:
                    return SitePrivilege.errorsView;

                case Client.SitePrivilege.FrontPageConfigurator:
                    return SitePrivilege.frontPageConfigurator;

                case Client.SitePrivilege.GroupsAll:
                    return SitePrivilege.groupsAll;

                case Client.SitePrivilege.GroupsCreate:
                    return SitePrivilege.groupsCreate;

                case Client.SitePrivilege.GroupsDelete:
                    return SitePrivilege.groupsDelete;

                case Client.SitePrivilege.GroupsEdit:
                    return SitePrivilege.groupsEdit;

                case Client.SitePrivilege.GroupsView:
                    return SitePrivilege.groupsView;

                case Client.SitePrivilege.ProductsAdmin:
                    return SitePrivilege.productsAdmin;

                case Client.SitePrivilege.ProductsAuditTrail:
                    return SitePrivilege.productsAuditTrail;

                case Client.SitePrivilege.ProductsCommenter:
                    return SitePrivilege.productsCommenter;

                case Client.SitePrivilege.ProductsCommentsAdmin:
                    return SitePrivilege.productsCommentsAdmin;

                case Client.SitePrivilege.ProductsConfigurator:
                    return SitePrivilege.productsConfigurator;

                case Client.SitePrivilege.ProductsCreate:
                    return SitePrivilege.productsCreate;

                case Client.SitePrivilege.ProductsPublisher:
                    return SitePrivilege.productsPublisher;

                case Client.SitePrivilege.ProductsTestRunSetDeleter:
                    return SitePrivilege.productsTestRunSetDeleter;

                case Client.SitePrivilege.ProductsViewer:
                    return SitePrivilege.productsViewer;

                case Client.SitePrivilege.RolesAll:
                    return SitePrivilege.rolesAll;

                case Client.SitePrivilege.RolesCreate:
                    return SitePrivilege.rolesCreate;

                case Client.SitePrivilege.RolesDelete:
                    return SitePrivilege.rolesDelete;

                case Client.SitePrivilege.RolesEdit:
                    return SitePrivilege.rolesEdit;

                case Client.SitePrivilege.RolesView:
                    return SitePrivilege.rolesView;

                case Client.SitePrivilege.SuperUser:
                    return SitePrivilege.superUser;

                case Client.SitePrivilege.UsersAll:
                    return SitePrivilege.usersAll;

                case Client.SitePrivilege.UsersCreate:
                    return SitePrivilege.usersCreate;

                case Client.SitePrivilege.UsersDelete:
                    return SitePrivilege.usersDelete;

                case Client.SitePrivilege.UsersEdit:
                    return SitePrivilege.usersEdit;

                case Client.SitePrivilege.UsersView:
                    return SitePrivilege.usersView;

                default:
                    throw new NotSupportedException($"Don't know how to convert '{sitePrivilege}' to a valid REST API site privilege");
            }
        }


        public static Client.SitePrivilege ConvertToClientSitePrivilege(this SitePrivilege sitePrivilege)
        {
            switch (sitePrivilege)
            {
                case SitePrivilege.anonymousUserAll:
                    return Client.SitePrivilege.AnonymousUserAll;

                case SitePrivilege.anonymousUserEdit:
                    return Client.SitePrivilege.AnonymousUserEdit;

                case SitePrivilege.anonymousUserEnable:
                    return Client.SitePrivilege.AnonymousUserEnable;

                case SitePrivilege.anonymousUserView:
                    return Client.SitePrivilege.AnonymousUserView;

                case SitePrivilege.errorsAll:
                    return Client.SitePrivilege.ErrorsAll;

                case SitePrivilege.errorsClose:
                    return Client.SitePrivilege.ErrorsClose;

                case SitePrivilege.errorsView:
                    return Client.SitePrivilege.ErrorsView;

                case SitePrivilege.frontPageConfigurator:
                    return Client.SitePrivilege.FrontPageConfigurator;

                case SitePrivilege.groupsAll:
                    return Client.SitePrivilege.GroupsAll;

                case SitePrivilege.groupsCreate:
                    return Client.SitePrivilege.GroupsCreate;

                case SitePrivilege.groupsDelete:
                    return Client.SitePrivilege.GroupsDelete;

                case SitePrivilege.groupsEdit:
                    return Client.SitePrivilege.GroupsEdit;

                case SitePrivilege.groupsView:
                    return Client.SitePrivilege.GroupsView;

                case SitePrivilege.productsAdmin:
                    return Client.SitePrivilege.ProductsAdmin;

                case SitePrivilege.productsAuditTrail:
                    return Client.SitePrivilege.ProductsAuditTrail;

                case SitePrivilege.productsCommenter:
                    return Client.SitePrivilege.ProductsCommenter;

                case SitePrivilege.productsCommentsAdmin:
                    return Client.SitePrivilege.ProductsCommentsAdmin;

                case SitePrivilege.productsConfigurator:
                    return Client.SitePrivilege.ProductsConfigurator;

                case SitePrivilege.productsCreate:
                    return Client.SitePrivilege.ProductsCreate;

                case SitePrivilege.productsTestRunSetDeleter:
                    return Client.SitePrivilege.ProductsTestRunSetDeleter;

                case SitePrivilege.productsPublisher:
                    return Client.SitePrivilege.ProductsPublisher;

                case SitePrivilege.productsViewer:
                    return Client.SitePrivilege.ProductsViewer;

                case SitePrivilege.rolesAll:
                    return Client.SitePrivilege.RolesAll;

                case SitePrivilege.rolesCreate:
                    return Client.SitePrivilege.RolesCreate;

                case SitePrivilege.rolesDelete:
                    return Client.SitePrivilege.RolesDelete;

                case SitePrivilege.rolesEdit:
                    return Client.SitePrivilege.RolesEdit;

                case SitePrivilege.rolesView:
                    return Client.SitePrivilege.RolesView;

                case SitePrivilege.superUser:
                    return Client.SitePrivilege.SuperUser;

                case SitePrivilege.usersAll:
                    return Client.SitePrivilege.UsersAll;

                case SitePrivilege.usersCreate:
                    return Client.SitePrivilege.UsersCreate;

                case SitePrivilege.usersDelete:
                    return Client.SitePrivilege.UsersDelete;

                case SitePrivilege.usersEdit:
                    return Client.SitePrivilege.UsersEdit;

                case SitePrivilege.usersView:
                    return Client.SitePrivilege.UsersView;

                default:
                    throw new NotSupportedException($"Don't know how to convert '{sitePrivilege}' to a valid Client site privilege");
            }
        }

        #endregion


        /// <summary>
        /// Convert the supplied image to a byte array in the specified format
        /// </summary>
        public static byte[] ImageToByteArray(System.Drawing.Image image, System.Drawing.Imaging.ImageFormat imageFormat)
        {
            if (image == null)
                throw new ArgumentNullException(nameof(image));

            Byte[] imageBytes;
            using (var memoryStream = new System.IO.MemoryStream())
            {
                image.Save(memoryStream, imageFormat);

                imageBytes = new byte[memoryStream.Position];

                using (var ostream = new System.IO.MemoryStream(imageBytes))
                {

                    memoryStream.Position = 0;
                    memoryStream.CopyTo(ostream, imageBytes.Length);

                }
            }

            return imageBytes;
        }
    }
}
