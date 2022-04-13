using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BorsukSoftware.Conical.Client
{
    /// <summary>
    /// Information about an additional file in the tool
    /// </summary>
    public interface IAdditionalFile
    {
        /// <summary>
        /// Get the name of the additional file
        /// </summary>
        string Name { get; }

        /// <summary>
        /// Get the description of the additional file
        /// </summary>
        string Description { get; }

        /// <summary>
        /// Get the file size in bytes
        /// </summary>
        long FileSize { get; }

        /// <summary>
        /// Get a stream over the contents of the file
        /// </summary>
        /// <returns></returns>
        Task<System.IO.Stream> GetFileContents();
    }
}
