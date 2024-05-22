namespace BasicInformation.Core.Keyword.Contracts;

using Swan.Web.Core.Contract;

public class TitleAndModeSearch : PageQuery<PagedData<TitleAndModeSearchResult>>
{
    public string Title { get; set; } = Empty;
    public string? Mode { get; set; } = Empty;
}