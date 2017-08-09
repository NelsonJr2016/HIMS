namespace HIMS.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class UserDetail
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string MiddleName { get; set; }

        public string LastName { get; set; }

        public DateTime BirthDate { get; set; }

        public string BirthPlace { get; set; }

        public string Gender { get; set; }

        public string MaritalStatus { get; set; }

        public int Height { get; set; }

        public int Weight { get; set; }

        public string BloodGroup { get; set; }

        public string EyeColor { get; set; }

        public string SkinColor { get; set; }

        public int ContactDetailId { get; set; }

        [StringLength(128)]
        public string UserId { get; set; }

        public DateTime DateCreated { get; set; }

        public string CreatedBy { get; set; }

        public DateTime DateLastModified { get; set; }

        public string LastModifiedBy { get; set; }

        public virtual AspNetUser AspNetUser { get; set; }

        public virtual ContactDetail ContactDetail { get; set; }
    }
}
