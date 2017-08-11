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
        private GenericRepository<Address> _addressRepository;
        private GenericRepository<Bill> _billRepository;
        private GenericRepository<BillService> _billServiceRepository;
        private GenericRepository<Case> _caseRepository;
        private GenericRepository<CasePhysicianAssignment> _casePhysicianAssignmentRepository;
        private GenericRepository<ContactDetail> _contactDetailRepository;
        private GenericRepository<HospitalService> _hospitalServiceRepository;
        private GenericRepository<PatientDetail> _patientDetailRepository;
        private GenericRepository<PhysicianSchedule> _physicianScheduleRepository;
        private GenericRepository<PhysicianSpecialization> _physicianSpecializationRepository;
        private GenericRepository<Specialization> _specializationRepository;
        private GenericRepository<UserDetail> _userDetailRepository;

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

        public GenericRepository<Address> AddressRepository
        {
            get
            {
                if (this._addressRepository == null)
                    this._addressRepository = new GenericRepository<Address>(_context);
                return _addressRepository;
            }
        }

        public GenericRepository<Bill> BillRepository
        {
            get
            {
                if (this._billRepository == null)
                    this._billRepository = new GenericRepository<Bill>(_context);
                return _billRepository;
            }
        }
 
        public GenericRepository<BillService> BillServiceRepository
        {
            get
            {
                if (this._billServiceRepository == null)
                    this._billServiceRepository = new GenericRepository<BillService>(_context);
                return _billServiceRepository;
            }
        }

        public GenericRepository<Case> CaseRepository
        {
            get
            {
                if (this._caseRepository == null)
                    this._caseRepository = new GenericRepository<Case>(_context);
                return _caseRepository;
            }
        }

        public GenericRepository<CasePhysicianAssignment> CasePhysicianAssignmentRepository
        {
            get
            {
                if (this._casePhysicianAssignmentRepository == null)
                    this._casePhysicianAssignmentRepository = new GenericRepository<CasePhysicianAssignment>(_context);
                return _casePhysicianAssignmentRepository;
            }
        }

        public GenericRepository<ContactDetail> ContactDetailRepository
        {
            get
            {
                if (this._contactDetailRepository == null)
                    this._contactDetailRepository = new GenericRepository<ContactDetail>(_context);
                return _contactDetailRepository;
            }
        }

        public GenericRepository<HospitalService> HospitalServiceRepository
        {
            get
            {
                if (this._hospitalServiceRepository == null)
                    this._hospitalServiceRepository = new GenericRepository<HospitalService>(_context);
                return _hospitalServiceRepository;
            }
        }

        public GenericRepository<PatientDetail> PatientDetailRepository
        {
            get
            {
                if (this._patientDetailRepository == null)
                    this._patientDetailRepository = new GenericRepository<PatientDetail>(_context);
                return _patientDetailRepository;
            }
        }

        public GenericRepository<PhysicianSchedule> PhysicianScheduleRepository
        {
            get
            {
                if (this._physicianScheduleRepository == null)
                    this._physicianScheduleRepository = new GenericRepository<PhysicianSchedule>(_context);
                return _physicianScheduleRepository;
            }
        }

        public GenericRepository<PhysicianSpecialization> PhysicianSpecializationRepository
        {
            get
            {
                if (this._physicianSpecializationRepository == null)
                    this._physicianSpecializationRepository = new GenericRepository<PhysicianSpecialization>(_context);
                return _physicianSpecializationRepository;
            }
        }

        public GenericRepository<Specialization> SpecializationRepository
        {
            get
            {
                if (this._specializationRepository == null)
                    this._specializationRepository = new GenericRepository<Specialization>(_context);
                return _specializationRepository;
            }
        }

        public GenericRepository<UserDetail> UserDetailRepository
        {
            get
            {
                if (this._userDetailRepository == null)
                    this._userDetailRepository = new GenericRepository<UserDetail>(_context);
                return _userDetailRepository;
            }
        }

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
                    //use log4net?
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
