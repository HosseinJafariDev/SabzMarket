using Newtonsoft.Json;
using SabzMarket.Application.Common;
using SabzMarket.Application.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace SabzMarket.Infrastructure.Logging
{
    public class FileLogService : IFileLogService
    {
        private static readonly SemaphoreSlim _lock = new SemaphoreSlim(1, 1);
        private static readonly string _filePath =
            Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "logss", "failed_logs.txt");
        public async Task<string> SaveFailedLogAsync(ErrorLogDTO errorLogDTO)
        {
            try
            {
                var dir = Path.GetDirectoryName(_filePath)!;
                if (!Directory.Exists(dir))
                    Directory.CreateDirectory(dir);
                var json = JsonConvert.SerializeObject(errorLogDTO) + Environment.NewLine;

                await _lock.WaitAsync();
                try
                {
                    await File.AppendAllTextAsync(_filePath, json, Encoding.UTF8);
                }
                finally
                {
                    _lock.Release();
                }
                return errorLogDTO.CreatedAt.ToString();

            }
            catch (Exception exception)
            {
                return exception.ToString();
            }
        }
    }
}
