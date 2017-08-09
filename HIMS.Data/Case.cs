namespace HIMS.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Case
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Case()
        {
            Bills = new HashSet<Bill>();
            CasePhysicianAssignments = new HashSet<CasePhysicianAssignment>();
        }

        public int Id { get; set; }

        public string Complaints { get; set; }

        public string Remarks { get; set; }

        public int PatientId { get; set; }

        public int StageId { get; set; }

        public DateTime DateCreated { get; set; }

        public string CreatedBy { get; set; }

        public DateTime DateLastModified { get; set; }

        public string LastModifiedBy { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Bill> Bills { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CasePhysicianAssignment> CasePhysicianAssignments { get; set; }

        public virtual CaseStage CaseStage { get; set; }

        public virtual PatientDetail PatientDetail { get; set; }
    }
}
