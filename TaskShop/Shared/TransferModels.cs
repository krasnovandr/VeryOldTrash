using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TaskShop.Shared
{
   
        public class Battery
        {
            public int Id { get; set; }
            public string Model { get; set; }
            public string Producer { get; set; }
            public int Capacity { get; set; }
            public int Voltage { get; set; }
            public int Price { get; set; }
        }

        public class Earphone
        {
            public int Id { get; set; }
            public string Model { get; set; }
            public string Producer { get; set; }
            public double CableLength { get; set; }
            public int Resistance { get; set; }
            public int MaxFrequency { get; set; }
            public int Price { get; set; }
        }

        public class MemoryCard
        {
            public int Id { get; set; }
            public string Model { get; set; }
            public string Producer { get; set; }
            public int Size { get; set; }
            public int WriteSpeed { get; set; }
            public int ReadSpeed { get; set; }
            public int Price { get; set; }
        }

        public class Monitor
        {

            public int Id { get; set; }
            public string Model { get; set; }
            public string Producer { get; set; }
            public string Resolution { get; set; }
            public int Frequency { get; set; }
            public string MatrixType { get; set; }
            public int Price { get; set; }
        
    }
}