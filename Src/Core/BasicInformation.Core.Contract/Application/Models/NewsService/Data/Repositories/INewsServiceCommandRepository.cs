﻿namespace BasicInformation.Core.NewsService.Contracts;

using Models;

public interface INewsServiceCommandRepository
{
    Task AddAsync(NewsService entity);
}