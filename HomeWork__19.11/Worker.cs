using System;
namespace Project8
{
    public class Worker
    {
        public string name;
        public string surname;
        public Task task;
        public Task Task
        {
            get { return task; }
        }
        public Worker(string name, string surname)
        {
            this.name = name;
            this.surname = surname;
        }
        public string Print()
        {
            return $"{name}, {surname}";
        }
        public static void GiveTask(List<Worker> workers, List<Task> tasks)
        {
            var temp = new List<Task>();
            temp.AddRange(tasks);
            foreach (var worker in workers)
            {
                for (int i = 0; i < temp.Count; i++)
                {
                    Console.WriteLine("Задача:");
                    temp[i].Print();
                    Console.WriteLine("Сотрудник:");
                    Console.WriteLine(worker.Print());
                    Console.WriteLine("Берет ли сотрудник задачу? (Да/Нет)");
                    string answer = Console.ReadLine().ToLower();
                    while (!answer.Equals("да") && !answer.Equals("нет"))
                    {
                        Console.WriteLine("Повторите ответ");
                        answer = Console.ReadLine();

                    }
                    if (answer.Equals("да") || i == temp.Count - 1)
                    {
                        worker.task = temp[i];
                        Task.ChangeTheStatus(worker, temp[i]);
                        Console.WriteLine("Сотрудник получил задачу");
                        temp.Remove(temp[i]);
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Что выберет тимлид? 1) Отклонить 2) Удалить задание 3) Дать задание другому ");
                        string comm = Console.ReadLine();
                        switch (comm)
                        {
                            case "1":
                                {
                                    Console.WriteLine("Тимлид отклонил запрос, задача остается прежней");
                                    break;
                                }
                            case "2":
                                {
                                    tasks.Remove(worker.task);
                                    worker.task = null;
                                    break;
                                }
                            case "3":
                                {
                                    Console.WriteLine("Выберите другую задачу");
                                    break;
                                }
                        }
                    }
                }
            }
        }

    }
}
