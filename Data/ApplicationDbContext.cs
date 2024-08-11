using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using c_sharp_asp_net_core_player_tracker.Models;

namespace c_sharp_asp_net_core_player_tracker.Data;

public class ApplicationDbContext : IdentityDbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

public DbSet<c_sharp_asp_net_core_player_tracker.Models.Player> Player { get; set; } = default!;
}

