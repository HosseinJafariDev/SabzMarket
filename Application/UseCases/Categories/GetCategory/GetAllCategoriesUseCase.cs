using AutoMapper;
using SabzMarket.Application.Common;
using SabzMarket.Application.Interfaces.Repository;
using SabzMarket.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SabzMarket.Application.UseCases.Categories.GetCategory
{
    public class GetAllCategoriesUseCase : IGetAllCategoriesUseCase
    {
        private readonly IMapper _mapper;
        private readonly ICategorieRepository _categorieRepository;

        public GetAllCategoriesUseCase(
            IMapper mapper,
            ICategorieRepository categorieRepository)
        {
            _categorieRepository = categorieRepository;
            _mapper = mapper;
        }

        public async Task<OperationResult<List<GetAllCategoriesOutputDTO>>> ExecuteAsync(CancellationToken token)
        {
            var result = await _categorieRepository.SelectAsync(token);
            var getAllCategoriesOutputDTO = _mapper
                .Map<List<GetAllCategoriesOutputDTO>>(result);

            return OperationResult<List<GetAllCategoriesOutputDTO>>
                .Success(getAllCategoriesOutputDTO, OperationError.Success);
        }
    }
}