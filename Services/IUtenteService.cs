public interface IUtenteService {
    Task<Utente> CreaUtenteAsync(UtenteCreateDto dto);
    Task<UtenteResponseDto> UpdateMacroAsync(int id, UtenteUpdateMacroDto dto);
}

