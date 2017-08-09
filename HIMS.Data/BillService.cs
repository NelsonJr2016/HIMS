namespace HIMS.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class BillService
    {
        public int Id { get; set; }

        public int Quantity { get; set; }

        public int BillId { get; set; }

        public int ServiceId { get; set; }

        public DateTime DateCreated { get; set; }

        public string CreatedBy { get; set; }

        public DateTime DateLastModified { get; set; }

        public string LastModifiedBy { get; set; }

        public virtual Bill Bill { get; set; }

        public virtual HospitalService HospitalService { get; set; }
    }
}
