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
            string transparencyConfig = ConfigurationManager.AppSettings["TransparencyConstant"];

            float floatCast = 0;

            if (!float.TryParse(transparencyConfig, out floatCast))
            {
                throw new InvalidCastException();
            }
            else
            {
                model.TransparencyConstant = floatCast;
            }


            string sizeConfig = ConfigurationManager.AppSettings["SizeConstant"];
            floatCast = 0;

            if (!float.TryParse(sizeConfig, out floatCast))
            {
                throw new InvalidCastException();
            }
            else
            {
                model.SizeConstant = floatCast;
            }

            string initialRad = ConfigurationManager.AppSettings["InitialRadius"];
            floatCast = 0;

            if (!float.TryParse(initialRad, out floatCast))
            {
                throw new InvalidCastException();
            }
            else
            {
                model.InitialRadius = floatCast;
            }

            string atmosVis = ConfigurationManager.AppSettings["AtmosphericVisibility"];
            int intCast = 0;

            if (!int.TryParse(atmosVis, out intCast))
            {
                throw new InvalidCastException();
            }
            else
            {
                model.AtmosphericVisibility = intCast;
            }

            string userDis = ConfigurationManager.AppSettings["UserDistance"];
            intCast = 0;

            if (!int.TryParse(userDis, out intCast))
            {
                throw new InvalidCastException();
            }
            else
            {
                model.UserDistance = intCast;
            }

            string realTargetSize = ConfigurationManager.AppSettings["RealTargetSize"];
            intCast = 0;

            if (!int.TryParse(realTargetSize, out intCast))
            {
                throw new InvalidCastException();
            }
            else
            {
                model.RealTargetSize = intCast;
            }

            return model;
        }

    }
}
