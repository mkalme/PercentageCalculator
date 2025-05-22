using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Diagnostics;

namespace PercentageCalculator
{
    class Program
    {
        public static Double[] array;

        static void Main(string[] args)
        {
            createBase();

            Console.WriteLine("Calculated percentage: " + calculatePercentage() + "%\n");

            Console.Write("Original deposit: ");
            Double deposit = Double.Parse(Console.ReadLine().Replace(".", ","));

            Console.Write("Monthly deposit: ");
            Double monthlyDeposit = Double.Parse(Console.ReadLine().Replace(".", ","));

            Console.Write(calculateAccumulation(deposit, monthlyDeposit));
            cont();
        }

        public static void cont() {
            Console.ReadLine();
            cont();
        }

        public static String calculateAccumulation(Double deposit, Double monthlyDeposit){
            Double amount = deposit;
            for (int i = 0; i < array.Length; i++)
            {
                amount = (amount + monthlyDeposit) * array[i];
            }

            return "Calculated amount: " + Math.Round(amount, 2) + " || Number of months: " + array.Length;

        }

        public static String calculatePercentage() {
            String text = File.ReadAllText(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + @"\percent.txt").Replace("%", "").Replace(".", ",");
            array = Array.ConvertAll(text.Split(new string[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries), Double.Parse);

            for (int i = 0; i < array.Length; i++)
            {
                array[i] = (array[i] / 100) + 1;
            }
            Double totalNumber = 1;
            for (int i = 0; i < array.Length; i++)
            {
                totalNumber *= array[i];
            }

            return Math.Round((totalNumber - 1) * 100, 5).ToString();
        }

        static void createBase()
        {
            String path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + @"\percent.txt";
            if (!File.Exists(path))
            {
                using (var tw = new StreamWriter(path, true))
                {
                    tw.WriteLine();
                }
            }
        }
    }
}
