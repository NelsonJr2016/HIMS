using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HIMS.Entity
{
    public class PhysicianEntity : UserEntity
    {
        public List<ScheduleEntity> Schedule { get; set; }

        public List<SpecializationEntity> SpecializationList { get; set; }
    }
}
