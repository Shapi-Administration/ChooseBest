using ChooseBest.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ChooseBest.Data
{
    public class VoteDbContext : IdentityDbContext
    {
        public VoteDbContext(DbContextOptions<VoteDbContext> options)
            : base(options)
        {
        }
        public DbSet<Player>? Players { get; set; }
        public DbSet<Team>? Teams { get; set; }
        public DbSet<Trainer>? Trainers { get; set; }
        public object Player { get; internal set; }
    }
}