using AdresbeheerBL.Services;
using AdresbeheerREST.Model.Output;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AdresbeheerREST.Controllers
{
    [Route("api/[controller]/gemeente")]
    [ApiController]
    public class AdresbeheerController : ControllerBase
    {
        private GemeenteService gemeenteService;

        public AdresbeheerController(GemeenteService gemeenteService)
        {
            this.gemeenteService = gemeenteService;
        }

        [HttpGet("{gemeenteId}")]
        public ActionResult<GemeenteRESToutputDTO> GetGemeente(int gemeenteId)
        {
            try
            {
                gemeenteService.GeefGemeente(gemeenteId);
            }
            catch(Exception ex) { return NotFound(ex.Message); } }
        }
    }
}
