using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cars
{
    class Car
    {
        private string carName;
        public string CarName
        {
            get { return carName; }
            set { carName = value; }
        }
        private string carModel;
        public string CarModel
        {
            get { return carModel; }
            set { carModel = value; }
        }
        private string owner;
        public string Owner
        {
            get { return owner; }
            set { owner = value; }
        }
        private CarService carService = new CarService();
        public CarService CarService
        {
            get { return carService; }
            set { carService = value; }
        }
        private string carTag;
        public string CarTag
        {
            get { return carTag; }
            set { carTag = value; }
        }
        public void Status()
        {
            Console.WriteLine( string.Format("CarName:{0},CarModel:{1},Owner:{2},CarTag:{3},kilometrfeli:{4},tarikh:{5},taviz filterroghan:{6},taviz filterhava:{7},taviz filtercabin:{8},taviz safibenzin:{9},service vaskazin:{10},kilometr service badi:{11}",
                CarName,CarModel,Owner,carTag,CarService.KilometrFeli,CarService.Tarikh,CarService.TavizFilterRoghan,CarService.TavizFilterHava,CarService.TavizFilterCabin,CarService.TavizSafiBenzin,CarService.ServiceVaskazin,CarService.KilometrServiceBadi));
        }
        public string WriteData()
        {
            return string.Format("CarName:{0},CarModel:{1},Owner:{2},CarTag:{3},kilometrfeli:{4},tarikh:{5},taviz filterroghan:{6},taviz filterhava:{7},taviz filtercabin:{8},taviz safibenzin:{9},service vaskazin:{10},kilometr service badi:{11}",
                CarName, CarModel, Owner, carTag, CarService.KilometrFeli, CarService.Tarikh, CarService.TavizFilterRoghan, CarService.TavizFilterHava, CarService.TavizFilterCabin, CarService.TavizSafiBenzin, CarService.ServiceVaskazin, CarService.KilometrServiceBadi);
        }
    }
}
