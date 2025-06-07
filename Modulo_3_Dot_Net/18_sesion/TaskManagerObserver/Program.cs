/*
using Microsoft.AspNetCore.SignalR.Client;
using TaskManager.Shared.Events;

var connection = new HubConnectionBuilder()
    .WithUrl("http://localhost:5080/taskEvents")
    .Build();

connection.On<TaskEvent>("TaskEvent", ev =>
{
    Console.WriteLine($"{ev.EventName}: {ev.Payload.Title}");
});

await connection.StartAsync();
Console.WriteLine("Observando eventos...");
await Task.Delay(Timeout.Infinite);
*/

using Domain;
using Intraestructure;
using Subscribers;

var bus = new EventBus();
var repo = new TaskRepository(bus);

bus.Subscribe(new EmailNotifier());
bus.Subscribe(new SmsNotifier());
bus.Subscribe(new ConsoleUI());

var task1 = repo.Add(new TaskItem { Title = "Aprender Patron observer" });

var task2 = repo.Add(new TaskItem { Title = "Conectar" });


task1.Complete();
repo.Update(task1);

repo.Delete(task2.id);