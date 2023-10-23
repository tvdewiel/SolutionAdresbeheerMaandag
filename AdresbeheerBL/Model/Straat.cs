using AdresbeheerBL.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdresbeheerBL.Model
{
    public class Straat
    {
        public Straat(string straatNaam)
        {
            ZetStraatnaam(straatNaam);
        }
        public Straat(string straatNaam, Gemeente gemeente) : this(straatNaam)
        {
            ZetGemeente(gemeente);
        }
        public Straat(int id, string straatNaam, Gemeente gemeente) : this(straatNaam, gemeente)
        {
            ZetId(id);
        }
        public int Id { get; private set; }
        public string StraatNaam { get; private set; }
        public Gemeente Gemeente { get; private set; }
        public void ZetStraatnaam(string naam)
        {
            if (string.IsNullOrWhiteSpace(naam))
            {
                StraatException ex = new StraatException("naam niet correct");
                ex.Data.Add("Straatnaam", naam);
                throw ex;
            }
            StraatNaam = naam;
        }
        public void ZetId(int id)
        {
            if (id < 0)
            {
                StraatException ex = new StraatException("id niet correct");
                ex.Data.Add("Id", id);
                throw ex;
            }
            Id= id;
        }
        public void ZetGemeente(Gemeente nieuweGemeente)
        {
            if (nieuweGemeente == null) { throw new StraatException("zetgemeente - null"); }
            if (nieuweGemeente.Equals(Gemeente)) { throw new StraatException("gemeente niet nieuw"); }
            Gemeente = nieuweGemeente;
        }
    }
}
