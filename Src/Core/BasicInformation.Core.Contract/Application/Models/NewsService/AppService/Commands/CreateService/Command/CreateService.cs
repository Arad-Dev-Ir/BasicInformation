namespace BasicInformation.Core.NewsService.Contracts;

using Swan.Web.Core.Contract;

public class CreateService : Command<long>
{
    public string Title { get; set; } = Empty;
    public string Name { get; set; } = Empty;
}