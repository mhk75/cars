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
        private string tarikh;
        public string Tarikh
        {
            get { return tarikh; }
            set { tarikh = value; }
        }
        private int kilometrFeli;
        public int KilometrFeli
        {
            get { return kilometrFeli; }
            set { kilometrFeli = value; }
        }
        private bool tavizFilterRoghan;
        public bool TavizFilterRoghan
        {
            get { return tavizFilterRoghan; }
            set { tavizFilterRoghan = value; }
        }
        private bool tavizFilterHava;
        public bool TavizFilterHava
        {
            get { return tavizFilterHava; }
            set { tavizFilterHava = value; }
        }
        private bool tavizFilterCabin;
        public bool TavizFilterCabin
        {
            get { return tavizFilterCabin; }
            set { tavizFilterCabin = value; }
        }
        private bool tavizSafiBenzin;
        public bool TavizSafiBenzin
        {
            get { return tavizSafiBenzin; }
            set { tavizSafiBenzin = value; }
        }
        private Service_Vaskazin serviceVaskazin;
        public Service_Vaskazin ServiceVaskazin
        {
            get { return serviceVaskazin; }
            set { serviceVaskazin = value; }
        }
        private int kilometrServiceBadi;
        public int KilometrServiceBadi
        {
            get { return kilometrServiceBadi; }
            set { kilometrServiceBadi = value; }
        }
    }
}
