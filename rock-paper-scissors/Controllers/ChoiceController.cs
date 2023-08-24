using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using rock_paper_scissors.Entities;
using rock_paper_scissors.Services;

namespace rock_paper_scissors.Controllers
{
    [ApiController]
    [Route("api/choice")]
    public class ChoiceController : ControllerBase
    {

        private readonly IChoiceRepository _choiceRepository;
        private readonly IMapper _mapper;

        public ChoiceController(IChoiceRepository choiceRepository, IMapper mapper)
        {
            _choiceRepository = choiceRepository;
            _mapper = mapper;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetChoice(int id)
        {
            var choice = await _choiceRepository.GetChoiceAsync(id);

            if (choice == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(choice);
            }
        }

        [HttpPost]
        public async Task<ActionResult<Choice>> PostChoice(Choice choice)
        {
            if (choice == null)
            {
                return BadRequest("Invalid data");
            }

            var addedChoice = await _choiceRepository.CreateAsync(choice);
            await _choiceRepository.SaveChangesAsync();

            return CreatedAtAction("GetChoice", new { id = addedChoice.Id, }, addedChoice.Id);
        }

    }
}