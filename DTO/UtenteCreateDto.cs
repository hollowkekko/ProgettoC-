public class UtenteCreateDto {
    public string Email { get; set; } = string.Empty;

    public string Password { get; set; } = string.Empty;

    public string Nome { get; set; } = string.Empty;

    public string Cognome { get; set; } = string.Empty;

    public int Età { get; set; }

    public string Genere { get; set; } = string.Empty;

    public int Peso { get; set; }

    public int Altezza { get; set; }
}