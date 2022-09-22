using exemploAPI1.Models;
using Microsoft.EntityFrameworkCore;

namespace exemploAPI1.Context
{
    public class AgendaContext : DbContext
    {
        public AgendaContext(DbContextOptions<AgendaContext> options) : base(options){

        }

        public DbSet<Contato> Contatos { get; set; }
    }
}