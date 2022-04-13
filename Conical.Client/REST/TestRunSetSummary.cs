using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BorsukSoftware.Conical.Client.REST
{
    /// <summary>
    /// Standard implementation of <see cref="ITestRunSetSummary" />
    /// </summary>
    /// TODO - Needs to be updated to reflect the test run set count
    public class TestRunSetSummary : TestRunSet, ITestRunSetSummary
    {
        public TestRunSetSummary(IApiService apiService,
            string product,
            int id,
            string name,
            string description,
            Client.TestRunSetStatus status,
            DateTime refDate,
            DateTime runDate,
            string creator,
            IReadOnlyCollection<string> tags) : base(apiService, product, id, name, description, status, refDate, runDate, creator, tags)
        {
        }
    }
}
