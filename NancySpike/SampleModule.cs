using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Nancy;
using NancySpike.Models;
using NancySpike.Modules;

namespace NancySpike
{
    public class SampleModule : RavenModule
    {
        public SampleModule()
        {
            Get["//"] = parameters =>
            {
                var config = DocumentSession.Query<Config>().First();
                return View["index.cshtml", config  ];
            };
        }
    }
}