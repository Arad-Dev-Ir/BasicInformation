namespace BasicInformation.Endpoint.Service.APIs;

using Microsoft.AspNetCore.Mvc;
using Swan.Web.Endpoint.API;
using Core.NewsService.Contracts;

[Route("api/[controller]")]
public class ServiceController : ApiController
{
    [HttpPost("create-new-service")]
    public async Task<IActionResult> Post(CreateNewsService command)
    => await Create<CreateNewsService, long>(command);
}