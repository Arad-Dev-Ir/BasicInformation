namespace BasicInformation.Core.Keyword.Contracts;

using Swan.Web.Core.Contract;

public class DeactivateKeyword : Command
{
    public long Id { get; set; }
}