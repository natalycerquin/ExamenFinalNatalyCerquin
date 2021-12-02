using Examen.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Examen.Interface
{
    public interface InterfaceCuenta
    {
        List<Cuenta> retonarCuentas();
        List<Cuenta> retonarCuentas(string criterio);
        void guardarCuenta(Cuenta cuenta);
        Cuenta cuenta(int id);
        List<Cuenta> retonarCuenta(int id);
        void update(int  id, decimal saldo);
    }
}
