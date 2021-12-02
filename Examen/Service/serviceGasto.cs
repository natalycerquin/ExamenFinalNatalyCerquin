using Examen.Interface;
using Examen.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Examen.Service
{
    public class serviceGasto : InterfaceGasto
    {
        readonly private ContextApp contextApp;

        public serviceGasto(ContextApp contextApp)
        {
            this.contextApp = contextApp;
        }

        public void saveGasto(Gastos gastos)
        {
            contextApp.Gastos.Add(gastos);
            contextApp.SaveChanges();
        }
    }
}
