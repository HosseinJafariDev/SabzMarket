using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SabzMarket.API.ApiResultt;
using SabzMarket.Application.Common;
using SabzMarket.Application.UseCases.Chats.findUsersChatted;
using SabzMarket.Application.UseCases.Chats.GetMessage;
using SabzMarket.Application.UseCases.Chats.SendMessage;

namespace SabzMarket.API.Controllers.V1{
    [Authorize]
    public class ChatsController : BaseController
    {
        private readonly IFindUsersChattedWithIdUseCase _findUsersChatted;
        private readonly IGetMessageUseCase _getMessage;
        private readonly ISendMessageUseCase _sendMessage;

        public ChatsController(
            IFindUsersChattedWithIdUseCase findUsersChatted,
            IGetMessageUseCase getMessage,
            ISendMessageUseCase sendMessage)
        {
            _findUsersChatted = findUsersChatted;
            _getMessage = getMessage;
            _sendMessage = sendMessage;
        }

        [HttpGet("{id:long}/user")]
        public async Task<ApiResult<List<findUsersChattedOutputDTO>>> FindUsersChattedWithId(long id,
            CancellationToken token)
        {
            var result = await _findUsersChatted.ExecuteAsync(id, token);
            return result.OperationResultTOApiResult();
        }

        [HttpGet]
        public async Task<ApiResult<List<GetMessageOutputDTO>>> GetMessage(long fromId, long toId,
            CancellationToken token)
        {
            var result = await _getMessage.ExecuteAsync(fromId, toId, token);
            return result.OperationResultTOApiResult();
        }

        [HttpPost]
        public async Task<ApiResult> SendMessage(SendMessageInputDTO sendMessageInputDto, CancellationToken token)
        {
            var result = await _sendMessage.ExecuteAsync(sendMessageInputDto, token);
            return result.OperationResultTOApiResult();
        }
    }
}