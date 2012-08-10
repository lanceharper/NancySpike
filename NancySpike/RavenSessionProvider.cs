using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Raven.Client;
using Raven.Client.Document;

namespace NancySpike
{
    public interface IRavenSessionProvider
    {
        IDocumentSession GetSession();
    }

    public class RavenSessionProvider : IRavenSessionProvider
    {
        private static DocumentStore _documentStore;

        public static DocumentStore DocumentStore
        {
            get { return (_documentStore ?? (_documentStore = CreateDocumentStore())); }
        }

        private static DocumentStore CreateDocumentStore()
        {
            DocumentStore store = new DocumentStore
            {
                Url = "http://localhost:8080"
            };

            store.Initialize();

            return store;
        }

        public IDocumentSession GetSession()
        {
            var session = DocumentStore.OpenSession();
            return session;
        }

    }
}