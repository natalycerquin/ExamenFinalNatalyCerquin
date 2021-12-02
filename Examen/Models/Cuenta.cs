using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Examen.Models
{
    public class Cuenta
    {
        public int Id { get; set; }
        public string Nombres { get; set; }
        public string Categoria { get; set; }
        public decimal Saldo { get; set; }
        public IList<Gastos> Gastos { get; set; }
    }
}
