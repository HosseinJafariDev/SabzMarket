using SabzMarket.Application.Common;
using SabzMarket.Application.Interfaces.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SabzMarket.Application.UseCases.Chats.findUsersChatted
{
    public class findUsersChattedWithIdUseCase : IfindUsersChattedWithIdUseCase
    {
        private readonly IChatQueryService _queryService;
        private readonly IErrorRepository _errorRepository;
        public findUsersChattedWithIdUseCase(IChatQueryService queryService, IErrorRepository errorRepository)
        {
            _queryService = queryService;
            _errorRepository = errorRepository;
        }
        public async Task<OperationResult<List<findUsersChattedOutputDTO>>> ExecuteAsync(long id, CancellationToken token)
        {
            try
            {
                var result = await _queryService.findUsersChattedWith(id, token);
                if (!result.Any())
                {
                    return OperationResult<List<findUsersChattedOutputDTO>>.FailedResult(Messages.NotFoundUsersChatted);
                }
                return OperationResult<List<findUsersChattedOutputDTO>>.SuccessedResult(result);
            }
            catch (Exception ex)
            {
                var errorResult = await _errorRepository.LogErrorAsync(ex.ExceptionToErrorDTO(GetType().Name));
                return OperationResult<List<findUsersChattedOutputDTO>>.Failed(errorResult);
            }
        }
    }
}
