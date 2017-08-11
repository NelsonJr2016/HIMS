using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HIMS.Entity
{
    public class AddressEntity : ChangeDetails
    {
        public string Line1 { get; set; }

        public string Line2 { get; set; }

        public string Line3 { get; set; }

        public string ZipCode { get; set; }

        public string AddressType { get; set; }
    }
}
