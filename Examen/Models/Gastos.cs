using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Examen.Models
{
    public class Gastos
    {
        public int Id { get; set; }
        public Cuenta Cuenta { get; set; }
        public string Descripcion { get; set; }
        public DateTime Fecha { get; set; }
        public Decimal Monto { get; set; }
        public int CuentaId { get; set; }
    }
}
