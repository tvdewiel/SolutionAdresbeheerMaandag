using AdresbeheerBL.Model;
using AdresbeheerBL.Services;
using AdresbeheerREST.Mappers;
using AdresbeheerREST.Model.Input;
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
        private StraatService straatService;
        private string url = "http://localhost:5117/api/adresbeheer";

        public AdresbeheerController(GemeenteService gemeenteService,StraatService straatService)
        {
            this.gemeenteService = gemeenteService;
            this.straatService = straatService;
        }

        [HttpGet("{gemeenteId}")]
        public ActionResult<GemeenteRESToutputDTO> GetGemeente(int gemeenteId)
        {
            try
            {
                //gemeente ophales bij BL
                //gemeente mappen naar DTO
                Gemeente gemeente=gemeenteService.GeefGemeente(gemeenteId);
                return Ok(MapFromDomain.MapFromGemeenteDomain(url,gemeente,straatService));
            }
            catch(Exception ex) { return NotFound(ex.Message); } 
        }
        [HttpPost]
        public ActionResult<GemeenteRESToutputDTO> PostGemeente([FromBody] GemeenteRESTinputDTO inputDTO)
        {
            try
            {
                Gemeente gemeente=gemeenteService.VoegGemeenteToe(MapToDomain.MapToGemeenteDomain(inputDTO));
                return CreatedAtAction(nameof(GetGemeente),new {gemeenteId=gemeente.NIScode},MapFromDomain.MapFromGemeenteDomain(url,gemeente,straatService));
            }
            catch (Exception ex) { return BadRequest(ex.Message); }
        }
        [HttpDelete("{gemeenteId}")]
        public IActionResult DeleteGemeente(int gemeenteId)
        {
            try
            {
                gemeenteService.VerwijderGemeente(gemeenteId);
                return NoContent();
            }
            catch (Exception ex) { return BadRequest(ex.Message); }
        }
    }
}
