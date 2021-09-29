using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Varuosad.DTO
{
    public class Part
    {
        public string SerialNumber { get; set; }
        public string Name { get; set; }
        public string CarModel { get; set; }
        public double price { get; set; }
        public double PriceVat { get; set; }
    }
}
