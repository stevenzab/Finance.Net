using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System;

namespace Financio.Domain.Models
{
    public enum TransactionType
    {
        Income = 0,
        Expense = 1
    }

    public class Transaction : RepositoryCollection
    {
        public decimal Amount { get; set; }

        public TransactionType Type { get; set; }

        public string Category { get; set; }

        public string Description { get; set; }

        public DateTime Date { get; set; } = DateTime.Now;
    }
}
