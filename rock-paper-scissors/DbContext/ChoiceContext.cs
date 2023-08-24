using Microsoft.EntityFrameworkCore;
using rock_paper_scissors.Entities;

namespace rock_paper_scissors.DbContexts
{
    public class ChoiceContext : DbContext
    {

        public DbSet<Choice> Choices { get; set; } = null!;


        public ChoiceContext(DbContextOptions<ChoiceContext> options) : base(options) { }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
          
        }


    }
}
