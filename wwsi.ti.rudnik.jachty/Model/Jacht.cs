using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace wwsi.ti.rudnik.jachty.Model
{
    public class Jacht
    {
        public int ID { get; set; }
        public string Nazwa { get; set; }
        public string Model { get; set; }
        public int Zaloga { get; set; }
        public int Kajuty { get; set; }
        public float Cena { get; set; }
        public string Opis { get; set; }
        public string Zdjecie { get; set; }
        public string Typ { get; set; }
    }
}
