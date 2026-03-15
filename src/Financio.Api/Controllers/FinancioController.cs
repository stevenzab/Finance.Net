using Financio.Applications.Services.Transactions;
using Financio.Domain.Models;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System.Collections.Generic;
using Financio.Domain.Dto;

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
        public async Task<IActionResult> GetAll()
        {
            var transaction = await _transactionService.GetAllAsync();

            return Ok(transaction);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetById(string id)
        {
            var item = await _transactionService.GetByIdAsync(id);
            if (item == null) return NotFound();
            return Ok(item);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] TransactionDto transaction)
        {
            await _transactionService.CreateAsync(transaction);
            return CreatedAtAction(nameof(GetById), new { id = transaction.TransactionId }, transaction);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(string id, [FromBody] TransactionDto transaction)
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
