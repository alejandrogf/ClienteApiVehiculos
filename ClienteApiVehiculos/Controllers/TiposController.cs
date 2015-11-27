using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using BaseServicios;
using ClienteApiVehiculos.Models;
using Microsoft.Practices.Unity;

namespace ClienteApiVehiculos.Controllers
{
    public class TiposController : Controller
    {
        [Dependency]
        public IServiciosRest<Tipo> Servicio { get; set; }
        // GET: Tipo
        public ActionResult Index()
        {
            var data = Servicio.Get();
            return View(data);
        }

        public ActionResult Alta()
        {
            return View(new Tipo());

        }

        [HttpPost]
        public async Task<ActionResult> Alta(Tipo model)
        {
            var data = await Servicio.Add(model);
            return RedirectToAction("Index");
        }
    }
}