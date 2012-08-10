using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Nancy;
using Raven.Client;

namespace NancySpike.Modules
{
    public class RavenModule :NancyModule
    {
        public IDocumentSession DocumentSession
        {
            get { return Context.Items["RavenSession"] as IDocumentSession; }
        }

        public RavenModule()
        {
        }

        public RavenModule(string modulepath)
            : base(modulepath)
        {
        }
    }
}