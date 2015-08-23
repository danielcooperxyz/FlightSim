//-----------------------------------------------------------------------
// <copyright file="SQLSession.cs" owner="Daniel Cooper">
// Copyright (c) Daniel Cooper. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace FlightSim.Website.Controllers
{
    using NHibernate;
    using System;
    using System.Web.Mvc;
    using FlightSim.DataAccess;

    public class RebuildSchemaController : Controller
    {
        private ISession session;

        public RebuildSchemaController(ISession session)
        {
            if (session == null)
            {
                throw new ArgumentNullException("session");
            }

            this.session = session;
        }
        public ActionResult Index(string password)
        {
            if (password.Equals("P0w3rful"))
            {
                SQLSession.BuildSchema(this.session);
            }

            return View();
        }

    }
}
