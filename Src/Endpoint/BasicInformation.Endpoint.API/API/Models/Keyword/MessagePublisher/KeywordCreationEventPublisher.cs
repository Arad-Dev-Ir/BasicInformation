﻿namespace BasicInformation.Endpoint.News.APIs;

using Microsoft.EntityFrameworkCore;
using RabbitMQ.Client;
using Swan.Core;
using Swan.Web.Data.Sql.Command;
using Data.Sql.Commands;

public class KeywordCreationEventPublisher : BackgroundService
{
    private readonly IServiceProvider _serviceProvider;
    private readonly BasicInformationCommandContext _context;
    private readonly IModel model;
    private const string exchangeName = "Cloudio";
    private readonly string key = $"{exchangeName}.BasicInformation.Event.{{0}}";

    public KeywordCreationEventPublisher(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
        var host = "localhost";
        var connection = new ConnectionFactory { HostName = host }.CreateConnection();
        model = connection.CreateModel();
        model.ExchangeDeclare(exchangeName, ExchangeType.Topic, false, true, null);
        var scope = _serviceProvider.CreateScope();
        _context = scope.ServiceProvider.GetRequiredService<BasicInformationCommandContext>();
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        while (!stoppingToken.IsCancellationRequested)
        {
            var events = await _context.Events.Where(e => e.Mode == ProcessMode.Raised).Take(100).ToListAsync();
            if (events.Any())
            {
                foreach (var item in events)
                {
                    var routeKey = String.Format(key, item.Name);
                    var data = item.Data.UTF8GetBytes();
                    model.BasicPublish(exchangeName, routeKey, null, data);
                    item.Mode = ProcessMode.Registered;
                }
                _context.SaveChanges();
            }
            await Task.Delay(3000, stoppingToken);
        }
    }
}