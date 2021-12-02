using Examen.Controllers;
using Examen.Interface;
using Examen.Models;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestExamen.Controller
{
    public class CostoControllerTest
    {
        private Mock<InterfaceCuenta> ICuentasMock;
        private Mock<InterfaceGasto> IGastoMock;

        [SetUp]
        public void SetUp()
        {
            ICuentasMock = new Mock<InterfaceCuenta>();
            IGastoMock = new Mock<InterfaceGasto>();
        }
        [Test]
        public void CrearDeberetornarUnGasto()
        {
            ICuentasMock.Setup(a => a.cuenta(1)).Returns(new Cuenta() { Id=1});
            ICuentasMock.Setup(a => a.retonarCuenta(1)).Returns(new List<Cuenta>() { new Cuenta() { Id=1} });

            var controller = new GastoController(ICuentasMock.Object, IGastoMock.Object);

            var result = controller.Crear(1) as ViewResult;
            Assert.IsInstanceOf<Gastos>(result.Model);
        }
        [Test]
        public void CrearDeberetornarUnGasto02()
        {
            ICuentasMock.Setup(a => a.cuenta(1)).Returns(new Cuenta() { Id = 1 });
            ICuentasMock.Setup(a => a.retonarCuenta(1)).Returns(new List<Cuenta>() { new Cuenta() { Id = 1 } });

            var controller = new GastoController(ICuentasMock.Object, IGastoMock.Object)
            {
                montoTemp = new Cuenta()
                {
                    Id = 1,
                    Categoria = "Privado",
                    Nombres = "BCP"
                }
            };

            var result = controller.Crear(new Gastos());
            Assert.IsInstanceOf<ViewResult>(result);
        }

    }
}
