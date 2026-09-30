namespace SabzMarket.Application.Common.Dtos;

public sealed record PagedResult<T>(IReadOnlyList<T> Items, int TotalCount);