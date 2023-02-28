using MediatR;

namespace BankAccount.CQRS.DataAccess.Notificaitons;

public class ServiceBusEvent : INotification
{
    public string Message { get; set; }
}

public class EventHubEvent : INotification
{
    public int Number { get; set; }
}

public class ServiceBusEventHandler : INotificationHandler<ServiceBusEvent>
{
    public Task Handle(ServiceBusEvent notification, CancellationToken cancellationToken)
    {
        // Handle the Event1 notification
        Console.WriteLine($"Event1 handled: {notification.Message}");
        return Task.CompletedTask;
    }
}

public class EventHubEventHandler : INotificationHandler<EventHubEvent>
{
    public Task Handle(EventHubEvent notification, CancellationToken cancellationToken)
    {
        // Handle the Event2 notification
        Console.WriteLine($"Event2 handled: {notification.Number}");
        return Task.CompletedTask;
    }
}
