using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using wwsi.ti.rudnik.jachty.Model;

namespace wwsi.ti.rudnik.jachty.Serwis
{
    public interface IProgram
    {
        public Jacht PobierzJachtJeden(int ID);
        public IEnumerable<Jacht> PobierzJachtLista();
        public Rezerwacja ZapiszRezerwacja(Rezerwacja rezerwacja);

    }
}
