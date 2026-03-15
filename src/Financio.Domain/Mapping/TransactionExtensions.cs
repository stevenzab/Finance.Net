using Financio.Domain.Dto;
using Financio.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Financio.Domain.Mapping
{
    public static class TransactionExtensions
    {
        public static TransactionDto MapToDto(this Transaction source)
        {
            if (source == null) return null;

            return new TransactionDto
            {
                Amount = source.Amount,
                Type = (Financio.Domain.Dto.TransactionType)source.Type,
                Category = source.Category,
                Description = source.Description,
                Date = source.Date
            };
        }
    }
}
