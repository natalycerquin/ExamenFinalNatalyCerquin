using Examen.Controllers;
using Examen.Interface;
using Examen.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestExamen.Controller
{
    public class CunetaControllerTest
    {
        private Mock<InterfaceCuenta> ICuentasMock;

        [SetUp]
        public void SetUp()
        {
            ICuentasMock = new Mock<InterfaceCuenta>();
        }

        [Test]
        public void IndexTablaRetornaListaDeCuentasCriterioNull01()
        {
            ICuentasMock.Setup(a => a.retonarCuentas()).Returns(new List<Cuenta>());

            var controller = new CuentaController(ICuentasMock.Object);

            var result = controller.IndexTabla(null) as ViewResult;
            Assert.IsInstanceOf<List<Cuenta>>(result.Model);
        }

        [Test]
        public void IndexTablaRetornaListaDeCuentasCriterio02()
        {
            ICuentasMock.Setup(a => a.retonarCuentas("BCP")).Returns(new List<Cuenta>() {
                new Cuenta()
                {
                    Nombres = "BCP"
                }
            }); 

            var controller = new CuentaController(ICuentasMock.Object);

            var result = controller.IndexTabla("BCP") as ViewResult;
            Assert.IsInstanceOf<List<Cuenta>>(result.Model);
        }
        [Test]
        public void CrearDebeDevolverUnaCuenta03()
        {
            var controller = new CuentaController(ICuentasMock.Object);

            var result = controller.Crear(new Cuenta()) as ViewResult;
            Assert.IsInstanceOf<Cuenta>(result.Model);
        }
    }
}
