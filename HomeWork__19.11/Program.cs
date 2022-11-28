
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace Project8
{
    class Program
    {
        static void Main(string[] args)
        {
            Employer employer = new Employer("Линус", "Торвальдс");
            int count_workers = 10;
            List<Worker> workers = new List<Worker>(count_workers)
            {
                new Worker("Дмитрий ", "Тумаков"),
                new Worker("Аделя", "Гильфанова"),
                new Worker("Диана", "Хамидуллина"),
                new Worker("Мария", "Мошкина"),
                new Worker("Карина", "Хузина"),
                new Worker("Мария", "Головина"),
                new Worker("Элина", "Галимова"),
                new Worker("Илья", "Братухин"),
                new Worker("Илья", "Романов"),
                new Worker("Камиль", "Ахметзянов")
            };
            Customer customer = new Customer("Tatneft");
            List<Task> tasks = new List<Task>(count_workers)
            {
                new Task("Сделать проектирование программы", employer),
                new Task("Выполнить тестирование и отладку", employer),
                new Task("Выполнить анализ требований", employer),
                new Task("Сделать сортировку!", employer),
                new Task("Оптимозировать работу программу", employer),
                new Task("Создать черновик программы", employer),
                new Task("Протестировать всю систему", employer),
                new Task("Поддерживать всех работающих", employer),
                new Task("Выработать требование к программе", employer),
                new Task("Сделать корректировку кода и утвердить его", employer)
            };
            DateTime deadline = Task.dat();
            Project project = new Project("Написать крутую программу", deadline, employer, customer);
            project.AddTasksInProject(tasks);
            Worker.GiveTask(workers, tasks);
            Console.ReadKey();
            Console.Clear();
            Console.WriteLine("Задачи назначены, время сдавать отчеты");
            DateTime date = DateTime.Now;
            double delay = 0;
            for (int i = 0; i < 12; i++)
            {
                Console.WriteLine($"\tОтчеты за {i + 1}-й месяц");
                date = date.AddMonths(1);
                for (int j = 0; j < workers.Count; j++)
                {
                    Console.WriteLine($"Работнику {workers[j].name} была дана задача <<{workers[j].Task.description}>>");
                    Report report = Report.CreateReport(workers[i]);
                    Console.WriteLine($"Утверждает ли инициатор отчёт сотрудника: {workers[j].Print()}");
                    Console.WriteLine("Отчёт:");
                    report.Print();
                    string answer = Console.ReadLine().ToLower();
                    while (!answer.Equals("да") && !answer.Equals("нет"))
                    {
                        Console.WriteLine("Повторите ввод");
                        answer = Console.ReadLine();
                    }

                    if (answer.Equals("да"))
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine($"Отчет на {i + 1}-й месяц принят");
                        Console.ResetColor();
                        Task.CloseTask(workers[j]);
                        Console.WriteLine($"\t{workers[j].name} {workers[j].surname} отправил/a отчёт. \nСтатус задачи на текущий месяц - {workers[i].Task.status}. \nДата выполнения: {date}.\nДата дедлайна на текущий месяц - {date}");
                        Console.WriteLine();
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine($"Отчет на {i + 1}-й месяц не завершен");
                        Console.ResetColor();
                        Report reportnew = Report.CreateReport(workers[i]);
                        reportnew.Print();
                        Console.WriteLine("Сколько дней ушло на доработку?");
                        double overdue;
                        while (!double.TryParse(Console.ReadLine(), out overdue))
                        {
                            Console.WriteLine("Неверный ввод");
                        }

                        delay += overdue;
                        Task.CloseTask(workers[j]);
                        Console.WriteLine($"\t{workers[j].name} {workers[j].surname} отправил/a отчёт. \nСтатус задачи на текущий месяц - {workers[i].Task.status}. \nДата выполнения: {date + TimeSpan.FromDays(overdue)}.\nДата дедлайна на текущий месяц - {date}");

                    }
                }
                for (int a = 0; a < workers.Count; a++)
                {
                    Task.OpenTask(workers[a]);
                }
                Console.Clear();
            }
            project.CloseProject(date + TimeSpan.FromDays(delay), deadline);
        }
    }
}
