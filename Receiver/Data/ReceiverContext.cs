using Microsoft.EntityFrameworkCore;
using Receiver.Data.Entities;

namespace Receiver.Data
{
    public class ReceiverContext : DbContext, IUnitOfWork
    {
        public ReceiverContext(DbContextOptions<ReceiverContext> options) : base(options) { }

        public DbSet<Mensagem> Mensagens { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            foreach (var property in modelBuilder.Model.GetEntityTypes().SelectMany(
                e => e.GetProperties().Where(p => p.ClrType == typeof(string))))
                property.SetColumnType("varchar(100)");


            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ReceiverContext).Assembly);
        }

        public async Task<bool> Commit()
        {
            return await base.SaveChangesAsync() > 0;
        }
    }
}
