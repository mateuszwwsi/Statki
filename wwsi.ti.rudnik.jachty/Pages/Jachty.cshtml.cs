using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using wwsi.ti.rudnik.jachty.Model;
using wwsi.ti.rudnik.jachty.Serwis;

namespace wwsi.ti.rudnik.jachty.Pages
{
    public class JachtyModel : PageModel
    {
        public readonly IProgram _p;

        public IEnumerable<Jacht> mj { get; set; }

        public JachtyModel(IProgram jachty)
        {
            _p = jachty;
        }

        public void OnGet()
        {
            mj = _p.PobierzJachtLista();
        }

    }
}
