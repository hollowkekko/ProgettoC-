using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class GiornoController : ControllerBase {
    private readonly IGiornoService _giornoService;

    public GiornoController(IGiornoService giornoService) {
        _giornoService = giornoService;
    }

    [HttpPost("crea")]
    public async Task<IActionResult> CreaGiornoAsync([FromBody] GiornoCreateDto dto) {
        try {
            var nuovoGiorno = await _giornoService.CreaGiornoAsync(dto);
            
            return Ok(nuovoGiorno);
        } 
        catch (InvalidOperationException ex) {
            return BadRequest(ex.Message);
        } 
        catch (Exception ex) {
            return StatusCode(500, $"Errore server: {ex.Message}");
        }
    }
}
