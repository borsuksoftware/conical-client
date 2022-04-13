using System;
using System.Collections.Generic;
using System.Text;

namespace BorsukSoftware.Conical.Client
{
    public interface ITestRunSetAuditTrailMessage
    {
        string Product { get; }
        int TestRunSetID { get; }
        DateTime TimeStamp { get; }
        int? TestRunID { get; }
        string User { get; }
        string Message { get; }
    }
}
