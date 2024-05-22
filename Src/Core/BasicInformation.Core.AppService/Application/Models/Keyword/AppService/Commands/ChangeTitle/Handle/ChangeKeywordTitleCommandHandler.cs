﻿namespace BasicInformation.Core.Keyword.AppServices;

using Swan.Core;
using Swan.Web.Core.AppService;
using Swan.Web.Core.Contract;
using Contracts;

public class ChangeKeywordTitleCommandHandler : CommandHandler<ChangeKeywordTitle>
{
    private readonly IKeywordCommandRepository _repo;
    private readonly IUnitOfWork _unitOfWork;

    public ChangeKeywordTitleCommandHandler(IKeywordCommandRepository repo, IUnitOfWork unitOfWork)
    {
        _repo = repo;
        _unitOfWork = unitOfWork;
    }

    private void Initialize()
    { }

    public override async Task<CommandResponse> ExecuteAsync(ChangeKeywordTitle command)
    {
        var result = Response;
        var id = command.Id;
        var keyword = await _repo.GetGraphAsync(id);
        await keyword.IsNull(
        async () =>
        {
            AddMessage($"There is not any entity with Id: {id}.");
            result = await SetResponseAsync(ServiceStatus.NotFound);
        },
        async () =>
        {
            keyword.ChangeTitle(command.Title);
            await _unitOfWork.SaveAsync();
            result = await OkAsync();
        });
        return result;
    }
}
