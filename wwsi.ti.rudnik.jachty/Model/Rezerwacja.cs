using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace wwsi.ti.rudnik.jachty.Model
{
    public class Rezerwacja
    {
        public int ID { get; set; }
        public string JachtID { get; set; }
        public string Numer { get; set; }
        public string Od { get; set; }
        public string Do { get; set; }
        public string Koszt { get; set; }
        public string DodatkoweInformacje { get; set; }
        public string Imie { get; set; }
        public string Nazwisko { get; set; }
        public string Email { get; set; }
        public string Telefon { get; set; }
        public int Ret { get; set; }
        public string Calosc { get; set; }
    }
}
