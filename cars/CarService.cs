using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cars
{
    class CarService
    {
        public enum Service_Vaskazin
        {
            FULL,
            TAKMIL_SHOD,
            TAVIZ_SHOD
        }
        public string Tarikh { get; set; }
        public int KilometrFeli { get; set; }
        public bool TavizFilterRoghan { get;set; }
        public bool TavizFilterHava { get; set; }
        public bool TavizFilterCabin { get; set; }
        public bool TavizSafiBenzin { get; set; }
        public Service_Vaskazin ServiceVaskazin { get; set; }
        public int KilometrServiceBadi { get; set; }
        
    }
}
