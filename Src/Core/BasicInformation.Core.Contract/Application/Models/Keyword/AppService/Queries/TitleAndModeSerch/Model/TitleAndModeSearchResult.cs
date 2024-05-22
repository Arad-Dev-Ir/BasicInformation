namespace BasicInformation.Core.Keyword.Contracts;

using Swan.Core.Models;

public class TitleAndModeSearchResult : Model
{
    public long Id { get; set; }
    public Guid Code { get; set; }
    public string Title { get; set; } = Empty;
    public string Mode { get; set; } = Empty;
}