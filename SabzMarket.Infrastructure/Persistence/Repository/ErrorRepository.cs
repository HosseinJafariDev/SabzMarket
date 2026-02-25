using Microsoft.EntityFrameworkCore;
using SabzMarket.Application.Common;
using SabzMarket.Application.Interfaces.Repository;
using SabzMarket.Application.Interfaces.Services;
using SabzMarket.Infrastructure.Entities;

namespace SabzMarket.Infrastructure.Persistence.Repository
{
    public class ErrorRepository : IErrorRepository
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

        public async Task<string> LogErrorAsync(ErrorLogDTO errorLogDTO)
        {
            var errorLog = new ErrorTable
            {
                CreatedAt = errorLogDTO.CreatedAt,
                Message = errorLogDTO.Message!,
                Source = errorLogDTO.Source,
                StackTrace = errorLogDTO.StackTrace,
                Layer = errorLogDTO.Layer,
                Curl = errorLogDTO.Curl,
                Route = errorLogDTO.Route
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
                var result = await _fileLogService.SaveFailedLogAsync(errorLogDTO);
                return result;
            }
        }
    }
}
