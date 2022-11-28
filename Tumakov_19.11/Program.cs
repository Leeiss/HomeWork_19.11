using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project7
{
    enum AccountType
    {
        Current,
        Savings
    }
    class Bank
    {
        public Bank(string accountNumber, double balans, AccountType type)
        {
            AccountNumber = accountNumber;
            Balans = balans;
            Type = type;
        }
        public string AccountNumber { get; set; }
        public double Balans { get; set; }
        public AccountType Type { get; set; }
        public override string ToString() => $"Номер счета - {AccountNumber}, Баланс - {Balans}, Тип банковского счета - {Type}";

        public double PutOnAccount(double Balans)
        {
            Console.Write("Введите сумму для пополнения ");
            double temp = Convert.ToDouble(Console.ReadLine());
            return Balans + temp;
        }
        public double WithdrawFromAccount(double Balans)
        {
            Console.Write("Введите сумму для снятия ");
            double temp = Convert.ToDouble(Console.ReadLine());
            if (Balans >= temp)
            {
                return Balans - temp;
            }
            else
            {
                Console.WriteLine("На вашем счёте недостаточно средств!");
                return Balans;
            }
        }
        public void moneytransfer(Bank Bank, int amount)
        {
            this.Balans -= amount;
            Bank.Balans += amount;
        }

    }
    public static class StringExtension
    {
        public static string Reverse(this string str)
        {
            string res = string.Empty;
            for (int i = str.Length - 1; i >= 0; --i)
                res += str[i];
            return res;
        }
    }
    public class Temperature : IFormattable
    {
        private decimal temp;

        public Temperature(decimal temperature)
        {
            if (temperature < -273.15m)
                throw new ArgumentOutOfRangeException(String.Format("{0} is less than absolute zero.",
                                                    temperature));
            this.temp = temperature;
        }

        public string ToString(string format, IFormatProvider provider)
        {
            return temp.ToString("F2", provider) + " °C";
        }
    }

    class Program
    {
        static void checkArgImplementInterface(Temperature t)
        {
            IFormattable form, form2;

            if (t is IFormattable)
            {
                form = (IFormattable)t;
            }
            else
            {
                form = null;
            }

            if (form is null)
            {
                Console.WriteLine("Не реализует IFormattable");
            }
            else
            {
                Console.WriteLine("Реализует IFormattable");
            }

            form2 = t as IFormattable;

            if (form2 is null)
            {
                Console.WriteLine("Не реализует IFormattable");
            }
            else
            {
                Console.WriteLine("Реализует IFormattable");
            }
        }
        static void Main()
        {
            Console.WriteLine("Упражнение8.1");
            AccountType accountType = AccountType.Current;
            Bank bank1 = new Bank("764HGS78", 1000, AccountType.Savings);
            Bank bank2 = new Bank("386vfb3", 2000, AccountType.Current);
            Console.WriteLine("Какую сумму хотите перевести из первого банка во второй?");
            int monney = Convert.ToInt32(Console.ReadLine());
            bank1.moneytransfer(bank2, monney);
            Console.WriteLine(bank1);
            Console.WriteLine(bank2);
            Console.ReadKey();

            Console.WriteLine("\nУпражнение8.2");
            string s = "фбвгдежзимнклн";
            Console.WriteLine($"Изначальная строка: {s}\nПеревернутая: {s.Reverse()}");

            Console.WriteLine("\nУпражнение8.3");
            const string outputFileName = "ResultText.out";
            string inputFileName = string.Empty;

            Console.WriteLine("Введите название входного файла: ");
            inputFileName = Console.ReadLine();

            if (File.Exists(inputFileName))
            {
                File.WriteAllText(outputFileName, File.ReadAllText(inputFileName, Encoding.UTF8).ToUpper(), Encoding.UTF8);
                Console.WriteLine("Результат успешно записан в файл с именем \"{0}\"", outputFileName);
            }
            else
            {
                Console.WriteLine("Файл с именем \"{0}\" не найден!", inputFileName);
            }

            Console.ReadKey();

            Console.WriteLine("Упражнение8.4");
            Temperature t = new Temperature(50);
            checkArgImplementInterface(t);
        }
    }

}
