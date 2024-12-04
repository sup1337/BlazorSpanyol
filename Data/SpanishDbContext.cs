using BlazorSpanyol.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace BlazorSpanyol.Data;

public class SpanishDbContext: DbContext
{
    public SpanishDbContext(DbContextOptions<SpanishDbContext> options) : base(options)
    {
    }
    
    public DbSet<Words> Words { get; set; }
}