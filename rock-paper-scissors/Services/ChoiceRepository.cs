using Microsoft.EntityFrameworkCore;
using rock_paper_scissors.DbContexts;
using rock_paper_scissors.Entities;

namespace rock_paper_scissors.Services
{
    public class ChoiceRepository : IChoiceRepository
    {

        private ChoiceContext _context;


        public ChoiceRepository(ChoiceContext context)
        {
            _context = context;
        }

        public async Task<Choice> CreateAsync(Choice choice)
        {
            var addedChoice = await _context.Choices.AddAsync(choice);
            await _context.SaveChangesAsync(); // Persist the changes to the database
            return addedChoice.Entity; // Return the added entity
        }

        public async Task<Choice?> GetChoiceAsync(int choiceId)
        {
            return await _context.Choices.Where(c => c.Id == choiceId).FirstOrDefaultAsync();
        }

        public async Task<bool> SaveChangesAsync()
        {
            return (await _context.SaveChangesAsync() >= 0);
        }
    }
}
