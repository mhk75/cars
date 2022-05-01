using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cars
{
    class Oil
    {
        public string Name { get; set; }
        public string Type { get; set; }
        public int ID { get; set; }
        public string OilWriteData()
        {
            return string.Format("insert into Oil(name,type) values ('{0}','{1}')",
                Name, Type);
        }

        public string DeleteOilData()
        {
            return string.Format("DELETE FROM Oil  WHERE id = '{0}'",
                ID);
        }
        public void Status()
        {
            Console.WriteLine( string.Format("ID:{0}\nName:{1}\nType:{2}\n",
                ID,Name,Type));
        }
    }
}
//oil types: 10w40-10w60-20w50-5w40-5w30-15w40-5w50-10w30
//oil name: behran,speedy,caspian,elf,total