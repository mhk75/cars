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
            Oil oil = new Oil();
            int flag,Temp;
            string temp;
            List<Car> cars = new List<Car>();
            List<Oil> oils = new List<Oil>();
            cars = writer.ReadDataCar();
            cars = writer.ReadDataService(cars);
            oils = writer.ReadDataOil();
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
                Console.WriteLine("5- new oil");
                Console.WriteLine("6- show oil list");
                Console.WriteLine("7- remove oil");
                Console.WriteLine("8- exit");
                try { 
                flag = Convert.ToInt32(Console.ReadLine());
                }
                catch
                {
                    Console.WriteLine("\nplease enter a number.\n");
                    continue;
                }
                if (flag == 1)
                {
                    mycar = GetNewCar(oils);
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
                        GetNewService(mycar,oils);
                        writer.WriteData(mycar.ServiceUpdateData());
                        Console.WriteLine("data updated successfully");
                        }
                        else
                        {
                            Console.WriteLine("target car does not exist.");
                        }
                }
                else if (flag == 3)
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
                else if (flag == 5)
                {
                    oil = GetNewOil();
                    writer.WriteData(oil.OilWriteData());
                    oils.Add(oil);
                    Console.WriteLine("new oil added successfully");
                }
                else if (flag == 6)
                {
                    ShowOils(oils);
                    
                }
                else if (flag == 7)
                {
                    Console.WriteLine("enter Oil ID:");
                    Temp = Convert.ToInt32( Console.ReadLine());
                    oil = GetExistingOil(Temp, oils);
                    if (oil.ID == Temp)
                    {
                        writer.WriteData(oil.DeleteOilData());
                        var itemToRemove = oils.Single(r => r.ID == Temp);
                        oils.Remove(itemToRemove);
                        Console.WriteLine("Oil removed successfully");
                    }
                    else
                    {
                        Console.WriteLine("target Oil does not exist.");
                    }
                }
                else if (flag == 8)
                {
                    break;
                }
                else
                {
                    Console.WriteLine("\npelease enter a valid number.\n");
                }
            }
            
            
        }

        private static void ShowOils(List<Oil> oils)
        {
            foreach (Oil o in oils)
            {
                o.Status();
            }
        }

        private static Oil GetExistingOil(int temp, List<Oil> oils)
        {
            Oil TempOil = new Oil();
            foreach (Oil i in oils)
            {
                if (i.ID == temp)
                {
                    TempOil = i;
                    break;
                }
            }
            return TempOil;
        }

        private static Oil GetNewOil()
        {
            Oil oil = new Oil();
            Console.WriteLine("enter oil name:");
            oil.Name = Console.ReadLine();
            Console.WriteLine("enter oil type:");
            oil.Type = Console.ReadLine();
            return oil;
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

        private static void GetNewService(Car mycar,List<Oil> oils)
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
            Console.WriteLine("enter kilometr service badi:");
            mycar.CarService.KilometrServiceBadi = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("vaziat vaskazin:(full or takmil or taviz)");
            mycar.CarService.ServiceVaskazin = writer.ConvertServiceVaskazin(Console.ReadLine());
            if (mycar.CarService.ServiceVaskazin == CarService.Service_Vaskazin.TAVIZ_SHOD)
            {
                ShowOils(oils);
                Console.WriteLine("pelease enter your Oil ID:\n");
                int temp = Convert.ToInt32(Console.ReadLine());
                mycar.CarService.oil =  GetExistingOil(temp, oils);
            }
            
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

        private static Car GetNewCar(List<Oil> oils)
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
            Console.WriteLine("enter kilometr service badi:");
            mycar.CarService.KilometrServiceBadi = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("vaziat vaskazin:(full or takmil or taviz)");
            mycar.CarService.ServiceVaskazin = writer.ConvertServiceVaskazin(Console.ReadLine());
            if (mycar.CarService.ServiceVaskazin == CarService.Service_Vaskazin.TAVIZ_SHOD)
            {
                ShowOils(oils);
                Console.WriteLine("pelease enter your Oil ID:\n");
                int temp = Convert.ToInt32(Console.ReadLine());
                mycar.CarService.oil =  GetExistingOil(temp, oils);
            }
            writer.WriteData(mycar.CarWriteData());
            writer.WriteData(mycar.ServiceWriteData());
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
