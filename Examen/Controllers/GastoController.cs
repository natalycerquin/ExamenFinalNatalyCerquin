using Examen.Interface;
using Examen.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Examen.Controllers
{
    public class GastoController : Controller
    {
        readonly private InterfaceCuenta ICuenta;
        readonly private InterfaceGasto IGasto;
        public GastoController(InterfaceCuenta ICuenta, InterfaceGasto IGasto)
        {
            this.ICuenta = ICuenta;
            this.IGasto = IGasto;
        }
        public static Cuenta montoTemp;
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Crear(int id)
        {

            ViewBag.Cuenta = ICuenta.retonarCuenta(id);
            montoTemp = ICuenta.cuenta(id);
            return View(new Gastos());
        }

        [HttpPost]
        public ActionResult Crear(Gastos gasto)
        {
            ViewBag.Cuenta = ICuenta.retonarCuenta(montoTemp.Id);
            Validar(gasto);
            if (ModelState.IsValid)
            {
                montoTemp.Saldo = montoTemp.Saldo - gasto.Monto;
                gasto.CuentaId = montoTemp.Id;

                IGasto.saveGasto(gasto);
                ICuenta.update(montoTemp);
                return RedirectToActionPermanent("Index", "Cuenta");
            }
            return View("Crear");
        }

        private void Validar(Gastos gasto)
        {
            if (gasto.Monto < 0)
                ModelState.AddModelError("Monto", "El gasto debe ser mayo a 0");
            if (gasto.Monto > montoTemp.Saldo)
                ModelState.AddModelError("Monto", "No puede exceder el monto de " + montoTemp.Saldo);
            if (gasto.Fecha == null)
                ModelState.AddModelError("Fecha", "Fecha Obligatoria");

            if (gasto.Descripcion == null)
                ModelState.AddModelError("Descripcion", "Descripcion Obligatoria");
        }
    }
}
