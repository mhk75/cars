using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cars
{
    class Program
    {
        static void Main(string[] args)
        {
            Car mycar = new Car();
            int flag;
            string temp;
            List<Car> cars = new List<Car>();
            string ReadFile = File.ReadAllText("CarData.txt");
            Console.WriteLine(ReadFile);
            if (ReadFile != String.Empty)
            {
                cars = GetCarData(ReadFile);
            }
            while (true)
            {
                Console.WriteLine("kare khod ra entekhab konid:");
                Console.WriteLine("1- new car");
                Console.WriteLine("2- new service");
                Console.WriteLine("3- exit");
                flag = Convert.ToInt32( Console.ReadLine());
                if (flag == 1)
                {
                    mycar = GetNewCar();
                    cars.Add(mycar);
                    Console.WriteLine("new car added successfully");
                }
                else if (flag == 2)
                {
                
                        Console.WriteLine("enter cartag:");
                        temp = Console.ReadLine();
                        mycar = GetExistingCar(temp,cars);
                        if (mycar.CarTag == temp)
                        {
                        GetNewService(mycar);
                        }
                        else
                        {
                            Console.WriteLine("target car does not exist.");
                        }

                }
                else
                {
                    temp = "";
                    foreach(Car i in cars)
                    {
                        temp += i.WriteData();
                        temp += "\n";
                    }
                    File.WriteAllText("CarData.txt", temp);
                    break;
                }
            }
            
            
        }

        private static List<Car> GetCarData(string ReadFile)
        {
            Car temp_car = new Car();
            List<Car> File_Cars = new List<Car>();
            string[] Temp;
            
            string[] FileData = ReadFile.Split(new string[] { "\r\n", "\r", "\n" },
    StringSplitOptions.None);
            foreach (string i in FileData)
            {
                if(i == FileData.Last())
                {
                    break;
                }
                Temp = i.Split(',');
                foreach (string j in Temp)
                {
                    int charpos = j.IndexOf(':')+1;
                    string value = j.Substring(charpos);
                    string controller = j.Substring(0, charpos);
                    switch (controller)
                    {
                        case "CarName:":
                            temp_car.CarName = value;
                            break;
                        case "CarModel:":
                            temp_car.CarModel = value;
                            break;
                        case "Owner:":
                            temp_car.Owner = value;
                            break;
                        case "CarTag:":
                            temp_car.CarTag = value;
                            break;
                        case "tarikh:":
                            temp_car.CarService.Tarikh = value;
                            break;
                        case "kilometrfeli:":
                            temp_car.CarService.KilometrFeli = Convert.ToInt32(value);
                            break;
                        case "kilometr service badi:":
                            temp_car.CarService.KilometrServiceBadi = Convert.ToInt32(value);
                            break;
                        case "taviz filterroghan:":
                            temp_car.CarService.TavizFilterRoghan = Convert.ToBoolean(value);
                            break;
                        case "taviz filterhava:":
                            temp_car.CarService.TavizFilterHava = Convert.ToBoolean(value);
                            break;
                        case "taviz filtercabin:":
                            temp_car.CarService.TavizFilterCabin = Convert.ToBoolean(value);
                            break;
                        case "taviz safibenzin:":
                            temp_car.CarService.TavizSafiBenzin = Convert.ToBoolean(value);
                            break;
                        case "service vaskazin:":
                            temp_car.CarService.ServiceVaskazin = ConvertServiceVaskazin(value);
                            break;
                    }
                }
                File_Cars.Add(temp_car);
            }
            return File_Cars;
        }

        private static void GetNewService(Car mycar)
        {
            Console.WriteLine("enter service date:");
            mycar.CarService.Tarikh = Console.ReadLine();
            Console.WriteLine("enter kilometrfeli:");
            mycar.CarService.KilometrFeli = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("oil taviz shod:(y or n)");
            mycar.CarService.TavizFilterRoghan = ConvertYorNtoBool(Console.ReadLine());
            Console.WriteLine("filterhava taviz shod:(y or n)");
            mycar.CarService.TavizFilterHava = ConvertYorNtoBool(Console.ReadLine());
            Console.WriteLine("filtercabin taviz shod:(y or n)");
            mycar.CarService.TavizFilterCabin = ConvertYorNtoBool(Console.ReadLine());
            Console.WriteLine("safibenzin taviz shod:(y or n)");
            mycar.CarService.TavizSafiBenzin = ConvertYorNtoBool(Console.ReadLine());
            Console.WriteLine("vaziat vaskazin:(full or takmil or taviz)");
            mycar.CarService.ServiceVaskazin = ConvertServiceVaskazin(Console.ReadLine());
            Console.WriteLine("enter kilometr service badi:");
            mycar.CarService.KilometrServiceBadi = Convert.ToInt32(Console.ReadLine());
            mycar.Status();
        }

        private static Car GetExistingCar(string temp, List<Car> cars)
        {
            Car TempCar = new Car();
            foreach (Car i in cars)
            {
                if(i.CarTag == temp)
                {
                    TempCar = i;
                    break;
                }

            }
            return TempCar;
        }

        private static Car GetNewCar()
        {
            Car mycar = new Car();
            Console.WriteLine("enter car name:");
            mycar.CarName = Console.ReadLine();
            Console.WriteLine("enter car model:");
            mycar.CarModel = Console.ReadLine();
            Console.WriteLine("enter owner name:");
            mycar.Owner = Console.ReadLine();
            Console.WriteLine("enter car tag:");
            mycar.CarTag = Console.ReadLine();
            Console.WriteLine("enter service date:");
            mycar.CarService.Tarikh = Console.ReadLine();
            Console.WriteLine("enter kilometrfeli:");
            mycar.CarService.KilometrFeli = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("oil taviz shod:(y or n)");
            mycar.CarService.TavizFilterRoghan = ConvertYorNtoBool(Console.ReadLine());
            Console.WriteLine("filterhava taviz shod:(y or n)");
            mycar.CarService.TavizFilterHava = ConvertYorNtoBool(Console.ReadLine());
            Console.WriteLine("filtercabin taviz shod:(y or n)");
            mycar.CarService.TavizFilterCabin = ConvertYorNtoBool(Console.ReadLine());
            Console.WriteLine("safibenzin taviz shod:(y or n)");
            mycar.CarService.TavizSafiBenzin = ConvertYorNtoBool(Console.ReadLine());
            Console.WriteLine("vaziat vaskazin:(full or takmil or taviz)");
            mycar.CarService.ServiceVaskazin = ConvertServiceVaskazin(Console.ReadLine());
            Console.WriteLine("enter kilometr service badi:");
            mycar.CarService.KilometrServiceBadi = Convert.ToInt32(Console.ReadLine());
            mycar.Status();
            return mycar;
        }

        private static CarService.Service_Vaskazin ConvertServiceVaskazin(string v)
        {
            if (v=="full")
            {
                return CarService.Service_Vaskazin.FULL;
            }
            else if(v=="takmil")
            {
                return CarService.Service_Vaskazin.TAKMIL_SHOD;
            }
            else
            {
                return CarService.Service_Vaskazin.TAVIZ_SHOD;
            }
        }

        private static bool ConvertYorNtoBool(string v)
        {
            if (v=="y")
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
