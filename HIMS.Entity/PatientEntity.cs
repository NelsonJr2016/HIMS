using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HIMS.Entity
{
    public class PatientEntity : UserEntity
    {
        public string Occupation { get; set; }

        public string SmokingStatus { get; set; }

        public string AlcoholDrinkingStatus { get; set; }

        public string HistoryOfFamilyBloodDisease { get; set; }

        public string HistoryOfFamilyNeurologicalDisease { get; set; }

        public string HistoryOfFamilyHeartDisease { get; set; }
    }
}
