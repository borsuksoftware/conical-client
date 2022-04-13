using System;
using System.Collections.Generic;
using System.Linq;

namespace BorsukSoftware.Conical.Client
{
    /// <summary>
    /// Standard implementatino of <see cref="ITestRunSetAuditTrail"/>
    /// </summary>
    public class TestRunSetAuditTrail : ITestRunSetAuditTrail
    {
        public TestRunSetAuditTrail(IEnumerable<ITestRunSetAuditTrailMessage> messages)
        {
            this.Messages = messages == null ?
                (IReadOnlyList<ITestRunSetAuditTrailMessage>)Array.Empty<ITestRunSetAuditTrailMessage>() :
                messages.ToList();
        }

        public IReadOnlyList<ITestRunSetAuditTrailMessage> Messages { get; }
    }
}
