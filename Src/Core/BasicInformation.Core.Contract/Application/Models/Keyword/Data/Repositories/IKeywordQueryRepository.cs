namespace BasicInformation.Core.Keyword.Contracts;

using Swan.Web.Core.Contract;

public interface IKeywordQueryRepository : IQueryRepository
{
    Task<PagedData<TitleAndModeSearchResult>> Query(TitleAndModeSearch query);
}