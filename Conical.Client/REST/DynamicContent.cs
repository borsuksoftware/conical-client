using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

#pragma warning disable IDE0034 // default can be simplified
#pragma warning disable IDE0063 // using can be simplified
#pragma warning disable IDE1006 // Naming Styles

namespace BorsukSoftware.Conical.Client.REST
{
    public class AdditionalFileDetails
    {
        public string filename { get; set; }
        public string description { get; set; }
        public int filesize { get; set; }
    }

    public class AdditionalRoleDetailsModel
    {
        public string name { get; set; }
        public string description { get; set; }
        public string[] initialGroups { get; set; }
        public string[] initialUsers { get; set; }
        public ProductPrivilege[] productPrivileges { get; set; }
    }

    public class CheckEffectiveProductsPrivilegesModel
    {
        public string product { get; set; }
        public ProductPrivilege[] privileges { get; set; }
    }

    public class CheckEffectiveProductsPrivilegesResultsModel
    {
        public string product { get; set; }
        public ProductPrivilege[] effectivePrivileges { get; set; }
    }

    public class CheckEffectiveSitePrivilegesModel
    {
        public SitePrivilege[] privileges { get; set; }
    }

    public class CheckEffectiveSitePrivilegesResultsModel
    {
        public SitePrivilege[] effectivePrivileges { get; set; }
    }

    public class CommentEditDetails
    {
        public System.DateTime? timeStamp { get; set; }
        public string user { get; set; }
    }

    public enum CommentState
    {
        standard,
        edited,
        removed,
    }

    public class CommentSummaryModel
    {
        public int id { get; set; }
        public CommentState state { get; set; }
        public string title { get; set; }
        public System.DateTime timestamp { get; set; }
        public string author { get; set; }
        public int? parentID { get; set; }
        public CommentEditDetails editDetails { get; set; }
    }

    public class CommentUpdateModel
    {
        public bool updateTitle { get; set; }
        public bool updateBody { get; set; }
        public string newTitle { get; set; }
        public string newBody { get; set; }
    }

    public class ComponentDetailsModel
    {
        public string name { get; set; }
    }

    public class CreateProductModel
    {
        public string name { get; set; }
        public string description { get; set; }
        public string[] aliases { get; set; }
        public AdditionalRoleDetailsModel[] additionalRoles { get; set; }
        public RoleProductPrivilegeTuple[] additionalRolePrivileges { get; set; }
    }

    public class CreateRoleModel
    {
        public string name { get; set; }
        public string description { get; set; }
        public SitePrivilege[] sitePrivileges { get; set; }
        public ProductProductPrivilegeTuple[] productPrivileges { get; set; }
    }

    public class CreateTestRunTypeModel
    {
        public string name { get; set; }
        public string description { get; set; }
        public string[] components { get; set; }
    }

    public class CreateUserModel
    {
        public string name { get; set; }
        public string email { get; set; }
        public string password { get; set; }
        public string[] groups { get; set; }
        public string[] roles { get; set; }
    }

    public class CreateUserPersonalAccessTokenModel
    {
        public string name { get; set; }
        public string description { get; set; }
        public System.DateTime? expiry { get; set; }
        public PersonalAccessTokenPrivilegesScope scope { get; set; }
        public SitePrivilege[] sitePrivileges { get; set; }
        public ProductProductPrivilegeTuple[] productPrivileges { get; set; }
    }

    public class ErrorAdminModel
    {
        public int id { get; set; }
        public System.DateTime timeStamp { get; set; }
        public string client { get; set; }
        public string host { get; set; }
        public string path { get; set; }
        public string exceptionMessage { get; set; }
        public string[] stackTrace { get; set; }
    }

    public class ErrorSearchResultsModel
    {
        public ErrorAdminModel[] results { get; set; }
    }

    public class ExternalLink
    {
        public string name { get; set; }
        public string url { get; set; }
        public string description { get; set; }
    }

    public class GroupSummaryModel
    {
        public string name { get; set; }
        public string description { get; set; }
        public string email { get; set; }
        public string[] roles { get; set; }
    }

    public class HttpValidationProblemDetails : ProblemDetails
    {
        public object errors { get; set; }
    }

    public class ImageDetailsModel
    {
        public string contentType { get; set; }
        public int fileSize { get; set; }
        public int versionNumber { get; set; }
    }

    public enum LoginResult
    {
        success,
        locked,
    }

    public class LoginResultModel
    {
        public LoginResult result { get; set; }
    }

    public class LogMessagesModel
    {
        public string[] messages { get; set; }
    }

    public class LogSummaryModel
    {
        public int messageCount { get; set; }
    }

    public class MemorySnapshotModel
    {
        public long? workingSet { get; set; }
        public long? virtualMemorySize { get; set; }
        public long? nonpagedSystemMemorySize { get; set; }
        public long? pagedMemorySize { get; set; }
        public long? pagedSystemMemorySize { get; set; }
        public long? peakPagedMemorySize { get; set; }
        public long? peakVirtualMemorySize { get; set; }
        public long? peakWorkingSet { get; set; }
        public long? privateMemorySize { get; set; }
    }

    public enum PersonalAccessTokenPrivilegesScope
    {
        all,
        subset,
    }

    public class ProblemDetails
    {
        public string type { get; set; }
        public string title { get; set; }
        public int? status { get; set; }
        public string detail { get; set; }
        public string instance { get; set; }
    }

    public class ProductAuditModel
    {
        public ProductAuditTrailModel[] messages { get; set; }
    }

    public class ProductAuditTrailModel
    {
        public string product { get; set; }
        public System.DateTime timestamp { get; set; }
        public string message { get; set; }
        public string user { get; set; }
    }

    public class ProductModel
    {
        public string name { get; set; }
        public string description { get; set; }
        public string[] aliases { get; set; }
        public ProductStatus status { get; set; }
    }

    public enum ProductPrivilege
    {
        admin,
        configurator,
        testRunSetDeleter,
        publisher,
        viewer,
        auditTrail,
        commenter,
        commentsAdmin,
    }

    public class ProductProductPrivilegeTuple
    {
        public string product { get; set; }
        public ProductPrivilege privilege { get; set; }
    }

    public enum ProductStatus
    {
        standard,
        archived,
        recycleBin,
        deleting,
    }

    public class ResultsXmlTransformationModel
    {
        public string name { get; set; }
        public string description { get; set; }
        public string[] testRunTypes { get; set; }
        public string transformation { get; set; }
        public TransformationArgumentModel[] arguments { get; set; }
    }

    public class ResultsXmlTransformationSummaryModel
    {
        public string name { get; set; }
        public string description { get; set; }
        public string[] testRunTypes { get; set; }
    }

    public class RoleModel
    {
        public string name { get; set; }
        public string description { get; set; }
        public SitePrivilege[] sitePrivileges { get; set; }
        public ProductProductPrivilegeTuple[] productPrivileges { get; set; }
    }

    public class RoleProductPrivilegeTuple
    {
        public string role { get; set; }
        public ProductPrivilege privilege { get; set; }
    }

    public class SearchErrorsCriteriaModel
    {
        public int? id { get; set; }
        public System.DateTime? minTimeStamp { get; set; }
        public System.DateTime? maxTimeStamp { get; set; }
        public string client { get; set; }
        public string host { get; set; }
        public string path { get; set; }
    }

    public class SearchTestRunSetCriteriaModel
    {
        public string[] products { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public System.DateTime? minRefDate { get; set; }
        public System.DateTime? maxRefDate { get; set; }
        public System.DateTime? minRunDate { get; set; }
        public System.DateTime? maxRunDate { get; set; }
        public string creator { get; set; }
        public string[] tags { get; set; }
        public TestRunSetStatus[] statuses { get; set; }
    }

    public class SimpleMemorySnapshotModel
    {
        public MemorySnapshotModel start { get; set; }
        public MemorySnapshotModel end { get; set; }
    }

    public enum SitePrivilege
    {
        anonymousUserAll,
        anonymousUserEnable,
        anonymousUserEdit,
        anonymousUserView,
        usersAll,
        usersCreate,
        usersDelete,
        usersEdit,
        usersView,
        groupsAll,
        groupsCreate,
        groupsDelete,
        groupsEdit,
        groupsView,
        rolesAll,
        rolesDelete,
        rolesCreate,
        rolesEdit,
        rolesView,
        productsAdmin,
        productsCreate,
        productsConfigurator,
        productsTestRunSetDeleter,
        productsPublisher,
        productsViewer,
        productsAuditTrail,
        productsCommenter,
        productsCommentsAdmin,
        errorsAll,
        errorsView,
        errorsClose,
        frontPageConfigurator,
        serverMetrics,
        superUser,
    }

    public class TestRunAssemblyModel
    {
        public string name { get; set; }
        public string architecture { get; set; }
        public string version { get; set; }
        public string culture { get; set; }
        [System.Text.Json.Serialization.JsonConverter(typeof(ByteArrayConverter))]
        public byte[] publicToken { get; set; }
        public string path { get; set; }
        public System.DateTime timeStamp { get; set; }
    }

    public class TestRunIDModel
    {
        public int id { get; set; }
    }

    public class TestRunModel
    {
        public int id { get; set; }
        public string product { get; set; }
        public int testRunSetID { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public string testType { get; set; }
        public TestStatus status { get; set; }
    }

    public class TestRunResultsDetailsModel
    {
        public bool present { get; set; }
        public int? length { get; set; }
    }

    public class TestRunResultsModel
    {
        public TestRunResultTypes type { get; set; }
        public string content { get; set; }
    }

    public class TestRunResultsTextLinesModel
    {
        public string[] lines { get; set; }
    }

    public class TestRunResultsXsvDetailsModel
    {
        public bool present { get; set; }
        public int? rowCount { get; set; }
    }

    public enum TestRunResultTypes
    {
        text,
        jSon,
        xml,
    }

    public class TestRunSetAuditModel
    {
        public TestRunSetAuditTrailMessage[] messages { get; set; }
    }

    public class TestRunSetAuditTrailMessage
    {
        public string product { get; set; }
        public int testRunSetID { get; set; }
        public int? testRunID { get; set; }
        public System.DateTime timestamp { get; set; }
        public string message { get; set; }
        public string user { get; set; }
    }

    public class TestRunSetSearchResultsModel
    {
        public SearchTestRunSetCriteriaModel criteria { get; set; }
        public TestRunSetSummaryModel[] results { get; set; }
    }

    public enum TestRunSetStatus
    {
        publishing,
        standard,
        locked,
        recycleBin,
    }

    public class TestRunSetSummaryModel
    {
        public string product { get; set; }
        public int id { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public TestRunSetStatus status { get; set; }
        public System.DateTime refDate { get; set; }
        public System.DateTime runDate { get; set; }
        public string creator { get; set; }
        public string[] tags { get; set; }
        public int unknownTestRuns { get; set; }
        public int erroringTestRuns { get; set; }
        public int failedTestRuns { get; set; }
        public int successfulTestRuns { get; set; }
    }

    public class TestRunTypeComponentModel
    {
        public string name { get; set; }
    }

    public class TestRunTypeImageDetails
    {
        public string contentType { get; set; }
        public int fileSize { get; set; }
        public int versionNumber { get; set; }
    }

    public class TestRunTypeModel
    {
        public string product { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public TestRunTypeComponentModel[] components { get; set; }
        public TestRunTypeImageDetails customImageDetails { get; set; }
    }

    public enum TestStatus
    {
        unknown,
        exception,
        failed,
        passed,
    }

    public class TransformationArgumentModel
    {
        public string name { get; set; }
        public string namespaceUri { get; set; }
        public string description { get; set; }
        public string defaultValue { get; set; }
    }

    public class UpdateAnonymousUserRolesModel
    {
        public string[] rolesToRemove { get; set; }
        public string[] rolesToAdd { get; set; }
    }

    public class UpdateGroupDetailsModel
    {
        public string newName { get; set; }
        public string[] membersToRemove { get; set; }
        public string[] membersToAdd { get; set; }
        public string[] rolesToAdd { get; set; }
        public string[] rolesToRemove { get; set; }
    }

    public class UpdateProductAliasesModel
    {
        public string[] aliasesToAdd { get; set; }
        public string[] aliasesToRemove { get; set; }
    }

    public class UpdateRoleDetailsModel
    {
        public string newName { get; set; }
        public string description { get; set; }
        public SitePrivilege[] sitePrivilegesToRemove { get; set; }
        public SitePrivilege[] sitePrivilegesToAdd { get; set; }
        public ProductProductPrivilegeTuple[] productPrivilegesToRemove { get; set; }
        public ProductProductPrivilegeTuple[] productPrivilegesToAdd { get; set; }
    }

    public class UpdateUserDetailsModel
    {
        public string newName { get; set; }
        public string[] rolesToAdd { get; set; }
        public string[] rolesToRemove { get; set; }
    }

    public class UploadExternalLinksModel
    {
        public ExternalLink[] externalLinks { get; set; }
    }

    public class UserPersonalAccessTokenModel
    {
        public string name { get; set; }
        public string description { get; set; }
        public string tokenValue { get; set; }
        public System.DateTime creationTime { get; set; }
        public System.DateTime? expiryTime { get; set; }
        public PersonalAccessTokenPrivilegesScope privilegesScope { get; set; }
        public SitePrivilege[] sitePrivileges { get; set; }
        public ProductProductPrivilegeTuple[] productPrivileges { get; set; }
    }

    public class UserSessionModel
    {
        public int sessionID { get; set; }
        public string description { get; set; }
        public System.DateTime creationTime { get; set; }
    }

    public enum UserState
    {
        standard,
        locked,
    }

    public class UserSummaryModel
    {
        public string name { get; set; }
        public string email { get; set; }
        public UserState state { get; set; }
        public string[] groups { get; set; }
        public string[] roles { get; set; }
    }

    public class ValidateCanDeleteTestRunTypeModel
    {
        public bool validated { get; set; }
        public string validationError { get; set; }
    }

    public class ValidateCreateProductModel
    {
        public bool validated { get; set; }
        public string validationError { get; set; }
    }

    public class ValidateCreateUserModel
    {
        public bool shouldSucceed { get; set; }
        public string validationError { get; set; }
    }

    public class ValidateRenameProductModel
    {
        public bool validated { get; set; }
        public string validationError { get; set; }
    }

    public class ValidateUpdateAnonymousUserRolesModel
    {
        public bool validated { get; set; }
        public string validationError { get; set; }
    }

    public class ValidateUpdateGroupDetailsModel
    {
        public bool validated { get; set; }
        public string validationError { get; set; }
    }

    public class ValidateUpdateProductAliasesModel
    {
        public bool validated { get; set; }
        public string validationError { get; set; }
    }

    public class ValidateUpdateRoleDetailsModel
    {
        public bool validated { get; set; }
        public string validationError { get; set; }
    }

    public class ValidateUpdateUserDetailsModel
    {
        public bool validated { get; set; }
        public string validationError { get; set; }
    }

    public enum XsvStyle
    {
        csv,
        tsv,
    }

    public interface IApiService
    {
        string AnonymousaccessEnabledUrl();
        string AnonymousaccessEffectivesiteprivilegesUrl();
        string AnonymousaccessRolesUrl();
        string CurrentuserUrl();
        string CurrentuserEffectiveSitePrivilegesUrl();
        string CurrentuserEffectiveProductPrivilegesUrl(
            string product);
        string CurrentuserSessionsUrl();
        string CurrentuserPersonalaccesstokensUrl();
        string ErrorUrl(
            int errorID);
        string FrontPageUrl();
        string GroupUrl(
            string groupName);
        string GroupEffectiveSitePrivilegesUrl(
            string groupName);
        string GroupMembersUrl(
            string groupName);
        string GroupsAllUrl();
        string MetricsUrl();
        string ProductUrl(
            string productName);
        string ProductTestRunTypeImageUrl(
            string productName,
            string testRunType);
        string ProductComponentsUrl(
            string productName);
        string ProductTestRunTypesUrl(
            string productName);
        string ProductTestRunTypeUrl(
            string productName,
            string testRunType);
        string ProductTestRunTypeComponentsUrl(
            string productName,
            string testRunType);
        string ProductDefaultTestRunTypeImageDetailsUrl(
            string productName);
        string ProductDefaultTestRunTypeImageUrl(
            string productName);
        string ProductTestRunTypeCustomImageUrl(
            string productName,
            string testRunType);
        string ProductTestRunTypeCustomImageDetailsUrl(
            string productName,
            string testRunType);
        string ProductAuditTrailUrl(
            string productName);
        string ProductImageUrl(
            string productName);
        string ProductLandingPageUrl(
            string productName);
        string ProductResultsXmlTransformationsUrl(
            string productName);
        string ProductTestRunTypeResultsXmlTransformationsUrl(
            string productName,
            string testRunType);
        string ProductResultsXmlTransformationUrl(
            string productName,
            string transformationName);
        string ProductsUrl();
        string RoleUrl(
            string roleName);
        string RolesUrl();
        string ProductTestRunSetTestRunSummaryUrl(
            string productName,
            int testRunSetID,
            int testRunID);
        string ProductTestRunSetTestRunResultsXmlUrl(
            string productName,
            int testRunSetID,
            int testRunID);
        string ProductTestRunSetTestRunResultsXmlRawUrl(
            string productName,
            int testRunSetID,
            int testRunID);
        string ProductTestRunSetTestRunResultsXmlDetailsUrl(
            string productName,
            int testRunSetID,
            int testRunID);
        string ProductTestRunSetTestRunResultsJsonUrl(
            string productName,
            int testRunSetID,
            int testRunID);
        string ProductTestRunSetTestRunResultsJsonRawUrl(
            string productName,
            int testRunSetID,
            int testRunID);
        string ProductTestRunSetTestRunResultsJsonDetailsUrl(
            string productName,
            int testRunSetID,
            int testRunID);
        string ProductTestRunSetTestRunResultsTextUrl(
            string productName,
            int testRunSetID,
            int testRunID);
        string ProductTestRunSetTestRunResultsTextRawUrl(
            string productName,
            int testRunSetID,
            int testRunID);
        string ProductTestRunSetTestRunResultsTextLinesUrl(
            string productName,
            int testRunSetID,
            int testRunID);
        string ProductTestRunSetTestRunResultsTextDetailsUrl(
            string productName,
            int testRunSetID,
            int testRunID);
        string ProductTestRunSetTestRunLogsSummaryUrl(
            string productName,
            int testRunSetID,
            int testRunID);
        string ProductTestRunSetTestRunLogsMessagesUrl(
            string productName,
            int testRunSetID,
            int testRunID);
        string ProductTestRunSetTestRunLogsRawUrl(
            string productName,
            int testRunSetID,
            int testRunID);
        string ProductTestRunSetTestRunSimpleMemorySnapshotUrl(
            string productName,
            int testRunSetID,
            int testRunID);
        string ProductTestRunSetTestRunAssembliesUrl(
            string productName,
            int testRunSetID,
            int testRunID);
        string ProductTestRunSetTestRunAdditionalFilesUrl(
            string productName,
            int testRunSetID,
            int testRunID);
        string ProductTestRunSetTestRunAdditionalFileUrl(
            string productName,
            int testRunSetID,
            int testRunID,
            string fileName);
        string ProductTestRunSetTestRunExternalLinksUrl(
            string productName,
            int testRunSetID,
            int testRunID);
        string ProductTestRunSetSummaryUrl(
            string productName,
            int testRunSetID);
        string ProductTestRunSetTestRunsUrl(
            string productName,
            int testRunSetID);
        string ProductTestRunSetAuditTrailUrl(
            string productName,
            int testRunSetID);
        string ProductTestRunSetAdditionalFilesUrl(
            string productName,
            int testRunSetID);
        string ProductTestRunSetAdditionalFileUrl(
            string productName,
            int testRunSetID,
            string fileName);
        string ProductTestRunSetExternalLinksUrl(
            string productName,
            int testRunSetID);
        string ProductTestRunSetCommentUrl(
            string productName,
            int testRunSetID,
            int commentID);
        string ProductTestRunSetCommentBodyUrl(
            string productName,
            int testRunSetID,
            int commentID);
        string UserUrl(
            string userName);
        string UserEffectiveSitePrivilegesUrl(
            string userName);
        string UserSessionsUrl(
            string userName);
        string UserPersonalaccesstokensUrl(
            string userName);
        string UsersAllUrl();
        Task<bool> AnonymousaccessEnabled();
        Task<System.IO.Stream> AnonymousaccessEnabledStream();
        Task AnonymousaccessEnable();
        Task AnonymousaccessDisable();
        Task<SitePrivilege[]> AnonymousaccessEffectivesiteprivileges();
        Task<System.IO.Stream> AnonymousaccessEffectivesiteprivilegesStream();
        Task<string[]> AnonymousaccessRoles();
        Task<System.IO.Stream> AnonymousaccessRolesStream();
        Task<string[]> AnonymousaccessUpdateroles(
           UpdateAnonymousUserRolesModel body);
        Task<System.IO.Stream> AnonymousaccessUpdaterolesStream(
           UpdateAnonymousUserRolesModel body);
        Task<ValidateUpdateAnonymousUserRolesModel> AnonymousaccessValidateupdateroles(
           UpdateAnonymousUserRolesModel body);
        Task<System.IO.Stream> AnonymousaccessValidateupdaterolesStream(
           UpdateAnonymousUserRolesModel body);
        Task<UserSummaryModel> Currentuser();
        Task<System.IO.Stream> CurrentuserStream();
        Task<SitePrivilege[]> CurrentuserEffectiveSitePrivileges();
        Task<System.IO.Stream> CurrentuserEffectiveSitePrivilegesStream();
        Task<CheckEffectiveSitePrivilegesResultsModel> CurrentuserCheckEffectiveSitePrivileges(
           CheckEffectiveSitePrivilegesModel body);
        Task<System.IO.Stream> CurrentuserCheckEffectiveSitePrivilegesStream(
           CheckEffectiveSitePrivilegesModel body);
        Task<ProductPrivilege[]> CurrentuserEffectiveProductPrivileges(
           string product);
        Task<System.IO.Stream> CurrentuserEffectiveProductPrivilegesStream(
           string product);
        Task<CheckEffectiveProductsPrivilegesResultsModel> CurrentuserCheckEffectiveProductPrivileges(
           CheckEffectiveProductsPrivilegesModel body);
        Task<System.IO.Stream> CurrentuserCheckEffectiveProductPrivilegesStream(
           CheckEffectiveProductsPrivilegesModel body);
        Task CurrentuserChangepassword(
           string originalPassword,
           string password);
        Task<UserSessionModel[]> CurrentuserSessions();
        Task<System.IO.Stream> CurrentuserSessionsStream();
        Task<UserPersonalAccessTokenModel> CurrentuserPersonalaccesstokenCreate(
           CreateUserPersonalAccessTokenModel body);
        Task<System.IO.Stream> CurrentuserPersonalaccesstokenCreateStream(
           CreateUserPersonalAccessTokenModel body);
        Task CurrentuserPersonalaccesstokenDelete(
           string tokenName);
        Task<UserPersonalAccessTokenModel[]> CurrentuserPersonalaccesstokens();
        Task<System.IO.Stream> CurrentuserPersonalaccesstokensStream();
        Task CurrentuserPersonalaccesstokensWipe();
        Task<ErrorAdminModel> Error(
           int errorID);
        Task<System.IO.Stream> ErrorStream(
           int errorID);
        Task<ErrorSearchResultsModel> ErrorsSearch(
           int? maxResults,
           SearchErrorsCriteriaModel body);
        Task<System.IO.Stream> ErrorsSearchStream(
           int? maxResults,
           SearchErrorsCriteriaModel body);
        Task<string> FrontPageGet();
        Task<System.IO.Stream> FrontPageGetStream();
        Task FrontPagePut(
           string body);
        Task FrontPageDelete();
        Task<GroupSummaryModel> GroupGet(
           string groupName);
        Task<System.IO.Stream> GroupGetStream(
           string groupName);
        Task GroupDelete(
           string groupName);
        Task<SitePrivilege[]> GroupEffectiveSitePrivileges(
           string groupName);
        Task<System.IO.Stream> GroupEffectiveSitePrivilegesStream(
           string groupName);
        Task GroupUpdate(
           string groupName,
           UpdateGroupDetailsModel body);
        Task<ValidateUpdateGroupDetailsModel> GroupValidateUpdate(
           string groupName,
           UpdateGroupDetailsModel body);
        Task<System.IO.Stream> GroupValidateUpdateStream(
           string groupName,
           UpdateGroupDetailsModel body);
        Task<string[]> GroupMembers(
           string groupName);
        Task<System.IO.Stream> GroupMembersStream(
           string groupName);
        Task GroupsCreate(
           string groupName,
           string description,
           string contactEmail,
           string[] initialMembers,
           string[] initialGroups,
           string[] initialRoles,
           string[] adminUsers,
           string[] adminGroups);
        Task<GroupSummaryModel[]> GroupsAll();
        Task<System.IO.Stream> GroupsAllStream();
        Task<GroupSummaryModel[]> GroupsSearch(
           string searchText);
        Task<System.IO.Stream> GroupsSearchStream(
           string searchText);
        Task Logout();
        Task LogoutAllSessions();
        Task<LoginResultModel> Login(
           string userName,
           string password);
        Task<System.IO.Stream> LoginStream(
           string userName,
           string password);
        Task<string> Metrics();
        Task<System.IO.Stream> MetricsStream();
        Task<ProductModel> Product(
           string productName);
        Task<System.IO.Stream> ProductStream(
           string productName);
        Task<byte[]> ProductTestRunTypeImage(
           string productName,
           string testRunType);
        Task<System.IO.Stream> ProductTestRunTypeImageStream(
           string productName,
           string testRunType);
        Task<ComponentDetailsModel[]> ProductComponents(
           string productName);
        Task<System.IO.Stream> ProductComponentsStream(
           string productName);
        Task<TestRunTypeModel[]> ProductTestRunTypes(
           string productName);
        Task<System.IO.Stream> ProductTestRunTypesStream(
           string productName);
        Task<TestRunTypeModel> ProductTestRunTypeGet(
           string productName,
           string testRunType);
        Task<System.IO.Stream> ProductTestRunTypeGetStream(
           string productName,
           string testRunType);
        Task ProductTestRunTypeDelete(
           string productName,
           string testRunType);
        Task<string[]> ProductTestRunTypeComponents(
           string productName,
           string testRunType);
        Task<System.IO.Stream> ProductTestRunTypeComponentsStream(
           string productName,
           string testRunType);
        Task<TestRunTypeModel> ProductCreateTestRunType(
           string productName,
           CreateTestRunTypeModel body);
        Task<System.IO.Stream> ProductCreateTestRunTypeStream(
           string productName,
           CreateTestRunTypeModel body);
        Task ProductTestRunTypeUpdateComponents(
           string productName,
           string testRunType,
           string[] body);
        Task<ValidateCanDeleteTestRunTypeModel> ProductTestRunTypeValidateCanDelete(
           string productName,
           string testRunType);
        Task<System.IO.Stream> ProductTestRunTypeValidateCanDeleteStream(
           string productName,
           string testRunType);
        Task<ImageDetailsModel> ProductDefaultTestRunTypeImageDetails(
           string productName);
        Task<System.IO.Stream> ProductDefaultTestRunTypeImageDetailsStream(
           string productName);
        Task<byte[]> ProductDefaultTestRunTypeImageGet(
           string productName);
        Task<System.IO.Stream> ProductDefaultTestRunTypeImageGetStream(
           string productName);
        Task ProductDefaultTestRunTypeImagePut(
           string productName,
           byte[] image,
           string imageFileName,
           string imageContentType);
        Task ProductDefaultTestRunTypeImageDelete(
           string productName);
        Task<byte[]> ProductTestRunTypeCustomImageGet(
           string productName,
           string testRunType);
        Task<System.IO.Stream> ProductTestRunTypeCustomImageGetStream(
           string productName,
           string testRunType);
        Task ProductTestRunTypeCustomImagePut(
           string productName,
           string testRunType,
           byte[] image,
           string imageFileName,
           string imageContentType);
        Task ProductTestRunTypeCustomImageDelete(
           string productName,
           string testRunType);
        Task<ImageDetailsModel> ProductTestRunTypeCustomImageDetails(
           string productName,
           string testRunType);
        Task<System.IO.Stream> ProductTestRunTypeCustomImageDetailsStream(
           string productName,
           string testRunType);
        Task ProductEmptyRecycleBin(
           string productName);
        Task<ProductAuditModel> ProductAuditTrail(
           string productName);
        Task<System.IO.Stream> ProductAuditTrailStream(
           string productName);
        Task<ValidateRenameProductModel> ProductValidateRename(
           string productName,
           string newName,
           bool keepOldNameAsAlias);
        Task<System.IO.Stream> ProductValidateRenameStream(
           string productName,
           string newName,
           bool keepOldNameAsAlias);
        Task<ProductModel> ProductRename(
           string productName,
           string newName,
           bool keepOldNameAsAlias);
        Task<System.IO.Stream> ProductRenameStream(
           string productName,
           string newName,
           bool keepOldNameAsAlias);
        Task<ValidateUpdateProductAliasesModel> ProductValidateUpdateAliases(
           string productName,
           UpdateProductAliasesModel body);
        Task<System.IO.Stream> ProductValidateUpdateAliasesStream(
           string productName,
           UpdateProductAliasesModel body);
        Task<ProductModel> ProductUpdateAliases(
           string productName,
           UpdateProductAliasesModel body);
        Task<System.IO.Stream> ProductUpdateAliasesStream(
           string productName,
           UpdateProductAliasesModel body);
        Task ProductUpdateStatus(
           string productName,
           ProductStatus status);
        Task ProductObliterate(
           string productName);
        Task<byte[]> ProductImageGet(
           string productName);
        Task<System.IO.Stream> ProductImageGetStream(
           string productName);
        Task ProductImagePut(
           string productName,
           byte[] additionalFile,
           string additionalFileFileName,
           string additionalFileContentType);
        Task ProductImageDelete(
           string productName);
        Task<string> ProductLandingPageGet(
           string productName);
        Task<System.IO.Stream> ProductLandingPageGetStream(
           string productName);
        Task ProductLandingPagePut(
           string productName,
           string body);
        Task ProductLandingPageDelete(
           string productName);
        Task<ResultsXmlTransformationSummaryModel[]> ProductResultsXmlTransformations(
           string productName);
        Task<System.IO.Stream> ProductResultsXmlTransformationsStream(
           string productName);
        Task<string[]> ProductTestRunTypeResultsXmlTransformations(
           string productName,
           string testRunType);
        Task<System.IO.Stream> ProductTestRunTypeResultsXmlTransformationsStream(
           string productName,
           string testRunType);
        Task<ResultsXmlTransformationModel> ProductResultsXmlTransformationGet(
           string productName,
           string transformationName);
        Task<System.IO.Stream> ProductResultsXmlTransformationGetStream(
           string productName,
           string transformationName);
        Task ProductResultsXmlTransformationDelete(
           string productName,
           string transformationName);
        Task ProductResultsXmlTransformationPut(
           string productName,
           string transformationName,
           ResultsXmlTransformationModel body);
        Task ProductResultsXmlTransformationPatch(
           string productName,
           string transformationName,
           ResultsXmlTransformationModel body);
        Task<ValidateCreateProductModel> ProductsValidateCreateProduct(
           CreateProductModel body);
        Task<System.IO.Stream> ProductsValidateCreateProductStream(
           CreateProductModel body);
        Task<ProductModel> ProductsCreateProduct(
           CreateProductModel body);
        Task<System.IO.Stream> ProductsCreateProductStream(
           CreateProductModel body);
        Task<ProductModel[]> Products();
        Task<System.IO.Stream> ProductsStream();
        Task<RoleModel> RoleGet(
           string roleName);
        Task<System.IO.Stream> RoleGetStream(
           string roleName);
        Task RoleDelete(
           string roleName);
        Task<RoleModel> RoleUpdate(
           string roleName,
           UpdateRoleDetailsModel body);
        Task<System.IO.Stream> RoleUpdateStream(
           string roleName,
           UpdateRoleDetailsModel body);
        Task<ValidateUpdateRoleDetailsModel> RoleValidateUpdate(
           string roleName,
           UpdateRoleDetailsModel body);
        Task<System.IO.Stream> RoleValidateUpdateStream(
           string roleName,
           UpdateRoleDetailsModel body);
        Task<RoleModel[]> Roles();
        Task<System.IO.Stream> RolesStream();
        Task<RoleModel[]> RolesSearch(
           string criteria);
        Task<System.IO.Stream> RolesSearchStream(
           string criteria);
        Task<RoleModel> RolesCreate(
           CreateRoleModel body);
        Task<System.IO.Stream> RolesCreateStream(
           CreateRoleModel body);
        Task<TestRunSetSearchResultsModel> SearchTestRunSet(
           SearchTestRunSetCriteriaModel body);
        Task<System.IO.Stream> SearchTestRunSetStream(
           SearchTestRunSetCriteriaModel body);
        Task<TestRunModel> ProductTestRunSetTestRunSummary(
           string productName,
           int testRunSetID,
           int testRunID);
        Task<System.IO.Stream> ProductTestRunSetTestRunSummaryStream(
           string productName,
           int testRunSetID,
           int testRunID);
        Task<TestRunResultsModel> ProductTestRunSetTestRunResultsXml(
           string productName,
           int testRunSetID,
           int testRunID);
        Task<System.IO.Stream> ProductTestRunSetTestRunResultsXmlStream(
           string productName,
           int testRunSetID,
           int testRunID);
        Task<string> ProductTestRunSetTestRunResultsXmlRaw(
           string productName,
           int testRunSetID,
           int testRunID);
        Task<System.IO.Stream> ProductTestRunSetTestRunResultsXmlRawStream(
           string productName,
           int testRunSetID,
           int testRunID);
        Task<TestRunResultsDetailsModel> ProductTestRunSetTestRunResultsXmlDetails(
           string productName,
           int testRunSetID,
           int testRunID);
        Task<System.IO.Stream> ProductTestRunSetTestRunResultsXmlDetailsStream(
           string productName,
           int testRunSetID,
           int testRunID);
        Task<TestRunResultsModel> ProductTestRunSetTestRunResultsJson(
           string productName,
           int testRunSetID,
           int testRunID);
        Task<System.IO.Stream> ProductTestRunSetTestRunResultsJsonStream(
           string productName,
           int testRunSetID,
           int testRunID);
        Task<string> ProductTestRunSetTestRunResultsJsonRaw(
           string productName,
           int testRunSetID,
           int testRunID);
        Task<System.IO.Stream> ProductTestRunSetTestRunResultsJsonRawStream(
           string productName,
           int testRunSetID,
           int testRunID);
        Task<TestRunResultsDetailsModel> ProductTestRunSetTestRunResultsJsonDetails(
           string productName,
           int testRunSetID,
           int testRunID);
        Task<System.IO.Stream> ProductTestRunSetTestRunResultsJsonDetailsStream(
           string productName,
           int testRunSetID,
           int testRunID);
        Task<TestRunResultsModel> ProductTestRunSetTestRunResultsText(
           string productName,
           int testRunSetID,
           int testRunID);
        Task<System.IO.Stream> ProductTestRunSetTestRunResultsTextStream(
           string productName,
           int testRunSetID,
           int testRunID);
        Task<string> ProductTestRunSetTestRunResultsTextRaw(
           string productName,
           int testRunSetID,
           int testRunID);
        Task<System.IO.Stream> ProductTestRunSetTestRunResultsTextRawStream(
           string productName,
           int testRunSetID,
           int testRunID);
        Task<TestRunResultsTextLinesModel> ProductTestRunSetTestRunResultsTextLines(
           string productName,
           int testRunSetID,
           int testRunID);
        Task<System.IO.Stream> ProductTestRunSetTestRunResultsTextLinesStream(
           string productName,
           int testRunSetID,
           int testRunID);
        Task<TestRunResultsDetailsModel> ProductTestRunSetTestRunResultsTextDetails(
           string productName,
           int testRunSetID,
           int testRunID);
        Task<System.IO.Stream> ProductTestRunSetTestRunResultsTextDetailsStream(
           string productName,
           int testRunSetID,
           int testRunID);
        Task<TestRunResultsXsvDetailsModel> ProductTestRunSetTestRunResultsXsvDetails(
           string productName,
           int testRunSetID,
           int testRunID,
           XsvStyle xsvStyle);
        Task<System.IO.Stream> ProductTestRunSetTestRunResultsXsvDetailsStream(
           string productName,
           int testRunSetID,
           int testRunID,
           XsvStyle xsvStyle);
        Task<string> ProductTestRunSetTestRunResultsXsvRaw(
           string productName,
           int testRunSetID,
           int testRunID,
           XsvStyle xsvStyle);
        Task<System.IO.Stream> ProductTestRunSetTestRunResultsXsvRawStream(
           string productName,
           int testRunSetID,
           int testRunID,
           XsvStyle xsvStyle);
        Task<string[]> ProductTestRunSetTestRunResultsXsvLines(
           string productName,
           int testRunSetID,
           int testRunID,
           XsvStyle xsvStyle,
           int? minRow,
           int? maxRow);
        Task<System.IO.Stream> ProductTestRunSetTestRunResultsXsvLinesStream(
           string productName,
           int testRunSetID,
           int testRunID,
           XsvStyle xsvStyle,
           int? minRow,
           int? maxRow);
        Task<LogSummaryModel> ProductTestRunSetTestRunLogsSummary(
           string productName,
           int testRunSetID,
           int testRunID);
        Task<System.IO.Stream> ProductTestRunSetTestRunLogsSummaryStream(
           string productName,
           int testRunSetID,
           int testRunID);
        Task<LogMessagesModel> ProductTestRunSetTestRunLogsMessages(
           string productName,
           int testRunSetID,
           int testRunID);
        Task<System.IO.Stream> ProductTestRunSetTestRunLogsMessagesStream(
           string productName,
           int testRunSetID,
           int testRunID);
        Task<string> ProductTestRunSetTestRunLogsRaw(
           string productName,
           int testRunSetID,
           int testRunID);
        Task<System.IO.Stream> ProductTestRunSetTestRunLogsRawStream(
           string productName,
           int testRunSetID,
           int testRunID);
        Task<SimpleMemorySnapshotModel> ProductTestRunSetTestRunSimpleMemorySnapshot(
           string productName,
           int testRunSetID,
           int testRunID);
        Task<System.IO.Stream> ProductTestRunSetTestRunSimpleMemorySnapshotStream(
           string productName,
           int testRunSetID,
           int testRunID);
        Task<TestRunAssemblyModel[]> ProductTestRunSetTestRunAssemblies(
           string productName,
           int testRunSetID,
           int testRunID);
        Task<System.IO.Stream> ProductTestRunSetTestRunAssembliesStream(
           string productName,
           int testRunSetID,
           int testRunID);
        Task<AdditionalFileDetails[]> ProductTestRunSetTestRunAdditionalFiles(
           string productName,
           int testRunSetID,
           int testRunID);
        Task<System.IO.Stream> ProductTestRunSetTestRunAdditionalFilesStream(
           string productName,
           int testRunSetID,
           int testRunID);
        Task<byte[]> ProductTestRunSetTestRunAdditionalFile(
           string productName,
           int testRunSetID,
           int testRunID,
           string fileName);
        Task<System.IO.Stream> ProductTestRunSetTestRunAdditionalFileStream(
           string productName,
           int testRunSetID,
           int testRunID,
           string fileName);
        Task<ExternalLink[]> ProductTestRunSetTestRunExternalLinks(
           string productName,
           int testRunSetID,
           int testRunID);
        Task<System.IO.Stream> ProductTestRunSetTestRunExternalLinksStream(
           string productName,
           int testRunSetID,
           int testRunID);
        Task<TestRunSetSummaryModel> ProductTestRunSetSummary(
           string productName,
           int testRunSetID);
        Task<System.IO.Stream> ProductTestRunSetSummaryStream(
           string productName,
           int testRunSetID);
        Task<TestRunModel[]> ProductTestRunSetTestRuns(
           string productName,
           int testRunSetID);
        Task<System.IO.Stream> ProductTestRunSetTestRunsStream(
           string productName,
           int testRunSetID);
        Task<TestRunSetAuditModel> ProductTestRunSetAuditTrail(
           string productName,
           int testRunSetID);
        Task<System.IO.Stream> ProductTestRunSetAuditTrailStream(
           string productName,
           int testRunSetID);
        Task ProductTestRunSetUpdateStatus(
           string productName,
           int testRunSetID,
           TestRunSetStatus status);
        Task<AdditionalFileDetails[]> ProductTestRunSetAdditionalFiles(
           string productName,
           int testRunSetID);
        Task<System.IO.Stream> ProductTestRunSetAdditionalFilesStream(
           string productName,
           int testRunSetID);
        Task<byte[]> ProductTestRunSetAdditionalFile(
           string productName,
           int testRunSetID,
           string fileName);
        Task<System.IO.Stream> ProductTestRunSetAdditionalFileStream(
           string productName,
           int testRunSetID,
           string fileName);
        Task<ExternalLink[]> ProductTestRunSetExternalLinks(
           string productName,
           int testRunSetID);
        Task<System.IO.Stream> ProductTestRunSetExternalLinksStream(
           string productName,
           int testRunSetID);
        Task<CommentSummaryModel[]> ProductTestRunSetComments(
           string productName,
           int testRunSetID,
           int? parentID);
        Task<System.IO.Stream> ProductTestRunSetCommentsStream(
           string productName,
           int testRunSetID,
           int? parentID);
        Task<CommentSummaryModel> ProductTestRunSetCommentGet(
           string productName,
           int testRunSetID,
           int commentID);
        Task<System.IO.Stream> ProductTestRunSetCommentGetStream(
           string productName,
           int testRunSetID,
           int commentID);
        Task ProductTestRunSetCommentDelete(
           string productName,
           int testRunSetID,
           int commentID);
        Task<string> ProductTestRunSetCommentBody(
           string productName,
           int testRunSetID,
           int commentID);
        Task<System.IO.Stream> ProductTestRunSetCommentBodyStream(
           string productName,
           int testRunSetID,
           int commentID);
        Task<CommentSummaryModel> ProductTestRunSetNewComment(
           string productName,
           int testRunSetID,
           string commentTitle,
           int? parentID,
           string body);
        Task<System.IO.Stream> ProductTestRunSetNewCommentStream(
           string productName,
           int testRunSetID,
           string commentTitle,
           int? parentID,
           string body);
        Task<CommentSummaryModel> ProductTestRunSetCommentUpdate(
           string productName,
           int testRunSetID,
           int commentID,
           CommentUpdateModel body);
        Task<System.IO.Stream> ProductTestRunSetCommentUpdateStream(
           string productName,
           int testRunSetID,
           int commentID,
           CommentUpdateModel body);
        Task<TestRunSetSummaryModel> UploadCreateTestRunSet(
           string product,
           string name,
           string description,
           System.DateTime refDate,
           System.DateTime runDate,
           string[] tags);
        Task<System.IO.Stream> UploadCreateTestRunSetStream(
           string product,
           string name,
           string description,
           System.DateTime refDate,
           System.DateTime runDate,
           string[] tags);
        Task<TestRunIDModel> UploadCreateTestRun(
           string product,
           int? testRunSetID,
           string name,
           string description,
           string testRunType,
           TestStatus testStatus);
        Task<System.IO.Stream> UploadCreateTestRunStream(
           string product,
           int? testRunSetID,
           string name,
           string description,
           string testRunType,
           TestStatus testStatus);
        Task UploadPublishTestRunResults(
           string product,
           int? testRunSetID,
           int? testRunID,
           TestRunResultTypes resultType,
           string body);
        Task UploadPublishTestRunSimpleMemorySnapshot(
           string product,
           int? testRunSetID,
           int? testRunID,
           SimpleMemorySnapshotModel body);
        Task UploadPublishTestRunAssemblies(
           string product,
           int? testRunSetID,
           int? testRunID,
           TestRunAssemblyModel[] body);
        Task UploadPublishTestRunXsvResults(
           string product,
           int? testRunSetID,
           int? testRunID,
           XsvStyle style,
           string body);
        Task UploadPublishTestRunLogMessages(
           string product,
           int? testRunSetID,
           int? testRunID,
           string[] body);
        Task UploadPublishTestRunAdditionalFile(
           string product,
           int? testRunSetID,
           int? testRunID,
           string fileName,
           string description,
           byte[] additionalFile,
           string additionalFileFileName,
           string additionalFileContentType);
        Task UploadPublishTestRunExternalLinks(
           string product,
           int? testRunSetID,
           int? testRunID,
           UploadExternalLinksModel body);
        Task UploadPublishTestRunSetAdditionalFile(
           string product,
           int? testRunSetID,
           string fileName,
           string description,
           byte[] additionalFile,
           string additionalFileFileName,
           string additionalFileContentType);
        Task UploadPublishTestRunSetExternalLinks(
           string product,
           int? testRunSetID,
           UploadExternalLinksModel body);
        Task<UserSummaryModel> User(
           string userName);
        Task<System.IO.Stream> UserStream(
           string userName);
        Task<SitePrivilege[]> UserEffectiveSitePrivileges(
           string userName);
        Task<System.IO.Stream> UserEffectiveSitePrivilegesStream(
           string userName);
        Task UserChangepassword(
           string userName,
           string password);
        Task<UserSessionModel[]> UserSessions(
           string userName);
        Task<System.IO.Stream> UserSessionsStream(
           string userName);
        Task UserPersonalaccesstokenDelete(
           string userName,
           string tokenName);
        Task<UserPersonalAccessTokenModel[]> UserPersonalaccesstokens(
           string userName);
        Task<System.IO.Stream> UserPersonalaccesstokensStream(
           string userName);
        Task UserPersonalaccesstokensWipe(
           string userName);
        Task UserLock(
           string userName);
        Task UserUnlock(
           string userName);
        Task UserUpdate(
           string userName,
           UpdateUserDetailsModel body);
        Task<ValidateUpdateUserDetailsModel> UserValidateUpdate(
           string userName,
           UpdateUserDetailsModel body);
        Task<System.IO.Stream> UserValidateUpdateStream(
           string userName,
           UpdateUserDetailsModel body);
        Task<UserSummaryModel> UsersCreate(
           CreateUserModel body);
        Task<System.IO.Stream> UsersCreateStream(
           CreateUserModel body);
        Task<ValidateCreateUserModel> UsersValidateCreate(
           CreateUserModel body);
        Task<System.IO.Stream> UsersValidateCreateStream(
           CreateUserModel body);
        Task<UserSummaryModel[]> UsersAll();
        Task<System.IO.Stream> UsersAllStream();
        Task<UserSummaryModel[]> UsersSearch(
           string searchText);
        Task<System.IO.Stream> UsersSearchStream(
           string searchText);
    }

    public partial class ApiService
    {
        public string AnonymousaccessEnabledUrl()
        {
            return $"/api/anonymousaccess/enabled";
        }

        public string AnonymousaccessEffectivesiteprivilegesUrl()
        {
            return $"/api/anonymousaccess/effectivesiteprivileges";
        }

        public string AnonymousaccessRolesUrl()
        {
            return $"/api/anonymousaccess/roles";
        }

        public string CurrentuserUrl()
        {
            return $"/api/currentuser";
        }

        public string CurrentuserEffectiveSitePrivilegesUrl()
        {
            return $"/api/currentuser/effectiveSitePrivileges";
        }

        public string CurrentuserEffectiveProductPrivilegesUrl(
            string product)
        {
            return $"/api/currentuser/EffectiveProductPrivileges/{product}";
        }

        public string CurrentuserSessionsUrl()
        {
            return $"/api/currentuser/sessions";
        }

        public string CurrentuserPersonalaccesstokensUrl()
        {
            return $"/api/currentuser/personalaccesstokens";
        }

        public string ErrorUrl(
            int errorID)
        {
            return $"/api/error/{errorID}";
        }

        public string FrontPageUrl()
        {
            return $"/api/frontPage";
        }

        public string GroupUrl(
            string groupName)
        {
            return $"/api/group/{groupName}";
        }

        public string GroupEffectiveSitePrivilegesUrl(
            string groupName)
        {
            return $"/api/group/{groupName}/effectiveSitePrivileges";
        }

        public string GroupMembersUrl(
            string groupName)
        {
            return $"/api/group/{groupName}/members";
        }

        public string GroupsAllUrl()
        {
            return $"/api/groups/all";
        }

        public string MetricsUrl()
        {
            return $"/api/metrics";
        }

        public string ProductUrl(
            string productName)
        {
            return $"/api/Product/{productName}";
        }

        public string ProductTestRunTypeImageUrl(
            string productName,
            string testRunType)
        {
            return $"/api/product/{productName}/testRunType/{testRunType}/image";
        }

        public string ProductComponentsUrl(
            string productName)
        {
            return $"/api/product/{productName}/components";
        }

        public string ProductTestRunTypesUrl(
            string productName)
        {
            return $"/api/product/{productName}/testRunTypes";
        }

        public string ProductTestRunTypeUrl(
            string productName,
            string testRunType)
        {
            return $"/api/product/{productName}/testRunType/{testRunType}";
        }

        public string ProductTestRunTypeComponentsUrl(
            string productName,
            string testRunType)
        {
            return $"/api/product/{productName}/testRunType/{testRunType}/components";
        }

        public string ProductDefaultTestRunTypeImageDetailsUrl(
            string productName)
        {
            return $"/api/product/{productName}/defaultTestRunTypeImageDetails";
        }

        public string ProductDefaultTestRunTypeImageUrl(
            string productName)
        {
            return $"/api/product/{productName}/defaultTestRunTypeImage";
        }

        public string ProductTestRunTypeCustomImageUrl(
            string productName,
            string testRunType)
        {
            return $"/api/product/{productName}/testRunType/{testRunType}/customImage";
        }

        public string ProductTestRunTypeCustomImageDetailsUrl(
            string productName,
            string testRunType)
        {
            return $"/api/product/{productName}/testRunType/{testRunType}/customImageDetails";
        }

        public string ProductAuditTrailUrl(
            string productName)
        {
            return $"/api/product/{productName}/AuditTrail";
        }

        public string ProductImageUrl(
            string productName)
        {
            return $"/api/product/{productName}/image";
        }

        public string ProductLandingPageUrl(
            string productName)
        {
            return $"/api/product/{productName}/landingPage";
        }

        public string ProductResultsXmlTransformationsUrl(
            string productName)
        {
            return $"/api/product/{productName}/resultsXmlTransformations";
        }

        public string ProductTestRunTypeResultsXmlTransformationsUrl(
            string productName,
            string testRunType)
        {
            return $"/api/product/{productName}/testRunType/{testRunType}/resultsXmlTransformations";
        }

        public string ProductResultsXmlTransformationUrl(
            string productName,
            string transformationName)
        {
            return $"/api/product/{productName}/resultsXmlTransformation/{transformationName}";
        }

        public string ProductsUrl()
        {
            return $"/api/Products";
        }

        public string RoleUrl(
            string roleName)
        {
            return $"/api/role/{roleName}";
        }

        public string RolesUrl()
        {
            return $"/api/roles";
        }

        public string ProductTestRunSetTestRunSummaryUrl(
            string productName,
            int testRunSetID,
            int testRunID)
        {
            return $"/api/product/{productName}/TestRunSet/{testRunSetID}/TestRun/{testRunID}/summary";
        }

        public string ProductTestRunSetTestRunResultsXmlUrl(
            string productName,
            int testRunSetID,
            int testRunID)
        {
            return $"/api/product/{productName}/TestRunSet/{testRunSetID}/TestRun/{testRunID}/ResultsXml";
        }

        public string ProductTestRunSetTestRunResultsXmlRawUrl(
            string productName,
            int testRunSetID,
            int testRunID)
        {
            return $"/api/product/{productName}/TestRunSet/{testRunSetID}/TestRun/{testRunID}/ResultsXml/raw";
        }

        public string ProductTestRunSetTestRunResultsXmlDetailsUrl(
            string productName,
            int testRunSetID,
            int testRunID)
        {
            return $"/api/product/{productName}/TestRunSet/{testRunSetID}/TestRun/{testRunID}/ResultsXml/details";
        }

        public string ProductTestRunSetTestRunResultsJsonUrl(
            string productName,
            int testRunSetID,
            int testRunID)
        {
            return $"/api/product/{productName}/TestRunSet/{testRunSetID}/TestRun/{testRunID}/ResultsJson";
        }

        public string ProductTestRunSetTestRunResultsJsonRawUrl(
            string productName,
            int testRunSetID,
            int testRunID)
        {
            return $"/api/product/{productName}/TestRunSet/{testRunSetID}/TestRun/{testRunID}/ResultsJson/raw";
        }

        public string ProductTestRunSetTestRunResultsJsonDetailsUrl(
            string productName,
            int testRunSetID,
            int testRunID)
        {
            return $"/api/product/{productName}/TestRunSet/{testRunSetID}/TestRun/{testRunID}/ResultsJson/details";
        }

        public string ProductTestRunSetTestRunResultsTextUrl(
            string productName,
            int testRunSetID,
            int testRunID)
        {
            return $"/api/product/{productName}/TestRunSet/{testRunSetID}/TestRun/{testRunID}/ResultsText";
        }

        public string ProductTestRunSetTestRunResultsTextRawUrl(
            string productName,
            int testRunSetID,
            int testRunID)
        {
            return $"/api/product/{productName}/TestRunSet/{testRunSetID}/TestRun/{testRunID}/ResultsText/Raw";
        }

        public string ProductTestRunSetTestRunResultsTextLinesUrl(
            string productName,
            int testRunSetID,
            int testRunID)
        {
            return $"/api/product/{productName}/TestRunSet/{testRunSetID}/TestRun/{testRunID}/ResultsText/Lines";
        }

        public string ProductTestRunSetTestRunResultsTextDetailsUrl(
            string productName,
            int testRunSetID,
            int testRunID)
        {
            return $"/api/product/{productName}/TestRunSet/{testRunSetID}/TestRun/{testRunID}/ResultsText/details";
        }

        public string ProductTestRunSetTestRunLogsSummaryUrl(
            string productName,
            int testRunSetID,
            int testRunID)
        {
            return $"/api/product/{productName}/TestRunSet/{testRunSetID}/TestRun/{testRunID}/Logs/Summary";
        }

        public string ProductTestRunSetTestRunLogsMessagesUrl(
            string productName,
            int testRunSetID,
            int testRunID)
        {
            return $"/api/product/{productName}/TestRunSet/{testRunSetID}/TestRun/{testRunID}/Logs/Messages";
        }

        public string ProductTestRunSetTestRunLogsRawUrl(
            string productName,
            int testRunSetID,
            int testRunID)
        {
            return $"/api/product/{productName}/TestRunSet/{testRunSetID}/TestRun/{testRunID}/Logs/Raw";
        }

        public string ProductTestRunSetTestRunSimpleMemorySnapshotUrl(
            string productName,
            int testRunSetID,
            int testRunID)
        {
            return $"/api/product/{productName}/TestRunSet/{testRunSetID}/TestRun/{testRunID}/SimpleMemorySnapshot";
        }

        public string ProductTestRunSetTestRunAssembliesUrl(
            string productName,
            int testRunSetID,
            int testRunID)
        {
            return $"/api/product/{productName}/TestRunSet/{testRunSetID}/TestRun/{testRunID}/Assemblies";
        }

        public string ProductTestRunSetTestRunAdditionalFilesUrl(
            string productName,
            int testRunSetID,
            int testRunID)
        {
            return $"/api/product/{productName}/TestRunSet/{testRunSetID}/TestRun/{testRunID}/AdditionalFiles";
        }

        public string ProductTestRunSetTestRunAdditionalFileUrl(
            string productName,
            int testRunSetID,
            int testRunID,
            string fileName)
        {
            return $"/api/product/{productName}/TestRunSet/{testRunSetID}/TestRun/{testRunID}/AdditionalFile/{fileName}";
        }

        public string ProductTestRunSetTestRunExternalLinksUrl(
            string productName,
            int testRunSetID,
            int testRunID)
        {
            return $"/api/product/{productName}/TestRunSet/{testRunSetID}/TestRun/{testRunID}/externalLinks";
        }

        public string ProductTestRunSetSummaryUrl(
            string productName,
            int testRunSetID)
        {
            return $"/api/product/{productName}/TestRunSet/{testRunSetID}/Summary";
        }

        public string ProductTestRunSetTestRunsUrl(
            string productName,
            int testRunSetID)
        {
            return $"/api/product/{productName}/TestRunSet/{testRunSetID}/TestRuns";
        }

        public string ProductTestRunSetAuditTrailUrl(
            string productName,
            int testRunSetID)
        {
            return $"/api/product/{productName}/TestRunSet/{testRunSetID}/AuditTrail";
        }

        public string ProductTestRunSetAdditionalFilesUrl(
            string productName,
            int testRunSetID)
        {
            return $"/api/product/{productName}/TestRunSet/{testRunSetID}/AdditionalFiles";
        }

        public string ProductTestRunSetAdditionalFileUrl(
            string productName,
            int testRunSetID,
            string fileName)
        {
            return $"/api/product/{productName}/TestRunSet/{testRunSetID}/AdditionalFile/{fileName}";
        }

        public string ProductTestRunSetExternalLinksUrl(
            string productName,
            int testRunSetID)
        {
            return $"/api/product/{productName}/TestRunSet/{testRunSetID}/externalLinks";
        }

        public string ProductTestRunSetCommentUrl(
            string productName,
            int testRunSetID,
            int commentID)
        {
            return $"/api/product/{productName}/TestRunSet/{testRunSetID}/comment/{commentID}";
        }

        public string ProductTestRunSetCommentBodyUrl(
            string productName,
            int testRunSetID,
            int commentID)
        {
            return $"/api/product/{productName}/TestRunSet/{testRunSetID}/comment/{commentID}/body";
        }

        public string UserUrl(
            string userName)
        {
            return $"/api/user/{userName}";
        }

        public string UserEffectiveSitePrivilegesUrl(
            string userName)
        {
            return $"/api/user/{userName}/effectiveSitePrivileges";
        }

        public string UserSessionsUrl(
            string userName)
        {
            return $"/api/user/{userName}/sessions";
        }

        public string UserPersonalaccesstokensUrl(
            string userName)
        {
            return $"/api/user/{userName}/personalaccesstokens";
        }

        public string UsersAllUrl()
        {
            return $"/api/users/all";
        }

        public async Task<bool> AnonymousaccessEnabled()
        {
            string url = $"/api/anonymousaccess/enabled";
            var request = new HttpRequestMessage(HttpMethod.Get, url);

            var response = await _httpClient.SendAsync(request);

            switch ((int)response.StatusCode)
            {
                case 200:
                    {
                        using (var stream = await response.Content.ReadAsStreamAsync())
                        {
                            if (stream.Length == 0)
                                return default(bool);

                            var result = await JsonSerializer.DeserializeAsync<bool>(stream, _serializerOptions);
                            return result;
                        }
                    }

                default:
                    throw new InvalidOperationException($"Call Failed - {response.StatusCode}");
            }
        }

        public async Task<System.IO.Stream> AnonymousaccessEnabledStream()
        {
            string url = $"/api/anonymousaccess/enabled";
            var request = new HttpRequestMessage(HttpMethod.Get, url);

            var response = await _httpClient.SendAsync(request);

            switch ((int)response.StatusCode)
            {
                case 200:
                    var stream = await response.Content.ReadAsStreamAsync();
                    return stream;

                default:
                    throw new InvalidOperationException($"Call Failed - {response.StatusCode}");
            }
        }

        public async Task AnonymousaccessEnable()
        {
            string url = $"/api/anonymousaccess/enable";
            var request = new HttpRequestMessage(HttpMethod.Post, url);

            var response = await _httpClient.SendAsync(request);

            switch ((int)response.StatusCode)
            {
                case 204:
                    return;

                default:
                    throw new InvalidOperationException($"Call Failed - {response.StatusCode}");
            }
        }

        public async Task AnonymousaccessDisable()
        {
            string url = $"/api/anonymousaccess/disable";
            var request = new HttpRequestMessage(HttpMethod.Post, url);

            var response = await _httpClient.SendAsync(request);

            switch ((int)response.StatusCode)
            {
                case 204:
                    return;

                default:
                    throw new InvalidOperationException($"Call Failed - {response.StatusCode}");
            }
        }

        public async Task<SitePrivilege[]> AnonymousaccessEffectivesiteprivileges()
        {
            string url = $"/api/anonymousaccess/effectivesiteprivileges";
            var request = new HttpRequestMessage(HttpMethod.Get, url);

            var response = await _httpClient.SendAsync(request);

            switch ((int)response.StatusCode)
            {
                case 200:
                    {
                        using (var stream = await response.Content.ReadAsStreamAsync())
                        {
                            if (stream.Length == 0)
                                return default(SitePrivilege[]);

                            var result = await JsonSerializer.DeserializeAsync<SitePrivilege[]>(stream, _serializerOptions);
                            return result;
                        }
                    }

                default:
                    throw new InvalidOperationException($"Call Failed - {response.StatusCode}");
            }
        }

        public async Task<System.IO.Stream> AnonymousaccessEffectivesiteprivilegesStream()
        {
            string url = $"/api/anonymousaccess/effectivesiteprivileges";
            var request = new HttpRequestMessage(HttpMethod.Get, url);

            var response = await _httpClient.SendAsync(request);

            switch ((int)response.StatusCode)
            {
                case 200:
                    var stream = await response.Content.ReadAsStreamAsync();
                    return stream;

                default:
                    throw new InvalidOperationException($"Call Failed - {response.StatusCode}");
            }
        }

        public async Task<string[]> AnonymousaccessRoles()
        {
            string url = $"/api/anonymousaccess/roles";
            var request = new HttpRequestMessage(HttpMethod.Get, url);

            var response = await _httpClient.SendAsync(request);

            switch ((int)response.StatusCode)
            {
                case 200:
                    {
                        using (var stream = await response.Content.ReadAsStreamAsync())
                        {
                            if (stream.Length == 0)
                                return default(string[]);

                            var result = await JsonSerializer.DeserializeAsync<string[]>(stream, _serializerOptions);
                            return result;
                        }
                    }

                default:
                    throw new InvalidOperationException($"Call Failed - {response.StatusCode}");
            }
        }

        public async Task<System.IO.Stream> AnonymousaccessRolesStream()
        {
            string url = $"/api/anonymousaccess/roles";
            var request = new HttpRequestMessage(HttpMethod.Get, url);

            var response = await _httpClient.SendAsync(request);

            switch ((int)response.StatusCode)
            {
                case 200:
                    var stream = await response.Content.ReadAsStreamAsync();
                    return stream;

                default:
                    throw new InvalidOperationException($"Call Failed - {response.StatusCode}");
            }
        }

        public async Task<string[]> AnonymousaccessUpdateroles(
            UpdateAnonymousUserRolesModel body)
        {
            string url = $"/api/anonymousaccess/updateroles";
            var request = new HttpRequestMessage(HttpMethod.Post, url);
            var serializerOptions = new System.Text.Json.JsonSerializerOptions();
            serializerOptions.Converters.Add(new System.Text.Json.Serialization.JsonStringEnumConverter(JsonNamingPolicy.CamelCase));
            request.Content = System.Net.Http.Json.JsonContent.Create<UpdateAnonymousUserRolesModel>(body, options: serializerOptions);

            var response = await _httpClient.SendAsync(request);

            switch ((int)response.StatusCode)
            {
                case 200:
                    {
                        using (var stream = await response.Content.ReadAsStreamAsync())
                        {
                            if (stream.Length == 0)
                                return default(string[]);

                            var result = await JsonSerializer.DeserializeAsync<string[]>(stream, _serializerOptions);
                            return result;
                        }
                    }

                default:
                    throw new InvalidOperationException($"Call Failed - {response.StatusCode}");
            }
        }

        public async Task<System.IO.Stream> AnonymousaccessUpdaterolesStream(
            UpdateAnonymousUserRolesModel body)
        {
            string url = $"/api/anonymousaccess/updateroles";
            var request = new HttpRequestMessage(HttpMethod.Post, url);
            var serializerOptions = new System.Text.Json.JsonSerializerOptions();
            serializerOptions.Converters.Add(new System.Text.Json.Serialization.JsonStringEnumConverter(JsonNamingPolicy.CamelCase));
            request.Content = System.Net.Http.Json.JsonContent.Create<UpdateAnonymousUserRolesModel>(body, options: serializerOptions);

            var response = await _httpClient.SendAsync(request);

            switch ((int)response.StatusCode)
            {
                case 200:
                    var stream = await response.Content.ReadAsStreamAsync();
                    return stream;

                default:
                    throw new InvalidOperationException($"Call Failed - {response.StatusCode}");
            }
        }

        public async Task<ValidateUpdateAnonymousUserRolesModel> AnonymousaccessValidateupdateroles(
            UpdateAnonymousUserRolesModel body)
        {
            string url = $"/api/anonymousaccess/validateupdateroles";
            var request = new HttpRequestMessage(HttpMethod.Post, url);
            var serializerOptions = new System.Text.Json.JsonSerializerOptions();
            serializerOptions.Converters.Add(new System.Text.Json.Serialization.JsonStringEnumConverter(JsonNamingPolicy.CamelCase));
            request.Content = System.Net.Http.Json.JsonContent.Create<UpdateAnonymousUserRolesModel>(body, options: serializerOptions);

            var response = await _httpClient.SendAsync(request);

            switch ((int)response.StatusCode)
            {
                case 200:
                    {
                        using (var stream = await response.Content.ReadAsStreamAsync())
                        {
                            if (stream.Length == 0)
                                return default(ValidateUpdateAnonymousUserRolesModel);

                            var result = await JsonSerializer.DeserializeAsync<ValidateUpdateAnonymousUserRolesModel>(stream, _serializerOptions);
                            return result;
                        }
                    }

                default:
                    throw new InvalidOperationException($"Call Failed - {response.StatusCode}");
            }
        }

        public async Task<System.IO.Stream> AnonymousaccessValidateupdaterolesStream(
            UpdateAnonymousUserRolesModel body)
        {
            string url = $"/api/anonymousaccess/validateupdateroles";
            var request = new HttpRequestMessage(HttpMethod.Post, url);
            var serializerOptions = new System.Text.Json.JsonSerializerOptions();
            serializerOptions.Converters.Add(new System.Text.Json.Serialization.JsonStringEnumConverter(JsonNamingPolicy.CamelCase));
            request.Content = System.Net.Http.Json.JsonContent.Create<UpdateAnonymousUserRolesModel>(body, options: serializerOptions);

            var response = await _httpClient.SendAsync(request);

            switch ((int)response.StatusCode)
            {
                case 200:
                    var stream = await response.Content.ReadAsStreamAsync();
                    return stream;

                default:
                    throw new InvalidOperationException($"Call Failed - {response.StatusCode}");
            }
        }

        public async Task<UserSummaryModel> Currentuser()
        {
            string url = $"/api/currentuser";
            var request = new HttpRequestMessage(HttpMethod.Get, url);

            var response = await _httpClient.SendAsync(request);

            switch ((int)response.StatusCode)
            {
                case 200:
                    {
                        using (var stream = await response.Content.ReadAsStreamAsync())
                        {
                            if (stream.Length == 0)
                                return default(UserSummaryModel);

                            var result = await JsonSerializer.DeserializeAsync<UserSummaryModel>(stream, _serializerOptions);
                            return result;
                        }
                    }

                default:
                    throw new InvalidOperationException($"Call Failed - {response.StatusCode}");
            }
        }

        public async Task<System.IO.Stream> CurrentuserStream()
        {
            string url = $"/api/currentuser";
            var request = new HttpRequestMessage(HttpMethod.Get, url);

            var response = await _httpClient.SendAsync(request);

            switch ((int)response.StatusCode)
            {
                case 200:
                    var stream = await response.Content.ReadAsStreamAsync();
                    return stream;

                default:
                    throw new InvalidOperationException($"Call Failed - {response.StatusCode}");
            }
        }

        public async Task<SitePrivilege[]> CurrentuserEffectiveSitePrivileges()
        {
            string url = $"/api/currentuser/effectiveSitePrivileges";
            var request = new HttpRequestMessage(HttpMethod.Get, url);

            var response = await _httpClient.SendAsync(request);

            switch ((int)response.StatusCode)
            {
                case 200:
                    {
                        using (var stream = await response.Content.ReadAsStreamAsync())
                        {
                            if (stream.Length == 0)
                                return default(SitePrivilege[]);

                            var result = await JsonSerializer.DeserializeAsync<SitePrivilege[]>(stream, _serializerOptions);
                            return result;
                        }
                    }

                default:
                    throw new InvalidOperationException($"Call Failed - {response.StatusCode}");
            }
        }

        public async Task<System.IO.Stream> CurrentuserEffectiveSitePrivilegesStream()
        {
            string url = $"/api/currentuser/effectiveSitePrivileges";
            var request = new HttpRequestMessage(HttpMethod.Get, url);

            var response = await _httpClient.SendAsync(request);

            switch ((int)response.StatusCode)
            {
                case 200:
                    var stream = await response.Content.ReadAsStreamAsync();
                    return stream;

                default:
                    throw new InvalidOperationException($"Call Failed - {response.StatusCode}");
            }
        }

        public async Task<CheckEffectiveSitePrivilegesResultsModel> CurrentuserCheckEffectiveSitePrivileges(
            CheckEffectiveSitePrivilegesModel body)
        {
            string url = $"/api/currentuser/CheckEffectiveSitePrivileges";
            var request = new HttpRequestMessage(HttpMethod.Post, url);
            var serializerOptions = new System.Text.Json.JsonSerializerOptions();
            serializerOptions.Converters.Add(new System.Text.Json.Serialization.JsonStringEnumConverter(JsonNamingPolicy.CamelCase));
            request.Content = System.Net.Http.Json.JsonContent.Create<CheckEffectiveSitePrivilegesModel>(body, options: serializerOptions);

            var response = await _httpClient.SendAsync(request);

            switch ((int)response.StatusCode)
            {
                case 200:
                    {
                        using (var stream = await response.Content.ReadAsStreamAsync())
                        {
                            if (stream.Length == 0)
                                return default(CheckEffectiveSitePrivilegesResultsModel);

                            var result = await JsonSerializer.DeserializeAsync<CheckEffectiveSitePrivilegesResultsModel>(stream, _serializerOptions);
                            return result;
                        }
                    }

                default:
                    throw new InvalidOperationException($"Call Failed - {response.StatusCode}");
            }
        }

        public async Task<System.IO.Stream> CurrentuserCheckEffectiveSitePrivilegesStream(
            CheckEffectiveSitePrivilegesModel body)
        {
            string url = $"/api/currentuser/CheckEffectiveSitePrivileges";
            var request = new HttpRequestMessage(HttpMethod.Post, url);
            var serializerOptions = new System.Text.Json.JsonSerializerOptions();
            serializerOptions.Converters.Add(new System.Text.Json.Serialization.JsonStringEnumConverter(JsonNamingPolicy.CamelCase));
            request.Content = System.Net.Http.Json.JsonContent.Create<CheckEffectiveSitePrivilegesModel>(body, options: serializerOptions);

            var response = await _httpClient.SendAsync(request);

            switch ((int)response.StatusCode)
            {
                case 200:
                    var stream = await response.Content.ReadAsStreamAsync();
                    return stream;

                default:
                    throw new InvalidOperationException($"Call Failed - {response.StatusCode}");
            }
        }

        public async Task<ProductPrivilege[]> CurrentuserEffectiveProductPrivileges(
            string product)
        {
            string url = $"/api/currentuser/EffectiveProductPrivileges/{product}";
            var request = new HttpRequestMessage(HttpMethod.Get, url);

            var response = await _httpClient.SendAsync(request);

            switch ((int)response.StatusCode)
            {
                case 200:
                    {
                        using (var stream = await response.Content.ReadAsStreamAsync())
                        {
                            if (stream.Length == 0)
                                return default(ProductPrivilege[]);

                            var result = await JsonSerializer.DeserializeAsync<ProductPrivilege[]>(stream, _serializerOptions);
                            return result;
                        }
                    }

                default:
                    throw new InvalidOperationException($"Call Failed - {response.StatusCode}");
            }
        }

        public async Task<System.IO.Stream> CurrentuserEffectiveProductPrivilegesStream(
            string product)
        {
            string url = $"/api/currentuser/EffectiveProductPrivileges/{product}";
            var request = new HttpRequestMessage(HttpMethod.Get, url);

            var response = await _httpClient.SendAsync(request);

            switch ((int)response.StatusCode)
            {
                case 200:
                    var stream = await response.Content.ReadAsStreamAsync();
                    return stream;

                default:
                    throw new InvalidOperationException($"Call Failed - {response.StatusCode}");
            }
        }

        public async Task<CheckEffectiveProductsPrivilegesResultsModel> CurrentuserCheckEffectiveProductPrivileges(
            CheckEffectiveProductsPrivilegesModel body)
        {
            string url = $"/api/currentuser/CheckEffectiveProductPrivileges";
            var request = new HttpRequestMessage(HttpMethod.Post, url);
            var serializerOptions = new System.Text.Json.JsonSerializerOptions();
            serializerOptions.Converters.Add(new System.Text.Json.Serialization.JsonStringEnumConverter(JsonNamingPolicy.CamelCase));
            request.Content = System.Net.Http.Json.JsonContent.Create<CheckEffectiveProductsPrivilegesModel>(body, options: serializerOptions);

            var response = await _httpClient.SendAsync(request);

            switch ((int)response.StatusCode)
            {
                case 200:
                    {
                        using (var stream = await response.Content.ReadAsStreamAsync())
                        {
                            if (stream.Length == 0)
                                return default(CheckEffectiveProductsPrivilegesResultsModel);

                            var result = await JsonSerializer.DeserializeAsync<CheckEffectiveProductsPrivilegesResultsModel>(stream, _serializerOptions);
                            return result;
                        }
                    }

                default:
                    throw new InvalidOperationException($"Call Failed - {response.StatusCode}");
            }
        }

        public async Task<System.IO.Stream> CurrentuserCheckEffectiveProductPrivilegesStream(
            CheckEffectiveProductsPrivilegesModel body)
        {
            string url = $"/api/currentuser/CheckEffectiveProductPrivileges";
            var request = new HttpRequestMessage(HttpMethod.Post, url);
            var serializerOptions = new System.Text.Json.JsonSerializerOptions();
            serializerOptions.Converters.Add(new System.Text.Json.Serialization.JsonStringEnumConverter(JsonNamingPolicy.CamelCase));
            request.Content = System.Net.Http.Json.JsonContent.Create<CheckEffectiveProductsPrivilegesModel>(body, options: serializerOptions);

            var response = await _httpClient.SendAsync(request);

            switch ((int)response.StatusCode)
            {
                case 200:
                    var stream = await response.Content.ReadAsStreamAsync();
                    return stream;

                default:
                    throw new InvalidOperationException($"Call Failed - {response.StatusCode}");
            }
        }

        public async Task CurrentuserChangepassword(
            string originalPassword,
            string password)
        {
            string url = $"/api/currentuser/changepassword";
            {
                var qsh = new QueryStringHelper(url);
                qsh.RegisterQueryParameter("originalPassword", originalPassword);
                qsh.RegisterQueryParameter("password", password);
                url = qsh.GenerateFullUri();
            }
            var request = new HttpRequestMessage(HttpMethod.Post, url);

            var response = await _httpClient.SendAsync(request);

            switch ((int)response.StatusCode)
            {
                case 204:
                    return;

                default:
                    throw new InvalidOperationException($"Call Failed - {response.StatusCode}");
            }
        }

        public async Task<UserSessionModel[]> CurrentuserSessions()
        {
            string url = $"/api/currentuser/sessions";
            var request = new HttpRequestMessage(HttpMethod.Get, url);

            var response = await _httpClient.SendAsync(request);

            switch ((int)response.StatusCode)
            {
                case 200:
                    {
                        using (var stream = await response.Content.ReadAsStreamAsync())
                        {
                            if (stream.Length == 0)
                                return default(UserSessionModel[]);

                            var result = await JsonSerializer.DeserializeAsync<UserSessionModel[]>(stream, _serializerOptions);
                            return result;
                        }
                    }

                default:
                    throw new InvalidOperationException($"Call Failed - {response.StatusCode}");
            }
        }

        public async Task<System.IO.Stream> CurrentuserSessionsStream()
        {
            string url = $"/api/currentuser/sessions";
            var request = new HttpRequestMessage(HttpMethod.Get, url);

            var response = await _httpClient.SendAsync(request);

            switch ((int)response.StatusCode)
            {
                case 200:
                    var stream = await response.Content.ReadAsStreamAsync();
                    return stream;

                default:
                    throw new InvalidOperationException($"Call Failed - {response.StatusCode}");
            }
        }

        public async Task<UserPersonalAccessTokenModel> CurrentuserPersonalaccesstokenCreate(
            CreateUserPersonalAccessTokenModel body)
        {
            string url = $"/api/currentuser/personalaccesstoken/create";
            var request = new HttpRequestMessage(HttpMethod.Post, url);
            var serializerOptions = new System.Text.Json.JsonSerializerOptions();
            serializerOptions.Converters.Add(new System.Text.Json.Serialization.JsonStringEnumConverter(JsonNamingPolicy.CamelCase));
            request.Content = System.Net.Http.Json.JsonContent.Create<CreateUserPersonalAccessTokenModel>(body, options: serializerOptions);

            var response = await _httpClient.SendAsync(request);

            switch ((int)response.StatusCode)
            {
                case 201:
                    {
                        using (var stream = await response.Content.ReadAsStreamAsync())
                        {
                            if (stream.Length == 0)
                                return default(UserPersonalAccessTokenModel);

                            var result = await JsonSerializer.DeserializeAsync<UserPersonalAccessTokenModel>(stream, _serializerOptions);
                            return result;
                        }
                    }

                default:
                    throw new InvalidOperationException($"Call Failed - {response.StatusCode}");
            }
        }

        public async Task<System.IO.Stream> CurrentuserPersonalaccesstokenCreateStream(
            CreateUserPersonalAccessTokenModel body)
        {
            string url = $"/api/currentuser/personalaccesstoken/create";
            var request = new HttpRequestMessage(HttpMethod.Post, url);
            var serializerOptions = new System.Text.Json.JsonSerializerOptions();
            serializerOptions.Converters.Add(new System.Text.Json.Serialization.JsonStringEnumConverter(JsonNamingPolicy.CamelCase));
            request.Content = System.Net.Http.Json.JsonContent.Create<CreateUserPersonalAccessTokenModel>(body, options: serializerOptions);

            var response = await _httpClient.SendAsync(request);

            switch ((int)response.StatusCode)
            {
                case 200:
                    var stream = await response.Content.ReadAsStreamAsync();
                    return stream;

                default:
                    throw new InvalidOperationException($"Call Failed - {response.StatusCode}");
            }
        }

        public async Task CurrentuserPersonalaccesstokenDelete(
            string tokenName)
        {
            string url = $"/api/currentuser/personalaccesstoken/delete";
            {
                var qsh = new QueryStringHelper(url);
                qsh.RegisterQueryParameter("tokenName", tokenName);
                url = qsh.GenerateFullUri();
            }
            var request = new HttpRequestMessage(HttpMethod.Delete, url);

            var response = await _httpClient.SendAsync(request);

            switch ((int)response.StatusCode)
            {
                case 204:
                    return;

                default:
                    throw new InvalidOperationException($"Call Failed - {response.StatusCode}");
            }
        }

        public async Task<UserPersonalAccessTokenModel[]> CurrentuserPersonalaccesstokens()
        {
            string url = $"/api/currentuser/personalaccesstokens";
            var request = new HttpRequestMessage(HttpMethod.Get, url);

            var response = await _httpClient.SendAsync(request);

            switch ((int)response.StatusCode)
            {
                case 200:
                    {
                        using (var stream = await response.Content.ReadAsStreamAsync())
                        {
                            if (stream.Length == 0)
                                return default(UserPersonalAccessTokenModel[]);

                            var result = await JsonSerializer.DeserializeAsync<UserPersonalAccessTokenModel[]>(stream, _serializerOptions);
                            return result;
                        }
                    }

                default:
                    throw new InvalidOperationException($"Call Failed - {response.StatusCode}");
            }
        }

        public async Task<System.IO.Stream> CurrentuserPersonalaccesstokensStream()
        {
            string url = $"/api/currentuser/personalaccesstokens";
            var request = new HttpRequestMessage(HttpMethod.Get, url);

            var response = await _httpClient.SendAsync(request);

            switch ((int)response.StatusCode)
            {
                case 200:
                    var stream = await response.Content.ReadAsStreamAsync();
                    return stream;

                default:
                    throw new InvalidOperationException($"Call Failed - {response.StatusCode}");
            }
        }

        public async Task CurrentuserPersonalaccesstokensWipe()
        {
            string url = $"/api/currentuser/personalaccesstokens/wipe";
            var request = new HttpRequestMessage(HttpMethod.Delete, url);

            var response = await _httpClient.SendAsync(request);

            switch ((int)response.StatusCode)
            {
                case 204:
                    return;

                default:
                    throw new InvalidOperationException($"Call Failed - {response.StatusCode}");
            }
        }

        public async Task<ErrorAdminModel> Error(
            int errorID)
        {
            string url = $"/api/error/{errorID}";
            var request = new HttpRequestMessage(HttpMethod.Get, url);

            var response = await _httpClient.SendAsync(request);

            switch ((int)response.StatusCode)
            {
                case 200:
                    {
                        using (var stream = await response.Content.ReadAsStreamAsync())
                        {
                            if (stream.Length == 0)
                                return default(ErrorAdminModel);

                            var result = await JsonSerializer.DeserializeAsync<ErrorAdminModel>(stream, _serializerOptions);
                            return result;
                        }
                    }

                default:
                    throw new InvalidOperationException($"Call Failed - {response.StatusCode}");
            }
        }

        public async Task<System.IO.Stream> ErrorStream(
            int errorID)
        {
            string url = $"/api/error/{errorID}";
            var request = new HttpRequestMessage(HttpMethod.Get, url);

            var response = await _httpClient.SendAsync(request);

            switch ((int)response.StatusCode)
            {
                case 200:
                    var stream = await response.Content.ReadAsStreamAsync();
                    return stream;

                default:
                    throw new InvalidOperationException($"Call Failed - {response.StatusCode}");
            }
        }

        public async Task<ErrorSearchResultsModel> ErrorsSearch(
            int? maxResults,
            SearchErrorsCriteriaModel body)
        {
            string url = $"/api/errors/search";
            {
                var qsh = new QueryStringHelper(url);
                qsh.RegisterQueryParameter("maxResults", maxResults);
                url = qsh.GenerateFullUri();
            }
            var request = new HttpRequestMessage(HttpMethod.Post, url);
            var serializerOptions = new System.Text.Json.JsonSerializerOptions();
            serializerOptions.Converters.Add(new System.Text.Json.Serialization.JsonStringEnumConverter(JsonNamingPolicy.CamelCase));
            request.Content = System.Net.Http.Json.JsonContent.Create<SearchErrorsCriteriaModel>(body, options: serializerOptions);

            var response = await _httpClient.SendAsync(request);

            switch ((int)response.StatusCode)
            {
                case 200:
                    {
                        using (var stream = await response.Content.ReadAsStreamAsync())
                        {
                            if (stream.Length == 0)
                                return default(ErrorSearchResultsModel);

                            var result = await JsonSerializer.DeserializeAsync<ErrorSearchResultsModel>(stream, _serializerOptions);
                            return result;
                        }
                    }

                default:
                    throw new InvalidOperationException($"Call Failed - {response.StatusCode}");
            }
        }

        public async Task<System.IO.Stream> ErrorsSearchStream(
            int? maxResults,
            SearchErrorsCriteriaModel body)
        {
            string url = $"/api/errors/search";
            {
                var qsh = new QueryStringHelper(url);
                qsh.RegisterQueryParameter("maxResults", maxResults);
                url = qsh.GenerateFullUri();
            }
            var request = new HttpRequestMessage(HttpMethod.Post, url);
            var serializerOptions = new System.Text.Json.JsonSerializerOptions();
            serializerOptions.Converters.Add(new System.Text.Json.Serialization.JsonStringEnumConverter(JsonNamingPolicy.CamelCase));
            request.Content = System.Net.Http.Json.JsonContent.Create<SearchErrorsCriteriaModel>(body, options: serializerOptions);

            var response = await _httpClient.SendAsync(request);

            switch ((int)response.StatusCode)
            {
                case 200:
                    var stream = await response.Content.ReadAsStreamAsync();
                    return stream;

                default:
                    throw new InvalidOperationException($"Call Failed - {response.StatusCode}");
            }
        }

        public async Task<string> FrontPageGet()
        {
            string url = $"/api/frontPage";
            var request = new HttpRequestMessage(HttpMethod.Get, url);

            var response = await _httpClient.SendAsync(request);

            switch ((int)response.StatusCode)
            {
                case 200:
                    {
                        var result = await response.Content.ReadAsStringAsync();
                        return result;
                    }

                default:
                    throw new InvalidOperationException($"Call Failed - {response.StatusCode}");
            }
        }

        public async Task<System.IO.Stream> FrontPageGetStream()
        {
            string url = $"/api/frontPage";
            var request = new HttpRequestMessage(HttpMethod.Get, url);

            var response = await _httpClient.SendAsync(request);

            switch ((int)response.StatusCode)
            {
                case 200:
                    var stream = await response.Content.ReadAsStreamAsync();
                    return stream;

                default:
                    throw new InvalidOperationException($"Call Failed - {response.StatusCode}");
            }
        }

        public async Task FrontPagePut(
            string body)
        {
            string url = $"/api/frontPage";
            var request = new HttpRequestMessage(HttpMethod.Put, url);
            var serializerOptions = new System.Text.Json.JsonSerializerOptions();
            serializerOptions.Converters.Add(new System.Text.Json.Serialization.JsonStringEnumConverter(JsonNamingPolicy.CamelCase));
            request.Content = System.Net.Http.Json.JsonContent.Create<string>(body, options: serializerOptions);

            var response = await _httpClient.SendAsync(request);

            switch ((int)response.StatusCode)
            {
                case 204:
                    return;

                default:
                    throw new InvalidOperationException($"Call Failed - {response.StatusCode}");
            }
        }

        public async Task FrontPageDelete()
        {
            string url = $"/api/frontPage";
            var request = new HttpRequestMessage(HttpMethod.Delete, url);

            var response = await _httpClient.SendAsync(request);

            switch ((int)response.StatusCode)
            {
                case 204:
                    return;

                default:
                    throw new InvalidOperationException($"Call Failed - {response.StatusCode}");
            }
        }

        public async Task<GroupSummaryModel> GroupGet(
            string groupName)
        {
            string url = $"/api/group/{groupName}";
            var request = new HttpRequestMessage(HttpMethod.Get, url);

            var response = await _httpClient.SendAsync(request);

            switch ((int)response.StatusCode)
            {
                case 200:
                    {
                        using (var stream = await response.Content.ReadAsStreamAsync())
                        {
                            if (stream.Length == 0)
                                return default(GroupSummaryModel);

                            var result = await JsonSerializer.DeserializeAsync<GroupSummaryModel>(stream, _serializerOptions);
                            return result;
                        }
                    }

                default:
                    throw new InvalidOperationException($"Call Failed - {response.StatusCode}");
            }
        }

        public async Task<System.IO.Stream> GroupGetStream(
            string groupName)
        {
            string url = $"/api/group/{groupName}";
            var request = new HttpRequestMessage(HttpMethod.Get, url);

            var response = await _httpClient.SendAsync(request);

            switch ((int)response.StatusCode)
            {
                case 200:
                    var stream = await response.Content.ReadAsStreamAsync();
                    return stream;

                default:
                    throw new InvalidOperationException($"Call Failed - {response.StatusCode}");
            }
        }

        public async Task GroupDelete(
            string groupName)
        {
            string url = $"/api/group/{groupName}";
            var request = new HttpRequestMessage(HttpMethod.Delete, url);

            var response = await _httpClient.SendAsync(request);

            switch ((int)response.StatusCode)
            {
                case 204:
                    return;

                default:
                    throw new InvalidOperationException($"Call Failed - {response.StatusCode}");
            }
        }

        public async Task<SitePrivilege[]> GroupEffectiveSitePrivileges(
            string groupName)
        {
            string url = $"/api/group/{groupName}/effectiveSitePrivileges";
            var request = new HttpRequestMessage(HttpMethod.Get, url);

            var response = await _httpClient.SendAsync(request);

            switch ((int)response.StatusCode)
            {
                case 200:
                    {
                        using (var stream = await response.Content.ReadAsStreamAsync())
                        {
                            if (stream.Length == 0)
                                return default(SitePrivilege[]);

                            var result = await JsonSerializer.DeserializeAsync<SitePrivilege[]>(stream, _serializerOptions);
                            return result;
                        }
                    }

                default:
                    throw new InvalidOperationException($"Call Failed - {response.StatusCode}");
            }
        }

        public async Task<System.IO.Stream> GroupEffectiveSitePrivilegesStream(
            string groupName)
        {
            string url = $"/api/group/{groupName}/effectiveSitePrivileges";
            var request = new HttpRequestMessage(HttpMethod.Get, url);

            var response = await _httpClient.SendAsync(request);

            switch ((int)response.StatusCode)
            {
                case 200:
                    var stream = await response.Content.ReadAsStreamAsync();
                    return stream;

                default:
                    throw new InvalidOperationException($"Call Failed - {response.StatusCode}");
            }
        }

        public async Task GroupUpdate(
            string groupName,
            UpdateGroupDetailsModel body)
        {
            string url = $"/api/group/{groupName}/update";
            var request = new HttpRequestMessage(HttpMethod.Post, url);
            var serializerOptions = new System.Text.Json.JsonSerializerOptions();
            serializerOptions.Converters.Add(new System.Text.Json.Serialization.JsonStringEnumConverter(JsonNamingPolicy.CamelCase));
            request.Content = System.Net.Http.Json.JsonContent.Create<UpdateGroupDetailsModel>(body, options: serializerOptions);

            var response = await _httpClient.SendAsync(request);

            switch ((int)response.StatusCode)
            {
                case 204:
                    return;

                default:
                    throw new InvalidOperationException($"Call Failed - {response.StatusCode}");
            }
        }

        public async Task<ValidateUpdateGroupDetailsModel> GroupValidateUpdate(
            string groupName,
            UpdateGroupDetailsModel body)
        {
            string url = $"/api/group/{groupName}/validateUpdate";
            var request = new HttpRequestMessage(HttpMethod.Post, url);
            var serializerOptions = new System.Text.Json.JsonSerializerOptions();
            serializerOptions.Converters.Add(new System.Text.Json.Serialization.JsonStringEnumConverter(JsonNamingPolicy.CamelCase));
            request.Content = System.Net.Http.Json.JsonContent.Create<UpdateGroupDetailsModel>(body, options: serializerOptions);

            var response = await _httpClient.SendAsync(request);

            switch ((int)response.StatusCode)
            {
                case 200:
                    {
                        using (var stream = await response.Content.ReadAsStreamAsync())
                        {
                            if (stream.Length == 0)
                                return default(ValidateUpdateGroupDetailsModel);

                            var result = await JsonSerializer.DeserializeAsync<ValidateUpdateGroupDetailsModel>(stream, _serializerOptions);
                            return result;
                        }
                    }

                default:
                    throw new InvalidOperationException($"Call Failed - {response.StatusCode}");
            }
        }

        public async Task<System.IO.Stream> GroupValidateUpdateStream(
            string groupName,
            UpdateGroupDetailsModel body)
        {
            string url = $"/api/group/{groupName}/validateUpdate";
            var request = new HttpRequestMessage(HttpMethod.Post, url);
            var serializerOptions = new System.Text.Json.JsonSerializerOptions();
            serializerOptions.Converters.Add(new System.Text.Json.Serialization.JsonStringEnumConverter(JsonNamingPolicy.CamelCase));
            request.Content = System.Net.Http.Json.JsonContent.Create<UpdateGroupDetailsModel>(body, options: serializerOptions);

            var response = await _httpClient.SendAsync(request);

            switch ((int)response.StatusCode)
            {
                case 200:
                    var stream = await response.Content.ReadAsStreamAsync();
                    return stream;

                default:
                    throw new InvalidOperationException($"Call Failed - {response.StatusCode}");
            }
        }

        public async Task<string[]> GroupMembers(
            string groupName)
        {
            string url = $"/api/group/{groupName}/members";
            var request = new HttpRequestMessage(HttpMethod.Get, url);

            var response = await _httpClient.SendAsync(request);

            switch ((int)response.StatusCode)
            {
                case 200:
                    {
                        using (var stream = await response.Content.ReadAsStreamAsync())
                        {
                            if (stream.Length == 0)
                                return default(string[]);

                            var result = await JsonSerializer.DeserializeAsync<string[]>(stream, _serializerOptions);
                            return result;
                        }
                    }

                default:
                    throw new InvalidOperationException($"Call Failed - {response.StatusCode}");
            }
        }

        public async Task<System.IO.Stream> GroupMembersStream(
            string groupName)
        {
            string url = $"/api/group/{groupName}/members";
            var request = new HttpRequestMessage(HttpMethod.Get, url);

            var response = await _httpClient.SendAsync(request);

            switch ((int)response.StatusCode)
            {
                case 200:
                    var stream = await response.Content.ReadAsStreamAsync();
                    return stream;

                default:
                    throw new InvalidOperationException($"Call Failed - {response.StatusCode}");
            }
        }

        public async Task GroupsCreate(
            string groupName,
            string description,
            string contactEmail,
            string[] initialMembers,
            string[] initialGroups,
            string[] initialRoles,
            string[] adminUsers,
            string[] adminGroups)
        {
            string url = $"/api/groups/Create";
            {
                var qsh = new QueryStringHelper(url);
                qsh.RegisterQueryParameter("groupName", groupName);
                qsh.RegisterQueryParameter("description", description);
                qsh.RegisterQueryParameter("contactEmail", contactEmail);
                qsh.RegisterQueryParameter("initialMembers", initialMembers);
                qsh.RegisterQueryParameter("initialGroups", initialGroups);
                qsh.RegisterQueryParameter("initialRoles", initialRoles);
                qsh.RegisterQueryParameter("adminUsers", adminUsers);
                qsh.RegisterQueryParameter("adminGroups", adminGroups);
                url = qsh.GenerateFullUri();
            }
            var request = new HttpRequestMessage(HttpMethod.Post, url);

            var response = await _httpClient.SendAsync(request);

            switch ((int)response.StatusCode)
            {
                case 201:
                    return;

                default:
                    throw new InvalidOperationException($"Call Failed - {response.StatusCode}");
            }
        }

        public async Task<GroupSummaryModel[]> GroupsAll()
        {
            string url = $"/api/groups/all";
            var request = new HttpRequestMessage(HttpMethod.Get, url);

            var response = await _httpClient.SendAsync(request);

            switch ((int)response.StatusCode)
            {
                case 200:
                    {
                        using (var stream = await response.Content.ReadAsStreamAsync())
                        {
                            if (stream.Length == 0)
                                return default(GroupSummaryModel[]);

                            var result = await JsonSerializer.DeserializeAsync<GroupSummaryModel[]>(stream, _serializerOptions);
                            return result;
                        }
                    }

                default:
                    throw new InvalidOperationException($"Call Failed - {response.StatusCode}");
            }
        }

        public async Task<System.IO.Stream> GroupsAllStream()
        {
            string url = $"/api/groups/all";
            var request = new HttpRequestMessage(HttpMethod.Get, url);

            var response = await _httpClient.SendAsync(request);

            switch ((int)response.StatusCode)
            {
                case 200:
                    var stream = await response.Content.ReadAsStreamAsync();
                    return stream;

                default:
                    throw new InvalidOperationException($"Call Failed - {response.StatusCode}");
            }
        }

        public async Task<GroupSummaryModel[]> GroupsSearch(
            string searchText)
        {
            string url = $"/api/groups/search";
            {
                var qsh = new QueryStringHelper(url);
                qsh.RegisterQueryParameter("searchText", searchText);
                url = qsh.GenerateFullUri();
            }
            var request = new HttpRequestMessage(HttpMethod.Post, url);

            var response = await _httpClient.SendAsync(request);

            switch ((int)response.StatusCode)
            {
                case 200:
                    {
                        using (var stream = await response.Content.ReadAsStreamAsync())
                        {
                            if (stream.Length == 0)
                                return default(GroupSummaryModel[]);

                            var result = await JsonSerializer.DeserializeAsync<GroupSummaryModel[]>(stream, _serializerOptions);
                            return result;
                        }
                    }

                default:
                    throw new InvalidOperationException($"Call Failed - {response.StatusCode}");
            }
        }

        public async Task<System.IO.Stream> GroupsSearchStream(
            string searchText)
        {
            string url = $"/api/groups/search";
            {
                var qsh = new QueryStringHelper(url);
                qsh.RegisterQueryParameter("searchText", searchText);
                url = qsh.GenerateFullUri();
            }
            var request = new HttpRequestMessage(HttpMethod.Post, url);

            var response = await _httpClient.SendAsync(request);

            switch ((int)response.StatusCode)
            {
                case 200:
                    var stream = await response.Content.ReadAsStreamAsync();
                    return stream;

                default:
                    throw new InvalidOperationException($"Call Failed - {response.StatusCode}");
            }
        }

        public async Task Logout()
        {
            string url = $"/api/logout";
            var request = new HttpRequestMessage(HttpMethod.Post, url);

            var response = await _httpClient.SendAsync(request);

            switch ((int)response.StatusCode)
            {
                case 204:
                    return;

                default:
                    throw new InvalidOperationException($"Call Failed - {response.StatusCode}");
            }
        }

        public async Task LogoutAllSessions()
        {
            string url = $"/api/logout/allSessions";
            var request = new HttpRequestMessage(HttpMethod.Post, url);

            var response = await _httpClient.SendAsync(request);

            switch ((int)response.StatusCode)
            {
                case 204:
                    return;

                default:
                    throw new InvalidOperationException($"Call Failed - {response.StatusCode}");
            }
        }

        public async Task<LoginResultModel> Login(
            string userName,
            string password)
        {
            string url = $"/api/login";
            {
                var qsh = new QueryStringHelper(url);
                qsh.RegisterQueryParameter("userName", userName);
                qsh.RegisterQueryParameter("password", password);
                url = qsh.GenerateFullUri();
            }
            var request = new HttpRequestMessage(HttpMethod.Post, url);

            var response = await _httpClient.SendAsync(request);

            switch ((int)response.StatusCode)
            {
                case 200:
                    {
                        using (var stream = await response.Content.ReadAsStreamAsync())
                        {
                            if (stream.Length == 0)
                                return default(LoginResultModel);

                            var result = await JsonSerializer.DeserializeAsync<LoginResultModel>(stream, _serializerOptions);
                            return result;
                        }
                    }

                default:
                    throw new InvalidOperationException($"Call Failed - {response.StatusCode}");
            }
        }

        public async Task<System.IO.Stream> LoginStream(
            string userName,
            string password)
        {
            string url = $"/api/login";
            {
                var qsh = new QueryStringHelper(url);
                qsh.RegisterQueryParameter("userName", userName);
                qsh.RegisterQueryParameter("password", password);
                url = qsh.GenerateFullUri();
            }
            var request = new HttpRequestMessage(HttpMethod.Post, url);

            var response = await _httpClient.SendAsync(request);

            switch ((int)response.StatusCode)
            {
                case 200:
                    var stream = await response.Content.ReadAsStreamAsync();
                    return stream;

                default:
                    throw new InvalidOperationException($"Call Failed - {response.StatusCode}");
            }
        }

        public async Task<string> Metrics()
        {
            string url = $"/api/metrics";
            var request = new HttpRequestMessage(HttpMethod.Get, url);

            var response = await _httpClient.SendAsync(request);

            switch ((int)response.StatusCode)
            {
                case 200:
                    {
                        var result = await response.Content.ReadAsStringAsync();
                        return result;
                    }

                default:
                    throw new InvalidOperationException($"Call Failed - {response.StatusCode}");
            }
        }

        public async Task<System.IO.Stream> MetricsStream()
        {
            string url = $"/api/metrics";
            var request = new HttpRequestMessage(HttpMethod.Get, url);

            var response = await _httpClient.SendAsync(request);

            switch ((int)response.StatusCode)
            {
                case 200:
                    var stream = await response.Content.ReadAsStreamAsync();
                    return stream;

                default:
                    throw new InvalidOperationException($"Call Failed - {response.StatusCode}");
            }
        }

        public async Task<ProductModel> Product(
            string productName)
        {
            string url = $"/api/Product/{productName}";
            var request = new HttpRequestMessage(HttpMethod.Get, url);

            var response = await _httpClient.SendAsync(request);

            switch ((int)response.StatusCode)
            {
                case 200:
                    {
                        using (var stream = await response.Content.ReadAsStreamAsync())
                        {
                            if (stream.Length == 0)
                                return default(ProductModel);

                            var result = await JsonSerializer.DeserializeAsync<ProductModel>(stream, _serializerOptions);
                            return result;
                        }
                    }

                default:
                    throw new InvalidOperationException($"Call Failed - {response.StatusCode}");
            }
        }

        public async Task<System.IO.Stream> ProductStream(
            string productName)
        {
            string url = $"/api/Product/{productName}";
            var request = new HttpRequestMessage(HttpMethod.Get, url);

            var response = await _httpClient.SendAsync(request);

            switch ((int)response.StatusCode)
            {
                case 200:
                    var stream = await response.Content.ReadAsStreamAsync();
                    return stream;

                default:
                    throw new InvalidOperationException($"Call Failed - {response.StatusCode}");
            }
        }

        public async Task<byte[]> ProductTestRunTypeImage(
            string productName,
            string testRunType)
        {
            string url = $"/api/product/{productName}/testRunType/{testRunType}/image";
            var request = new HttpRequestMessage(HttpMethod.Get, url);

            var response = await _httpClient.SendAsync(request);

            switch ((int)response.StatusCode)
            {
                case 200:
                    {
                        using (var stream = await response.Content.ReadAsStreamAsync())
                        {
                            if (stream.Length == 0)
                                return default(byte[]);

                            var buffer = new byte[stream.Length];
                            using (var memoryStream = new System.IO.MemoryStream(buffer))
                                await stream.CopyToAsync(memoryStream);

                            return buffer;
                        }
                    }

                default:
                    throw new InvalidOperationException($"Call Failed - {response.StatusCode}");
            }
        }

        public async Task<System.IO.Stream> ProductTestRunTypeImageStream(
            string productName,
            string testRunType)
        {
            string url = $"/api/product/{productName}/testRunType/{testRunType}/image";
            var request = new HttpRequestMessage(HttpMethod.Get, url);

            var response = await _httpClient.SendAsync(request);

            switch ((int)response.StatusCode)
            {
                case 200:
                    var stream = await response.Content.ReadAsStreamAsync();
                    return stream;

                default:
                    throw new InvalidOperationException($"Call Failed - {response.StatusCode}");
            }
        }

        public async Task<ComponentDetailsModel[]> ProductComponents(
            string productName)
        {
            string url = $"/api/product/{productName}/components";
            var request = new HttpRequestMessage(HttpMethod.Get, url);

            var response = await _httpClient.SendAsync(request);

            switch ((int)response.StatusCode)
            {
                case 200:
                    {
                        using (var stream = await response.Content.ReadAsStreamAsync())
                        {
                            if (stream.Length == 0)
                                return default(ComponentDetailsModel[]);

                            var result = await JsonSerializer.DeserializeAsync<ComponentDetailsModel[]>(stream, _serializerOptions);
                            return result;
                        }
                    }

                default:
                    throw new InvalidOperationException($"Call Failed - {response.StatusCode}");
            }
        }

        public async Task<System.IO.Stream> ProductComponentsStream(
            string productName)
        {
            string url = $"/api/product/{productName}/components";
            var request = new HttpRequestMessage(HttpMethod.Get, url);

            var response = await _httpClient.SendAsync(request);

            switch ((int)response.StatusCode)
            {
                case 200:
                    var stream = await response.Content.ReadAsStreamAsync();
                    return stream;

                default:
                    throw new InvalidOperationException($"Call Failed - {response.StatusCode}");
            }
        }

        public async Task<TestRunTypeModel[]> ProductTestRunTypes(
            string productName)
        {
            string url = $"/api/product/{productName}/testRunTypes";
            var request = new HttpRequestMessage(HttpMethod.Get, url);

            var response = await _httpClient.SendAsync(request);

            switch ((int)response.StatusCode)
            {
                case 200:
                    {
                        using (var stream = await response.Content.ReadAsStreamAsync())
                        {
                            if (stream.Length == 0)
                                return default(TestRunTypeModel[]);

                            var result = await JsonSerializer.DeserializeAsync<TestRunTypeModel[]>(stream, _serializerOptions);
                            return result;
                        }
                    }

                default:
                    throw new InvalidOperationException($"Call Failed - {response.StatusCode}");
            }
        }

        public async Task<System.IO.Stream> ProductTestRunTypesStream(
            string productName)
        {
            string url = $"/api/product/{productName}/testRunTypes";
            var request = new HttpRequestMessage(HttpMethod.Get, url);

            var response = await _httpClient.SendAsync(request);

            switch ((int)response.StatusCode)
            {
                case 200:
                    var stream = await response.Content.ReadAsStreamAsync();
                    return stream;

                default:
                    throw new InvalidOperationException($"Call Failed - {response.StatusCode}");
            }
        }

        public async Task<TestRunTypeModel> ProductTestRunTypeGet(
            string productName,
            string testRunType)
        {
            string url = $"/api/product/{productName}/testRunType/{testRunType}";
            var request = new HttpRequestMessage(HttpMethod.Get, url);

            var response = await _httpClient.SendAsync(request);

            switch ((int)response.StatusCode)
            {
                case 200:
                    {
                        using (var stream = await response.Content.ReadAsStreamAsync())
                        {
                            if (stream.Length == 0)
                                return default(TestRunTypeModel);

                            var result = await JsonSerializer.DeserializeAsync<TestRunTypeModel>(stream, _serializerOptions);
                            return result;
                        }
                    }

                default:
                    throw new InvalidOperationException($"Call Failed - {response.StatusCode}");
            }
        }

        public async Task<System.IO.Stream> ProductTestRunTypeGetStream(
            string productName,
            string testRunType)
        {
            string url = $"/api/product/{productName}/testRunType/{testRunType}";
            var request = new HttpRequestMessage(HttpMethod.Get, url);

            var response = await _httpClient.SendAsync(request);

            switch ((int)response.StatusCode)
            {
                case 200:
                    var stream = await response.Content.ReadAsStreamAsync();
                    return stream;

                default:
                    throw new InvalidOperationException($"Call Failed - {response.StatusCode}");
            }
        }

        public async Task ProductTestRunTypeDelete(
            string productName,
            string testRunType)
        {
            string url = $"/api/product/{productName}/testRunType/{testRunType}";
            var request = new HttpRequestMessage(HttpMethod.Delete, url);

            var response = await _httpClient.SendAsync(request);

            switch ((int)response.StatusCode)
            {
                case 204:
                    return;

                default:
                    throw new InvalidOperationException($"Call Failed - {response.StatusCode}");
            }
        }

        public async Task<string[]> ProductTestRunTypeComponents(
            string productName,
            string testRunType)
        {
            string url = $"/api/product/{productName}/testRunType/{testRunType}/components";
            var request = new HttpRequestMessage(HttpMethod.Get, url);

            var response = await _httpClient.SendAsync(request);

            switch ((int)response.StatusCode)
            {
                case 200:
                    {
                        using (var stream = await response.Content.ReadAsStreamAsync())
                        {
                            if (stream.Length == 0)
                                return default(string[]);

                            var result = await JsonSerializer.DeserializeAsync<string[]>(stream, _serializerOptions);
                            return result;
                        }
                    }

                default:
                    throw new InvalidOperationException($"Call Failed - {response.StatusCode}");
            }
        }

        public async Task<System.IO.Stream> ProductTestRunTypeComponentsStream(
            string productName,
            string testRunType)
        {
            string url = $"/api/product/{productName}/testRunType/{testRunType}/components";
            var request = new HttpRequestMessage(HttpMethod.Get, url);

            var response = await _httpClient.SendAsync(request);

            switch ((int)response.StatusCode)
            {
                case 200:
                    var stream = await response.Content.ReadAsStreamAsync();
                    return stream;

                default:
                    throw new InvalidOperationException($"Call Failed - {response.StatusCode}");
            }
        }

        public async Task<TestRunTypeModel> ProductCreateTestRunType(
            string productName,
            CreateTestRunTypeModel body)
        {
            string url = $"/api/product/{productName}/createTestRunType";
            var request = new HttpRequestMessage(HttpMethod.Post, url);
            var serializerOptions = new System.Text.Json.JsonSerializerOptions();
            serializerOptions.Converters.Add(new System.Text.Json.Serialization.JsonStringEnumConverter(JsonNamingPolicy.CamelCase));
            request.Content = System.Net.Http.Json.JsonContent.Create<CreateTestRunTypeModel>(body, options: serializerOptions);

            var response = await _httpClient.SendAsync(request);

            switch ((int)response.StatusCode)
            {
                case 201:
                    {
                        using (var stream = await response.Content.ReadAsStreamAsync())
                        {
                            if (stream.Length == 0)
                                return default(TestRunTypeModel);

                            var result = await JsonSerializer.DeserializeAsync<TestRunTypeModel>(stream, _serializerOptions);
                            return result;
                        }
                    }

                default:
                    throw new InvalidOperationException($"Call Failed - {response.StatusCode}");
            }
        }

        public async Task<System.IO.Stream> ProductCreateTestRunTypeStream(
            string productName,
            CreateTestRunTypeModel body)
        {
            string url = $"/api/product/{productName}/createTestRunType";
            var request = new HttpRequestMessage(HttpMethod.Post, url);
            var serializerOptions = new System.Text.Json.JsonSerializerOptions();
            serializerOptions.Converters.Add(new System.Text.Json.Serialization.JsonStringEnumConverter(JsonNamingPolicy.CamelCase));
            request.Content = System.Net.Http.Json.JsonContent.Create<CreateTestRunTypeModel>(body, options: serializerOptions);

            var response = await _httpClient.SendAsync(request);

            switch ((int)response.StatusCode)
            {
                case 200:
                    var stream = await response.Content.ReadAsStreamAsync();
                    return stream;

                default:
                    throw new InvalidOperationException($"Call Failed - {response.StatusCode}");
            }
        }

        public async Task ProductTestRunTypeUpdateComponents(
            string productName,
            string testRunType,
            string[] body)
        {
            string url = $"/api/product/{productName}/testRunType/{testRunType}/updateComponents";
            var request = new HttpRequestMessage(HttpMethod.Post, url);
            var serializerOptions = new System.Text.Json.JsonSerializerOptions();
            serializerOptions.Converters.Add(new System.Text.Json.Serialization.JsonStringEnumConverter(JsonNamingPolicy.CamelCase));
            request.Content = System.Net.Http.Json.JsonContent.Create<string[]>(body, options: serializerOptions);

            var response = await _httpClient.SendAsync(request);

            switch ((int)response.StatusCode)
            {
                case 204:
                    return;

                default:
                    throw new InvalidOperationException($"Call Failed - {response.StatusCode}");
            }
        }

        public async Task<ValidateCanDeleteTestRunTypeModel> ProductTestRunTypeValidateCanDelete(
            string productName,
            string testRunType)
        {
            string url = $"/api/product/{productName}/testRunType/{testRunType}/validateCanDelete";
            var request = new HttpRequestMessage(HttpMethod.Post, url);

            var response = await _httpClient.SendAsync(request);

            switch ((int)response.StatusCode)
            {
                case 200:
                    {
                        using (var stream = await response.Content.ReadAsStreamAsync())
                        {
                            if (stream.Length == 0)
                                return default(ValidateCanDeleteTestRunTypeModel);

                            var result = await JsonSerializer.DeserializeAsync<ValidateCanDeleteTestRunTypeModel>(stream, _serializerOptions);
                            return result;
                        }
                    }

                default:
                    throw new InvalidOperationException($"Call Failed - {response.StatusCode}");
            }
        }

        public async Task<System.IO.Stream> ProductTestRunTypeValidateCanDeleteStream(
            string productName,
            string testRunType)
        {
            string url = $"/api/product/{productName}/testRunType/{testRunType}/validateCanDelete";
            var request = new HttpRequestMessage(HttpMethod.Post, url);

            var response = await _httpClient.SendAsync(request);

            switch ((int)response.StatusCode)
            {
                case 200:
                    var stream = await response.Content.ReadAsStreamAsync();
                    return stream;

                default:
                    throw new InvalidOperationException($"Call Failed - {response.StatusCode}");
            }
        }

        public async Task<ImageDetailsModel> ProductDefaultTestRunTypeImageDetails(
            string productName)
        {
            string url = $"/api/product/{productName}/defaultTestRunTypeImageDetails";
            var request = new HttpRequestMessage(HttpMethod.Get, url);

            var response = await _httpClient.SendAsync(request);

            switch ((int)response.StatusCode)
            {
                case 200:
                    {
                        using (var stream = await response.Content.ReadAsStreamAsync())
                        {
                            if (stream.Length == 0)
                                return default(ImageDetailsModel);

                            var result = await JsonSerializer.DeserializeAsync<ImageDetailsModel>(stream, _serializerOptions);
                            return result;
                        }
                    }

                default:
                    throw new InvalidOperationException($"Call Failed - {response.StatusCode}");
            }
        }

        public async Task<System.IO.Stream> ProductDefaultTestRunTypeImageDetailsStream(
            string productName)
        {
            string url = $"/api/product/{productName}/defaultTestRunTypeImageDetails";
            var request = new HttpRequestMessage(HttpMethod.Get, url);

            var response = await _httpClient.SendAsync(request);

            switch ((int)response.StatusCode)
            {
                case 200:
                    var stream = await response.Content.ReadAsStreamAsync();
                    return stream;

                default:
                    throw new InvalidOperationException($"Call Failed - {response.StatusCode}");
            }
        }

        public async Task<byte[]> ProductDefaultTestRunTypeImageGet(
            string productName)
        {
            string url = $"/api/product/{productName}/defaultTestRunTypeImage";
            var request = new HttpRequestMessage(HttpMethod.Get, url);

            var response = await _httpClient.SendAsync(request);

            switch ((int)response.StatusCode)
            {
                case 200:
                    {
                        using (var stream = await response.Content.ReadAsStreamAsync())
                        {
                            if (stream.Length == 0)
                                return default(byte[]);

                            var buffer = new byte[stream.Length];
                            using (var memoryStream = new System.IO.MemoryStream(buffer))
                                await stream.CopyToAsync(memoryStream);

                            return buffer;
                        }
                    }

                default:
                    throw new InvalidOperationException($"Call Failed - {response.StatusCode}");
            }
        }

        public async Task<System.IO.Stream> ProductDefaultTestRunTypeImageGetStream(
            string productName)
        {
            string url = $"/api/product/{productName}/defaultTestRunTypeImage";
            var request = new HttpRequestMessage(HttpMethod.Get, url);

            var response = await _httpClient.SendAsync(request);

            switch ((int)response.StatusCode)
            {
                case 200:
                    var stream = await response.Content.ReadAsStreamAsync();
                    return stream;

                default:
                    throw new InvalidOperationException($"Call Failed - {response.StatusCode}");
            }
        }

        public async Task ProductDefaultTestRunTypeImagePut(
            string productName,
            byte[] image,
            string imageFileName,
            string imageContentType)
        {
            string url = $"/api/product/{productName}/defaultTestRunTypeImage";
            var request = new HttpRequestMessage(HttpMethod.Put, url);
            {
                var mpfdContent = new System.Net.Http.MultipartFormDataContent();
                {
                    var bac = new System.Net.Http.ByteArrayContent(image);
                    if (!string.IsNullOrEmpty(imageContentType))
                        bac.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue(imageContentType);
                    mpfdContent.Add(bac, "image", imageFileName);
                }
                request.Content = mpfdContent;
            }

            var response = await _httpClient.SendAsync(request);

            switch ((int)response.StatusCode)
            {
                case 204:
                    return;

                default:
                    throw new InvalidOperationException($"Call Failed - {response.StatusCode}");
            }
        }

        public async Task ProductDefaultTestRunTypeImageDelete(
            string productName)
        {
            string url = $"/api/product/{productName}/defaultTestRunTypeImage";
            var request = new HttpRequestMessage(HttpMethod.Delete, url);

            var response = await _httpClient.SendAsync(request);

            switch ((int)response.StatusCode)
            {
                case 204:
                    return;

                default:
                    throw new InvalidOperationException($"Call Failed - {response.StatusCode}");
            }
        }

        public async Task<byte[]> ProductTestRunTypeCustomImageGet(
            string productName,
            string testRunType)
        {
            string url = $"/api/product/{productName}/testRunType/{testRunType}/customImage";
            var request = new HttpRequestMessage(HttpMethod.Get, url);

            var response = await _httpClient.SendAsync(request);

            switch ((int)response.StatusCode)
            {
                case 200:
                    {
                        using (var stream = await response.Content.ReadAsStreamAsync())
                        {
                            if (stream.Length == 0)
                                return default(byte[]);

                            var buffer = new byte[stream.Length];
                            using (var memoryStream = new System.IO.MemoryStream(buffer))
                                await stream.CopyToAsync(memoryStream);

                            return buffer;
                        }
                    }

                default:
                    throw new InvalidOperationException($"Call Failed - {response.StatusCode}");
            }
        }

        public async Task<System.IO.Stream> ProductTestRunTypeCustomImageGetStream(
            string productName,
            string testRunType)
        {
            string url = $"/api/product/{productName}/testRunType/{testRunType}/customImage";
            var request = new HttpRequestMessage(HttpMethod.Get, url);

            var response = await _httpClient.SendAsync(request);

            switch ((int)response.StatusCode)
            {
                case 200:
                    var stream = await response.Content.ReadAsStreamAsync();
                    return stream;

                default:
                    throw new InvalidOperationException($"Call Failed - {response.StatusCode}");
            }
        }

        public async Task ProductTestRunTypeCustomImagePut(
            string productName,
            string testRunType,
            byte[] image,
            string imageFileName,
            string imageContentType)
        {
            string url = $"/api/product/{productName}/testRunType/{testRunType}/customImage";
            var request = new HttpRequestMessage(HttpMethod.Put, url);
            {
                var mpfdContent = new System.Net.Http.MultipartFormDataContent();
                {
                    var bac = new System.Net.Http.ByteArrayContent(image);
                    if (!string.IsNullOrEmpty(imageContentType))
                        bac.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue(imageContentType);
                    mpfdContent.Add(bac, "image", imageFileName);
                }
                request.Content = mpfdContent;
            }

            var response = await _httpClient.SendAsync(request);

            switch ((int)response.StatusCode)
            {
                case 204:
                    return;

                default:
                    throw new InvalidOperationException($"Call Failed - {response.StatusCode}");
            }
        }

        public async Task ProductTestRunTypeCustomImageDelete(
            string productName,
            string testRunType)
        {
            string url = $"/api/product/{productName}/testRunType/{testRunType}/customImage";
            var request = new HttpRequestMessage(HttpMethod.Delete, url);

            var response = await _httpClient.SendAsync(request);

            switch ((int)response.StatusCode)
            {
                case 204:
                    return;

                default:
                    throw new InvalidOperationException($"Call Failed - {response.StatusCode}");
            }
        }

        public async Task<ImageDetailsModel> ProductTestRunTypeCustomImageDetails(
            string productName,
            string testRunType)
        {
            string url = $"/api/product/{productName}/testRunType/{testRunType}/customImageDetails";
            var request = new HttpRequestMessage(HttpMethod.Get, url);

            var response = await _httpClient.SendAsync(request);

            switch ((int)response.StatusCode)
            {
                case 200:
                    {
                        using (var stream = await response.Content.ReadAsStreamAsync())
                        {
                            if (stream.Length == 0)
                                return default(ImageDetailsModel);

                            var result = await JsonSerializer.DeserializeAsync<ImageDetailsModel>(stream, _serializerOptions);
                            return result;
                        }
                    }

                default:
                    throw new InvalidOperationException($"Call Failed - {response.StatusCode}");
            }
        }

        public async Task<System.IO.Stream> ProductTestRunTypeCustomImageDetailsStream(
            string productName,
            string testRunType)
        {
            string url = $"/api/product/{productName}/testRunType/{testRunType}/customImageDetails";
            var request = new HttpRequestMessage(HttpMethod.Get, url);

            var response = await _httpClient.SendAsync(request);

            switch ((int)response.StatusCode)
            {
                case 200:
                    var stream = await response.Content.ReadAsStreamAsync();
                    return stream;

                default:
                    throw new InvalidOperationException($"Call Failed - {response.StatusCode}");
            }
        }

        public async Task ProductEmptyRecycleBin(
            string productName)
        {
            string url = $"/api/product/{productName}/emptyRecycleBin";
            var request = new HttpRequestMessage(HttpMethod.Post, url);

            var response = await _httpClient.SendAsync(request);

            switch ((int)response.StatusCode)
            {
                case 204:
                    return;

                default:
                    throw new InvalidOperationException($"Call Failed - {response.StatusCode}");
            }
        }

        public async Task<ProductAuditModel> ProductAuditTrail(
            string productName)
        {
            string url = $"/api/product/{productName}/AuditTrail";
            var request = new HttpRequestMessage(HttpMethod.Get, url);

            var response = await _httpClient.SendAsync(request);

            switch ((int)response.StatusCode)
            {
                case 200:
                    {
                        using (var stream = await response.Content.ReadAsStreamAsync())
                        {
                            if (stream.Length == 0)
                                return default(ProductAuditModel);

                            var result = await JsonSerializer.DeserializeAsync<ProductAuditModel>(stream, _serializerOptions);
                            return result;
                        }
                    }

                default:
                    throw new InvalidOperationException($"Call Failed - {response.StatusCode}");
            }
        }

        public async Task<System.IO.Stream> ProductAuditTrailStream(
            string productName)
        {
            string url = $"/api/product/{productName}/AuditTrail";
            var request = new HttpRequestMessage(HttpMethod.Get, url);

            var response = await _httpClient.SendAsync(request);

            switch ((int)response.StatusCode)
            {
                case 200:
                    var stream = await response.Content.ReadAsStreamAsync();
                    return stream;

                default:
                    throw new InvalidOperationException($"Call Failed - {response.StatusCode}");
            }
        }

        public async Task<ValidateRenameProductModel> ProductValidateRename(
            string productName,
            string newName,
            bool keepOldNameAsAlias)
        {
            string url = $"/api/product/{productName}/validateRename";
            {
                var qsh = new QueryStringHelper(url);
                qsh.RegisterQueryParameter("newName", newName);
                qsh.RegisterQueryParameter("keepOldNameAsAlias", keepOldNameAsAlias);
                url = qsh.GenerateFullUri();
            }
            var request = new HttpRequestMessage(HttpMethod.Post, url);

            var response = await _httpClient.SendAsync(request);

            switch ((int)response.StatusCode)
            {
                case 200:
                    {
                        using (var stream = await response.Content.ReadAsStreamAsync())
                        {
                            if (stream.Length == 0)
                                return default(ValidateRenameProductModel);

                            var result = await JsonSerializer.DeserializeAsync<ValidateRenameProductModel>(stream, _serializerOptions);
                            return result;
                        }
                    }

                default:
                    throw new InvalidOperationException($"Call Failed - {response.StatusCode}");
            }
        }

        public async Task<System.IO.Stream> ProductValidateRenameStream(
            string productName,
            string newName,
            bool keepOldNameAsAlias)
        {
            string url = $"/api/product/{productName}/validateRename";
            {
                var qsh = new QueryStringHelper(url);
                qsh.RegisterQueryParameter("newName", newName);
                qsh.RegisterQueryParameter("keepOldNameAsAlias", keepOldNameAsAlias);
                url = qsh.GenerateFullUri();
            }
            var request = new HttpRequestMessage(HttpMethod.Post, url);

            var response = await _httpClient.SendAsync(request);

            switch ((int)response.StatusCode)
            {
                case 200:
                    var stream = await response.Content.ReadAsStreamAsync();
                    return stream;

                default:
                    throw new InvalidOperationException($"Call Failed - {response.StatusCode}");
            }
        }

        public async Task<ProductModel> ProductRename(
            string productName,
            string newName,
            bool keepOldNameAsAlias)
        {
            string url = $"/api/product/{productName}/rename";
            {
                var qsh = new QueryStringHelper(url);
                qsh.RegisterQueryParameter("newName", newName);
                qsh.RegisterQueryParameter("keepOldNameAsAlias", keepOldNameAsAlias);
                url = qsh.GenerateFullUri();
            }
            var request = new HttpRequestMessage(HttpMethod.Post, url);

            var response = await _httpClient.SendAsync(request);

            switch ((int)response.StatusCode)
            {
                case 200:
                    {
                        using (var stream = await response.Content.ReadAsStreamAsync())
                        {
                            if (stream.Length == 0)
                                return default(ProductModel);

                            var result = await JsonSerializer.DeserializeAsync<ProductModel>(stream, _serializerOptions);
                            return result;
                        }
                    }

                default:
                    throw new InvalidOperationException($"Call Failed - {response.StatusCode}");
            }
        }

        public async Task<System.IO.Stream> ProductRenameStream(
            string productName,
            string newName,
            bool keepOldNameAsAlias)
        {
            string url = $"/api/product/{productName}/rename";
            {
                var qsh = new QueryStringHelper(url);
                qsh.RegisterQueryParameter("newName", newName);
                qsh.RegisterQueryParameter("keepOldNameAsAlias", keepOldNameAsAlias);
                url = qsh.GenerateFullUri();
            }
            var request = new HttpRequestMessage(HttpMethod.Post, url);

            var response = await _httpClient.SendAsync(request);

            switch ((int)response.StatusCode)
            {
                case 200:
                    var stream = await response.Content.ReadAsStreamAsync();
                    return stream;

                default:
                    throw new InvalidOperationException($"Call Failed - {response.StatusCode}");
            }
        }

        public async Task<ValidateUpdateProductAliasesModel> ProductValidateUpdateAliases(
            string productName,
            UpdateProductAliasesModel body)
        {
            string url = $"/api/product/{productName}/validateUpdateAliases";
            var request = new HttpRequestMessage(HttpMethod.Post, url);
            var serializerOptions = new System.Text.Json.JsonSerializerOptions();
            serializerOptions.Converters.Add(new System.Text.Json.Serialization.JsonStringEnumConverter(JsonNamingPolicy.CamelCase));
            request.Content = System.Net.Http.Json.JsonContent.Create<UpdateProductAliasesModel>(body, options: serializerOptions);

            var response = await _httpClient.SendAsync(request);

            switch ((int)response.StatusCode)
            {
                case 200:
                    {
                        using (var stream = await response.Content.ReadAsStreamAsync())
                        {
                            if (stream.Length == 0)
                                return default(ValidateUpdateProductAliasesModel);

                            var result = await JsonSerializer.DeserializeAsync<ValidateUpdateProductAliasesModel>(stream, _serializerOptions);
                            return result;
                        }
                    }

                default:
                    throw new InvalidOperationException($"Call Failed - {response.StatusCode}");
            }
        }

        public async Task<System.IO.Stream> ProductValidateUpdateAliasesStream(
            string productName,
            UpdateProductAliasesModel body)
        {
            string url = $"/api/product/{productName}/validateUpdateAliases";
            var request = new HttpRequestMessage(HttpMethod.Post, url);
            var serializerOptions = new System.Text.Json.JsonSerializerOptions();
            serializerOptions.Converters.Add(new System.Text.Json.Serialization.JsonStringEnumConverter(JsonNamingPolicy.CamelCase));
            request.Content = System.Net.Http.Json.JsonContent.Create<UpdateProductAliasesModel>(body, options: serializerOptions);

            var response = await _httpClient.SendAsync(request);

            switch ((int)response.StatusCode)
            {
                case 200:
                    var stream = await response.Content.ReadAsStreamAsync();
                    return stream;

                default:
                    throw new InvalidOperationException($"Call Failed - {response.StatusCode}");
            }
        }

        public async Task<ProductModel> ProductUpdateAliases(
            string productName,
            UpdateProductAliasesModel body)
        {
            string url = $"/api/product/{productName}/updateAliases";
            var request = new HttpRequestMessage(HttpMethod.Post, url);
            var serializerOptions = new System.Text.Json.JsonSerializerOptions();
            serializerOptions.Converters.Add(new System.Text.Json.Serialization.JsonStringEnumConverter(JsonNamingPolicy.CamelCase));
            request.Content = System.Net.Http.Json.JsonContent.Create<UpdateProductAliasesModel>(body, options: serializerOptions);

            var response = await _httpClient.SendAsync(request);

            switch ((int)response.StatusCode)
            {
                case 200:
                    {
                        using (var stream = await response.Content.ReadAsStreamAsync())
                        {
                            if (stream.Length == 0)
                                return default(ProductModel);

                            var result = await JsonSerializer.DeserializeAsync<ProductModel>(stream, _serializerOptions);
                            return result;
                        }
                    }

                default:
                    throw new InvalidOperationException($"Call Failed - {response.StatusCode}");
            }
        }

        public async Task<System.IO.Stream> ProductUpdateAliasesStream(
            string productName,
            UpdateProductAliasesModel body)
        {
            string url = $"/api/product/{productName}/updateAliases";
            var request = new HttpRequestMessage(HttpMethod.Post, url);
            var serializerOptions = new System.Text.Json.JsonSerializerOptions();
            serializerOptions.Converters.Add(new System.Text.Json.Serialization.JsonStringEnumConverter(JsonNamingPolicy.CamelCase));
            request.Content = System.Net.Http.Json.JsonContent.Create<UpdateProductAliasesModel>(body, options: serializerOptions);

            var response = await _httpClient.SendAsync(request);

            switch ((int)response.StatusCode)
            {
                case 200:
                    var stream = await response.Content.ReadAsStreamAsync();
                    return stream;

                default:
                    throw new InvalidOperationException($"Call Failed - {response.StatusCode}");
            }
        }

        public async Task ProductUpdateStatus(
            string productName,
            ProductStatus status)
        {
            string url = $"/api/product/{productName}/updateStatus";
            {
                var qsh = new QueryStringHelper(url);
                qsh.RegisterQueryParameter("status", status);
                url = qsh.GenerateFullUri();
            }
            var request = new HttpRequestMessage(HttpMethod.Post, url);

            var response = await _httpClient.SendAsync(request);

            switch ((int)response.StatusCode)
            {
                case 204:
                    return;

                default:
                    throw new InvalidOperationException($"Call Failed - {response.StatusCode}");
            }
        }

        public async Task ProductObliterate(
            string productName)
        {
            string url = $"/api/product/{productName}/obliterate";
            var request = new HttpRequestMessage(HttpMethod.Delete, url);

            var response = await _httpClient.SendAsync(request);

            switch ((int)response.StatusCode)
            {
                case 204:
                    return;

                default:
                    throw new InvalidOperationException($"Call Failed - {response.StatusCode}");
            }
        }

        public async Task<byte[]> ProductImageGet(
            string productName)
        {
            string url = $"/api/product/{productName}/image";
            var request = new HttpRequestMessage(HttpMethod.Get, url);

            var response = await _httpClient.SendAsync(request);

            switch ((int)response.StatusCode)
            {
                case 200:
                    {
                        using (var stream = await response.Content.ReadAsStreamAsync())
                        {
                            if (stream.Length == 0)
                                return default(byte[]);

                            var buffer = new byte[stream.Length];
                            using (var memoryStream = new System.IO.MemoryStream(buffer))
                                await stream.CopyToAsync(memoryStream);

                            return buffer;
                        }
                    }

                default:
                    throw new InvalidOperationException($"Call Failed - {response.StatusCode}");
            }
        }

        public async Task<System.IO.Stream> ProductImageGetStream(
            string productName)
        {
            string url = $"/api/product/{productName}/image";
            var request = new HttpRequestMessage(HttpMethod.Get, url);

            var response = await _httpClient.SendAsync(request);

            switch ((int)response.StatusCode)
            {
                case 200:
                    var stream = await response.Content.ReadAsStreamAsync();
                    return stream;

                default:
                    throw new InvalidOperationException($"Call Failed - {response.StatusCode}");
            }
        }

        public async Task ProductImagePut(
            string productName,
            byte[] additionalFile,
            string additionalFileFileName,
            string additionalFileContentType)
        {
            string url = $"/api/product/{productName}/image";
            var request = new HttpRequestMessage(HttpMethod.Put, url);
            {
                var mpfdContent = new System.Net.Http.MultipartFormDataContent();
                {
                    var bac = new System.Net.Http.ByteArrayContent(additionalFile);
                    if (!string.IsNullOrEmpty(additionalFileContentType))
                        bac.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue(additionalFileContentType);
                    mpfdContent.Add(bac, "additionalFile", additionalFileFileName);
                }
                request.Content = mpfdContent;
            }

            var response = await _httpClient.SendAsync(request);

            switch ((int)response.StatusCode)
            {
                case 204:
                    return;

                default:
                    throw new InvalidOperationException($"Call Failed - {response.StatusCode}");
            }
        }

        public async Task ProductImageDelete(
            string productName)
        {
            string url = $"/api/product/{productName}/image";
            var request = new HttpRequestMessage(HttpMethod.Delete, url);

            var response = await _httpClient.SendAsync(request);

            switch ((int)response.StatusCode)
            {
                case 204:
                    return;

                default:
                    throw new InvalidOperationException($"Call Failed - {response.StatusCode}");
            }
        }

        public async Task<string> ProductLandingPageGet(
            string productName)
        {
            string url = $"/api/product/{productName}/landingPage";
            var request = new HttpRequestMessage(HttpMethod.Get, url);

            var response = await _httpClient.SendAsync(request);

            switch ((int)response.StatusCode)
            {
                case 200:
                    {
                        var result = await response.Content.ReadAsStringAsync();
                        return result;
                    }

                default:
                    throw new InvalidOperationException($"Call Failed - {response.StatusCode}");
            }
        }

        public async Task<System.IO.Stream> ProductLandingPageGetStream(
            string productName)
        {
            string url = $"/api/product/{productName}/landingPage";
            var request = new HttpRequestMessage(HttpMethod.Get, url);

            var response = await _httpClient.SendAsync(request);

            switch ((int)response.StatusCode)
            {
                case 200:
                    var stream = await response.Content.ReadAsStreamAsync();
                    return stream;

                default:
                    throw new InvalidOperationException($"Call Failed - {response.StatusCode}");
            }
        }

        public async Task ProductLandingPagePut(
            string productName,
            string body)
        {
            string url = $"/api/product/{productName}/landingPage";
            var request = new HttpRequestMessage(HttpMethod.Put, url);
            var serializerOptions = new System.Text.Json.JsonSerializerOptions();
            serializerOptions.Converters.Add(new System.Text.Json.Serialization.JsonStringEnumConverter(JsonNamingPolicy.CamelCase));
            request.Content = System.Net.Http.Json.JsonContent.Create<string>(body, options: serializerOptions);

            var response = await _httpClient.SendAsync(request);

            switch ((int)response.StatusCode)
            {
                case 204:
                    return;

                default:
                    throw new InvalidOperationException($"Call Failed - {response.StatusCode}");
            }
        }

        public async Task ProductLandingPageDelete(
            string productName)
        {
            string url = $"/api/product/{productName}/landingPage";
            var request = new HttpRequestMessage(HttpMethod.Delete, url);

            var response = await _httpClient.SendAsync(request);

            switch ((int)response.StatusCode)
            {
                case 204:
                    return;

                default:
                    throw new InvalidOperationException($"Call Failed - {response.StatusCode}");
            }
        }

        public async Task<ResultsXmlTransformationSummaryModel[]> ProductResultsXmlTransformations(
            string productName)
        {
            string url = $"/api/product/{productName}/resultsXmlTransformations";
            var request = new HttpRequestMessage(HttpMethod.Get, url);

            var response = await _httpClient.SendAsync(request);

            switch ((int)response.StatusCode)
            {
                case 200:
                    {
                        using (var stream = await response.Content.ReadAsStreamAsync())
                        {
                            if (stream.Length == 0)
                                return default(ResultsXmlTransformationSummaryModel[]);

                            var result = await JsonSerializer.DeserializeAsync<ResultsXmlTransformationSummaryModel[]>(stream, _serializerOptions);
                            return result;
                        }
                    }

                default:
                    throw new InvalidOperationException($"Call Failed - {response.StatusCode}");
            }
        }

        public async Task<System.IO.Stream> ProductResultsXmlTransformationsStream(
            string productName)
        {
            string url = $"/api/product/{productName}/resultsXmlTransformations";
            var request = new HttpRequestMessage(HttpMethod.Get, url);

            var response = await _httpClient.SendAsync(request);

            switch ((int)response.StatusCode)
            {
                case 200:
                    var stream = await response.Content.ReadAsStreamAsync();
                    return stream;

                default:
                    throw new InvalidOperationException($"Call Failed - {response.StatusCode}");
            }
        }

        public async Task<string[]> ProductTestRunTypeResultsXmlTransformations(
            string productName,
            string testRunType)
        {
            string url = $"/api/product/{productName}/testRunType/{testRunType}/resultsXmlTransformations";
            var request = new HttpRequestMessage(HttpMethod.Get, url);

            var response = await _httpClient.SendAsync(request);

            switch ((int)response.StatusCode)
            {
                case 200:
                    {
                        using (var stream = await response.Content.ReadAsStreamAsync())
                        {
                            if (stream.Length == 0)
                                return default(string[]);

                            var result = await JsonSerializer.DeserializeAsync<string[]>(stream, _serializerOptions);
                            return result;
                        }
                    }

                default:
                    throw new InvalidOperationException($"Call Failed - {response.StatusCode}");
            }
        }

        public async Task<System.IO.Stream> ProductTestRunTypeResultsXmlTransformationsStream(
            string productName,
            string testRunType)
        {
            string url = $"/api/product/{productName}/testRunType/{testRunType}/resultsXmlTransformations";
            var request = new HttpRequestMessage(HttpMethod.Get, url);

            var response = await _httpClient.SendAsync(request);

            switch ((int)response.StatusCode)
            {
                case 200:
                    var stream = await response.Content.ReadAsStreamAsync();
                    return stream;

                default:
                    throw new InvalidOperationException($"Call Failed - {response.StatusCode}");
            }
        }

        public async Task<ResultsXmlTransformationModel> ProductResultsXmlTransformationGet(
            string productName,
            string transformationName)
        {
            string url = $"/api/product/{productName}/resultsXmlTransformation/{transformationName}";
            var request = new HttpRequestMessage(HttpMethod.Get, url);

            var response = await _httpClient.SendAsync(request);

            switch ((int)response.StatusCode)
            {
                case 200:
                    {
                        using (var stream = await response.Content.ReadAsStreamAsync())
                        {
                            if (stream.Length == 0)
                                return default(ResultsXmlTransformationModel);

                            var result = await JsonSerializer.DeserializeAsync<ResultsXmlTransformationModel>(stream, _serializerOptions);
                            return result;
                        }
                    }

                default:
                    throw new InvalidOperationException($"Call Failed - {response.StatusCode}");
            }
        }

        public async Task<System.IO.Stream> ProductResultsXmlTransformationGetStream(
            string productName,
            string transformationName)
        {
            string url = $"/api/product/{productName}/resultsXmlTransformation/{transformationName}";
            var request = new HttpRequestMessage(HttpMethod.Get, url);

            var response = await _httpClient.SendAsync(request);

            switch ((int)response.StatusCode)
            {
                case 200:
                    var stream = await response.Content.ReadAsStreamAsync();
                    return stream;

                default:
                    throw new InvalidOperationException($"Call Failed - {response.StatusCode}");
            }
        }

        public async Task ProductResultsXmlTransformationDelete(
            string productName,
            string transformationName)
        {
            string url = $"/api/product/{productName}/resultsXmlTransformation/{transformationName}";
            var request = new HttpRequestMessage(HttpMethod.Delete, url);

            var response = await _httpClient.SendAsync(request);

            switch ((int)response.StatusCode)
            {
                case 204:
                    return;

                default:
                    throw new InvalidOperationException($"Call Failed - {response.StatusCode}");
            }
        }

        public async Task ProductResultsXmlTransformationPut(
            string productName,
            string transformationName,
            ResultsXmlTransformationModel body)
        {
            string url = $"/api/product/{productName}/resultsXmlTransformation/{transformationName}";
            var request = new HttpRequestMessage(HttpMethod.Put, url);
            var serializerOptions = new System.Text.Json.JsonSerializerOptions();
            serializerOptions.Converters.Add(new System.Text.Json.Serialization.JsonStringEnumConverter(JsonNamingPolicy.CamelCase));
            request.Content = System.Net.Http.Json.JsonContent.Create<ResultsXmlTransformationModel>(body, options: serializerOptions);

            var response = await _httpClient.SendAsync(request);

            switch ((int)response.StatusCode)
            {
                case 204:
                    return;

                default:
                    throw new InvalidOperationException($"Call Failed - {response.StatusCode}");
            }
        }

        public async Task ProductResultsXmlTransformationPatch(
            string productName,
            string transformationName,
            ResultsXmlTransformationModel body)
        {
            string url = $"/api/product/{productName}/resultsXmlTransformation/{transformationName}";
            var request = new HttpRequestMessage(new HttpMethod("PATCH"), url);
            var serializerOptions = new System.Text.Json.JsonSerializerOptions();
            serializerOptions.Converters.Add(new System.Text.Json.Serialization.JsonStringEnumConverter(JsonNamingPolicy.CamelCase));
            request.Content = System.Net.Http.Json.JsonContent.Create<ResultsXmlTransformationModel>(body, options: serializerOptions);

            var response = await _httpClient.SendAsync(request);

            switch ((int)response.StatusCode)
            {
                case 204:
                    return;

                default:
                    throw new InvalidOperationException($"Call Failed - {response.StatusCode}");
            }
        }

        public async Task<ValidateCreateProductModel> ProductsValidateCreateProduct(
            CreateProductModel body)
        {
            string url = $"/api/Products/ValidateCreateProduct";
            var request = new HttpRequestMessage(HttpMethod.Post, url);
            var serializerOptions = new System.Text.Json.JsonSerializerOptions();
            serializerOptions.Converters.Add(new System.Text.Json.Serialization.JsonStringEnumConverter(JsonNamingPolicy.CamelCase));
            request.Content = System.Net.Http.Json.JsonContent.Create<CreateProductModel>(body, options: serializerOptions);

            var response = await _httpClient.SendAsync(request);

            switch ((int)response.StatusCode)
            {
                case 200:
                    {
                        using (var stream = await response.Content.ReadAsStreamAsync())
                        {
                            if (stream.Length == 0)
                                return default(ValidateCreateProductModel);

                            var result = await JsonSerializer.DeserializeAsync<ValidateCreateProductModel>(stream, _serializerOptions);
                            return result;
                        }
                    }

                default:
                    throw new InvalidOperationException($"Call Failed - {response.StatusCode}");
            }
        }

        public async Task<System.IO.Stream> ProductsValidateCreateProductStream(
            CreateProductModel body)
        {
            string url = $"/api/Products/ValidateCreateProduct";
            var request = new HttpRequestMessage(HttpMethod.Post, url);
            var serializerOptions = new System.Text.Json.JsonSerializerOptions();
            serializerOptions.Converters.Add(new System.Text.Json.Serialization.JsonStringEnumConverter(JsonNamingPolicy.CamelCase));
            request.Content = System.Net.Http.Json.JsonContent.Create<CreateProductModel>(body, options: serializerOptions);

            var response = await _httpClient.SendAsync(request);

            switch ((int)response.StatusCode)
            {
                case 200:
                    var stream = await response.Content.ReadAsStreamAsync();
                    return stream;

                default:
                    throw new InvalidOperationException($"Call Failed - {response.StatusCode}");
            }
        }

        public async Task<ProductModel> ProductsCreateProduct(
            CreateProductModel body)
        {
            string url = $"/api/Products/CreateProduct";
            var request = new HttpRequestMessage(HttpMethod.Post, url);
            var serializerOptions = new System.Text.Json.JsonSerializerOptions();
            serializerOptions.Converters.Add(new System.Text.Json.Serialization.JsonStringEnumConverter(JsonNamingPolicy.CamelCase));
            request.Content = System.Net.Http.Json.JsonContent.Create<CreateProductModel>(body, options: serializerOptions);

            var response = await _httpClient.SendAsync(request);

            switch ((int)response.StatusCode)
            {
                case 201:
                    {
                        using (var stream = await response.Content.ReadAsStreamAsync())
                        {
                            if (stream.Length == 0)
                                return default(ProductModel);

                            var result = await JsonSerializer.DeserializeAsync<ProductModel>(stream, _serializerOptions);
                            return result;
                        }
                    }

                default:
                    throw new InvalidOperationException($"Call Failed - {response.StatusCode}");
            }
        }

        public async Task<System.IO.Stream> ProductsCreateProductStream(
            CreateProductModel body)
        {
            string url = $"/api/Products/CreateProduct";
            var request = new HttpRequestMessage(HttpMethod.Post, url);
            var serializerOptions = new System.Text.Json.JsonSerializerOptions();
            serializerOptions.Converters.Add(new System.Text.Json.Serialization.JsonStringEnumConverter(JsonNamingPolicy.CamelCase));
            request.Content = System.Net.Http.Json.JsonContent.Create<CreateProductModel>(body, options: serializerOptions);

            var response = await _httpClient.SendAsync(request);

            switch ((int)response.StatusCode)
            {
                case 200:
                    var stream = await response.Content.ReadAsStreamAsync();
                    return stream;

                default:
                    throw new InvalidOperationException($"Call Failed - {response.StatusCode}");
            }
        }

        public async Task<ProductModel[]> Products()
        {
            string url = $"/api/Products";
            var request = new HttpRequestMessage(HttpMethod.Get, url);

            var response = await _httpClient.SendAsync(request);

            switch ((int)response.StatusCode)
            {
                case 200:
                    {
                        using (var stream = await response.Content.ReadAsStreamAsync())
                        {
                            if (stream.Length == 0)
                                return default(ProductModel[]);

                            var result = await JsonSerializer.DeserializeAsync<ProductModel[]>(stream, _serializerOptions);
                            return result;
                        }
                    }

                default:
                    throw new InvalidOperationException($"Call Failed - {response.StatusCode}");
            }
        }

        public async Task<System.IO.Stream> ProductsStream()
        {
            string url = $"/api/Products";
            var request = new HttpRequestMessage(HttpMethod.Get, url);

            var response = await _httpClient.SendAsync(request);

            switch ((int)response.StatusCode)
            {
                case 200:
                    var stream = await response.Content.ReadAsStreamAsync();
                    return stream;

                default:
                    throw new InvalidOperationException($"Call Failed - {response.StatusCode}");
            }
        }

        public async Task<RoleModel> RoleGet(
            string roleName)
        {
            string url = $"/api/role/{roleName}";
            var request = new HttpRequestMessage(HttpMethod.Get, url);

            var response = await _httpClient.SendAsync(request);

            switch ((int)response.StatusCode)
            {
                case 200:
                    {
                        using (var stream = await response.Content.ReadAsStreamAsync())
                        {
                            if (stream.Length == 0)
                                return default(RoleModel);

                            var result = await JsonSerializer.DeserializeAsync<RoleModel>(stream, _serializerOptions);
                            return result;
                        }
                    }

                default:
                    throw new InvalidOperationException($"Call Failed - {response.StatusCode}");
            }
        }

        public async Task<System.IO.Stream> RoleGetStream(
            string roleName)
        {
            string url = $"/api/role/{roleName}";
            var request = new HttpRequestMessage(HttpMethod.Get, url);

            var response = await _httpClient.SendAsync(request);

            switch ((int)response.StatusCode)
            {
                case 200:
                    var stream = await response.Content.ReadAsStreamAsync();
                    return stream;

                default:
                    throw new InvalidOperationException($"Call Failed - {response.StatusCode}");
            }
        }

        public async Task RoleDelete(
            string roleName)
        {
            string url = $"/api/role/{roleName}";
            var request = new HttpRequestMessage(HttpMethod.Delete, url);

            var response = await _httpClient.SendAsync(request);

            switch ((int)response.StatusCode)
            {
                case 204:
                    return;

                default:
                    throw new InvalidOperationException($"Call Failed - {response.StatusCode}");
            }
        }

        public async Task<RoleModel> RoleUpdate(
            string roleName,
            UpdateRoleDetailsModel body)
        {
            string url = $"/api/role/{roleName}/update";
            var request = new HttpRequestMessage(HttpMethod.Post, url);
            var serializerOptions = new System.Text.Json.JsonSerializerOptions();
            serializerOptions.Converters.Add(new System.Text.Json.Serialization.JsonStringEnumConverter(JsonNamingPolicy.CamelCase));
            request.Content = System.Net.Http.Json.JsonContent.Create<UpdateRoleDetailsModel>(body, options: serializerOptions);

            var response = await _httpClient.SendAsync(request);

            switch ((int)response.StatusCode)
            {
                case 200:
                    {
                        using (var stream = await response.Content.ReadAsStreamAsync())
                        {
                            if (stream.Length == 0)
                                return default(RoleModel);

                            var result = await JsonSerializer.DeserializeAsync<RoleModel>(stream, _serializerOptions);
                            return result;
                        }
                    }

                default:
                    throw new InvalidOperationException($"Call Failed - {response.StatusCode}");
            }
        }

        public async Task<System.IO.Stream> RoleUpdateStream(
            string roleName,
            UpdateRoleDetailsModel body)
        {
            string url = $"/api/role/{roleName}/update";
            var request = new HttpRequestMessage(HttpMethod.Post, url);
            var serializerOptions = new System.Text.Json.JsonSerializerOptions();
            serializerOptions.Converters.Add(new System.Text.Json.Serialization.JsonStringEnumConverter(JsonNamingPolicy.CamelCase));
            request.Content = System.Net.Http.Json.JsonContent.Create<UpdateRoleDetailsModel>(body, options: serializerOptions);

            var response = await _httpClient.SendAsync(request);

            switch ((int)response.StatusCode)
            {
                case 200:
                    var stream = await response.Content.ReadAsStreamAsync();
                    return stream;

                default:
                    throw new InvalidOperationException($"Call Failed - {response.StatusCode}");
            }
        }

        public async Task<ValidateUpdateRoleDetailsModel> RoleValidateUpdate(
            string roleName,
            UpdateRoleDetailsModel body)
        {
            string url = $"/api/role/{roleName}/validateUpdate";
            var request = new HttpRequestMessage(HttpMethod.Post, url);
            var serializerOptions = new System.Text.Json.JsonSerializerOptions();
            serializerOptions.Converters.Add(new System.Text.Json.Serialization.JsonStringEnumConverter(JsonNamingPolicy.CamelCase));
            request.Content = System.Net.Http.Json.JsonContent.Create<UpdateRoleDetailsModel>(body, options: serializerOptions);

            var response = await _httpClient.SendAsync(request);

            switch ((int)response.StatusCode)
            {
                case 200:
                    {
                        using (var stream = await response.Content.ReadAsStreamAsync())
                        {
                            if (stream.Length == 0)
                                return default(ValidateUpdateRoleDetailsModel);

                            var result = await JsonSerializer.DeserializeAsync<ValidateUpdateRoleDetailsModel>(stream, _serializerOptions);
                            return result;
                        }
                    }

                default:
                    throw new InvalidOperationException($"Call Failed - {response.StatusCode}");
            }
        }

        public async Task<System.IO.Stream> RoleValidateUpdateStream(
            string roleName,
            UpdateRoleDetailsModel body)
        {
            string url = $"/api/role/{roleName}/validateUpdate";
            var request = new HttpRequestMessage(HttpMethod.Post, url);
            var serializerOptions = new System.Text.Json.JsonSerializerOptions();
            serializerOptions.Converters.Add(new System.Text.Json.Serialization.JsonStringEnumConverter(JsonNamingPolicy.CamelCase));
            request.Content = System.Net.Http.Json.JsonContent.Create<UpdateRoleDetailsModel>(body, options: serializerOptions);

            var response = await _httpClient.SendAsync(request);

            switch ((int)response.StatusCode)
            {
                case 200:
                    var stream = await response.Content.ReadAsStreamAsync();
                    return stream;

                default:
                    throw new InvalidOperationException($"Call Failed - {response.StatusCode}");
            }
        }

        public async Task<RoleModel[]> Roles()
        {
            string url = $"/api/roles";
            var request = new HttpRequestMessage(HttpMethod.Get, url);

            var response = await _httpClient.SendAsync(request);

            switch ((int)response.StatusCode)
            {
                case 200:
                    {
                        using (var stream = await response.Content.ReadAsStreamAsync())
                        {
                            if (stream.Length == 0)
                                return default(RoleModel[]);

                            var result = await JsonSerializer.DeserializeAsync<RoleModel[]>(stream, _serializerOptions);
                            return result;
                        }
                    }

                default:
                    throw new InvalidOperationException($"Call Failed - {response.StatusCode}");
            }
        }

        public async Task<System.IO.Stream> RolesStream()
        {
            string url = $"/api/roles";
            var request = new HttpRequestMessage(HttpMethod.Get, url);

            var response = await _httpClient.SendAsync(request);

            switch ((int)response.StatusCode)
            {
                case 200:
                    var stream = await response.Content.ReadAsStreamAsync();
                    return stream;

                default:
                    throw new InvalidOperationException($"Call Failed - {response.StatusCode}");
            }
        }

        public async Task<RoleModel[]> RolesSearch(
            string criteria)
        {
            string url = $"/api/roles/search";
            {
                var qsh = new QueryStringHelper(url);
                qsh.RegisterQueryParameter("criteria", criteria);
                url = qsh.GenerateFullUri();
            }
            var request = new HttpRequestMessage(HttpMethod.Post, url);

            var response = await _httpClient.SendAsync(request);

            switch ((int)response.StatusCode)
            {
                case 200:
                    {
                        using (var stream = await response.Content.ReadAsStreamAsync())
                        {
                            if (stream.Length == 0)
                                return default(RoleModel[]);

                            var result = await JsonSerializer.DeserializeAsync<RoleModel[]>(stream, _serializerOptions);
                            return result;
                        }
                    }

                default:
                    throw new InvalidOperationException($"Call Failed - {response.StatusCode}");
            }
        }

        public async Task<System.IO.Stream> RolesSearchStream(
            string criteria)
        {
            string url = $"/api/roles/search";
            {
                var qsh = new QueryStringHelper(url);
                qsh.RegisterQueryParameter("criteria", criteria);
                url = qsh.GenerateFullUri();
            }
            var request = new HttpRequestMessage(HttpMethod.Post, url);

            var response = await _httpClient.SendAsync(request);

            switch ((int)response.StatusCode)
            {
                case 200:
                    var stream = await response.Content.ReadAsStreamAsync();
                    return stream;

                default:
                    throw new InvalidOperationException($"Call Failed - {response.StatusCode}");
            }
        }

        public async Task<RoleModel> RolesCreate(
            CreateRoleModel body)
        {
            string url = $"/api/roles/create";
            var request = new HttpRequestMessage(HttpMethod.Post, url);
            var serializerOptions = new System.Text.Json.JsonSerializerOptions();
            serializerOptions.Converters.Add(new System.Text.Json.Serialization.JsonStringEnumConverter(JsonNamingPolicy.CamelCase));
            request.Content = System.Net.Http.Json.JsonContent.Create<CreateRoleModel>(body, options: serializerOptions);

            var response = await _httpClient.SendAsync(request);

            switch ((int)response.StatusCode)
            {
                case 201:
                    {
                        using (var stream = await response.Content.ReadAsStreamAsync())
                        {
                            if (stream.Length == 0)
                                return default(RoleModel);

                            var result = await JsonSerializer.DeserializeAsync<RoleModel>(stream, _serializerOptions);
                            return result;
                        }
                    }

                default:
                    throw new InvalidOperationException($"Call Failed - {response.StatusCode}");
            }
        }

        public async Task<System.IO.Stream> RolesCreateStream(
            CreateRoleModel body)
        {
            string url = $"/api/roles/create";
            var request = new HttpRequestMessage(HttpMethod.Post, url);
            var serializerOptions = new System.Text.Json.JsonSerializerOptions();
            serializerOptions.Converters.Add(new System.Text.Json.Serialization.JsonStringEnumConverter(JsonNamingPolicy.CamelCase));
            request.Content = System.Net.Http.Json.JsonContent.Create<CreateRoleModel>(body, options: serializerOptions);

            var response = await _httpClient.SendAsync(request);

            switch ((int)response.StatusCode)
            {
                case 200:
                    var stream = await response.Content.ReadAsStreamAsync();
                    return stream;

                default:
                    throw new InvalidOperationException($"Call Failed - {response.StatusCode}");
            }
        }

        public async Task<TestRunSetSearchResultsModel> SearchTestRunSet(
            SearchTestRunSetCriteriaModel body)
        {
            string url = $"/api/Search/TestRunSet";
            var request = new HttpRequestMessage(HttpMethod.Post, url);
            var serializerOptions = new System.Text.Json.JsonSerializerOptions();
            serializerOptions.Converters.Add(new System.Text.Json.Serialization.JsonStringEnumConverter(JsonNamingPolicy.CamelCase));
            request.Content = System.Net.Http.Json.JsonContent.Create<SearchTestRunSetCriteriaModel>(body, options: serializerOptions);

            var response = await _httpClient.SendAsync(request);

            switch ((int)response.StatusCode)
            {
                case 200:
                    {
                        using (var stream = await response.Content.ReadAsStreamAsync())
                        {
                            if (stream.Length == 0)
                                return default(TestRunSetSearchResultsModel);

                            var result = await JsonSerializer.DeserializeAsync<TestRunSetSearchResultsModel>(stream, _serializerOptions);
                            return result;
                        }
                    }

                default:
                    throw new InvalidOperationException($"Call Failed - {response.StatusCode}");
            }
        }

        public async Task<System.IO.Stream> SearchTestRunSetStream(
            SearchTestRunSetCriteriaModel body)
        {
            string url = $"/api/Search/TestRunSet";
            var request = new HttpRequestMessage(HttpMethod.Post, url);
            var serializerOptions = new System.Text.Json.JsonSerializerOptions();
            serializerOptions.Converters.Add(new System.Text.Json.Serialization.JsonStringEnumConverter(JsonNamingPolicy.CamelCase));
            request.Content = System.Net.Http.Json.JsonContent.Create<SearchTestRunSetCriteriaModel>(body, options: serializerOptions);

            var response = await _httpClient.SendAsync(request);

            switch ((int)response.StatusCode)
            {
                case 200:
                    var stream = await response.Content.ReadAsStreamAsync();
                    return stream;

                default:
                    throw new InvalidOperationException($"Call Failed - {response.StatusCode}");
            }
        }

        public async Task<TestRunModel> ProductTestRunSetTestRunSummary(
            string productName,
            int testRunSetID,
            int testRunID)
        {
            string url = $"/api/product/{productName}/TestRunSet/{testRunSetID}/TestRun/{testRunID}/summary";
            var request = new HttpRequestMessage(HttpMethod.Get, url);

            var response = await _httpClient.SendAsync(request);

            switch ((int)response.StatusCode)
            {
                case 200:
                    {
                        using (var stream = await response.Content.ReadAsStreamAsync())
                        {
                            if (stream.Length == 0)
                                return default(TestRunModel);

                            var result = await JsonSerializer.DeserializeAsync<TestRunModel>(stream, _serializerOptions);
                            return result;
                        }
                    }

                default:
                    throw new InvalidOperationException($"Call Failed - {response.StatusCode}");
            }
        }

        public async Task<System.IO.Stream> ProductTestRunSetTestRunSummaryStream(
            string productName,
            int testRunSetID,
            int testRunID)
        {
            string url = $"/api/product/{productName}/TestRunSet/{testRunSetID}/TestRun/{testRunID}/summary";
            var request = new HttpRequestMessage(HttpMethod.Get, url);

            var response = await _httpClient.SendAsync(request);

            switch ((int)response.StatusCode)
            {
                case 200:
                    var stream = await response.Content.ReadAsStreamAsync();
                    return stream;

                default:
                    throw new InvalidOperationException($"Call Failed - {response.StatusCode}");
            }
        }

        public async Task<TestRunResultsModel> ProductTestRunSetTestRunResultsXml(
            string productName,
            int testRunSetID,
            int testRunID)
        {
            string url = $"/api/product/{productName}/TestRunSet/{testRunSetID}/TestRun/{testRunID}/ResultsXml";
            var request = new HttpRequestMessage(HttpMethod.Get, url);

            var response = await _httpClient.SendAsync(request);

            switch ((int)response.StatusCode)
            {
                case 200:
                    {
                        using (var stream = await response.Content.ReadAsStreamAsync())
                        {
                            if (stream.Length == 0)
                                return default(TestRunResultsModel);

                            var result = await JsonSerializer.DeserializeAsync<TestRunResultsModel>(stream, _serializerOptions);
                            return result;
                        }
                    }

                default:
                    throw new InvalidOperationException($"Call Failed - {response.StatusCode}");
            }
        }

        public async Task<System.IO.Stream> ProductTestRunSetTestRunResultsXmlStream(
            string productName,
            int testRunSetID,
            int testRunID)
        {
            string url = $"/api/product/{productName}/TestRunSet/{testRunSetID}/TestRun/{testRunID}/ResultsXml";
            var request = new HttpRequestMessage(HttpMethod.Get, url);

            var response = await _httpClient.SendAsync(request);

            switch ((int)response.StatusCode)
            {
                case 200:
                    var stream = await response.Content.ReadAsStreamAsync();
                    return stream;

                default:
                    throw new InvalidOperationException($"Call Failed - {response.StatusCode}");
            }
        }

        public async Task<string> ProductTestRunSetTestRunResultsXmlRaw(
            string productName,
            int testRunSetID,
            int testRunID)
        {
            string url = $"/api/product/{productName}/TestRunSet/{testRunSetID}/TestRun/{testRunID}/ResultsXml/raw";
            var request = new HttpRequestMessage(HttpMethod.Get, url);

            var response = await _httpClient.SendAsync(request);

            switch ((int)response.StatusCode)
            {
                case 200:
                    {
                        var result = await response.Content.ReadAsStringAsync();
                        return result;
                    }

                default:
                    throw new InvalidOperationException($"Call Failed - {response.StatusCode}");
            }
        }

        public async Task<System.IO.Stream> ProductTestRunSetTestRunResultsXmlRawStream(
            string productName,
            int testRunSetID,
            int testRunID)
        {
            string url = $"/api/product/{productName}/TestRunSet/{testRunSetID}/TestRun/{testRunID}/ResultsXml/raw";
            var request = new HttpRequestMessage(HttpMethod.Get, url);

            var response = await _httpClient.SendAsync(request);

            switch ((int)response.StatusCode)
            {
                case 200:
                    var stream = await response.Content.ReadAsStreamAsync();
                    return stream;

                default:
                    throw new InvalidOperationException($"Call Failed - {response.StatusCode}");
            }
        }

        public async Task<TestRunResultsDetailsModel> ProductTestRunSetTestRunResultsXmlDetails(
            string productName,
            int testRunSetID,
            int testRunID)
        {
            string url = $"/api/product/{productName}/TestRunSet/{testRunSetID}/TestRun/{testRunID}/ResultsXml/details";
            var request = new HttpRequestMessage(HttpMethod.Get, url);

            var response = await _httpClient.SendAsync(request);

            switch ((int)response.StatusCode)
            {
                case 200:
                    {
                        using (var stream = await response.Content.ReadAsStreamAsync())
                        {
                            if (stream.Length == 0)
                                return default(TestRunResultsDetailsModel);

                            var result = await JsonSerializer.DeserializeAsync<TestRunResultsDetailsModel>(stream, _serializerOptions);
                            return result;
                        }
                    }

                default:
                    throw new InvalidOperationException($"Call Failed - {response.StatusCode}");
            }
        }

        public async Task<System.IO.Stream> ProductTestRunSetTestRunResultsXmlDetailsStream(
            string productName,
            int testRunSetID,
            int testRunID)
        {
            string url = $"/api/product/{productName}/TestRunSet/{testRunSetID}/TestRun/{testRunID}/ResultsXml/details";
            var request = new HttpRequestMessage(HttpMethod.Get, url);

            var response = await _httpClient.SendAsync(request);

            switch ((int)response.StatusCode)
            {
                case 200:
                    var stream = await response.Content.ReadAsStreamAsync();
                    return stream;

                default:
                    throw new InvalidOperationException($"Call Failed - {response.StatusCode}");
            }
        }

        public async Task<TestRunResultsModel> ProductTestRunSetTestRunResultsJson(
            string productName,
            int testRunSetID,
            int testRunID)
        {
            string url = $"/api/product/{productName}/TestRunSet/{testRunSetID}/TestRun/{testRunID}/ResultsJson";
            var request = new HttpRequestMessage(HttpMethod.Get, url);

            var response = await _httpClient.SendAsync(request);

            switch ((int)response.StatusCode)
            {
                case 200:
                    {
                        using (var stream = await response.Content.ReadAsStreamAsync())
                        {
                            if (stream.Length == 0)
                                return default(TestRunResultsModel);

                            var result = await JsonSerializer.DeserializeAsync<TestRunResultsModel>(stream, _serializerOptions);
                            return result;
                        }
                    }

                default:
                    throw new InvalidOperationException($"Call Failed - {response.StatusCode}");
            }
        }

        public async Task<System.IO.Stream> ProductTestRunSetTestRunResultsJsonStream(
            string productName,
            int testRunSetID,
            int testRunID)
        {
            string url = $"/api/product/{productName}/TestRunSet/{testRunSetID}/TestRun/{testRunID}/ResultsJson";
            var request = new HttpRequestMessage(HttpMethod.Get, url);

            var response = await _httpClient.SendAsync(request);

            switch ((int)response.StatusCode)
            {
                case 200:
                    var stream = await response.Content.ReadAsStreamAsync();
                    return stream;

                default:
                    throw new InvalidOperationException($"Call Failed - {response.StatusCode}");
            }
        }

        public async Task<string> ProductTestRunSetTestRunResultsJsonRaw(
            string productName,
            int testRunSetID,
            int testRunID)
        {
            string url = $"/api/product/{productName}/TestRunSet/{testRunSetID}/TestRun/{testRunID}/ResultsJson/raw";
            var request = new HttpRequestMessage(HttpMethod.Get, url);

            var response = await _httpClient.SendAsync(request);

            switch ((int)response.StatusCode)
            {
                case 200:
                    {
                        var result = await response.Content.ReadAsStringAsync();
                        return result;
                    }

                default:
                    throw new InvalidOperationException($"Call Failed - {response.StatusCode}");
            }
        }

        public async Task<System.IO.Stream> ProductTestRunSetTestRunResultsJsonRawStream(
            string productName,
            int testRunSetID,
            int testRunID)
        {
            string url = $"/api/product/{productName}/TestRunSet/{testRunSetID}/TestRun/{testRunID}/ResultsJson/raw";
            var request = new HttpRequestMessage(HttpMethod.Get, url);

            var response = await _httpClient.SendAsync(request);

            switch ((int)response.StatusCode)
            {
                case 200:
                    var stream = await response.Content.ReadAsStreamAsync();
                    return stream;

                default:
                    throw new InvalidOperationException($"Call Failed - {response.StatusCode}");
            }
        }

        public async Task<TestRunResultsDetailsModel> ProductTestRunSetTestRunResultsJsonDetails(
            string productName,
            int testRunSetID,
            int testRunID)
        {
            string url = $"/api/product/{productName}/TestRunSet/{testRunSetID}/TestRun/{testRunID}/ResultsJson/details";
            var request = new HttpRequestMessage(HttpMethod.Get, url);

            var response = await _httpClient.SendAsync(request);

            switch ((int)response.StatusCode)
            {
                case 200:
                    {
                        using (var stream = await response.Content.ReadAsStreamAsync())
                        {
                            if (stream.Length == 0)
                                return default(TestRunResultsDetailsModel);

                            var result = await JsonSerializer.DeserializeAsync<TestRunResultsDetailsModel>(stream, _serializerOptions);
                            return result;
                        }
                    }

                default:
                    throw new InvalidOperationException($"Call Failed - {response.StatusCode}");
            }
        }

        public async Task<System.IO.Stream> ProductTestRunSetTestRunResultsJsonDetailsStream(
            string productName,
            int testRunSetID,
            int testRunID)
        {
            string url = $"/api/product/{productName}/TestRunSet/{testRunSetID}/TestRun/{testRunID}/ResultsJson/details";
            var request = new HttpRequestMessage(HttpMethod.Get, url);

            var response = await _httpClient.SendAsync(request);

            switch ((int)response.StatusCode)
            {
                case 200:
                    var stream = await response.Content.ReadAsStreamAsync();
                    return stream;

                default:
                    throw new InvalidOperationException($"Call Failed - {response.StatusCode}");
            }
        }

        public async Task<TestRunResultsModel> ProductTestRunSetTestRunResultsText(
            string productName,
            int testRunSetID,
            int testRunID)
        {
            string url = $"/api/product/{productName}/TestRunSet/{testRunSetID}/TestRun/{testRunID}/ResultsText";
            var request = new HttpRequestMessage(HttpMethod.Get, url);

            var response = await _httpClient.SendAsync(request);

            switch ((int)response.StatusCode)
            {
                case 200:
                    {
                        using (var stream = await response.Content.ReadAsStreamAsync())
                        {
                            if (stream.Length == 0)
                                return default(TestRunResultsModel);

                            var result = await JsonSerializer.DeserializeAsync<TestRunResultsModel>(stream, _serializerOptions);
                            return result;
                        }
                    }

                default:
                    throw new InvalidOperationException($"Call Failed - {response.StatusCode}");
            }
        }

        public async Task<System.IO.Stream> ProductTestRunSetTestRunResultsTextStream(
            string productName,
            int testRunSetID,
            int testRunID)
        {
            string url = $"/api/product/{productName}/TestRunSet/{testRunSetID}/TestRun/{testRunID}/ResultsText";
            var request = new HttpRequestMessage(HttpMethod.Get, url);

            var response = await _httpClient.SendAsync(request);

            switch ((int)response.StatusCode)
            {
                case 200:
                    var stream = await response.Content.ReadAsStreamAsync();
                    return stream;

                default:
                    throw new InvalidOperationException($"Call Failed - {response.StatusCode}");
            }
        }

        public async Task<string> ProductTestRunSetTestRunResultsTextRaw(
            string productName,
            int testRunSetID,
            int testRunID)
        {
            string url = $"/api/product/{productName}/TestRunSet/{testRunSetID}/TestRun/{testRunID}/ResultsText/Raw";
            var request = new HttpRequestMessage(HttpMethod.Get, url);

            var response = await _httpClient.SendAsync(request);

            switch ((int)response.StatusCode)
            {
                case 200:
                    {
                        var result = await response.Content.ReadAsStringAsync();
                        return result;
                    }

                default:
                    throw new InvalidOperationException($"Call Failed - {response.StatusCode}");
            }
        }

        public async Task<System.IO.Stream> ProductTestRunSetTestRunResultsTextRawStream(
            string productName,
            int testRunSetID,
            int testRunID)
        {
            string url = $"/api/product/{productName}/TestRunSet/{testRunSetID}/TestRun/{testRunID}/ResultsText/Raw";
            var request = new HttpRequestMessage(HttpMethod.Get, url);

            var response = await _httpClient.SendAsync(request);

            switch ((int)response.StatusCode)
            {
                case 200:
                    var stream = await response.Content.ReadAsStreamAsync();
                    return stream;

                default:
                    throw new InvalidOperationException($"Call Failed - {response.StatusCode}");
            }
        }

        public async Task<TestRunResultsTextLinesModel> ProductTestRunSetTestRunResultsTextLines(
            string productName,
            int testRunSetID,
            int testRunID)
        {
            string url = $"/api/product/{productName}/TestRunSet/{testRunSetID}/TestRun/{testRunID}/ResultsText/Lines";
            var request = new HttpRequestMessage(HttpMethod.Get, url);

            var response = await _httpClient.SendAsync(request);

            switch ((int)response.StatusCode)
            {
                case 200:
                    {
                        using (var stream = await response.Content.ReadAsStreamAsync())
                        {
                            if (stream.Length == 0)
                                return default(TestRunResultsTextLinesModel);

                            var result = await JsonSerializer.DeserializeAsync<TestRunResultsTextLinesModel>(stream, _serializerOptions);
                            return result;
                        }
                    }

                default:
                    throw new InvalidOperationException($"Call Failed - {response.StatusCode}");
            }
        }

        public async Task<System.IO.Stream> ProductTestRunSetTestRunResultsTextLinesStream(
            string productName,
            int testRunSetID,
            int testRunID)
        {
            string url = $"/api/product/{productName}/TestRunSet/{testRunSetID}/TestRun/{testRunID}/ResultsText/Lines";
            var request = new HttpRequestMessage(HttpMethod.Get, url);

            var response = await _httpClient.SendAsync(request);

            switch ((int)response.StatusCode)
            {
                case 200:
                    var stream = await response.Content.ReadAsStreamAsync();
                    return stream;

                default:
                    throw new InvalidOperationException($"Call Failed - {response.StatusCode}");
            }
        }

        public async Task<TestRunResultsDetailsModel> ProductTestRunSetTestRunResultsTextDetails(
            string productName,
            int testRunSetID,
            int testRunID)
        {
            string url = $"/api/product/{productName}/TestRunSet/{testRunSetID}/TestRun/{testRunID}/ResultsText/details";
            var request = new HttpRequestMessage(HttpMethod.Get, url);

            var response = await _httpClient.SendAsync(request);

            switch ((int)response.StatusCode)
            {
                case 200:
                    {
                        using (var stream = await response.Content.ReadAsStreamAsync())
                        {
                            if (stream.Length == 0)
                                return default(TestRunResultsDetailsModel);

                            var result = await JsonSerializer.DeserializeAsync<TestRunResultsDetailsModel>(stream, _serializerOptions);
                            return result;
                        }
                    }

                default:
                    throw new InvalidOperationException($"Call Failed - {response.StatusCode}");
            }
        }

        public async Task<System.IO.Stream> ProductTestRunSetTestRunResultsTextDetailsStream(
            string productName,
            int testRunSetID,
            int testRunID)
        {
            string url = $"/api/product/{productName}/TestRunSet/{testRunSetID}/TestRun/{testRunID}/ResultsText/details";
            var request = new HttpRequestMessage(HttpMethod.Get, url);

            var response = await _httpClient.SendAsync(request);

            switch ((int)response.StatusCode)
            {
                case 200:
                    var stream = await response.Content.ReadAsStreamAsync();
                    return stream;

                default:
                    throw new InvalidOperationException($"Call Failed - {response.StatusCode}");
            }
        }

        public async Task<TestRunResultsXsvDetailsModel> ProductTestRunSetTestRunResultsXsvDetails(
            string productName,
            int testRunSetID,
            int testRunID,
            XsvStyle xsvStyle)
        {
            string url = $"/api/product/{productName}/TestRunSet/{testRunSetID}/TestRun/{testRunID}/ResultsXsv/details";
            {
                var qsh = new QueryStringHelper(url);
                qsh.RegisterQueryParameter("xsvStyle", xsvStyle);
                url = qsh.GenerateFullUri();
            }
            var request = new HttpRequestMessage(HttpMethod.Get, url);

            var response = await _httpClient.SendAsync(request);

            switch ((int)response.StatusCode)
            {
                case 200:
                    {
                        using (var stream = await response.Content.ReadAsStreamAsync())
                        {
                            if (stream.Length == 0)
                                return default(TestRunResultsXsvDetailsModel);

                            var result = await JsonSerializer.DeserializeAsync<TestRunResultsXsvDetailsModel>(stream, _serializerOptions);
                            return result;
                        }
                    }

                default:
                    throw new InvalidOperationException($"Call Failed - {response.StatusCode}");
            }
        }

        public async Task<System.IO.Stream> ProductTestRunSetTestRunResultsXsvDetailsStream(
            string productName,
            int testRunSetID,
            int testRunID,
            XsvStyle xsvStyle)
        {
            string url = $"/api/product/{productName}/TestRunSet/{testRunSetID}/TestRun/{testRunID}/ResultsXsv/details";
            {
                var qsh = new QueryStringHelper(url);
                qsh.RegisterQueryParameter("xsvStyle", xsvStyle);
                url = qsh.GenerateFullUri();
            }
            var request = new HttpRequestMessage(HttpMethod.Get, url);

            var response = await _httpClient.SendAsync(request);

            switch ((int)response.StatusCode)
            {
                case 200:
                    var stream = await response.Content.ReadAsStreamAsync();
                    return stream;

                default:
                    throw new InvalidOperationException($"Call Failed - {response.StatusCode}");
            }
        }

        public async Task<string> ProductTestRunSetTestRunResultsXsvRaw(
            string productName,
            int testRunSetID,
            int testRunID,
            XsvStyle xsvStyle)
        {
            string url = $"/api/product/{productName}/TestRunSet/{testRunSetID}/TestRun/{testRunID}/ResultsXsv/raw";
            {
                var qsh = new QueryStringHelper(url);
                qsh.RegisterQueryParameter("xsvStyle", xsvStyle);
                url = qsh.GenerateFullUri();
            }
            var request = new HttpRequestMessage(HttpMethod.Get, url);

            var response = await _httpClient.SendAsync(request);

            switch ((int)response.StatusCode)
            {
                case 200:
                    {
                        var result = await response.Content.ReadAsStringAsync();
                        return result;
                    }

                default:
                    throw new InvalidOperationException($"Call Failed - {response.StatusCode}");
            }
        }

        public async Task<System.IO.Stream> ProductTestRunSetTestRunResultsXsvRawStream(
            string productName,
            int testRunSetID,
            int testRunID,
            XsvStyle xsvStyle)
        {
            string url = $"/api/product/{productName}/TestRunSet/{testRunSetID}/TestRun/{testRunID}/ResultsXsv/raw";
            {
                var qsh = new QueryStringHelper(url);
                qsh.RegisterQueryParameter("xsvStyle", xsvStyle);
                url = qsh.GenerateFullUri();
            }
            var request = new HttpRequestMessage(HttpMethod.Get, url);

            var response = await _httpClient.SendAsync(request);

            switch ((int)response.StatusCode)
            {
                case 200:
                    var stream = await response.Content.ReadAsStreamAsync();
                    return stream;

                default:
                    throw new InvalidOperationException($"Call Failed - {response.StatusCode}");
            }
        }

        public async Task<string[]> ProductTestRunSetTestRunResultsXsvLines(
            string productName,
            int testRunSetID,
            int testRunID,
            XsvStyle xsvStyle,
            int? minRow,
            int? maxRow)
        {
            string url = $"/api/product/{productName}/TestRunSet/{testRunSetID}/TestRun/{testRunID}/ResultsXsv/lines";
            {
                var qsh = new QueryStringHelper(url);
                qsh.RegisterQueryParameter("xsvStyle", xsvStyle);
                qsh.RegisterQueryParameter("minRow", minRow);
                qsh.RegisterQueryParameter("maxRow", maxRow);
                url = qsh.GenerateFullUri();
            }
            var request = new HttpRequestMessage(HttpMethod.Get, url);

            var response = await _httpClient.SendAsync(request);

            switch ((int)response.StatusCode)
            {
                case 200:
                    {
                        using (var stream = await response.Content.ReadAsStreamAsync())
                        {
                            if (stream.Length == 0)
                                return default(string[]);

                            var result = await JsonSerializer.DeserializeAsync<string[]>(stream, _serializerOptions);
                            return result;
                        }
                    }

                default:
                    throw new InvalidOperationException($"Call Failed - {response.StatusCode}");
            }
        }

        public async Task<System.IO.Stream> ProductTestRunSetTestRunResultsXsvLinesStream(
            string productName,
            int testRunSetID,
            int testRunID,
            XsvStyle xsvStyle,
            int? minRow,
            int? maxRow)
        {
            string url = $"/api/product/{productName}/TestRunSet/{testRunSetID}/TestRun/{testRunID}/ResultsXsv/lines";
            {
                var qsh = new QueryStringHelper(url);
                qsh.RegisterQueryParameter("xsvStyle", xsvStyle);
                qsh.RegisterQueryParameter("minRow", minRow);
                qsh.RegisterQueryParameter("maxRow", maxRow);
                url = qsh.GenerateFullUri();
            }
            var request = new HttpRequestMessage(HttpMethod.Get, url);

            var response = await _httpClient.SendAsync(request);

            switch ((int)response.StatusCode)
            {
                case 200:
                    var stream = await response.Content.ReadAsStreamAsync();
                    return stream;

                default:
                    throw new InvalidOperationException($"Call Failed - {response.StatusCode}");
            }
        }

        public async Task<LogSummaryModel> ProductTestRunSetTestRunLogsSummary(
            string productName,
            int testRunSetID,
            int testRunID)
        {
            string url = $"/api/product/{productName}/TestRunSet/{testRunSetID}/TestRun/{testRunID}/Logs/Summary";
            var request = new HttpRequestMessage(HttpMethod.Get, url);

            var response = await _httpClient.SendAsync(request);

            switch ((int)response.StatusCode)
            {
                case 200:
                    {
                        using (var stream = await response.Content.ReadAsStreamAsync())
                        {
                            if (stream.Length == 0)
                                return default(LogSummaryModel);

                            var result = await JsonSerializer.DeserializeAsync<LogSummaryModel>(stream, _serializerOptions);
                            return result;
                        }
                    }

                default:
                    throw new InvalidOperationException($"Call Failed - {response.StatusCode}");
            }
        }

        public async Task<System.IO.Stream> ProductTestRunSetTestRunLogsSummaryStream(
            string productName,
            int testRunSetID,
            int testRunID)
        {
            string url = $"/api/product/{productName}/TestRunSet/{testRunSetID}/TestRun/{testRunID}/Logs/Summary";
            var request = new HttpRequestMessage(HttpMethod.Get, url);

            var response = await _httpClient.SendAsync(request);

            switch ((int)response.StatusCode)
            {
                case 200:
                    var stream = await response.Content.ReadAsStreamAsync();
                    return stream;

                default:
                    throw new InvalidOperationException($"Call Failed - {response.StatusCode}");
            }
        }

        public async Task<LogMessagesModel> ProductTestRunSetTestRunLogsMessages(
            string productName,
            int testRunSetID,
            int testRunID)
        {
            string url = $"/api/product/{productName}/TestRunSet/{testRunSetID}/TestRun/{testRunID}/Logs/Messages";
            var request = new HttpRequestMessage(HttpMethod.Get, url);

            var response = await _httpClient.SendAsync(request);

            switch ((int)response.StatusCode)
            {
                case 200:
                    {
                        using (var stream = await response.Content.ReadAsStreamAsync())
                        {
                            if (stream.Length == 0)
                                return default(LogMessagesModel);

                            var result = await JsonSerializer.DeserializeAsync<LogMessagesModel>(stream, _serializerOptions);
                            return result;
                        }
                    }

                default:
                    throw new InvalidOperationException($"Call Failed - {response.StatusCode}");
            }
        }

        public async Task<System.IO.Stream> ProductTestRunSetTestRunLogsMessagesStream(
            string productName,
            int testRunSetID,
            int testRunID)
        {
            string url = $"/api/product/{productName}/TestRunSet/{testRunSetID}/TestRun/{testRunID}/Logs/Messages";
            var request = new HttpRequestMessage(HttpMethod.Get, url);

            var response = await _httpClient.SendAsync(request);

            switch ((int)response.StatusCode)
            {
                case 200:
                    var stream = await response.Content.ReadAsStreamAsync();
                    return stream;

                default:
                    throw new InvalidOperationException($"Call Failed - {response.StatusCode}");
            }
        }

        public async Task<string> ProductTestRunSetTestRunLogsRaw(
            string productName,
            int testRunSetID,
            int testRunID)
        {
            string url = $"/api/product/{productName}/TestRunSet/{testRunSetID}/TestRun/{testRunID}/Logs/Raw";
            var request = new HttpRequestMessage(HttpMethod.Get, url);

            var response = await _httpClient.SendAsync(request);

            switch ((int)response.StatusCode)
            {
                case 200:
                    {
                        var result = await response.Content.ReadAsStringAsync();
                        return result;
                    }

                default:
                    throw new InvalidOperationException($"Call Failed - {response.StatusCode}");
            }
        }

        public async Task<System.IO.Stream> ProductTestRunSetTestRunLogsRawStream(
            string productName,
            int testRunSetID,
            int testRunID)
        {
            string url = $"/api/product/{productName}/TestRunSet/{testRunSetID}/TestRun/{testRunID}/Logs/Raw";
            var request = new HttpRequestMessage(HttpMethod.Get, url);

            var response = await _httpClient.SendAsync(request);

            switch ((int)response.StatusCode)
            {
                case 200:
                    var stream = await response.Content.ReadAsStreamAsync();
                    return stream;

                default:
                    throw new InvalidOperationException($"Call Failed - {response.StatusCode}");
            }
        }

        public async Task<SimpleMemorySnapshotModel> ProductTestRunSetTestRunSimpleMemorySnapshot(
            string productName,
            int testRunSetID,
            int testRunID)
        {
            string url = $"/api/product/{productName}/TestRunSet/{testRunSetID}/TestRun/{testRunID}/SimpleMemorySnapshot";
            var request = new HttpRequestMessage(HttpMethod.Get, url);

            var response = await _httpClient.SendAsync(request);

            switch ((int)response.StatusCode)
            {
                case 200:
                    {
                        using (var stream = await response.Content.ReadAsStreamAsync())
                        {
                            if (stream.Length == 0)
                                return default(SimpleMemorySnapshotModel);

                            var result = await JsonSerializer.DeserializeAsync<SimpleMemorySnapshotModel>(stream, _serializerOptions);
                            return result;
                        }
                    }

                default:
                    throw new InvalidOperationException($"Call Failed - {response.StatusCode}");
            }
        }

        public async Task<System.IO.Stream> ProductTestRunSetTestRunSimpleMemorySnapshotStream(
            string productName,
            int testRunSetID,
            int testRunID)
        {
            string url = $"/api/product/{productName}/TestRunSet/{testRunSetID}/TestRun/{testRunID}/SimpleMemorySnapshot";
            var request = new HttpRequestMessage(HttpMethod.Get, url);

            var response = await _httpClient.SendAsync(request);

            switch ((int)response.StatusCode)
            {
                case 200:
                    var stream = await response.Content.ReadAsStreamAsync();
                    return stream;

                default:
                    throw new InvalidOperationException($"Call Failed - {response.StatusCode}");
            }
        }

        public async Task<TestRunAssemblyModel[]> ProductTestRunSetTestRunAssemblies(
            string productName,
            int testRunSetID,
            int testRunID)
        {
            string url = $"/api/product/{productName}/TestRunSet/{testRunSetID}/TestRun/{testRunID}/Assemblies";
            var request = new HttpRequestMessage(HttpMethod.Get, url);

            var response = await _httpClient.SendAsync(request);

            switch ((int)response.StatusCode)
            {
                case 200:
                    {
                        using (var stream = await response.Content.ReadAsStreamAsync())
                        {
                            if (stream.Length == 0)
                                return default(TestRunAssemblyModel[]);

                            var result = await JsonSerializer.DeserializeAsync<TestRunAssemblyModel[]>(stream, _serializerOptions);
                            return result;
                        }
                    }

                default:
                    throw new InvalidOperationException($"Call Failed - {response.StatusCode}");
            }
        }

        public async Task<System.IO.Stream> ProductTestRunSetTestRunAssembliesStream(
            string productName,
            int testRunSetID,
            int testRunID)
        {
            string url = $"/api/product/{productName}/TestRunSet/{testRunSetID}/TestRun/{testRunID}/Assemblies";
            var request = new HttpRequestMessage(HttpMethod.Get, url);

            var response = await _httpClient.SendAsync(request);

            switch ((int)response.StatusCode)
            {
                case 200:
                    var stream = await response.Content.ReadAsStreamAsync();
                    return stream;

                default:
                    throw new InvalidOperationException($"Call Failed - {response.StatusCode}");
            }
        }

        public async Task<AdditionalFileDetails[]> ProductTestRunSetTestRunAdditionalFiles(
            string productName,
            int testRunSetID,
            int testRunID)
        {
            string url = $"/api/product/{productName}/TestRunSet/{testRunSetID}/TestRun/{testRunID}/AdditionalFiles";
            var request = new HttpRequestMessage(HttpMethod.Get, url);

            var response = await _httpClient.SendAsync(request);

            switch ((int)response.StatusCode)
            {
                case 200:
                    {
                        using (var stream = await response.Content.ReadAsStreamAsync())
                        {
                            if (stream.Length == 0)
                                return default(AdditionalFileDetails[]);

                            var result = await JsonSerializer.DeserializeAsync<AdditionalFileDetails[]>(stream, _serializerOptions);
                            return result;
                        }
                    }

                default:
                    throw new InvalidOperationException($"Call Failed - {response.StatusCode}");
            }
        }

        public async Task<System.IO.Stream> ProductTestRunSetTestRunAdditionalFilesStream(
            string productName,
            int testRunSetID,
            int testRunID)
        {
            string url = $"/api/product/{productName}/TestRunSet/{testRunSetID}/TestRun/{testRunID}/AdditionalFiles";
            var request = new HttpRequestMessage(HttpMethod.Get, url);

            var response = await _httpClient.SendAsync(request);

            switch ((int)response.StatusCode)
            {
                case 200:
                    var stream = await response.Content.ReadAsStreamAsync();
                    return stream;

                default:
                    throw new InvalidOperationException($"Call Failed - {response.StatusCode}");
            }
        }

        public async Task<byte[]> ProductTestRunSetTestRunAdditionalFile(
            string productName,
            int testRunSetID,
            int testRunID,
            string fileName)
        {
            string url = $"/api/product/{productName}/TestRunSet/{testRunSetID}/TestRun/{testRunID}/AdditionalFile/{fileName}";
            var request = new HttpRequestMessage(HttpMethod.Get, url);

            var response = await _httpClient.SendAsync(request);

            switch ((int)response.StatusCode)
            {
                case 200:
                    {
                        using (var stream = await response.Content.ReadAsStreamAsync())
                        {
                            if (stream.Length == 0)
                                return default(byte[]);

                            var buffer = new byte[stream.Length];
                            using (var memoryStream = new System.IO.MemoryStream(buffer))
                                await stream.CopyToAsync(memoryStream);

                            return buffer;
                        }
                    }

                default:
                    throw new InvalidOperationException($"Call Failed - {response.StatusCode}");
            }
        }

        public async Task<System.IO.Stream> ProductTestRunSetTestRunAdditionalFileStream(
            string productName,
            int testRunSetID,
            int testRunID,
            string fileName)
        {
            string url = $"/api/product/{productName}/TestRunSet/{testRunSetID}/TestRun/{testRunID}/AdditionalFile/{fileName}";
            var request = new HttpRequestMessage(HttpMethod.Get, url);

            var response = await _httpClient.SendAsync(request);

            switch ((int)response.StatusCode)
            {
                case 200:
                    var stream = await response.Content.ReadAsStreamAsync();
                    return stream;

                default:
                    throw new InvalidOperationException($"Call Failed - {response.StatusCode}");
            }
        }

        public async Task<ExternalLink[]> ProductTestRunSetTestRunExternalLinks(
            string productName,
            int testRunSetID,
            int testRunID)
        {
            string url = $"/api/product/{productName}/TestRunSet/{testRunSetID}/TestRun/{testRunID}/externalLinks";
            var request = new HttpRequestMessage(HttpMethod.Get, url);

            var response = await _httpClient.SendAsync(request);

            switch ((int)response.StatusCode)
            {
                case 200:
                    {
                        using (var stream = await response.Content.ReadAsStreamAsync())
                        {
                            if (stream.Length == 0)
                                return default(ExternalLink[]);

                            var result = await JsonSerializer.DeserializeAsync<ExternalLink[]>(stream, _serializerOptions);
                            return result;
                        }
                    }

                default:
                    throw new InvalidOperationException($"Call Failed - {response.StatusCode}");
            }
        }

        public async Task<System.IO.Stream> ProductTestRunSetTestRunExternalLinksStream(
            string productName,
            int testRunSetID,
            int testRunID)
        {
            string url = $"/api/product/{productName}/TestRunSet/{testRunSetID}/TestRun/{testRunID}/externalLinks";
            var request = new HttpRequestMessage(HttpMethod.Get, url);

            var response = await _httpClient.SendAsync(request);

            switch ((int)response.StatusCode)
            {
                case 200:
                    var stream = await response.Content.ReadAsStreamAsync();
                    return stream;

                default:
                    throw new InvalidOperationException($"Call Failed - {response.StatusCode}");
            }
        }

        public async Task<TestRunSetSummaryModel> ProductTestRunSetSummary(
            string productName,
            int testRunSetID)
        {
            string url = $"/api/product/{productName}/TestRunSet/{testRunSetID}/Summary";
            var request = new HttpRequestMessage(HttpMethod.Get, url);

            var response = await _httpClient.SendAsync(request);

            switch ((int)response.StatusCode)
            {
                case 200:
                    {
                        using (var stream = await response.Content.ReadAsStreamAsync())
                        {
                            if (stream.Length == 0)
                                return default(TestRunSetSummaryModel);

                            var result = await JsonSerializer.DeserializeAsync<TestRunSetSummaryModel>(stream, _serializerOptions);
                            return result;
                        }
                    }

                default:
                    throw new InvalidOperationException($"Call Failed - {response.StatusCode}");
            }
        }

        public async Task<System.IO.Stream> ProductTestRunSetSummaryStream(
            string productName,
            int testRunSetID)
        {
            string url = $"/api/product/{productName}/TestRunSet/{testRunSetID}/Summary";
            var request = new HttpRequestMessage(HttpMethod.Get, url);

            var response = await _httpClient.SendAsync(request);

            switch ((int)response.StatusCode)
            {
                case 200:
                    var stream = await response.Content.ReadAsStreamAsync();
                    return stream;

                default:
                    throw new InvalidOperationException($"Call Failed - {response.StatusCode}");
            }
        }

        public async Task<TestRunModel[]> ProductTestRunSetTestRuns(
            string productName,
            int testRunSetID)
        {
            string url = $"/api/product/{productName}/TestRunSet/{testRunSetID}/TestRuns";
            var request = new HttpRequestMessage(HttpMethod.Get, url);

            var response = await _httpClient.SendAsync(request);

            switch ((int)response.StatusCode)
            {
                case 200:
                    {
                        using (var stream = await response.Content.ReadAsStreamAsync())
                        {
                            if (stream.Length == 0)
                                return default(TestRunModel[]);

                            var result = await JsonSerializer.DeserializeAsync<TestRunModel[]>(stream, _serializerOptions);
                            return result;
                        }
                    }

                default:
                    throw new InvalidOperationException($"Call Failed - {response.StatusCode}");
            }
        }

        public async Task<System.IO.Stream> ProductTestRunSetTestRunsStream(
            string productName,
            int testRunSetID)
        {
            string url = $"/api/product/{productName}/TestRunSet/{testRunSetID}/TestRuns";
            var request = new HttpRequestMessage(HttpMethod.Get, url);

            var response = await _httpClient.SendAsync(request);

            switch ((int)response.StatusCode)
            {
                case 200:
                    var stream = await response.Content.ReadAsStreamAsync();
                    return stream;

                default:
                    throw new InvalidOperationException($"Call Failed - {response.StatusCode}");
            }
        }

        public async Task<TestRunSetAuditModel> ProductTestRunSetAuditTrail(
            string productName,
            int testRunSetID)
        {
            string url = $"/api/product/{productName}/TestRunSet/{testRunSetID}/AuditTrail";
            var request = new HttpRequestMessage(HttpMethod.Get, url);

            var response = await _httpClient.SendAsync(request);

            switch ((int)response.StatusCode)
            {
                case 200:
                    {
                        using (var stream = await response.Content.ReadAsStreamAsync())
                        {
                            if (stream.Length == 0)
                                return default(TestRunSetAuditModel);

                            var result = await JsonSerializer.DeserializeAsync<TestRunSetAuditModel>(stream, _serializerOptions);
                            return result;
                        }
                    }

                default:
                    throw new InvalidOperationException($"Call Failed - {response.StatusCode}");
            }
        }

        public async Task<System.IO.Stream> ProductTestRunSetAuditTrailStream(
            string productName,
            int testRunSetID)
        {
            string url = $"/api/product/{productName}/TestRunSet/{testRunSetID}/AuditTrail";
            var request = new HttpRequestMessage(HttpMethod.Get, url);

            var response = await _httpClient.SendAsync(request);

            switch ((int)response.StatusCode)
            {
                case 200:
                    var stream = await response.Content.ReadAsStreamAsync();
                    return stream;

                default:
                    throw new InvalidOperationException($"Call Failed - {response.StatusCode}");
            }
        }

        public async Task ProductTestRunSetUpdateStatus(
            string productName,
            int testRunSetID,
            TestRunSetStatus status)
        {
            string url = $"/api/product/{productName}/TestRunSet/{testRunSetID}/UpdateStatus";
            {
                var qsh = new QueryStringHelper(url);
                qsh.RegisterQueryParameter("status", status);
                url = qsh.GenerateFullUri();
            }
            var request = new HttpRequestMessage(HttpMethod.Post, url);

            var response = await _httpClient.SendAsync(request);

            switch ((int)response.StatusCode)
            {
                case 204:
                    return;

                default:
                    throw new InvalidOperationException($"Call Failed - {response.StatusCode}");
            }
        }

        public async Task<AdditionalFileDetails[]> ProductTestRunSetAdditionalFiles(
            string productName,
            int testRunSetID)
        {
            string url = $"/api/product/{productName}/TestRunSet/{testRunSetID}/AdditionalFiles";
            var request = new HttpRequestMessage(HttpMethod.Get, url);

            var response = await _httpClient.SendAsync(request);

            switch ((int)response.StatusCode)
            {
                case 200:
                    {
                        using (var stream = await response.Content.ReadAsStreamAsync())
                        {
                            if (stream.Length == 0)
                                return default(AdditionalFileDetails[]);

                            var result = await JsonSerializer.DeserializeAsync<AdditionalFileDetails[]>(stream, _serializerOptions);
                            return result;
                        }
                    }

                default:
                    throw new InvalidOperationException($"Call Failed - {response.StatusCode}");
            }
        }

        public async Task<System.IO.Stream> ProductTestRunSetAdditionalFilesStream(
            string productName,
            int testRunSetID)
        {
            string url = $"/api/product/{productName}/TestRunSet/{testRunSetID}/AdditionalFiles";
            var request = new HttpRequestMessage(HttpMethod.Get, url);

            var response = await _httpClient.SendAsync(request);

            switch ((int)response.StatusCode)
            {
                case 200:
                    var stream = await response.Content.ReadAsStreamAsync();
                    return stream;

                default:
                    throw new InvalidOperationException($"Call Failed - {response.StatusCode}");
            }
        }

        public async Task<byte[]> ProductTestRunSetAdditionalFile(
            string productName,
            int testRunSetID,
            string fileName)
        {
            string url = $"/api/product/{productName}/TestRunSet/{testRunSetID}/AdditionalFile/{fileName}";
            var request = new HttpRequestMessage(HttpMethod.Get, url);

            var response = await _httpClient.SendAsync(request);

            switch ((int)response.StatusCode)
            {
                case 200:
                    {
                        using (var stream = await response.Content.ReadAsStreamAsync())
                        {
                            if (stream.Length == 0)
                                return default(byte[]);

                            var buffer = new byte[stream.Length];
                            using (var memoryStream = new System.IO.MemoryStream(buffer))
                                await stream.CopyToAsync(memoryStream);

                            return buffer;
                        }
                    }

                default:
                    throw new InvalidOperationException($"Call Failed - {response.StatusCode}");
            }
        }

        public async Task<System.IO.Stream> ProductTestRunSetAdditionalFileStream(
            string productName,
            int testRunSetID,
            string fileName)
        {
            string url = $"/api/product/{productName}/TestRunSet/{testRunSetID}/AdditionalFile/{fileName}";
            var request = new HttpRequestMessage(HttpMethod.Get, url);

            var response = await _httpClient.SendAsync(request);

            switch ((int)response.StatusCode)
            {
                case 200:
                    var stream = await response.Content.ReadAsStreamAsync();
                    return stream;

                default:
                    throw new InvalidOperationException($"Call Failed - {response.StatusCode}");
            }
        }

        public async Task<ExternalLink[]> ProductTestRunSetExternalLinks(
            string productName,
            int testRunSetID)
        {
            string url = $"/api/product/{productName}/TestRunSet/{testRunSetID}/externalLinks";
            var request = new HttpRequestMessage(HttpMethod.Get, url);

            var response = await _httpClient.SendAsync(request);

            switch ((int)response.StatusCode)
            {
                case 200:
                    {
                        using (var stream = await response.Content.ReadAsStreamAsync())
                        {
                            if (stream.Length == 0)
                                return default(ExternalLink[]);

                            var result = await JsonSerializer.DeserializeAsync<ExternalLink[]>(stream, _serializerOptions);
                            return result;
                        }
                    }

                default:
                    throw new InvalidOperationException($"Call Failed - {response.StatusCode}");
            }
        }

        public async Task<System.IO.Stream> ProductTestRunSetExternalLinksStream(
            string productName,
            int testRunSetID)
        {
            string url = $"/api/product/{productName}/TestRunSet/{testRunSetID}/externalLinks";
            var request = new HttpRequestMessage(HttpMethod.Get, url);

            var response = await _httpClient.SendAsync(request);

            switch ((int)response.StatusCode)
            {
                case 200:
                    var stream = await response.Content.ReadAsStreamAsync();
                    return stream;

                default:
                    throw new InvalidOperationException($"Call Failed - {response.StatusCode}");
            }
        }

        public async Task<CommentSummaryModel[]> ProductTestRunSetComments(
            string productName,
            int testRunSetID,
            int? parentID)
        {
            string url = $"/api/product/{productName}/TestRunSet/{testRunSetID}/Comments";
            {
                var qsh = new QueryStringHelper(url);
                qsh.RegisterQueryParameter("parentID", parentID);
                url = qsh.GenerateFullUri();
            }
            var request = new HttpRequestMessage(HttpMethod.Get, url);

            var response = await _httpClient.SendAsync(request);

            switch ((int)response.StatusCode)
            {
                case 200:
                    {
                        using (var stream = await response.Content.ReadAsStreamAsync())
                        {
                            if (stream.Length == 0)
                                return default(CommentSummaryModel[]);

                            var result = await JsonSerializer.DeserializeAsync<CommentSummaryModel[]>(stream, _serializerOptions);
                            return result;
                        }
                    }

                default:
                    throw new InvalidOperationException($"Call Failed - {response.StatusCode}");
            }
        }

        public async Task<System.IO.Stream> ProductTestRunSetCommentsStream(
            string productName,
            int testRunSetID,
            int? parentID)
        {
            string url = $"/api/product/{productName}/TestRunSet/{testRunSetID}/Comments";
            {
                var qsh = new QueryStringHelper(url);
                qsh.RegisterQueryParameter("parentID", parentID);
                url = qsh.GenerateFullUri();
            }
            var request = new HttpRequestMessage(HttpMethod.Get, url);

            var response = await _httpClient.SendAsync(request);

            switch ((int)response.StatusCode)
            {
                case 200:
                    var stream = await response.Content.ReadAsStreamAsync();
                    return stream;

                default:
                    throw new InvalidOperationException($"Call Failed - {response.StatusCode}");
            }
        }

        public async Task<CommentSummaryModel> ProductTestRunSetCommentGet(
            string productName,
            int testRunSetID,
            int commentID)
        {
            string url = $"/api/product/{productName}/TestRunSet/{testRunSetID}/comment/{commentID}";
            var request = new HttpRequestMessage(HttpMethod.Get, url);

            var response = await _httpClient.SendAsync(request);

            switch ((int)response.StatusCode)
            {
                case 200:
                    {
                        using (var stream = await response.Content.ReadAsStreamAsync())
                        {
                            if (stream.Length == 0)
                                return default(CommentSummaryModel);

                            var result = await JsonSerializer.DeserializeAsync<CommentSummaryModel>(stream, _serializerOptions);
                            return result;
                        }
                    }

                default:
                    throw new InvalidOperationException($"Call Failed - {response.StatusCode}");
            }
        }

        public async Task<System.IO.Stream> ProductTestRunSetCommentGetStream(
            string productName,
            int testRunSetID,
            int commentID)
        {
            string url = $"/api/product/{productName}/TestRunSet/{testRunSetID}/comment/{commentID}";
            var request = new HttpRequestMessage(HttpMethod.Get, url);

            var response = await _httpClient.SendAsync(request);

            switch ((int)response.StatusCode)
            {
                case 200:
                    var stream = await response.Content.ReadAsStreamAsync();
                    return stream;

                default:
                    throw new InvalidOperationException($"Call Failed - {response.StatusCode}");
            }
        }

        public async Task ProductTestRunSetCommentDelete(
            string productName,
            int testRunSetID,
            int commentID)
        {
            string url = $"/api/product/{productName}/TestRunSet/{testRunSetID}/comment/{commentID}";
            var request = new HttpRequestMessage(HttpMethod.Delete, url);

            var response = await _httpClient.SendAsync(request);

            switch ((int)response.StatusCode)
            {
                case 204:
                    return;

                default:
                    throw new InvalidOperationException($"Call Failed - {response.StatusCode}");
            }
        }

        public async Task<string> ProductTestRunSetCommentBody(
            string productName,
            int testRunSetID,
            int commentID)
        {
            string url = $"/api/product/{productName}/TestRunSet/{testRunSetID}/comment/{commentID}/body";
            var request = new HttpRequestMessage(HttpMethod.Get, url);

            var response = await _httpClient.SendAsync(request);

            switch ((int)response.StatusCode)
            {
                case 200:
                    {
                        var result = await response.Content.ReadAsStringAsync();
                        return result;
                    }

                default:
                    throw new InvalidOperationException($"Call Failed - {response.StatusCode}");
            }
        }

        public async Task<System.IO.Stream> ProductTestRunSetCommentBodyStream(
            string productName,
            int testRunSetID,
            int commentID)
        {
            string url = $"/api/product/{productName}/TestRunSet/{testRunSetID}/comment/{commentID}/body";
            var request = new HttpRequestMessage(HttpMethod.Get, url);

            var response = await _httpClient.SendAsync(request);

            switch ((int)response.StatusCode)
            {
                case 200:
                    var stream = await response.Content.ReadAsStreamAsync();
                    return stream;

                default:
                    throw new InvalidOperationException($"Call Failed - {response.StatusCode}");
            }
        }

        public async Task<CommentSummaryModel> ProductTestRunSetNewComment(
            string productName,
            int testRunSetID,
            string commentTitle,
            int? parentID,
            string body)
        {
            string url = $"/api/product/{productName}/TestRunSet/{testRunSetID}/newComment";
            {
                var qsh = new QueryStringHelper(url);
                qsh.RegisterQueryParameter("commentTitle", commentTitle);
                qsh.RegisterQueryParameter("parentID", parentID);
                url = qsh.GenerateFullUri();
            }
            var request = new HttpRequestMessage(HttpMethod.Post, url);
            var serializerOptions = new System.Text.Json.JsonSerializerOptions();
            serializerOptions.Converters.Add(new System.Text.Json.Serialization.JsonStringEnumConverter(JsonNamingPolicy.CamelCase));
            request.Content = System.Net.Http.Json.JsonContent.Create<string>(body, options: serializerOptions);

            var response = await _httpClient.SendAsync(request);

            switch ((int)response.StatusCode)
            {
                case 201:
                    {
                        using (var stream = await response.Content.ReadAsStreamAsync())
                        {
                            if (stream.Length == 0)
                                return default(CommentSummaryModel);

                            var result = await JsonSerializer.DeserializeAsync<CommentSummaryModel>(stream, _serializerOptions);
                            return result;
                        }
                    }

                default:
                    throw new InvalidOperationException($"Call Failed - {response.StatusCode}");
            }
        }

        public async Task<System.IO.Stream> ProductTestRunSetNewCommentStream(
            string productName,
            int testRunSetID,
            string commentTitle,
            int? parentID,
            string body)
        {
            string url = $"/api/product/{productName}/TestRunSet/{testRunSetID}/newComment";
            {
                var qsh = new QueryStringHelper(url);
                qsh.RegisterQueryParameter("commentTitle", commentTitle);
                qsh.RegisterQueryParameter("parentID", parentID);
                url = qsh.GenerateFullUri();
            }
            var request = new HttpRequestMessage(HttpMethod.Post, url);
            var serializerOptions = new System.Text.Json.JsonSerializerOptions();
            serializerOptions.Converters.Add(new System.Text.Json.Serialization.JsonStringEnumConverter(JsonNamingPolicy.CamelCase));
            request.Content = System.Net.Http.Json.JsonContent.Create<string>(body, options: serializerOptions);

            var response = await _httpClient.SendAsync(request);

            switch ((int)response.StatusCode)
            {
                case 200:
                    var stream = await response.Content.ReadAsStreamAsync();
                    return stream;

                default:
                    throw new InvalidOperationException($"Call Failed - {response.StatusCode}");
            }
        }

        public async Task<CommentSummaryModel> ProductTestRunSetCommentUpdate(
            string productName,
            int testRunSetID,
            int commentID,
            CommentUpdateModel body)
        {
            string url = $"/api/product/{productName}/TestRunSet/{testRunSetID}/comment/{commentID}/update";
            var request = new HttpRequestMessage(HttpMethod.Post, url);
            var serializerOptions = new System.Text.Json.JsonSerializerOptions();
            serializerOptions.Converters.Add(new System.Text.Json.Serialization.JsonStringEnumConverter(JsonNamingPolicy.CamelCase));
            request.Content = System.Net.Http.Json.JsonContent.Create<CommentUpdateModel>(body, options: serializerOptions);

            var response = await _httpClient.SendAsync(request);

            switch ((int)response.StatusCode)
            {
                case 200:
                    {
                        using (var stream = await response.Content.ReadAsStreamAsync())
                        {
                            if (stream.Length == 0)
                                return default(CommentSummaryModel);

                            var result = await JsonSerializer.DeserializeAsync<CommentSummaryModel>(stream, _serializerOptions);
                            return result;
                        }
                    }

                default:
                    throw new InvalidOperationException($"Call Failed - {response.StatusCode}");
            }
        }

        public async Task<System.IO.Stream> ProductTestRunSetCommentUpdateStream(
            string productName,
            int testRunSetID,
            int commentID,
            CommentUpdateModel body)
        {
            string url = $"/api/product/{productName}/TestRunSet/{testRunSetID}/comment/{commentID}/update";
            var request = new HttpRequestMessage(HttpMethod.Post, url);
            var serializerOptions = new System.Text.Json.JsonSerializerOptions();
            serializerOptions.Converters.Add(new System.Text.Json.Serialization.JsonStringEnumConverter(JsonNamingPolicy.CamelCase));
            request.Content = System.Net.Http.Json.JsonContent.Create<CommentUpdateModel>(body, options: serializerOptions);

            var response = await _httpClient.SendAsync(request);

            switch ((int)response.StatusCode)
            {
                case 200:
                    var stream = await response.Content.ReadAsStreamAsync();
                    return stream;

                default:
                    throw new InvalidOperationException($"Call Failed - {response.StatusCode}");
            }
        }

        public async Task<TestRunSetSummaryModel> UploadCreateTestRunSet(
            string product,
            string name,
            string description,
            System.DateTime refDate,
            System.DateTime runDate,
            string[] tags)
        {
            string url = $"/api/upload/CreateTestRunSet";
            {
                var qsh = new QueryStringHelper(url);
                qsh.RegisterQueryParameter("product", product);
                qsh.RegisterQueryParameter("name", name);
                qsh.RegisterQueryParameter("description", description);
                qsh.RegisterQueryParameter("refDate", refDate);
                qsh.RegisterQueryParameter("runDate", runDate);
                qsh.RegisterQueryParameter("tags", tags);
                url = qsh.GenerateFullUri();
            }
            var request = new HttpRequestMessage(HttpMethod.Post, url);

            var response = await _httpClient.SendAsync(request);

            switch ((int)response.StatusCode)
            {
                case 201:
                    {
                        using (var stream = await response.Content.ReadAsStreamAsync())
                        {
                            if (stream.Length == 0)
                                return default(TestRunSetSummaryModel);

                            var result = await JsonSerializer.DeserializeAsync<TestRunSetSummaryModel>(stream, _serializerOptions);
                            return result;
                        }
                    }

                default:
                    throw new InvalidOperationException($"Call Failed - {response.StatusCode}");
            }
        }

        public async Task<System.IO.Stream> UploadCreateTestRunSetStream(
            string product,
            string name,
            string description,
            System.DateTime refDate,
            System.DateTime runDate,
            string[] tags)
        {
            string url = $"/api/upload/CreateTestRunSet";
            {
                var qsh = new QueryStringHelper(url);
                qsh.RegisterQueryParameter("product", product);
                qsh.RegisterQueryParameter("name", name);
                qsh.RegisterQueryParameter("description", description);
                qsh.RegisterQueryParameter("refDate", refDate);
                qsh.RegisterQueryParameter("runDate", runDate);
                qsh.RegisterQueryParameter("tags", tags);
                url = qsh.GenerateFullUri();
            }
            var request = new HttpRequestMessage(HttpMethod.Post, url);

            var response = await _httpClient.SendAsync(request);

            switch ((int)response.StatusCode)
            {
                case 200:
                    var stream = await response.Content.ReadAsStreamAsync();
                    return stream;

                default:
                    throw new InvalidOperationException($"Call Failed - {response.StatusCode}");
            }
        }

        public async Task<TestRunIDModel> UploadCreateTestRun(
            string product,
            int? testRunSetID,
            string name,
            string description,
            string testRunType,
            TestStatus testStatus)
        {
            string url = $"/api/upload/CreateTestRun";
            {
                var qsh = new QueryStringHelper(url);
                qsh.RegisterQueryParameter("product", product);
                qsh.RegisterQueryParameter("testRunSetID", testRunSetID);
                qsh.RegisterQueryParameter("name", name);
                qsh.RegisterQueryParameter("description", description);
                qsh.RegisterQueryParameter("testRunType", testRunType);
                qsh.RegisterQueryParameter("testStatus", testStatus);
                url = qsh.GenerateFullUri();
            }
            var request = new HttpRequestMessage(HttpMethod.Post, url);

            var response = await _httpClient.SendAsync(request);

            switch ((int)response.StatusCode)
            {
                case 201:
                    {
                        using (var stream = await response.Content.ReadAsStreamAsync())
                        {
                            if (stream.Length == 0)
                                return default(TestRunIDModel);

                            var result = await JsonSerializer.DeserializeAsync<TestRunIDModel>(stream, _serializerOptions);
                            return result;
                        }
                    }

                default:
                    throw new InvalidOperationException($"Call Failed - {response.StatusCode}");
            }
        }

        public async Task<System.IO.Stream> UploadCreateTestRunStream(
            string product,
            int? testRunSetID,
            string name,
            string description,
            string testRunType,
            TestStatus testStatus)
        {
            string url = $"/api/upload/CreateTestRun";
            {
                var qsh = new QueryStringHelper(url);
                qsh.RegisterQueryParameter("product", product);
                qsh.RegisterQueryParameter("testRunSetID", testRunSetID);
                qsh.RegisterQueryParameter("name", name);
                qsh.RegisterQueryParameter("description", description);
                qsh.RegisterQueryParameter("testRunType", testRunType);
                qsh.RegisterQueryParameter("testStatus", testStatus);
                url = qsh.GenerateFullUri();
            }
            var request = new HttpRequestMessage(HttpMethod.Post, url);

            var response = await _httpClient.SendAsync(request);

            switch ((int)response.StatusCode)
            {
                case 200:
                    var stream = await response.Content.ReadAsStreamAsync();
                    return stream;

                default:
                    throw new InvalidOperationException($"Call Failed - {response.StatusCode}");
            }
        }

        public async Task UploadPublishTestRunResults(
            string product,
            int? testRunSetID,
            int? testRunID,
            TestRunResultTypes resultType,
            string body)
        {
            string url = $"/api/upload/PublishTestRunResults";
            {
                var qsh = new QueryStringHelper(url);
                qsh.RegisterQueryParameter("product", product);
                qsh.RegisterQueryParameter("testRunSetID", testRunSetID);
                qsh.RegisterQueryParameter("testRunID", testRunID);
                qsh.RegisterQueryParameter("resultType", resultType);
                url = qsh.GenerateFullUri();
            }
            var request = new HttpRequestMessage(HttpMethod.Post, url);
            var serializerOptions = new System.Text.Json.JsonSerializerOptions();
            serializerOptions.Converters.Add(new System.Text.Json.Serialization.JsonStringEnumConverter(JsonNamingPolicy.CamelCase));
            request.Content = System.Net.Http.Json.JsonContent.Create<string>(body, options: serializerOptions);

            var response = await _httpClient.SendAsync(request);

            switch ((int)response.StatusCode)
            {
                case 204:
                    return;

                default:
                    throw new InvalidOperationException($"Call Failed - {response.StatusCode}");
            }
        }

        public async Task UploadPublishTestRunSimpleMemorySnapshot(
            string product,
            int? testRunSetID,
            int? testRunID,
            SimpleMemorySnapshotModel body)
        {
            string url = $"/api/upload/PublishTestRunSimpleMemorySnapshot";
            {
                var qsh = new QueryStringHelper(url);
                qsh.RegisterQueryParameter("product", product);
                qsh.RegisterQueryParameter("testRunSetID", testRunSetID);
                qsh.RegisterQueryParameter("testRunID", testRunID);
                url = qsh.GenerateFullUri();
            }
            var request = new HttpRequestMessage(HttpMethod.Post, url);
            var serializerOptions = new System.Text.Json.JsonSerializerOptions();
            serializerOptions.Converters.Add(new System.Text.Json.Serialization.JsonStringEnumConverter(JsonNamingPolicy.CamelCase));
            request.Content = System.Net.Http.Json.JsonContent.Create<SimpleMemorySnapshotModel>(body, options: serializerOptions);

            var response = await _httpClient.SendAsync(request);

            switch ((int)response.StatusCode)
            {
                case 204:
                    return;

                default:
                    throw new InvalidOperationException($"Call Failed - {response.StatusCode}");
            }
        }

        public async Task UploadPublishTestRunAssemblies(
            string product,
            int? testRunSetID,
            int? testRunID,
            TestRunAssemblyModel[] body)
        {
            string url = $"/api/upload/PublishTestRunAssemblies";
            {
                var qsh = new QueryStringHelper(url);
                qsh.RegisterQueryParameter("product", product);
                qsh.RegisterQueryParameter("testRunSetID", testRunSetID);
                qsh.RegisterQueryParameter("testRunID", testRunID);
                url = qsh.GenerateFullUri();
            }
            var request = new HttpRequestMessage(HttpMethod.Post, url);
            var serializerOptions = new System.Text.Json.JsonSerializerOptions();
            serializerOptions.Converters.Add(new System.Text.Json.Serialization.JsonStringEnumConverter(JsonNamingPolicy.CamelCase));
            request.Content = System.Net.Http.Json.JsonContent.Create<TestRunAssemblyModel[]>(body, options: serializerOptions);

            var response = await _httpClient.SendAsync(request);

            switch ((int)response.StatusCode)
            {
                case 204:
                    return;

                default:
                    throw new InvalidOperationException($"Call Failed - {response.StatusCode}");
            }
        }

        public async Task UploadPublishTestRunXsvResults(
            string product,
            int? testRunSetID,
            int? testRunID,
            XsvStyle style,
            string body)
        {
            string url = $"/api/upload/PublishTestRunXsvResults";
            {
                var qsh = new QueryStringHelper(url);
                qsh.RegisterQueryParameter("product", product);
                qsh.RegisterQueryParameter("testRunSetID", testRunSetID);
                qsh.RegisterQueryParameter("testRunID", testRunID);
                qsh.RegisterQueryParameter("style", style);
                url = qsh.GenerateFullUri();
            }
            var request = new HttpRequestMessage(HttpMethod.Post, url);
            var serializerOptions = new System.Text.Json.JsonSerializerOptions();
            serializerOptions.Converters.Add(new System.Text.Json.Serialization.JsonStringEnumConverter(JsonNamingPolicy.CamelCase));
            request.Content = System.Net.Http.Json.JsonContent.Create<string>(body, options: serializerOptions);

            var response = await _httpClient.SendAsync(request);

            switch ((int)response.StatusCode)
            {
                case 204:
                    return;

                default:
                    throw new InvalidOperationException($"Call Failed - {response.StatusCode}");
            }
        }

        public async Task UploadPublishTestRunLogMessages(
            string product,
            int? testRunSetID,
            int? testRunID,
            string[] body)
        {
            string url = $"/api/upload/PublishTestRunLogMessages";
            {
                var qsh = new QueryStringHelper(url);
                qsh.RegisterQueryParameter("product", product);
                qsh.RegisterQueryParameter("testRunSetID", testRunSetID);
                qsh.RegisterQueryParameter("testRunID", testRunID);
                url = qsh.GenerateFullUri();
            }
            var request = new HttpRequestMessage(HttpMethod.Post, url);
            var serializerOptions = new System.Text.Json.JsonSerializerOptions();
            serializerOptions.Converters.Add(new System.Text.Json.Serialization.JsonStringEnumConverter(JsonNamingPolicy.CamelCase));
            request.Content = System.Net.Http.Json.JsonContent.Create<string[]>(body, options: serializerOptions);

            var response = await _httpClient.SendAsync(request);

            switch ((int)response.StatusCode)
            {
                case 204:
                    return;

                default:
                    throw new InvalidOperationException($"Call Failed - {response.StatusCode}");
            }
        }

        public async Task UploadPublishTestRunAdditionalFile(
            string product,
            int? testRunSetID,
            int? testRunID,
            string fileName,
            string description,
            byte[] additionalFile,
            string additionalFileFileName,
            string additionalFileContentType)
        {
            string url = $"/api/upload/PublishTestRunAdditionalFile";
            {
                var qsh = new QueryStringHelper(url);
                qsh.RegisterQueryParameter("product", product);
                qsh.RegisterQueryParameter("testRunSetID", testRunSetID);
                qsh.RegisterQueryParameter("testRunID", testRunID);
                qsh.RegisterQueryParameter("fileName", fileName);
                qsh.RegisterQueryParameter("description", description);
                url = qsh.GenerateFullUri();
            }
            var request = new HttpRequestMessage(HttpMethod.Post, url);
            {
                var mpfdContent = new System.Net.Http.MultipartFormDataContent();
                {
                    var bac = new System.Net.Http.ByteArrayContent(additionalFile);
                    if (!string.IsNullOrEmpty(additionalFileContentType))
                        bac.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue(additionalFileContentType);
                    mpfdContent.Add(bac, "additionalFile", additionalFileFileName);
                }
                request.Content = mpfdContent;
            }

            var response = await _httpClient.SendAsync(request);

            switch ((int)response.StatusCode)
            {
                case 204:
                    return;

                default:
                    throw new InvalidOperationException($"Call Failed - {response.StatusCode}");
            }
        }

        public async Task UploadPublishTestRunExternalLinks(
            string product,
            int? testRunSetID,
            int? testRunID,
            UploadExternalLinksModel body)
        {
            string url = $"/api/upload/PublishTestRunExternalLinks";
            {
                var qsh = new QueryStringHelper(url);
                qsh.RegisterQueryParameter("product", product);
                qsh.RegisterQueryParameter("testRunSetID", testRunSetID);
                qsh.RegisterQueryParameter("testRunID", testRunID);
                url = qsh.GenerateFullUri();
            }
            var request = new HttpRequestMessage(HttpMethod.Post, url);
            var serializerOptions = new System.Text.Json.JsonSerializerOptions();
            serializerOptions.Converters.Add(new System.Text.Json.Serialization.JsonStringEnumConverter(JsonNamingPolicy.CamelCase));
            request.Content = System.Net.Http.Json.JsonContent.Create<UploadExternalLinksModel>(body, options: serializerOptions);

            var response = await _httpClient.SendAsync(request);

            switch ((int)response.StatusCode)
            {
                case 204:
                    return;

                default:
                    throw new InvalidOperationException($"Call Failed - {response.StatusCode}");
            }
        }

        public async Task UploadPublishTestRunSetAdditionalFile(
            string product,
            int? testRunSetID,
            string fileName,
            string description,
            byte[] additionalFile,
            string additionalFileFileName,
            string additionalFileContentType)
        {
            string url = $"/api/upload/PublishTestRunSetAdditionalFile";
            {
                var qsh = new QueryStringHelper(url);
                qsh.RegisterQueryParameter("product", product);
                qsh.RegisterQueryParameter("testRunSetID", testRunSetID);
                qsh.RegisterQueryParameter("fileName", fileName);
                qsh.RegisterQueryParameter("description", description);
                url = qsh.GenerateFullUri();
            }
            var request = new HttpRequestMessage(HttpMethod.Post, url);
            {
                var mpfdContent = new System.Net.Http.MultipartFormDataContent();
                {
                    var bac = new System.Net.Http.ByteArrayContent(additionalFile);
                    if (!string.IsNullOrEmpty(additionalFileContentType))
                        bac.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue(additionalFileContentType);
                    mpfdContent.Add(bac, "additionalFile", additionalFileFileName);
                }
                request.Content = mpfdContent;
            }

            var response = await _httpClient.SendAsync(request);

            switch ((int)response.StatusCode)
            {
                case 204:
                    return;

                default:
                    throw new InvalidOperationException($"Call Failed - {response.StatusCode}");
            }
        }

        public async Task UploadPublishTestRunSetExternalLinks(
            string product,
            int? testRunSetID,
            UploadExternalLinksModel body)
        {
            string url = $"/api/upload/PublishTestRunSetExternalLinks";
            {
                var qsh = new QueryStringHelper(url);
                qsh.RegisterQueryParameter("product", product);
                qsh.RegisterQueryParameter("testRunSetID", testRunSetID);
                url = qsh.GenerateFullUri();
            }
            var request = new HttpRequestMessage(HttpMethod.Post, url);
            var serializerOptions = new System.Text.Json.JsonSerializerOptions();
            serializerOptions.Converters.Add(new System.Text.Json.Serialization.JsonStringEnumConverter(JsonNamingPolicy.CamelCase));
            request.Content = System.Net.Http.Json.JsonContent.Create<UploadExternalLinksModel>(body, options: serializerOptions);

            var response = await _httpClient.SendAsync(request);

            switch ((int)response.StatusCode)
            {
                case 204:
                    return;

                default:
                    throw new InvalidOperationException($"Call Failed - {response.StatusCode}");
            }
        }

        public async Task<UserSummaryModel> User(
            string userName)
        {
            string url = $"/api/user/{userName}";
            var request = new HttpRequestMessage(HttpMethod.Get, url);

            var response = await _httpClient.SendAsync(request);

            switch ((int)response.StatusCode)
            {
                case 200:
                    {
                        using (var stream = await response.Content.ReadAsStreamAsync())
                        {
                            if (stream.Length == 0)
                                return default(UserSummaryModel);

                            var result = await JsonSerializer.DeserializeAsync<UserSummaryModel>(stream, _serializerOptions);
                            return result;
                        }
                    }

                default:
                    throw new InvalidOperationException($"Call Failed - {response.StatusCode}");
            }
        }

        public async Task<System.IO.Stream> UserStream(
            string userName)
        {
            string url = $"/api/user/{userName}";
            var request = new HttpRequestMessage(HttpMethod.Get, url);

            var response = await _httpClient.SendAsync(request);

            switch ((int)response.StatusCode)
            {
                case 200:
                    var stream = await response.Content.ReadAsStreamAsync();
                    return stream;

                default:
                    throw new InvalidOperationException($"Call Failed - {response.StatusCode}");
            }
        }

        public async Task<SitePrivilege[]> UserEffectiveSitePrivileges(
            string userName)
        {
            string url = $"/api/user/{userName}/effectiveSitePrivileges";
            var request = new HttpRequestMessage(HttpMethod.Get, url);

            var response = await _httpClient.SendAsync(request);

            switch ((int)response.StatusCode)
            {
                case 200:
                    {
                        using (var stream = await response.Content.ReadAsStreamAsync())
                        {
                            if (stream.Length == 0)
                                return default(SitePrivilege[]);

                            var result = await JsonSerializer.DeserializeAsync<SitePrivilege[]>(stream, _serializerOptions);
                            return result;
                        }
                    }

                default:
                    throw new InvalidOperationException($"Call Failed - {response.StatusCode}");
            }
        }

        public async Task<System.IO.Stream> UserEffectiveSitePrivilegesStream(
            string userName)
        {
            string url = $"/api/user/{userName}/effectiveSitePrivileges";
            var request = new HttpRequestMessage(HttpMethod.Get, url);

            var response = await _httpClient.SendAsync(request);

            switch ((int)response.StatusCode)
            {
                case 200:
                    var stream = await response.Content.ReadAsStreamAsync();
                    return stream;

                default:
                    throw new InvalidOperationException($"Call Failed - {response.StatusCode}");
            }
        }

        public async Task UserChangepassword(
            string userName,
            string password)
        {
            string url = $"/api/user/{userName}/changepassword";
            {
                var qsh = new QueryStringHelper(url);
                qsh.RegisterQueryParameter("password", password);
                url = qsh.GenerateFullUri();
            }
            var request = new HttpRequestMessage(HttpMethod.Post, url);

            var response = await _httpClient.SendAsync(request);

            switch ((int)response.StatusCode)
            {
                case 204:
                    return;

                default:
                    throw new InvalidOperationException($"Call Failed - {response.StatusCode}");
            }
        }

        public async Task<UserSessionModel[]> UserSessions(
            string userName)
        {
            string url = $"/api/user/{userName}/sessions";
            var request = new HttpRequestMessage(HttpMethod.Get, url);

            var response = await _httpClient.SendAsync(request);

            switch ((int)response.StatusCode)
            {
                case 200:
                    {
                        using (var stream = await response.Content.ReadAsStreamAsync())
                        {
                            if (stream.Length == 0)
                                return default(UserSessionModel[]);

                            var result = await JsonSerializer.DeserializeAsync<UserSessionModel[]>(stream, _serializerOptions);
                            return result;
                        }
                    }

                default:
                    throw new InvalidOperationException($"Call Failed - {response.StatusCode}");
            }
        }

        public async Task<System.IO.Stream> UserSessionsStream(
            string userName)
        {
            string url = $"/api/user/{userName}/sessions";
            var request = new HttpRequestMessage(HttpMethod.Get, url);

            var response = await _httpClient.SendAsync(request);

            switch ((int)response.StatusCode)
            {
                case 200:
                    var stream = await response.Content.ReadAsStreamAsync();
                    return stream;

                default:
                    throw new InvalidOperationException($"Call Failed - {response.StatusCode}");
            }
        }

        public async Task UserPersonalaccesstokenDelete(
            string userName,
            string tokenName)
        {
            string url = $"/api/user/{userName}/personalaccesstoken/delete";
            {
                var qsh = new QueryStringHelper(url);
                qsh.RegisterQueryParameter("tokenName", tokenName);
                url = qsh.GenerateFullUri();
            }
            var request = new HttpRequestMessage(HttpMethod.Delete, url);

            var response = await _httpClient.SendAsync(request);

            switch ((int)response.StatusCode)
            {
                case 204:
                    return;

                default:
                    throw new InvalidOperationException($"Call Failed - {response.StatusCode}");
            }
        }

        public async Task<UserPersonalAccessTokenModel[]> UserPersonalaccesstokens(
            string userName)
        {
            string url = $"/api/user/{userName}/personalaccesstokens";
            var request = new HttpRequestMessage(HttpMethod.Get, url);

            var response = await _httpClient.SendAsync(request);

            switch ((int)response.StatusCode)
            {
                case 200:
                    {
                        using (var stream = await response.Content.ReadAsStreamAsync())
                        {
                            if (stream.Length == 0)
                                return default(UserPersonalAccessTokenModel[]);

                            var result = await JsonSerializer.DeserializeAsync<UserPersonalAccessTokenModel[]>(stream, _serializerOptions);
                            return result;
                        }
                    }

                default:
                    throw new InvalidOperationException($"Call Failed - {response.StatusCode}");
            }
        }

        public async Task<System.IO.Stream> UserPersonalaccesstokensStream(
            string userName)
        {
            string url = $"/api/user/{userName}/personalaccesstokens";
            var request = new HttpRequestMessage(HttpMethod.Get, url);

            var response = await _httpClient.SendAsync(request);

            switch ((int)response.StatusCode)
            {
                case 200:
                    var stream = await response.Content.ReadAsStreamAsync();
                    return stream;

                default:
                    throw new InvalidOperationException($"Call Failed - {response.StatusCode}");
            }
        }

        public async Task UserPersonalaccesstokensWipe(
            string userName)
        {
            string url = $"/api/user/{userName}/personalaccesstokens/wipe";
            var request = new HttpRequestMessage(HttpMethod.Delete, url);

            var response = await _httpClient.SendAsync(request);

            switch ((int)response.StatusCode)
            {
                case 204:
                    return;

                default:
                    throw new InvalidOperationException($"Call Failed - {response.StatusCode}");
            }
        }

        public async Task UserLock(
            string userName)
        {
            string url = $"/api/user/{userName}/lock";
            var request = new HttpRequestMessage(HttpMethod.Post, url);

            var response = await _httpClient.SendAsync(request);

            switch ((int)response.StatusCode)
            {
                case 204:
                    return;

                default:
                    throw new InvalidOperationException($"Call Failed - {response.StatusCode}");
            }
        }

        public async Task UserUnlock(
            string userName)
        {
            string url = $"/api/user/{userName}/unlock";
            var request = new HttpRequestMessage(HttpMethod.Post, url);

            var response = await _httpClient.SendAsync(request);

            switch ((int)response.StatusCode)
            {
                case 204:
                    return;

                default:
                    throw new InvalidOperationException($"Call Failed - {response.StatusCode}");
            }
        }

        public async Task UserUpdate(
            string userName,
            UpdateUserDetailsModel body)
        {
            string url = $"/api/user/{userName}/update";
            var request = new HttpRequestMessage(HttpMethod.Post, url);
            var serializerOptions = new System.Text.Json.JsonSerializerOptions();
            serializerOptions.Converters.Add(new System.Text.Json.Serialization.JsonStringEnumConverter(JsonNamingPolicy.CamelCase));
            request.Content = System.Net.Http.Json.JsonContent.Create<UpdateUserDetailsModel>(body, options: serializerOptions);

            var response = await _httpClient.SendAsync(request);

            switch ((int)response.StatusCode)
            {
                case 200:
                    return;

                default:
                    throw new InvalidOperationException($"Call Failed - {response.StatusCode}");
            }
        }

        public async Task<ValidateUpdateUserDetailsModel> UserValidateUpdate(
            string userName,
            UpdateUserDetailsModel body)
        {
            string url = $"/api/user/{userName}/validateUpdate";
            var request = new HttpRequestMessage(HttpMethod.Post, url);
            var serializerOptions = new System.Text.Json.JsonSerializerOptions();
            serializerOptions.Converters.Add(new System.Text.Json.Serialization.JsonStringEnumConverter(JsonNamingPolicy.CamelCase));
            request.Content = System.Net.Http.Json.JsonContent.Create<UpdateUserDetailsModel>(body, options: serializerOptions);

            var response = await _httpClient.SendAsync(request);

            switch ((int)response.StatusCode)
            {
                case 200:
                    {
                        using (var stream = await response.Content.ReadAsStreamAsync())
                        {
                            if (stream.Length == 0)
                                return default(ValidateUpdateUserDetailsModel);

                            var result = await JsonSerializer.DeserializeAsync<ValidateUpdateUserDetailsModel>(stream, _serializerOptions);
                            return result;
                        }
                    }

                default:
                    throw new InvalidOperationException($"Call Failed - {response.StatusCode}");
            }
        }

        public async Task<System.IO.Stream> UserValidateUpdateStream(
            string userName,
            UpdateUserDetailsModel body)
        {
            string url = $"/api/user/{userName}/validateUpdate";
            var request = new HttpRequestMessage(HttpMethod.Post, url);
            var serializerOptions = new System.Text.Json.JsonSerializerOptions();
            serializerOptions.Converters.Add(new System.Text.Json.Serialization.JsonStringEnumConverter(JsonNamingPolicy.CamelCase));
            request.Content = System.Net.Http.Json.JsonContent.Create<UpdateUserDetailsModel>(body, options: serializerOptions);

            var response = await _httpClient.SendAsync(request);

            switch ((int)response.StatusCode)
            {
                case 200:
                    var stream = await response.Content.ReadAsStreamAsync();
                    return stream;

                default:
                    throw new InvalidOperationException($"Call Failed - {response.StatusCode}");
            }
        }

        public async Task<UserSummaryModel> UsersCreate(
            CreateUserModel body)
        {
            string url = $"/api/users/Create";
            var request = new HttpRequestMessage(HttpMethod.Post, url);
            var serializerOptions = new System.Text.Json.JsonSerializerOptions();
            serializerOptions.Converters.Add(new System.Text.Json.Serialization.JsonStringEnumConverter(JsonNamingPolicy.CamelCase));
            request.Content = System.Net.Http.Json.JsonContent.Create<CreateUserModel>(body, options: serializerOptions);

            var response = await _httpClient.SendAsync(request);

            switch ((int)response.StatusCode)
            {
                case 201:
                    {
                        using (var stream = await response.Content.ReadAsStreamAsync())
                        {
                            if (stream.Length == 0)
                                return default(UserSummaryModel);

                            var result = await JsonSerializer.DeserializeAsync<UserSummaryModel>(stream, _serializerOptions);
                            return result;
                        }
                    }

                default:
                    throw new InvalidOperationException($"Call Failed - {response.StatusCode}");
            }
        }

        public async Task<System.IO.Stream> UsersCreateStream(
            CreateUserModel body)
        {
            string url = $"/api/users/Create";
            var request = new HttpRequestMessage(HttpMethod.Post, url);
            var serializerOptions = new System.Text.Json.JsonSerializerOptions();
            serializerOptions.Converters.Add(new System.Text.Json.Serialization.JsonStringEnumConverter(JsonNamingPolicy.CamelCase));
            request.Content = System.Net.Http.Json.JsonContent.Create<CreateUserModel>(body, options: serializerOptions);

            var response = await _httpClient.SendAsync(request);

            switch ((int)response.StatusCode)
            {
                case 200:
                    var stream = await response.Content.ReadAsStreamAsync();
                    return stream;

                default:
                    throw new InvalidOperationException($"Call Failed - {response.StatusCode}");
            }
        }

        public async Task<ValidateCreateUserModel> UsersValidateCreate(
            CreateUserModel body)
        {
            string url = $"/api/users/ValidateCreate";
            var request = new HttpRequestMessage(HttpMethod.Post, url);
            var serializerOptions = new System.Text.Json.JsonSerializerOptions();
            serializerOptions.Converters.Add(new System.Text.Json.Serialization.JsonStringEnumConverter(JsonNamingPolicy.CamelCase));
            request.Content = System.Net.Http.Json.JsonContent.Create<CreateUserModel>(body, options: serializerOptions);

            var response = await _httpClient.SendAsync(request);

            switch ((int)response.StatusCode)
            {
                case 200:
                    {
                        using (var stream = await response.Content.ReadAsStreamAsync())
                        {
                            if (stream.Length == 0)
                                return default(ValidateCreateUserModel);

                            var result = await JsonSerializer.DeserializeAsync<ValidateCreateUserModel>(stream, _serializerOptions);
                            return result;
                        }
                    }

                default:
                    throw new InvalidOperationException($"Call Failed - {response.StatusCode}");
            }
        }

        public async Task<System.IO.Stream> UsersValidateCreateStream(
            CreateUserModel body)
        {
            string url = $"/api/users/ValidateCreate";
            var request = new HttpRequestMessage(HttpMethod.Post, url);
            var serializerOptions = new System.Text.Json.JsonSerializerOptions();
            serializerOptions.Converters.Add(new System.Text.Json.Serialization.JsonStringEnumConverter(JsonNamingPolicy.CamelCase));
            request.Content = System.Net.Http.Json.JsonContent.Create<CreateUserModel>(body, options: serializerOptions);

            var response = await _httpClient.SendAsync(request);

            switch ((int)response.StatusCode)
            {
                case 200:
                    var stream = await response.Content.ReadAsStreamAsync();
                    return stream;

                default:
                    throw new InvalidOperationException($"Call Failed - {response.StatusCode}");
            }
        }

        public async Task<UserSummaryModel[]> UsersAll()
        {
            string url = $"/api/users/all";
            var request = new HttpRequestMessage(HttpMethod.Get, url);

            var response = await _httpClient.SendAsync(request);

            switch ((int)response.StatusCode)
            {
                case 200:
                    {
                        using (var stream = await response.Content.ReadAsStreamAsync())
                        {
                            if (stream.Length == 0)
                                return default(UserSummaryModel[]);

                            var result = await JsonSerializer.DeserializeAsync<UserSummaryModel[]>(stream, _serializerOptions);
                            return result;
                        }
                    }

                default:
                    throw new InvalidOperationException($"Call Failed - {response.StatusCode}");
            }
        }

        public async Task<System.IO.Stream> UsersAllStream()
        {
            string url = $"/api/users/all";
            var request = new HttpRequestMessage(HttpMethod.Get, url);

            var response = await _httpClient.SendAsync(request);

            switch ((int)response.StatusCode)
            {
                case 200:
                    var stream = await response.Content.ReadAsStreamAsync();
                    return stream;

                default:
                    throw new InvalidOperationException($"Call Failed - {response.StatusCode}");
            }
        }

        public async Task<UserSummaryModel[]> UsersSearch(
            string searchText)
        {
            string url = $"/api/users/search";
            {
                var qsh = new QueryStringHelper(url);
                qsh.RegisterQueryParameter("searchText", searchText);
                url = qsh.GenerateFullUri();
            }
            var request = new HttpRequestMessage(HttpMethod.Post, url);

            var response = await _httpClient.SendAsync(request);

            switch ((int)response.StatusCode)
            {
                case 200:
                    {
                        using (var stream = await response.Content.ReadAsStreamAsync())
                        {
                            if (stream.Length == 0)
                                return default(UserSummaryModel[]);

                            var result = await JsonSerializer.DeserializeAsync<UserSummaryModel[]>(stream, _serializerOptions);
                            return result;
                        }
                    }

                default:
                    throw new InvalidOperationException($"Call Failed - {response.StatusCode}");
            }
        }

        public async Task<System.IO.Stream> UsersSearchStream(
            string searchText)
        {
            string url = $"/api/users/search";
            {
                var qsh = new QueryStringHelper(url);
                qsh.RegisterQueryParameter("searchText", searchText);
                url = qsh.GenerateFullUri();
            }
            var request = new HttpRequestMessage(HttpMethod.Post, url);

            var response = await _httpClient.SendAsync(request);

            switch ((int)response.StatusCode)
            {
                case 200:
                    var stream = await response.Content.ReadAsStreamAsync();
                    return stream;

                default:
                    throw new InvalidOperationException($"Call Failed - {response.StatusCode}");
            }
        }
    }
}