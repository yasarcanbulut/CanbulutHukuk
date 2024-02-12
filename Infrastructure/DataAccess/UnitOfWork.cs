using NPoco;
using CanbulutHukuk.Infrastructure.Common;
using CanbulutHukuk.Infrastructure.DataAccess.Factories;
using CanbulutHukuk.Infrastructure.DataAccess.Repository;
using System;

namespace CanbulutHukuk.DataAccess
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly IDbFactory _DbFactory;
        private IDataAccessSessionProvider _dataAccessSessionProvider;
        private ITransaction _transaction;

        private IDatabase _context;
        public IDatabase Context
        {
            get
            {
                return _context ?? (_context = _DbFactory.Init());
            }
        }

        private CategoryRepository _AsalSaglikRepository;

        public UnitOfWork(IDbFactory dbFactory, IDataAccessSessionProvider dataAccessSessionProvider)
        {
            this._DbFactory = dbFactory;
            this._dataAccessSessionProvider = dataAccessSessionProvider;
        }

        public CategoryRepository AsalSaglikRepository
        {
            get
            {
                if (this._AsalSaglikRepository == null)
                {
                    this._AsalSaglikRepository = new CategoryRepository(Context);
                }
                return _AsalSaglikRepository;
            }
        }


        public void BeginTransaction()
        { 
            if(_transaction == null)
            {
                _transaction = Context.GetTransaction();
            }
        }

        public void Commit()
        {
            try
            {
                if (_transaction != null)
                {
                    _transaction.Complete();
                    _transaction.Dispose();
                    _transaction = null;
                }
            }
            catch (Exception ex)
            {
                _transaction.Dispose();
                _transaction = null;

                throw ex;
            }
        }
    }

    public interface IUnitOfWork
    {
        IDatabase Context { get; }
        CategoryRepository AsalSaglikRepository { get; }
        void BeginTransaction();
        void Commit();
    }
}
