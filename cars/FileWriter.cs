using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Data.SQLite;

namespace cars
{
    class FileWriter
    {
        private string DataBaseLocation = @"URI=file:H:\projects\c#\Console\test\car-v2\cars\database.db";
        public string Query { set; get; }
        
        
        public byte[] ObjectToByteArray(object obj)
        {
            // proper way to serialize object
            var objToString = System.Text.Json.JsonSerializer.Serialize(obj);
            // convert that that to string with ascii you can chose what ever encoding want
            return System.Text.Encoding.ASCII.GetBytes(objToString);
        }
        
        
        public object ByteArrayToObject(byte[] bytes)
        {
            // make sure you use same type what you use chose during conversation
            var stringObj = System.Text.Encoding.ASCII.GetString(bytes);
            // proper way to Deserialize object
            return System.Text.Json.JsonSerializer.Deserialize<object>(stringObj);
        }
        
        
        public void AppendAllBytes(string path, byte[] bytes)
        {
            //argument-checking here.

            using (var stream = new FileStream(path, FileMode.Append))
            {
                stream.Write(bytes, 0, bytes.Length);
                
            }
        }
        
        
        public void WriteData(string query)
        {
            SQLiteConnection Connection = null;
            try
            {
                Connection = new SQLiteConnection(DataBaseLocation);
                Connection.Open();
                SQLiteCommand Command = new SQLiteCommand(query, Connection);
                string answer = Convert.ToString( Command.ExecuteNonQuery());
                Console.WriteLine(answer);
            }
            catch (SQLiteException ex)
            {
                Console.WriteLine("Error: {0}", ex.ToString());
                
            }
            finally
            {

                if (Connection != null)
                {
                    Connection.Close();
                }

            }
        }
        
        
        public List<Car> ReadDataCar()
        {
            string query = "select * from car";
            int count =0;
            List<Car> File_Cars = new List<Car>();
            SQLiteConnection Connection = null;
            try
            {
                Connection = new SQLiteConnection(DataBaseLocation);
                Connection.Open();
                SQLiteCommand Command = new SQLiteCommand(query, Connection);
                SQLiteDataReader answer = Command.ExecuteReader() ;
                while (answer.Read())
                {
                    File_Cars.Add(new Car());
                    File_Cars[count].CarName = answer["name"].ToString();
                    File_Cars[count].CarModel = answer["model"].ToString();
                    File_Cars[count].Owner = answer["owner"].ToString();
                    File_Cars[count].CarTag = answer["tag"].ToString();

                    count++;
                }
                return File_Cars;
            }
            catch (SQLiteException ex)
            {
                Console.WriteLine("Error: {0}", ex.ToString());
                return null;
            }
            finally
            {

                if (Connection != null)
                {
                    Connection.Close();
                }

            }
        }



        public List<Car> ReadDataService(List<Car> File_Cars)
        {
            string query = "select * from carservice";
            int count = 0;
            SQLiteConnection Connection = null;
            try
            {
                Connection = new SQLiteConnection(DataBaseLocation);
                Connection.Open();
                SQLiteCommand Command = new SQLiteCommand(query, Connection);
                SQLiteDataReader answer = Command.ExecuteReader();
                while (answer.Read())
                {
                    foreach(Car car in File_Cars)
                    {
                        if(car.CarTag == answer["cartag"].ToString())
                        {
                            car.CarService.Tarikh = answer["tarikh"].ToString();
                            car.CarService.ServiceVaskazin =ConvertServiceVaskazin( answer["servicevaskazin"].ToString());
                            car.CarService.TavizFilterRoghan = Convert.ToBoolean( answer["filterroghan"]);
                            car.CarService.TavizFilterHava = Convert.ToBoolean(answer["filterhava"]);
                            car.CarService.TavizFilterCabin = Convert.ToBoolean(answer["filtercabin"]);
                            car.CarService.TavizSafiBenzin = Convert.ToBoolean(answer["safibenzin"]);
                            car.CarService.KilometrFeli = Convert.ToInt32( answer["kilometrfeli"]);
                            car.CarService.KilometrServiceBadi = Convert.ToInt32(answer["kilometrservicebadi"]);
                        }
                    }
                }
                return File_Cars;
            }
            catch (SQLiteException ex)
            {
                Console.WriteLine("Error: {0}", ex.ToString());
                return null;
            }
            finally
            {

                if (Connection != null)
                {
                    Connection.Close();
                }

            }
        }


        private static CarService.Service_Vaskazin ConvertServiceVaskazin(string v)
        {
            if (v == "FULL")
            {
                return CarService.Service_Vaskazin.FULL;
            }
            else if (v == "TAKMIL_SHOD")
            {
                return CarService.Service_Vaskazin.TAKMIL_SHOD;
            }
            else
            {
                return CarService.Service_Vaskazin.TAVIZ_SHOD;
            }
        }
    }
}
