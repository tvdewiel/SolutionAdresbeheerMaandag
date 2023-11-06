using AdresbeheerBL.Exceptions;
using AdresbeheerBL.Interfaces;
using AdresbeheerBL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdresbeheerBL.Services
{
    public class GemeenteService
    {
        private IGemeenteRepository repo;

        public GemeenteService(IGemeenteRepository repo)
        {
            this.repo = repo;
        }

        public Gemeente GeefGemeente(int gemeenteId)
        {
            try
            {
                return repo.GeefGemeente(gemeenteId);
            }
            catch(Exception ex) { throw new GemeenteServiceException("geefgemeente", ex); }
        }

        public void VerwijderGemeente(int gemeenteId)
        {
            try
            {
                if (!repo.HeeftGemeente(gemeenteId)) { throw new GemeenteServiceException("verwijdergemeente - gemeente bestaat niet"); }
                if (repo.HeeftStraten(gemeenteId)) { throw new GemeenteServiceException("verwijdergemeente - straten niet leeg"); }
                repo.Verwijdergemeente(gemeenteId);
            }
            catch(Exception ex)
            {
                throw new GemeenteServiceException("verwijdergemeente", ex);
            }
        }

        public Gemeente VoegGemeenteToe(Gemeente gemeente)
        {
           try
            {
                if (gemeente == null) { throw new GemeenteServiceException("voeggemeentetoe"); }
                if (repo.HeeftGemeente(gemeente.NIScode)) throw new GemeenteServiceException("voeggemeentetoe - gemeente bestaat reeds");
                repo.VoegGemeenteToe(gemeente);
                return gemeente;
            }
            catch(Exception ex) { throw new GemeenteServiceException("voeggemeentetoe", ex); }
        }
    }
}
