
using System;
namespace Project8
{
    public enum Status_task
    {
        Назначена,
        В_работе,
        На_проверке,
        Выполнена
    }
    public class Task
    {
        public string description;
        public DateTime date;
        public Employer employer;
        public Worker worker;
        public Status_task status;
        public Task(string description, Employer employer)
        {
            this.description = description;
            this.employer = employer;
            status = Status_task.Назначена;

        }

        public Worker Worker
        {
            get { return worker; }
            set { worker = value; }
        }
        public static DateTime dat()
        {
            return new DateTime(2024, 1, 1);
        }
        public static void ChangeTheStatus(Worker worker, Task task)
        {
            if (worker.Task != null && worker.Task.status == Status_task.Назначена)
            {
                worker.Task.status = Status_task.В_работе;
                task.Worker = worker;
            }
        }
        public void Print()
        {

            Console.WriteLine($"Задача: {description}. Дедлайн: {dat()}");
        }

        public static void StatusReport(Worker worker)
        {
            if (worker.Task.status == Status_task.В_работе)
            {
                worker.Task.status = Status_task.На_проверке;
            }
        }
        public static void OpenTask(Worker worker)
        {
            if (worker.Task.status == Status_task.Выполнена)
            {
                worker.Task.status = Status_task.На_проверке;
            }
        }
        public static void CloseTask(Worker worker)
        {
            if (worker.Task.status == Status_task.На_проверке)
            {
                worker.Task.status = Status_task.Выполнена;
            }
        }
    }
}
