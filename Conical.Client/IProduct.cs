using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BorsukSoftware.Conical.Client
{
    /// <summary>
    /// Interface representing the concept of a product in a Conical instance
    /// </summary>
	public interface IProduct
	{
        /// <summary>
        /// Get the name of the product
        /// </summary>
		string Name { get; }

        /// <summary>
        /// Get the description of the product
        /// </summary>
		string Description { get; }

        /// <summary>
        /// Get the status of the product
        /// </summary>
        ProductStatus Status { get; }

        /// <summary>
        /// Get the set of aliases for this product
        /// </summary>
        IReadOnlyCollection<string> Aliases { get; }

        /// <summary>
        /// Gets the set of test types which are supported for the given product
        /// </summary>
        /// <returns>The set of supported test types</returns>
        Task<IReadOnlyCollection<ITestRunType>> GetTestTypes();

        /// <summary>
        /// Get the set of components which are valid for this product
        /// </summary>
        /// <returns>The set of components</returns>
        /// TODO - Update to return a fuller object?
        Task<IReadOnlyCollection<string>> GetAvailableComponents();

        /// <summary>
        /// Create a new test run type
        /// </summary>
        /// <param name="testRunTypeName">The name of the test run type</param>
        /// <param name="testRunTypeDescription">The description of thetest run type</param>
        /// <param name="components">Set of components which should be initially made available (may be null)</param>
        /// <param name="image">Optional image</param>
        /// <returns></returns>
        Task<ITestRunType> CreateTestRunType(string testRunTypeName, string testRunTypeDescription, string[] components, System.Drawing.Image image);

        /// <summary>
        /// Create a new test run set
        /// </summary>
        /// <param name="testRunSetName"></param>
        /// <param name="testRunSetDescription"></param>
        /// <param name="refDate"></param>
        /// <param name="runDate"></param>
        /// <param name="tags"></param>
        /// <returns>The test run object</returns>
        Task<ITestRunSet> CreateTestRunSet(string testRunSetName, string testRunSetDescription, DateTime refDate, DateTime runDate, IReadOnlyCollection<string> tags);

        /// <summary>
        /// Get a single test run set
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<ITestRunSet> GetTestRunSet(int id);

        /// <summary>
        /// Set the default image to use for a test run type
        /// </summary>
        /// <param name="image">The image, if null, then any existing image will be removed</param>
        /// <returns></returns>
        Task SetDefaultTestRunTypeImage(System.Drawing.Image image);

        /// <summary>
        /// Get the default image to use (if any) for a test run type if no override at a test run type layer has been specified
        /// </summary>
        /// <returns></returns>
        Task<System.Drawing.Image> GetDefaultTestRunTypeImage();

        /// <summary>
        /// Check whether or not one would expect the given rename to work
        /// </summary>
        /// <param name="newName">The new candidate name</param>
        /// <param name="keepOldNameAsAlias">Whether or not the old name should be retained as an alias</param>
        /// <returns></returns>
        Task<(bool canRename, string validationError)> CanRename(string newName, bool keepOldNameAsAlias);

        /// <summary>
        /// Rename the product
        /// </summary>
        /// <param name="newName">The new name</param>
        /// <param name="keepOldNameAsAlias">Whether or not the old name should be retained as an alias</param>
        /// <returns>A task which will perform the action</returns>
        Task Rename(string newName, bool keepOldNameAsAlias);

        /// <summary>
        /// Check whether or not one would expect the given update to work
        /// </summary>
        /// <param name="aliasesToRemove">The set of aliases to remove (optional)</param>
        /// <param name="aliasesToAdd">The set of aliases to add (optional)</param>
        /// <returns>A task which will perform the action</returns>
        Task<(bool canUpdateAliases, string validationError)> CanUpdateAliases(IReadOnlyCollection<string> aliasesToRemove, IReadOnlyCollection<string> aliasesToAdd);

        /// <summary>
        /// Update the set of aliases for this product
        /// </summary>
        /// <param name="aliasesToRemove">The set of aliases to remove (optional)</param>
        /// <param name="aliasesToAdd">The set of aliases to add (optional)</param>
        /// <returns>A task which will perform the action</returns>
        Task UpdateAliases(IReadOnlyCollection<string> aliasesToRemove, IReadOnlyCollection<string> aliasesToAdd);
    }
}
