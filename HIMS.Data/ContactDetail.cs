namespace HIMS.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class ContactDetail
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ContactDetail()
        {
            Addresses = new HashSet<Address>();
            UserDetails = new HashSet<UserDetail>();
        }

        public int Id { get; set; }

        public string HomeTelephone { get; set; }

        public string OfficeTelephone { get; set; }

        public string MobileNumber { get; set; }

        public string Email { get; set; }

        public string PersonToContactEmergency { get; set; }

        public string NumberToContactEmergency { get; set; }

        public DateTime DateCreated { get; set; }

        public string CreatedBy { get; set; }

        public DateTime DateLastModified { get; set; }

        public string LastModifiedBy { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Address> Addresses { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<UserDetail> UserDetails { get; set; }
    }
}
