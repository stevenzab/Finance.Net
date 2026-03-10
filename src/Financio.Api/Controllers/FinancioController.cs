using Financio.Applications.Services.Transactions;
using Financio.Domain.Models;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Financio.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FinancioController : ControllerBase
    {
        private readonly ITransactionService _transactionService;

        public FinancioController(ITransactionService transactionService)
        {
            _transactionService = transactionService;
        }

        [HttpGet]
        public async Task<IEnumerable<Transaction>> GetAll()
        {
            return await _transactionService.GetAllAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Transaction>> GetById(string id)
        {
            var item = await _transactionService.GetByIdAsync(id);
            if (item == null) return NotFound();
            return Ok(item);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Transaction transaction)
        {
            await _transactionService.CreateAsync(transaction);
            return CreatedAtAction(nameof(GetById), new { id = transaction.Id }, transaction);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(string id, [FromBody] Transaction transaction)
        {
            var existing = await _transactionService.GetByIdAsync(id);
            if (existing == null) return NotFound();
            await _transactionService.UpdateAsync(id, transaction);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            var existing = await _transactionService.GetByIdAsync(id);
            if (existing == null) return NotFound();
            await _transactionService.DeleteAsync(id);
            return NoContent();
        }
    }
}
