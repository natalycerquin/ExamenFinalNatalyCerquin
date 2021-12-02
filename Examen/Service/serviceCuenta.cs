using Examen.Interface;
using Examen.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Examen.Service
{

    public class serviceCuenta : InterfaceCuenta
    {
        readonly private ContextApp contextApp;

        public serviceCuenta(ContextApp contextApp)
        {
            this.contextApp = contextApp;
        }

        public Cuenta cuenta(int id)
        {
            return contextApp.Cuentas.Where(cu => cu.Id == id).FirstOrDefault();
        }

        public void guardarCuenta(Cuenta cuenta)
        {
            contextApp.Cuentas.Add(cuenta);
            contextApp.SaveChanges();
        }

        public Cuenta retonarCuenta(int id)
        {
            return contextApp.Cuentas.Where(a => a.Id == id).FirstOrDefault();
        }

        public List<Cuenta> retonarCuentas()
        {
            return contextApp.Cuentas.Include(g => g.Gastos).ToList();
        }

        public List<Cuenta> retonarCuentas(string criterio)
        {
            return contextApp.Cuentas.Where(g => g.Nombres.Contains(criterio)).Include(a => a.Gastos).ToList();
        }

        //public void update(int id,)
        //{
        //   var cuenta contextApp.Cuentas.Where(a => a.Id == id).FirstOrDefault();

        //    contextApp.Cuentas.Update(cuenta);
        //    contextApp.SaveChanges();
        //}

        public void update(int id, decimal saldo)
        {
            Cuenta cuenta =  contextApp.Cuentas.Where(a => a.Id == id).FirstOrDefault();

            cuenta.Saldo = saldo;
            contextApp.SaveChanges();

        }

        List<Cuenta> InterfaceCuenta.retonarCuenta(int id)
        {
            return contextApp.Cuentas.Where(a => a.Id == id).ToList();
        }
    }
}
