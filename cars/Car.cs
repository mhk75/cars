using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cars
{
    class Car
    {
        public string CarName { get; set; }
        public string CarModel { get; set; }
        public string Owner { get; set; }
        public CarService CarService { get; set; } = new CarService();
        public string CarTag { get; set; }
        public void Status()
        {
            Console.WriteLine( string.Format("CarName: {0}\nCarModel: {1}\nOwner: {2}\nCarTag: {3}\nkilometrfeli: {4}\ntarikh: {5}\ntaviz filterroghan: {6}\ntaviz filterhava: {7}\ntaviz filtercabin: {8}\ntaviz safibenzin: {9}\nservice vaskazin: {10}\nkilometr service badi: {11}",
                CarName,CarModel,Owner,CarTag,CarService.KilometrFeli,CarService.Tarikh,CarService.TavizFilterRoghan,CarService.TavizFilterHava,CarService.TavizFilterCabin,CarService.TavizSafiBenzin,CarService.ServiceVaskazin,CarService.KilometrServiceBadi));
        }
        public string CarWriteData()
        {
            return string.Format("insert into car(name,model,owner,tag) values('{0}','{1}','{2}','{3}')",
                CarName, CarModel, Owner, CarTag);
        }
        public string ServiceWriteData()
        {
            return string.Format("insert into carservice(cartag,tarikh,kilometrfeli,filterroghan,filterhava,filtercabin,safibenzin,servicevaskazin,kilometrservicebadi) values(  '{0}','{1}',{2},{3},{4},{5},{6},'{7}',{8})",
                CarTag, CarService.Tarikh, CarService.KilometrFeli, CarService.TavizFilterRoghan, CarService.TavizFilterHava, CarService.TavizFilterCabin, CarService.TavizSafiBenzin, CarService.ServiceVaskazin.ToString(), CarService.KilometrServiceBadi);
        }
        public void ServiceStatus()
        {
            Console.WriteLine(string.Format("CarTag: {0}\nkilometrfeli: {1}\ntarikh: {2}\ntaviz filterroghan: {3}\ntaviz filterhava: {4}\ntaviz filtercabin: {5}\ntaviz safibenzin: {6}\nservice vaskazin: {7}\nkilometr service badi: {8}",
                CarTag, CarService.KilometrFeli, CarService.Tarikh, CarService.TavizFilterRoghan, CarService.TavizFilterHava, CarService.TavizFilterCabin, CarService.TavizSafiBenzin, CarService.ServiceVaskazin, CarService.KilometrServiceBadi));
        }
    }
}
