using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BlazorSpanyol.Data;

public class SpanishAuthDbContext : IdentityDbContext<IdentityUser>
{
    public SpanishAuthDbContext(DbContextOptions<SpanishAuthDbContext> options) : base(options)
    {
    }
    
}