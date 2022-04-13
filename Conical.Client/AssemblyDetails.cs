using System;
using System.Collections.Generic;
using System.Text;

namespace BorsukSoftware.Conical.Client
{
    public class AssemblyDetails : IAssemblyDetails
    {
        #region IAssemblyDetails Members

        public string Name { get; private set; }

        public string Architecture { get; private set; }

        public string Version { get; private set; }

        public string Culture { get; private set; }

        public byte[] PublicToken { get; private set; }

        public string Path { get; private set; }

        public DateTime TimeStamp { get; private set; }

        #endregion

        public AssemblyDetails(
            string name,
            string architecture,
            string version,
            string culture,
            byte[] publicToken,
            string path,
            DateTime timeStamp)
        {
            this.Name = name;
            this.Architecture = architecture;
            this.Version = version;
            this.Culture = culture;
            this.PublicToken = publicToken;
            this.Path = path;
            this.TimeStamp = timeStamp;
        }
    }
}
