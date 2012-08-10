using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Nancy;
using Nancy.ModelBinding;
using Nancy.Routing;
using Nancy.Validation;
using Nancy.ViewEngines;
using NancySpike.Modules;

namespace NancySpike
{
    public class RavenAwareModuleBuilder : INancyModuleBuilder
    {
        private readonly IViewFactory viewFactory;
        private readonly IResponseFormatterFactory responseFormatterFactory;
        private readonly IModelBinderLocator modelBinderLocator;
        private readonly IRavenSessionProvider _ravenSessionProvider;
        private readonly IModelValidatorLocator validatorLocator;

        public RavenAwareModuleBuilder(IViewFactory viewFactory, IResponseFormatterFactory responseFormatterFactory,
                                       IModelBinderLocator modelBinderLocator,
                                       IRavenSessionProvider ravenSessionProvider,
             IModelValidatorLocator validatorLocator)
        {
            this.viewFactory = viewFactory;
            this.responseFormatterFactory = responseFormatterFactory;
            this.modelBinderLocator = modelBinderLocator;
            this.validatorLocator = validatorLocator;
            _ravenSessionProvider = ravenSessionProvider;
        }

        public NancyModule BuildModule(NancyModule module, NancyContext context)
        {
            module.Context = context;
            module.Response = this.responseFormatterFactory.Create(context);
            module.ViewFactory = this.viewFactory;
            module.ModelBinderLocator = this.modelBinderLocator;
            module.ValidatorLocator = this.validatorLocator;

            if (module is RavenModule)
            {
                context.Items.Add("RavenSession", _ravenSessionProvider.GetSession());
            }

            return module;
        }
    }

}