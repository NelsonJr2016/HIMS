using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HIMS.Entity
{
    public class PersonEntity : ChangeDetails
    {
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

        public ContactDetailEntity ContactDetails { get; set; }
    }
}
