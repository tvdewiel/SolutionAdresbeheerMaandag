using AdresbeheerBL.Exceptions;
using AdresbeheerBL.Model;
using AdresbeheerREST.Model.Input;

namespace AdresbeheerREST.Mappers
{
    public static class MapToDomain
    {
        public static Gemeente MapToGemeenteDomain(GemeenteRESTinputDTO dto)
        {
            try
            {
                return new Gemeente(dto.NIScode, dto.Naam);
            }
            catch(Exception ex) { throw new MapException("maptogemeentedomain", ex); }
        }
    }
}
