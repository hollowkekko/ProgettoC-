public class Giorno {
    public int Id { get; set; }

    public DateTime Data { get; set; }
    
    public bool IsWorkout { get; set; }   

    // FK -> Utente
    public int UtenteId { get; set; }

    public Utente? Utente { get; set; }

    // Relazione 1 a molti con Pasto (un giorno può avere più pasti)
    public List<Pasto> Pasti { get; set; } = new List<Pasto>();

    // Relazione 1 a molti con Allenamento (un giorno può avere più allenamenti)
    public List<Allenamento> Allenamenti { get; set; } = new List<Allenamento>();
}