using Microsoft.EntityFrameworkCore;
using SabzMarket.Application.Errors;
using SabzMarket.Application.Interfaces.Repository;
using SabzMarket.Application.Interfaces.Services;
using SabzMarket.Domain.Entities;
using SabzMarket.Infrastructure.Entities;
using SabzMarket.Infrastructure.Mappers;
using SabzMarket.Infrastructure.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SabzMarket.Infrastructure.Persistence.Repository
{
    public class ErrorRepository:IErrorRepository
    {
        private readonly IDbContextFactory<SabzMarketDbContext> _contextFactory;
        private readonly IFileLogService _fileLogService;

        public ErrorRepository
            (IDbContextFactory<SabzMarketDbContext> contextFactory,
            IFileLogService fileLogService) 
        {
            _contextFactory = contextFactory;
            _fileLogService = fileLogService;
        }

        public async Task<string> LogErrorAsync(Exception ex, String layer)
        {
            var error = ex.ExceptionToErrorDTO(layer);
            var errorLog = new ErrorTable
            {
                CreatedAt = error.CreatedAt,
                Message = error.Message!,
                Source = error.Source,
                StackTrace = error.StackTrace,
                Layer= error.Layer,
                Curl= error.Curl,
                Route= error.Route
            };
            try
            {
                await using var context = await _contextFactory.CreateDbContextAsync();

                context.ErrorLogs.Add(errorLog);
                await context.SaveChangesAsync();
               
                return errorLog.Id.ToString();
            }
            catch (Exception ex2)
            {
               var result= await _fileLogService.SaveFailedLogAsync(ex2);
                return result;  
            }



        }
    }
}
