using Microsoft.AspNetCore.Mvc;
using SabzMarket.Application.Common;
using SabzMarket.Application.UseCases.Chats.findUsersChatted;
using SabzMarket.Application.UseCases.Chats.GetMessage;
using SabzMarket.Application.UseCases.Chats.SendMessage;

namespace SabzMarket.API.Controllers
{
    public class ChatController : BaseController
    {
        private readonly IfindUsersChattedWithIdUseCase _findUsersChatted;
        private readonly IGetMessageUseCase _getMessage;
        private readonly ISendMessageUseCase _sendMessage;
        public ChatController(
            IfindUsersChattedWithIdUseCase findUsersChatted,
            IGetMessageUseCase getMessage,
            ISendMessageUseCase sendMessage)
        {
            _findUsersChatted = findUsersChatted;
            _getMessage = getMessage;
            _sendMessage = sendMessage;
        }
        [HttpGet]
        public async Task<OperationResult<List<findUsersChattedOutputDTO>>> FindUsersChattedWithIdAsync(long id, CancellationToken token)
        {
            var result = await _findUsersChatted.ExecuteAsync(id, token);
            return result;
        }
        [HttpGet]
        public async Task<OperationResult<List<GetMessageOutputDTO>>> GetMessageAsync(long fromId, long toId, CancellationToken token)
        {
            var result = await _getMessage.ExecuteAsync(fromId, toId, token);
            return result;
        }
        [HttpPost]
        public async Task<OperationResult> SendMessageAsync(SendMessageInputDTO sendMessageInputDTO, CancellationToken token)
        {
            var result = await _sendMessage.ExecuteAsync(sendMessageInputDTO, token);
            return result;
        }
    }
}
