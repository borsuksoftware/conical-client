using System;
using System.Collections.Generic;
using System.Text;

namespace BorsukSoftware.Conical.Client
{
    public enum ProductStatus
    {
        /// <summary>
        /// Standard state
        /// </summary>
        Standard,

        /// <summary>
        /// The product has been archived and is visible but may not be modified
        /// </summary>
        Archived,

        /// <summary>
        /// The product is in the recycle bin and may be deleted at any time
        /// </summary>
        RecycleBin,

        /// <summary>
        /// The product is in the process of being deleted
        /// </summary>
        Deleting,
    }
}
