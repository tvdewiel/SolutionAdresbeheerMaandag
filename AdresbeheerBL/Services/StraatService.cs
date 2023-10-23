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
    public class StraatService
    {
        private IStraatRepository straatRepository;

        public StraatService(IStraatRepository straatRepository)
        {
            this.straatRepository = straatRepository;
        }

        public List<Straat> GeefstratenGemeente(int id)
        {
            try
            {
                return straatRepository.GeefStratenGemeente(id);
            }
            catch(Exception ex) { throw new StraatServiceException("geefstratengemeente",ex); }
        }
    }
}
