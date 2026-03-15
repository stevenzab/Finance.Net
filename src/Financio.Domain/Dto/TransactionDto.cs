using Financio.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Financio.Domain.Dto
{
    public enum TransactionType
    {
        Income = 0,
        Expense = 1
    }
    public class TransactionDto
    {
        public string TransactionId { get; set; }

        public decimal Amount { get; set; }

        public TransactionType Type { get; set; }

        public string Category { get; set; }

        public string Description { get; set; }

        public DateTime Date { get; set; } = DateTime.Now;

    }
}
