namespace HIMS.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class CasePhysicianAssignment
    {
        public int Id { get; set; }

        public bool IsLeadPhysician { get; set; }

        public bool IsAccepted { get; set; }

        public int CaseId { get; set; }

        [StringLength(128)]
        public string PhysicianId { get; set; }

        public DateTime DateCreated { get; set; }

        public string CreatedBy { get; set; }

        public DateTime DateLastModified { get; set; }

        public string LastModifiedBy { get; set; }

        public virtual AspNetUser AspNetUser { get; set; }

        public virtual Case Case { get; set; }
    }
}
