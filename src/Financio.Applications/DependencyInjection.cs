using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Financio.Applications.Services.Transactions;
using Financio.Applications.Services.Transactions.DataAccess;
using Microsoft.Extensions.DependencyInjection;

namespace Financio.Applications
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplications(this IServiceCollection services)
        {
            services.AddScoped<ITransactionDataAccess, TransactionDataAccess>();
            services.AddScoped<ITransactionService, TransactionService>();
            return services;
        }
    }
}
