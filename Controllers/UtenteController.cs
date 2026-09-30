using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class UtenteController : ControllerBase {
    private readonly IUtenteService _userService;

    public UtenteController(IUtenteService userService) {
        _userService = userService;
    }

    [HttpPost("register")]
    public async Task<IActionResult> RegisterAsync([FromBody] UtenteCreateDto dto) {
        try {
            // creo utente
            var nuovoUtente = await _userService.CreaUtenteAsync(dto);

            // mappo utente in dto
            var utenteResponseDto = new UtenteResponseDto {
                Email = nuovoUtente.Email,
                Nome = nuovoUtente.Nome,
                Cognome = nuovoUtente.Cognome,
                Età = nuovoUtente.Età,
                Genere = nuovoUtente.Genere,
                Peso = nuovoUtente.Peso,
                Altezza = nuovoUtente.Altezza
            };

            // rispondo 201 created
            return Ok(utenteResponseDto);
        }
        catch (Exception ex) {
            return BadRequest(ex.Message);
        }
    }    

    [HttpPut("macro/{id}")]
    public async Task<IActionResult> UpdateMacroAsync(int id, [FromBody] UtenteUpdateMacroDto dto) {
        try {
            // aggiorno macro
            var updatedUser = await _userService.UpdateMacroAsync(id, dto);

            // rispondo 200 ok
            return Ok(updatedUser);
        }
        catch (Exception ex) {
            return BadRequest(ex.Message);
        }
    }
}