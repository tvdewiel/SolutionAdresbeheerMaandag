using AdresbeheerBL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdresbeheerBL.Interfaces
{
    public interface IGemeenteRepository
    {
        Gemeente GeefGemeente(int gemeenteId);
        bool HeeftGemeente(int nIScode);
        bool HeeftStraten(int gemeenteId);
        void Verwijdergemeente(int gemeenteId);
        void VoegGemeenteToe(Gemeente gemeente);
    }
}
