using Microsoft.EntityFrameworkCore;

public class GiornoService : IGiornoService {
    private readonly TrackerDbContext _context;

    public GiornoService(TrackerDbContext context) {
        _context = context;
    }

    public async Task<Giorno> CreaGiornoAsync(GiornoCreateDto dto) {
        
        // creo nuovo giorno
        var nuovoGiorno = new Giorno {
            UtenteId = dto.UtenteId,
            Data = dto.Data,
            IsWorkout = dto.IsWorkout
        };

        // controllo se esiste gia un giorno con la stessa data
        bool giornoEsiste = await _context.Giorni
        .AnyAsync(g => g.UtenteId == dto.UtenteId && g.Data.Date == dto.Data.Date);

        if (giornoEsiste) {
            throw new InvalidOperationException("Hai gia creato il diario per questa data");
        }    

        // aggiungi il giorno al db
        _context.Giorni.Add(nuovoGiorno);

        // salva modifiche
        await _context.SaveChangesAsync();

        // ritorna il nuovo giorno
        return nuovoGiorno; 
    }
}