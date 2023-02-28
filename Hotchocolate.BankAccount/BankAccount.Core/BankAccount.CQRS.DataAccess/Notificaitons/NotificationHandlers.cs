using MediatR;

namespace BankAccount.CQRS.DataAccess.Notificaitons;

public class Event1 : INotification
{
    public string Message { get; set; }
}

public class Event2 : INotification
{
    public int Number { get; set; }
}

public class Event1Handler : INotificationHandler<Event1>
{
    public Task Handle(Event1 notification, CancellationToken cancellationToken)
    {
        // Handle the Event1 notification
        Console.WriteLine($"Event1 handled: {notification.Message}");
        return Task.CompletedTask;
    }
}

public class Event2Handler : INotificationHandler<Event2>
{
    public Task Handle(Event2 notification, CancellationToken cancellationToken)
    {
        // Handle the Event2 notification
        Console.WriteLine($"Event2 handled: {notification.Number}");
        return Task.CompletedTask;
    }
}
