using System;
namespace Project8
{
    public class Report
    {
        public string text;
        public Worker worker;
        public Report(Worker worker, string text)
        {
            this.worker = worker;
            this.text = text;
        }
        public static Report CreateReport(Worker worker)
        {
            Console.WriteLine("Напишите отчет");
            string text = Console.ReadLine();
            Task.StatusReport(worker);
            return new Report(worker, text);
        }
        public void Print()
        {
            Console.WriteLine($"{text}");
        }
    }
}
