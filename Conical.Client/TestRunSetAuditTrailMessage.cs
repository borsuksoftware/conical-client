using System;
using System.Collections.Generic;
using System.Text;

namespace BorsukSoftware.Conical.Client
{
    internal class TestRunSetAuditTrailMessage : ITestRunSetAuditTrailMessage
    {
        public string Product { get; set; }

        public int TestRunSetID { get; set; }

        public DateTime TimeStamp { get; set; }

        public int? TestRunID { get; set; }

        public string User { get; set; }

        public string Message { get; set; }
    }
}
