using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HIMS.Entity
{
    public class UserEntity : PersonEntity
    {
        public string Username { get; set; }

        public string Password { get; set; }

        public List<string> RoleList { get; set; }
    }
}
