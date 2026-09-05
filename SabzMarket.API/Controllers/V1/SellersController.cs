using Microsoft.AspNetCore.Mvc;
using SabzMarket.API.ApiResultt;
using SabzMarket.Application.Common;
using SabzMarket.Application.UseCases.Auth.UserIsSeller;
using SabzMarket.Application.UseCases.Sellers.CreateSeller;
using SabzMarket.Application.UseCases.Sellers.GetSeller;
using SabzMarket.Application.UseCases.Sellers.UpdateSeller;
using System.IO;
using Microsoft.AspNetCore.Authorization;

namespace SabzMarket.API.Controllers.V1
{
    [Authorize]
    public class SellersController : BaseController
    {
        private readonly ICreateSellerUseCase _createSellerUseCase;
        private readonly IUserIsSellerUseCase _userIsSellerUseCase;
        private readonly IGetSellerByUsenameUseCase _getSellerByUsenameUseCase;
        private readonly IGetSellerByIdUseCase _getSellerByIdUseCase;
        private readonly IGetAllSellerByPhoneNumberUseCase _getAllSellerByPhoneNumberUseCase;
        private readonly ISellerUpdateUseCase _sellerUpdateUseCase;

        public SellersController(
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
        public async Task<ApiResult> CreateSeller([FromForm] CreateSellerInputDTO createSellerInputDto,
            IFormFile file, CancellationToken token)
        {
            Stream? stream = null;
            if (file != null)
            {
                stream = file.OpenReadStream();
            }

            var result = await _createSellerUseCase.ExecuteAsync(createSellerInputDto, stream, token);
            return result.OperationResultTOApiResult();
        }

        [HttpGet("{username}/is-seller")]
        public async Task<ApiResult> CheckUserIsSeller(string username, CancellationToken token)
        {
            var result = await _userIsSellerUseCase.ExecuteAsync(username, token);
            return result.OperationResultTOApiResult();
        }

        [HttpGet("{username}")]
        public async Task<ApiResult<GetSellerOutputDTO>> GetByUsername(string username,
            CancellationToken token)
        {
            var result = await _getSellerByUsenameUseCase.ExecuteAsync(username, token);
            return result.OperationResultTOApiResult();
        }

        [HttpPut]
        public async Task<ApiResult> Update([FromForm] SellerUpdateInputDTO sellerUpdateInputDto, IFormFile file,
            CancellationToken token)
        {
            Stream? stream = null;
            if (file != null)
            {
                stream = file.OpenReadStream();
            }

            var result = await _sellerUpdateUseCase.ExecuteAsync(sellerUpdateInputDto, stream, token);
            return result.OperationResultTOApiResult();
        }

        [HttpGet("by-phone/{phone}")]
        public async Task<ApiResult<List<GetSellerOutputDTO>>> GetByPhoneNumber(string phone,
            CancellationToken token)
        {
            var result = await _getAllSellerByPhoneNumberUseCase.ExecuteAsync(phone, token);
            return result.OperationResultTOApiResult();
        }

        [HttpGet("{id:long}")]
        public async Task<ApiResult<GetSellerOutputDTO>> GetById(long id, CancellationToken token)
        {
            var result = await _getSellerByIdUseCase.ExecuteAsync(id, token);
            return result.OperationResultTOApiResult();
        }
    }
}