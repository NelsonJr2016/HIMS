namespace HIMS.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class PatientDetail
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public PatientDetail()
        {
            Cases = new HashSet<Case>();
        }

        public int Id { get; set; }

        public string Occupation { get; set; }

        public string SmokingStatus { get; set; }

        public string AlcoholDrinkingStatus { get; set; }

        public string HistoryOfFamilyBloodDisease { get; set; }

        public string HistoryOfFamilyNeurologicalDisease { get; set; }

        public string HistoryOfFamilyHeartDisease { get; set; }

        [StringLength(128)]
        public string User_Id { get; set; }

        public DateTime DateCreated { get; set; }

        public string CreatedBy { get; set; }

        public DateTime DateLastModified { get; set; }

        public string LastModifiedBy { get; set; }

        public virtual AspNetUser AspNetUser { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Case> Cases { get; set; }
    }
}
