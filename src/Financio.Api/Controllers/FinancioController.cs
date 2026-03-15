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

        [HttpGet("GetAllTransactions")]
        public async Task<IActionResult> GetAll(CancellationToken cancellationToken)
        {
            var transaction = await _transactionService.GetAllAsync(cancellationToken);

            return Ok(transaction);
        }

        [HttpGet("GetById/{id}")]
        public async Task<ActionResult> GetById(string id, CancellationToken cancellationToken)
        {
            var item = await _transactionService.GetByIdAsync(id, cancellationToken);
            if (item == null) return NotFound();
            return Ok(item);
        }

        [HttpPost("AddTransactions")]
        public async Task<IActionResult> Create([FromBody] TransactionDto transaction, CancellationToken cancellationToken)
        {
            await _transactionService.CreateAsync(transaction, cancellationToken);
            return CreatedAtAction(nameof(GetById), new { id = transaction.TransactionId }, transaction);
        }

        [HttpPut("Update/{id}")]
        public async Task<IActionResult> Update(string id, [FromBody] TransactionDto transaction, CancellationToken cancellationToken)
        {
            var existing = await _transactionService.GetByIdAsync(id, cancellationToken);
            if (existing == null) return NotFound();
            await _transactionService.UpdateAsync(id, transaction, cancellationToken);
            return NoContent();
        }

        [HttpDelete("Transaction/{id}")]
        public async Task<IActionResult> Delete(string id, CancellationToken cancellationToken)
        {
            var existing = await _transactionService.GetByIdAsync(id, cancellationToken);
            if (existing == null) return NotFound();
            await _transactionService.DeleteAsync(id, cancellationToken);
            return NoContent();
        }
    }
}
