using API_MercaditoTEC.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace XUnitTest_MercaditoTEC.Infrastructure
{
    class MercaditoTECTestBase : IDisposable
    {
        private readonly MercaditoTECContext _context;

        public MercaditoTECTestBase()
        {
            var options = new DbContextOptionsBuilder<MercaditoTECContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;

            _context = new MercaditoTECContext(options);

            _context.Database.EnsureCreated();

            //MercaditoTECInitializer.Initialize(_context);
        }

        public void Dispose()
        {
            _context.Database.EnsureDeleted();

            _context.Dispose();
        }
    }
}
