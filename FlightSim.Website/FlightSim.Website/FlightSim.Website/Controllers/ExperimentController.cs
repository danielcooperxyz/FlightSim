/// Copyright Daniel Cooper

namespace FlightSim.Website.Controllers
{
    using FlightSim.Website.Models;
    using System;
    using System.Collections.Generic;
    using System.Configuration;
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;

    public class ExperimentController : Controller
    {
        //
        // GET: /Experiment/

        public ActionResult Index()
        {
            ExperimentModel model = new ExperimentModel();

            model = this.GetConfiguration(model);

            return this.View(model);
        }

        private ExperimentModel GetConfiguration(ExperimentModel model)
        {
            string transparencyConfig = ConfigurationManager.AppSettings["transparency"];

            float result = 0;

            if (!float.TryParse(transparencyConfig, out result))
            {
                throw new InvalidCastException();
            }
            else
            {
                model.TransparencyConstant = result;
            }


            string sizeConfig = ConfigurationManager.AppSettings["size"];
            result = 0;

            if (!float.TryParse(sizeConfig, out result))
            {
                throw new InvalidCastException();
            }
            else
            {
                model.SizeConstant = result;
            }

            return model;
        }

    }
}
