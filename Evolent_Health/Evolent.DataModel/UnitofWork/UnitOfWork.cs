using Evolent.DataModel.GenericRepository;
using Evolent.DataModel.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;

namespace Evolent.DataModel.UnitofWork
{
    /// <summary>
    /// <see cref="UnitOfWork"/> class which implements <see cref="IDisposable"/> and <see cref="IUnitOfWork"/> interfaces.
    /// </summary>
    public class UnitOfWork : IDisposable, IUnitOfWork
    {
        #region Private member variables

        private Evolent_HealthEntities _context;
        private GenericRepository<Contact> _contactRepository;
        private bool disposed = false;

        #endregion

        public UnitOfWork()
        {
            _context = new Evolent_HealthEntities();
        }


        #region Public Repository Creation properties

        /// <summary>
        /// Get/Set Property for Employee repository.
        /// </summary>
        public GenericRepository<Contact> ContactRepository
        {
            get
            {
                if (this._contactRepository == null)
                    this._contactRepository = new GenericRepository<Contact>(_context);
                return _contactRepository;
            }
        }
        #endregion


        #region Public member methods
        /// <summary>
        /// Save method.
        /// </summary>
        public void Save()
        {
            try
            {
                _context.SaveChanges();
            }
            catch (DbEntityValidationException e)
            {

                var outputLines = new List<string>();
                foreach (var eve in e.EntityValidationErrors)
                {
                    outputLines.Add(string.Format(
                        "{0}: Entity of type \"{1}\" in state \"{2}\" has the following validation errors:", DateTime.Now,
                        eve.Entry.Entity.GetType().Name, eve.Entry.State));
                    foreach (var ve in eve.ValidationErrors)
                    {
                        outputLines.Add(string.Format("- Property: \"{0}\", Error: \"{1}\"", ve.PropertyName, ve.ErrorMessage));
                    }
                }
                throw e;
            }

        }

        #endregion

        #region Implementing IDiosposable

        /// <summary>
        /// Protected Virtual Dispose method
        /// </summary>
        /// <param name="disposing"></param>
        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            this.disposed = true;
        }

        /// <summary>
        /// Dispose method
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        #endregion
    }
}