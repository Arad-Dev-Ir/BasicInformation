namespace BasicInformation.Core.Keyword.Contracts;

using Swan.Core.Models;
using Keyword = Models.Keyword;

public interface IKeywordCommandRepository
{
    Task<Keyword> GetGraphAsync(Id id);
    Task AddAsync(Keyword entity);
    void Add(Keyword entity);
}