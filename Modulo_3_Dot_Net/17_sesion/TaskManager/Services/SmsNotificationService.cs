using System.Diagnostics;
using TaskManager.Models;

namespace TaskManager.Services
{

    public class SmsNotificationService : NotificationService
    {

        public SmsNotificationService() : base("Gestor de tareas") { }

        public override Task NotifyTaskCreatedAsync(TaskItem task)
        {
            //Aqui se manda el sms
            Console.WriteLine($"[SMS] {SenderName}: Nueva tarea '{task.Title}'");
            return Task.CompletedTask;
        }
        
    }

}