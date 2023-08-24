using rock_paper_scissors.Entities;

namespace rock_paper_scissors.Services
{
    public interface IChoiceRepository
    {
        Task<Choice?> GetChoiceAsync(int choiceId);
        Task<Choice> CreateAsync(Choice choice);
        Task<bool> SaveChangesAsync();
    }
}
