using System;
using NPoco;
using System.Data.SqlClient;
using Microsoft.Extensions.Options;
using CanbulutHukuk.Infrastructure.Common;

namespace CanbulutHukuk.Infrastructure.DataAccess.Factories
{
    public class DbFactory : IDisposable, IDbFactory
    {
        private IDatabase _context;
        private SqlConnection _conn;
        private readonly ApplicationConfig _optionsAccessor;

        public DbFactory(IOptions<ApplicationConfig> optionsAccessor)
        {
            _optionsAccessor = optionsAccessor.Value;
        }

        public DbFactory(ApplicationConfig config)
        {
            _optionsAccessor = config;
        }

        public IDatabase Init()
        {
            return _context ?? (_context = GetNewDbConnection());
        }

        private Database GetNewDbConnection()
        {
            _conn = new SqlConnection(_optionsAccessor.ConnectionString);
            _conn.Open();
            return new Database(_conn);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        private void Dispose(bool disposing)
        {
            if (_context != null)
            {
                _context.CloseSharedConnection();
                _context.Dispose();
            }
            
            if(_conn != null)
            {
                _conn.Close();
                _conn.Dispose();
            }
        }
    }
}
