using API_MercaditoTEC.Data;
using API_MercaditoTEC.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using Xunit;

namespace XUnitTest_MercaditoTEC
{
    public class UnitTestProducto : IDisposable
    {
        protected readonly MercaditoTECContext _context;

        public UnitTestProducto()
        {
            var options = new DbContextOptionsBuilder<MercaditoTECContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;

            _context = new MercaditoTECContext(options);

            _context.Database.EnsureCreated();

            var productos = new[]
            {
                new Producto
                {
                    idProducto = 2,
                    idVendedor = 20,
                    nombre = "Guitarra",
                    descripcion = "Una guitarra",
                    idCategoria = 2,
                    precio = 1490000
                },
                new Producto
                {
                    idProducto = 6,
                    idVendedor = 36,
                    nombre = "Reloj",
                    descripcion = "Un reloj",
                    idCategoria = 13,
                    precio = 685000
                }
            };

            _context.Producto.AddRange(productos);

            _context.SaveChanges();
        }

        [Fact]
        public void ProductoGetOrderedByPrecio()
        {
            //Arrange
            var vendRepo = new SqlVendedorRepo(_context);
            var cls = new SqlProductoRepo(_context, vendRepo);

            //Act
            var result = cls.GetOrderedByPrecio();

            //Assert
            int idProductoFirst = 6;
            Assert.Equal(result.First().idProducto, idProductoFirst);
        }

        public void Dispose()
        {
            _context.Database.EnsureDeleted();
            _context.Dispose();
        }
    }
}
