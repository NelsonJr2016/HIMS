namespace HIMS.Data
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class HIMSDataModel : DbContext
    {
        public HIMSDataModel()
            : base("name=HIMSDataModel")
        {
        }

        public virtual DbSet<C__MigrationHistory> C__MigrationHistory { get; set; }
        public virtual DbSet<Address> Addresses { get; set; }
        public virtual DbSet<AddressType> AddressTypes { get; set; }
        public virtual DbSet<AspNetRole> AspNetRoles { get; set; }
        public virtual DbSet<AspNetUserClaim> AspNetUserClaims { get; set; }
        public virtual DbSet<AspNetUserLogin> AspNetUserLogins { get; set; }
        public virtual DbSet<AspNetUser> AspNetUsers { get; set; }
        public virtual DbSet<Bill> Bills { get; set; }
        public virtual DbSet<BillService> BillServices { get; set; }
        public virtual DbSet<CasePhysicianAssignment> CasePhysicianAssignments { get; set; }
        public virtual DbSet<Case> Cases { get; set; }
        public virtual DbSet<CaseStage> CaseStages { get; set; }
        public virtual DbSet<ContactDetail> ContactDetails { get; set; }
        public virtual DbSet<HospitalService> HospitalServices { get; set; }
        public virtual DbSet<HospitalServicesType> HospitalServicesTypes { get; set; }
        public virtual DbSet<PatientDetail> PatientDetails { get; set; }
        public virtual DbSet<PhysicianSchedule> PhysicianSchedules { get; set; }
        public virtual DbSet<PhysicianSpecialization> PhysicianSpecializations { get; set; }
        public virtual DbSet<Specialization> Specializations { get; set; }
        public virtual DbSet<UserDetail> UserDetails { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AspNetRole>()
                .HasMany(e => e.AspNetUsers)
                .WithMany(e => e.AspNetRoles)
                .Map(m => m.ToTable("AspNetUserRoles").MapLeftKey("RoleId").MapRightKey("UserId"));

            modelBuilder.Entity<AspNetUser>()
                .HasMany(e => e.AspNetUserClaims)
                .WithRequired(e => e.AspNetUser)
                .HasForeignKey(e => e.UserId);

            modelBuilder.Entity<AspNetUser>()
                .HasMany(e => e.AspNetUserLogins)
                .WithRequired(e => e.AspNetUser)
                .HasForeignKey(e => e.UserId);

            modelBuilder.Entity<AspNetUser>()
                .HasMany(e => e.CasePhysicianAssignments)
                .WithOptional(e => e.AspNetUser)
                .HasForeignKey(e => e.PhysicianId);

            modelBuilder.Entity<AspNetUser>()
                .HasMany(e => e.PatientDetails)
                .WithOptional(e => e.AspNetUser)
                .HasForeignKey(e => e.User_Id);

            modelBuilder.Entity<AspNetUser>()
                .HasMany(e => e.PhysicianSchedules)
                .WithOptional(e => e.AspNetUser)
                .HasForeignKey(e => e.PhysicianId);

            modelBuilder.Entity<AspNetUser>()
                .HasMany(e => e.PhysicianSpecializations)
                .WithOptional(e => e.AspNetUser)
                .HasForeignKey(e => e.PhysicianId);

            modelBuilder.Entity<AspNetUser>()
                .HasMany(e => e.UserDetails)
                .WithOptional(e => e.AspNetUser)
                .HasForeignKey(e => e.UserId);

            modelBuilder.Entity<CaseStage>()
                .HasMany(e => e.Cases)
                .WithRequired(e => e.CaseStage)
                .HasForeignKey(e => e.StageId);

            modelBuilder.Entity<HospitalService>()
                .HasMany(e => e.BillServices)
                .WithRequired(e => e.HospitalService)
                .HasForeignKey(e => e.ServiceId);

            modelBuilder.Entity<HospitalServicesType>()
                .HasMany(e => e.HospitalServices)
                .WithRequired(e => e.HospitalServicesType)
                .HasForeignKey(e => e.TypeId);

            modelBuilder.Entity<PatientDetail>()
                .HasMany(e => e.Cases)
                .WithRequired(e => e.PatientDetail)
                .HasForeignKey(e => e.PatientId);
        }
    }
}
