using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HIMS.Data;
using System.Data.Entity.Validation;
using System.Diagnostics;

namespace HIMS.Repository
{
    public class UnitOfWork : IDisposable
    {
        #region private members
        private HIMSDataModel _context = null;
        //use this as sample
        //private GenericRepository<EmployeeDataModel> _employeeRepository;
        
        #endregion

        public UnitOfWork()
        {
            _context = new HIMSDataModel();
        }

        #region Public Repository Creation properties...

        //use this as sample
        //public GenericRepository<EmployeeDataModel> EmployeeRepository
        //{
        //    get
        //    {
        //        if (this._employeeRepository == null)
        //            this._employeeRepository = new GenericRepository<EmployeeDataModel>(_context);
        //        return _employeeRepository;
        //    }
        //}



        #endregion

        #region Public member methods...
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
                //to do change directory to where solution is deployed
                System.IO.File.AppendAllLines(@"C:\errors.txt", outputLines);

                throw e;
            }

        }

        #endregion

        #region Implementing IDiosposable...

        #region private dispose variable declaration...
        private bool disposed = false;
        #endregion

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
                    Debug.WriteLine("UnitOfWork is being disposed");
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
