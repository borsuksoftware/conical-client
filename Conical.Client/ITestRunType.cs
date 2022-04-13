using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BorsukSoftware.Conical.Client
{
    /// <summary>
    /// Represents a test run type in the tool
    /// </summary>
    public interface ITestRunType
    {
        /// <summary>
        /// Get the name of the test run type
        /// </summary>
        string Name { get; }

        /// <summary>
        /// Get the description of the test run type
        /// </summary>
        string Description { get; }

        /// <summary>
        /// Get the ordered set of components which are currently enabled for this test run type
        /// </summary>
        IReadOnlyList<string> Components { get; }

        /// <summary>
        /// Update the set of active components for this test run type
        /// </summary>
        /// <param name="Components"></param>
        /// <returns></returns>
        Task UpdateComponents(IReadOnlyList<string> Components);

        /// <summary>
        /// Update the test run type's image
        /// </summary>
        /// <param name="image">The iamage to use, if null, then any existing custom image will be deleted</param>
        Task SetImage(System.Drawing.Image image);

        /// <summary>
        /// Gets the image if it's available
        /// </summary>
        Task<System.Drawing.Image> GetImage();
    }
}
