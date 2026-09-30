public class Pasto {
    public int Id { get; set; }

    public string Nome { get; set; } = string.Empty;
    
    public int Calorie { get; set; }
    
    public int Carboidrati { get; set; }
    
    public int Proteine { get; set; }
    
    public int Grassi { get; set; }

    // FK -> Giorno
    public int GiornoId { get; set; }

    public Giorno? Giorno { get; set; }
}