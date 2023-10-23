using AdresbeheerBL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdresbeheerBL.Interfaces
{
    public interface IStraatRepository
    {
        List<Straat> GeefStratenGemeente(int id);
    }
}
