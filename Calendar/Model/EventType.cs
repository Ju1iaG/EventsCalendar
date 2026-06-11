using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calendar.Model
{
    public class EventType
    {
        public string Name { get; private set; }
        public double Lambda { get; set; }
        public string ImagePath { get; set; } 

        public EventType(string name, double lambda, string imagePath = null)
        {
            Name = name;
            Lambda = lambda;
            ImagePath = imagePath;
        }

        private static readonly Random _rnd = new Random();
        public double NextInterval()
        {
            if (Lambda <= 0) return 1.0; 
            double u = _rnd.NextDouble();
            if (u < 1e-12) u = 1e-12;
            return -Math.Log(u) / Lambda;
        }
    }
}
