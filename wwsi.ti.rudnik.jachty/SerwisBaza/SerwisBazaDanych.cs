using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using wwsi.ti.rudnik.jachty.Model;
using wwsi.ti.rudnik.jachty.Serwis;

namespace wwsi.ti.rudnik.jachty.SerwisBaza
{
    public class SerwisBazaDanych : IProgram
    {   
        //Powołanie połaczenia do bazy danych
        private readonly IDbConnection _c;
        public SerwisBazaDanych(IDbConnection c)
        {
            _c = c;
        }

        public Jacht PobierzJachtJeden(int ID)
        {
            Jacht j = new Jacht();
            string sql = @"SELECT 
	                        j.ID,
	                        j.Nazwa,
	                        j.Model,
	                        j.Zaloga,
	                        j.Kajuty,
	                        j.Cena,
	                        J.Opis,
	                        j.Zdjecie,
	                        t.Typ

                        FROM Jacht as j (nolock) 
	                        JOIN Typ as t (nolock) on t.ID=j.TypID
                        WHERE j.ID = @ID";
            j = _c.Query<Jacht>(sql, new { @ID = ID }).FirstOrDefault();
            return j;
        }

        public IEnumerable<Jacht> PobierzJachtLista()
        {
            string sqlquery = @" SELECT 
	                                j.ID,
	                                j.Nazwa,
	                                j.Model,
	                                j.Zaloga,
	                                j.Kajuty,
	                                j.Cena,
	                                J.Opis,
	                                j.Zdjecie,
	                                t.Typ
                                FROM Jacht as j (nolock) 
	                                JOIN Typ as t (nolock) on t.ID=j.TypID";
            List<Jacht> j = new List<Jacht>();
            j = _c.Query<Jacht>(sqlquery).ToList();
            return j;
        }

        public Rezerwacja ZapiszRezerwacja(Rezerwacja rezerwacja)
        {
            string sql = "[dbo].[ZapiszRezerwacja]";
            var rez = new DynamicParameters();
            rez.Add("@JachtID", rezerwacja.JachtID);
            rez.Add("@Od", rezerwacja.Od);
            rez.Add("@Do", rezerwacja.Do);
            rez.Add("@Imie", rezerwacja.Imie);
            rez.Add("@Nazwisko", rezerwacja.Nazwisko);
            rez.Add("@Email", rezerwacja.Email);
            rez.Add("@Telefon", rezerwacja.Telefon);
            rez.Add("@DodatkoweInformacje", rezerwacja.DodatkoweInformacje);
            rez.Add("@ID", dbType: DbType.Int32, direction: ParameterDirection.Output);
            rez.Add("@Ret", dbType: DbType.Int32, direction: ParameterDirection.Output);
            rez.Add("@Numer", dbType: DbType.String, direction: ParameterDirection.Output, size: 50);
            rez.Add("@Calosc", dbType: DbType.String, direction: ParameterDirection.Output, size: 50);
            _c.Execute(sql, rez, commandType: CommandType.StoredProcedure);
            rezerwacja.Numer = rez.Get<string>("@Numer");
            rezerwacja.Calosc = rez.Get<string>("@Calosc");
            rezerwacja.Ret = rez.Get<int>("@Ret");
            rezerwacja.ID = rez.Get<int>("@ID");

            return rezerwacja;
        }
    }
}
