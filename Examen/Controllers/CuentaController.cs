using Examen.Interface;
using Examen.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Examen.Controllers
{
    public class CuentaController : Controller
    {
        readonly private InterfaceCuenta ICuenta;

        public CuentaController(InterfaceCuenta ICuenta)
        {
            this.ICuenta = ICuenta;
        }

        public ActionResult IndexTabla(string criterio)
        {
           
            if (string.IsNullOrEmpty(criterio))
            {
                var cuentas = ICuenta.retonarCuentas();
                return View(cuentas);
            }
            else
            {
                var cuentas = ICuenta.retonarCuentas(criterio);
                return View(cuentas);
            }
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Crear(Cuenta cuenta)
        {
            Validar(cuenta);
            if (ModelState.IsValid)
            {
                ICuenta.guardarCuenta(cuenta);
                return RedirectToAction("Index");
            }
            return View(cuenta);
        }

        [HttpGet]
        public ActionResult Crear()
        {
            return View(new Cuenta());
        }
        private void Validar(Cuenta cuenta)
        {
            if (cuenta.Nombres == null || cuenta.Nombres == "")
                ModelState.AddModelError("Nombres", "El nombre es requerido");

            if (cuenta.Categoria == null || cuenta.Categoria == "")
                ModelState.AddModelError("Categoria", "Seleccione una categoria");

            if (cuenta.Saldo < 100)
                ModelState.AddModelError("Saldo", "Mayo que 100");
        }
    }
}
