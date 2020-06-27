using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HydroDemo.Models
{
    public class HisobotPostPDK
    {
        public string post { get; set; }
        public HisobotPDKClass[] list;

        public HisobotPostPDK(KompanentaClass []koms)
        {
            list = new HisobotPDKClass[61];
            for (int i = 0; i < 61; i++)
            {
                list[i] = new HisobotPDKClass();
                list[i].komName = koms[i].Display;
                list[i].min = double.MaxValue;
                list[i].umumiy = 0;
            }
        }

    }
    public class HisobotPDKClass
    {
        public string name { get; set; }
        public string komName { get; set; }
        public int umumiy { get; set; }
        public double ortacha { get; set; }
        public double min { get; set; } 
        public double max { get; set; }

        public HisobotPDKClass()
        {
            umumiy = 0;
            ortacha = 0;
            min = 0;
            max = 0;
        }
    }
}
