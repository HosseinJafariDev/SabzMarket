using Microsoft.AspNetCore.Mvc;
using SabzMarket.Application.Common;
using SabzMarket.Application.UseCases.Auth.UserIsSeller;
using SabzMarket.Application.UseCases.Sellers.CreateSeller;
using SabzMarket.Application.UseCases.Sellers.GetSeller;
using SabzMarket.Application.UseCases.Sellers.UpdateSeller;
using System.IO;

namespace SabzMarket.API.Controllers
{
    public class SellerController : BaseController
    {
        private readonly ICreateSellerUseCase _createSellerUseCase;
        private readonly IUserIsSellerUseCase _userIsSellerUseCase;
        private readonly IGetSellerByUsenameUseCase _getSellerByUsenameUseCase;
        private readonly IGetSellerByIdUseCase _getSellerByIdUseCase;
        private readonly IGetAllSellerByPhoneNumberUseCase _getAllSellerByPhoneNumberUseCase;
        private readonly ISellerUpdateUseCase _sellerUpdateUseCase;
        public SellerController(
            ICreateSellerUseCase createSellerUseCase,
            IUserIsSellerUseCase userIsSellerUseCase,
            IGetSellerByUsenameUseCase getSellerByUsenameUseCase,
            IGetSellerByIdUseCase getSellerByIdUseCase,
            IGetAllSellerByPhoneNumberUseCase getAllSellerByPhoneNumberUseCase,
            ISellerUpdateUseCase sellerUpdateUseCase)
        {
            _createSellerUseCase = createSellerUseCase;
            _userIsSellerUseCase = userIsSellerUseCase;
            _getSellerByUsenameUseCase = getSellerByUsenameUseCase;
            _getSellerByIdUseCase = getSellerByIdUseCase;
            _getAllSellerByPhoneNumberUseCase = getAllSellerByPhoneNumberUseCase;
            _sellerUpdateUseCase = sellerUpdateUseCase;
        }
        [HttpPost]
        public async Task<OperationResult> CreateSelllerAsync([FromForm] CreateSellerInputDTO createSellerInputDTO, IFormFile file)
        {
            Stream stream = null;
            if (file != null)
            {
                stream = file.OpenReadStream();
            }
            var result = await _createSellerUseCase.ExecuteAsync(createSellerInputDTO, stream);
            return result;
        }
        [HttpGet]
        public async Task<OperationResult> CheckUserInSellerAsync(string username)
        {
            var result = await _userIsSellerUseCase.ExecuteAsync(username);
            return result;
        }
        [HttpGet]
        public async Task<OperationResult<GetSellerOutputDTO>> GetSellerByUsernameAsync(string username)
        {
            var result = await _getSellerByUsenameUseCase.ExecuteAsync(username);
            return result;

        }
        [HttpPost]
        public async Task<OperationResult> UpdateAsync([FromForm] SellerUpdateInputDTO sellerUpdateInputDTO, IFormFile file)
        {
            Stream stream = null;
            if (file != null)
            {
                stream = file.OpenReadStream();
            }
            var result = await _sellerUpdateUseCase.ExecuteAsync(sellerUpdateInputDTO, stream);
            return result;
        }
        [HttpGet]
        public async Task<OperationResult<List<GetSellerOutputDTO>>> GetByPhoneNumberAsync(string phone)
        {
            var result = await _getAllSellerByPhoneNumberUseCase.ExecuteAsync(phone);
            return result;
        }
        [HttpGet]
        public async Task<OperationResult<GetSellerOutputDTO>> GetByIdAsync(long id)
        {
            var result = await _getSellerByIdUseCase.ExecuteAsync(id);
            return result;
        }
    }
}
