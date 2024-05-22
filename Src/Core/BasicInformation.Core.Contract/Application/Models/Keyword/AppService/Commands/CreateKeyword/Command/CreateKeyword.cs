namespace BasicInformation.Core.Keyword.Contracts;

using Swan.Web.Core.Contract;

public class CreateKeyword : Command<long>
{
    public string Title { get; set; } = Empty;
}