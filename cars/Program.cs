using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;

namespace cars
{
    class Program
    {
        static void Main(string[] args)
        {
            FileWriter writer = new FileWriter(); 
            Car mycar = new Car();
            int flag;
            string temp;
            List<Car> cars = new List<Car>();
            cars = writer.ReadDataCar();
            cars = writer.ReadDataService(cars);
            //byte[] ReadFile = File.ReadAllBytes("test.txt");
            //Console.WriteLine(fw.ByteArrayToObject(ReadFile)); 
            //object test = fw.ByteArrayToObject(ReadFile);
            //Console.WriteLine(test);
            //string Readfile = File.ReadAllText("cardata.txt");
            //cars = GetCarData(Readfile);
            while (true)
            {
                Console.WriteLine("kare khod ra entekhab konid:");
                Console.WriteLine("1- new car");
                Console.WriteLine("2- new service");
                Console.WriteLine("3- show data");
                Console.WriteLine("4- remove car data");
                Console.WriteLine("5- exit");
                try
                {
                    flag = Convert.ToInt32(Console.ReadLine());
                }
                catch (Exception)
                {
                    Console.WriteLine("pls enter a valid number:");
                    flag = Convert.ToInt32(Console.ReadLine());
                }
                
                if (flag == 1)
                {
                    mycar = GetNewCar();
                    cars.Add(mycar);
                    writer.WriteData(mycar.CarWriteData());
                    writer.WriteData(mycar.ServiceWriteData());
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
                        writer.WriteData(mycar.ServiceUpdateData());
                        Console.WriteLine("data updated successfully");
                        }
                        else
                        {
                            Console.WriteLine("target car does not exist.");
                        }

                }
                else if(flag == 3)
                {
                    int count = 1;
                    foreach (Car i in cars)
                    {
                        Console.WriteLine("");
                        Console.WriteLine(count);
                        i.Status();
                        count++;
                        Console.WriteLine("");
                    }
                }
                else if (flag == 4)
                {
                    Console.WriteLine("enter cartag:");
                    temp = Console.ReadLine();
                    mycar = GetExistingCar(temp, cars);
                    if (mycar.CarTag == temp)
                    {
                        writer.WriteData(mycar.DeleteCar());
                        var itemToRemove = cars.Single(r => r.CarTag == temp);
                        cars.Remove(itemToRemove);
                        Console.WriteLine("car removed successfully");
                    }
                    else
                    {
                        Console.WriteLine("target car does not exist.");
                    }
                }
                else
                {                                       
                    break;
                }
            }
            
            
        }

        private static List<Car> GetCarData(string ReadFile)
        {
            FileWriter writer = new FileWriter();
            List<Car> File_Cars = new List<Car>();
            string[] Temp;
            int count =0;
            string[] FileData = ReadFile.Split(new string[] { "\r\n", "\r", "\n" },
    StringSplitOptions.None);
            foreach (string i in FileData)
            {
                if(i == FileData.Last())
                {
                    break;
                }
                File_Cars.Add(new Car());
                Temp = i.Split(',');
                foreach (string j in Temp)
                {
                    int charpos = j.IndexOf(':')+1;
                    string value = j.Substring(charpos);
                    string controller = j.Substring(0, charpos);
                    switch (controller)
                    {
                        case "CarName:":
                            File_Cars[count].CarName = value;
                            break;
                        case "CarModel:":
                            File_Cars[count].CarModel = value;
                            break;
                        case "Owner:":
                            File_Cars[count].Owner = value;
                            break;
                        case "CarTag:":
                            File_Cars[count].CarTag = value;
                            break;
                        case "tarikh:":
                            File_Cars[count].CarService.Tarikh = value;
                            break;
                        case "kilometrfeli:":
                            File_Cars[count].CarService.KilometrFeli = Convert.ToInt32(value);
                            break;
                        case "kilometr service badi:":
                            File_Cars[count].CarService.KilometrServiceBadi = Convert.ToInt32(value);
                            break;
                        case "taviz filterroghan:":
                            File_Cars[count].CarService.TavizFilterRoghan = Convert.ToBoolean(value);
                            break;
                        case "taviz filterhava:":
                            File_Cars[count].CarService.TavizFilterHava = Convert.ToBoolean(value);
                            break;
                        case "taviz filtercabin:":
                            File_Cars[count].CarService.TavizFilterCabin = Convert.ToBoolean(value);
                            break;
                        case "taviz safibenzin:":
                            File_Cars[count].CarService.TavizSafiBenzin = Convert.ToBoolean(value);
                            break;
                        case "service vaskazin:":
                            File_Cars[count].CarService.ServiceVaskazin = writer.ConvertServiceVaskazin(value);
                            break;
                    }
                }
                count++;
            }
            return File_Cars;
        }

        private static void GetNewService(Car mycar)
        {
            FileWriter writer = new FileWriter();
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
            mycar.CarService.ServiceVaskazin = writer.ConvertServiceVaskazin(Console.ReadLine());
            Console.WriteLine("enter kilometr service badi:");
            mycar.CarService.KilometrServiceBadi = Convert.ToInt32(Console.ReadLine());
            mycar.ServiceStatus();
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
            FileWriter writer = new FileWriter();
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
            mycar.CarService.ServiceVaskazin = writer.ConvertServiceVaskazin(Console.ReadLine());
            Console.WriteLine("enter kilometr service badi:");
            mycar.CarService.KilometrServiceBadi = Convert.ToInt32(Console.ReadLine());
            mycar.Status();
            return mycar;
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
