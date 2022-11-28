using System;
namespace Project8
{ 
    public enum Status_project
    {
        Проект, В_процессе, Выполнено
    }
    public class Project
    {
        public string description;
        public DateTime deadline;
        public Customer customer;
        List<Task> tasks;
        public Status_project status;
        public Project(string description, DateTime deadline, Employer employer, Customer customer)
        {
            this.description = description;
            this.deadline = deadline;
            status = Status_project.Проект;

        }

        public void AddTasksInProject(List<Task> tasks)
        {
            if (tasks != null && this.tasks != null)
            {
                this.tasks = tasks;
            }
        }
        public void CloseProject(DateTime date, DateTime deadline)
        {
            status = Status_project.Выполнено;
            Console.WriteLine($"Дата начала работы над проектом:{DateTime.Now}\nДата окончания работы над проектом:{date}\nДедлайн по проекту:{deadline}");
            if (date > deadline)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Проект просрочен");
                Console.ResetColor();

            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Проект успешно завершен, вы богаты!!");
                Console.ResetColor();
            }
        }
    }
}
