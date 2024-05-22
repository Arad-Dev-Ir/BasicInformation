namespace BasicInformation.Core.Keyword.Contracts;

using Swan.Web.Core.Contract;

public class ChangeKeywordTitle : Command
{
    public long Id { get; set; }
    public string Title { get; set; } = Empty;
}