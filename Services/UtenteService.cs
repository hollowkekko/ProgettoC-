public class UtenteService : IUtenteService {
    
    private readonly TrackerDbContext _context;

    public UtenteService(TrackerDbContext context) {
        _context = context;
    }

    public async Task<Utente> CreaUtenteAsync(UtenteCreateDto dto) {
        // creo nuova istanza dell'utente
        var nuovoUtente = new Utente {
            Email = dto.Email,
            PasswordHash = dto.Password,
            Nome = dto.Nome,
            Cognome = dto.Cognome,
            Età = dto.Età,
            Genere = dto.Genere,
            Peso = dto.Peso,
            Altezza = dto.Altezza
        }; 

        // aggiungi l'utente al database
        _context.Utenti.Add(nuovoUtente);

        // salva le modifiche
        await _context.SaveChangesAsync();

        return nuovoUtente;  
    }

    public async Task<UtenteResponseDto> UpdateMacroAsync(int id, UtenteUpdateMacroDto dto) {
        // trovo l'utente
        var utente = await _context.Utenti.FindAsync(id);
        
        // se non lo trovo sollevo eccezione
        if (utente == null) {
            throw new InvalidOperationException("Utente non trovato.");
        }
        
        // aggiorno i macro obiettivi se forniti
        if (dto.ObiettivoCalorieWorkout.HasValue) {
            utente.ObiettivoCalorieWorkout = dto.ObiettivoCalorieWorkout.Value;
        }

        if (dto.ObiettivoCarboidratiWorkout.HasValue) {
            utente.ObiettivoCarboidratiWorkout = dto.ObiettivoCarboidratiWorkout.Value;
        }

        if (dto.ObiettivoProteineWorkout.HasValue) {
            utente.ObiettivoProteineWorkout = dto.ObiettivoProteineWorkout.Value;
        }

        if (dto.ObiettivoGrassiWorkout.HasValue) {
            utente.ObiettivoGrassiWorkout = dto.ObiettivoGrassiWorkout.Value;
        }

        if (dto.ObiettivoCalorieRest.HasValue) {
            utente.ObiettivoCalorieRest = dto.ObiettivoCalorieRest.Value;
        }

        if (dto.ObiettivoCarboidratiRest.HasValue) {
            utente.ObiettivoCarboidratiRest = dto.ObiettivoCarboidratiRest.Value;
        }

        if (dto.ObiettivoProteineRest.HasValue) {
            utente.ObiettivoProteineRest = dto.ObiettivoProteineRest.Value;
        }

        if (dto.ObiettivoGrassiRest.HasValue) {
            utente.ObiettivoGrassiRest = dto.ObiettivoGrassiRest.Value;
        }

        // salvo le modifiche
        await _context.SaveChangesAsync();

        // mappo in dto
        return new UtenteResponseDto {
            Email = utente.Email,
            Nome = utente.Nome,
            Cognome = utente.Cognome,
            Età = utente.Età,
            Genere = utente.Genere,
            Peso = utente.Peso,
            Altezza = utente.Altezza
        };
    }
}