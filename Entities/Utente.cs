public class Utente {
    public int Id { get; set; }

    public string Email { get; set; } = string.Empty;

    public string PasswordHash { get; set; } = string.Empty;

    public string Nome { get; set; } = string.Empty; 

    public string Cognome { get; set; } = string.Empty;

    public int Età { get; set; }

    public string Genere { get; set; } = string.Empty;

    public int Peso { get; set; }

    public int Altezza { get; set; }
    
    public int ObiettivoCalorieWorkout { get; set; }
    
    public int ObiettivoCarboidratiWorkout { get; set; }
    
    public int ObiettivoProteineWorkout { get; set; }
    
    public int ObiettivoGrassiWorkout { get; set; }

    public int ObiettivoCalorieRest { get; set; }
    
    public int ObiettivoCarboidratiRest { get; set; }
    
    public int ObiettivoProteineRest { get; set; }
    
    public int ObiettivoGrassiRest { get; set; }

    // foreign key a giorni, relazione 1 a molti (un utente può avere molti giorni)
    public List<Giorno> Giorni { get; set; } = new List<Giorno>();
}