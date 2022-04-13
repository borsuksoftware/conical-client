using System;
using System.Collections.Generic;
using System.Text;

namespace BorsukSoftware.Conical.Client
{
    public class ExternalLink
    {
        public string Name { get; }
        public string Url { get; }
        public string Description { get; }

        public ExternalLink( string name, string url, string description)
        {
            this.Name = name;
            this.Description = description;
            this.Url = url;
        }
    }
}
