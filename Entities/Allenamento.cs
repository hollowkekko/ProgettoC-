public class Allenamento {
    public int Id { get; set; } 

    public string Nome { get; set; } = string.Empty;     

    public string Descrizione { get; set; } = string.Empty;
    
    public int Durata { get; set; }
    
    public int CalorieBruciate { get; set; }
    
    // FK -> Giorno
    public int GiornoId { get; set; }
    
    public Giorno? Giorno { get; set; }
}