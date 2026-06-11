using SabzMarket.Application.Common;
using SabzMarket.Application.Interfaces.Repository;
using SabzMarket.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SabzMarket.Domain.Exceptions;

namespace SabzMarket.Application.UseCases.Chats.findUsersChatted
{
    public class findUsersChattedWithIdUseCase : IFindUsersChattedWithIdUseCase
    {
        private readonly IChatQueryService _queryService;

        public findUsersChattedWithIdUseCase(IChatQueryService queryService)
        {
            _queryService = queryService;
        }

        public async Task<OperationResult<List<findUsersChattedOutputDTO>>> ExecuteAsync(long id,
            CancellationToken token)
        {
            var result = await _queryService.findUsersChattedWith(id, token);
            if (!result.Any())
                throw new NotFoundException(Messages.NotFoundUsersChatted);

            return OperationResult<List<findUsersChattedOutputDTO>>.Success(result, OperationError.Success);
        }
    }
}