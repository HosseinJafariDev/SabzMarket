using AutoMapper;
using SabzMarket.Application.Interfaces.Repository;

namespace SabzMarket.Application.UseCases.Categories.GetCategory;

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