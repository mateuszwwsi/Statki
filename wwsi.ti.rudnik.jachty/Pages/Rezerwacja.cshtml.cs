using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using wwsi.ti.rudnik.jachty.Model;
using wwsi.ti.rudnik.jachty.Serwis;

namespace wwsi.ti.rudnik.jachty.Pages
{
    public class RezerwacjaModel : PageModel
    {

        public readonly IProgram _p;
        public int ID;

        public RezerwacjaModel(IProgram j)
        {
            _p = j;
        }
        [BindProperty(SupportsGet = true)]
        public Rezerwacja r { get; set; }

        public Jacht jacht { get; set; }
        public void OnGet(int JachtID)
        {
            jacht = _p.PobierzJachtJeden(JachtID);
        }

        public IActionResult OnPost(IFormCollection form)
        {
            r = new Rezerwacja()
            {
                JachtID = form["JachtID"],
                Od = form["Od"],
                Do = form["Do"],
                Imie = form["Imie"],
                Nazwisko = form["Nazwisko"],
                Email = form["Email"],
                Telefon = form["Telefon"],
                DodatkoweInformacje = form["DodatkoweInformacje"]
            };
            r = _p.ZapiszRezerwacja(r);
            return RedirectToPage("Rezerwacja", r = r);
        }
    }
}
