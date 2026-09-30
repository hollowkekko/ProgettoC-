using Microsoft.EntityFrameworkCore;

public class TrackerDbContext : DbContext {
    public TrackerDbContext(DbContextOptions<TrackerDbContext> options) : base(options) {}

    public DbSet<Utente> Utenti { get; set; }

    public DbSet<Giorno> Giorni { get; set; }

    public DbSet<Pasto> Pasti { get; set; }

    public DbSet<Allenamento> Allenamenti { get; set; }
}