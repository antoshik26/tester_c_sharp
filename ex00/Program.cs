using System;


    class Program
    {
        static void Main(string[] args)
        {
            double  sum;
            double rate;
            int     term;
            int     selectedMonth;
            double  payment;
            double  a;
            double  Percentages;
            double  payment_per_month;
            double  overpayment_1;
            double  overpaymeny_2;
            int     i;

            overpayment_1 = 0;
            overpaymeny_2 = 0;
            
            if ((args.Length > 6) || (args.Length < 6))
            {
                Console.WriteLine("Ошибка ввода. Проверьте входные данные и повторите запрос.");
                Environment.Exit(-1);
            }
            for (i = 1; i < args.Length; i++)
            {
                foreach(var simvol in args[i])
                {
                    if (!char.IsDigit(simvol))
                    {
                        Console.WriteLine("Ошибка ввода. Проверьте входные данные и повторите запрос.");
                        Environment.Exit(-1);
                    }
                }
            }
            sum = Convert.ToDouble(args[1]);
            rate = Convert.ToDouble(args[2]);
            term = Convert.ToInt32(args[3]);
            selectedMonth = Convert.ToInt32(args[4]);
            payment = Convert.ToDouble(args[5]);
            a = rate / 12 / 100;
            payment_per_month = (sum * a * (Math.Pow((1 + a), term))) / ((Math.Pow((1 + a), term)) - 1);
            Console.WriteLine(payment_per_month);
            i = 1;
            while (i <= term)
            {
                Console.WriteLine(i);
                if (i == selectedMonth)
                {
                    sum = sum - payment;
                    a = rate / 12 / 100;
                    payment_per_month = (sum * a * (Math.Pow((1 + a), (6)))) / ((Math.Pow((1 + a), (6))) - 1);
                    Console.WriteLine(payment_per_month);
                }
                Percentages = (sum * rate * DateTime.DaysInMonth(2021, i)) / (100 * 365);
                Console.WriteLine(Percentages);
                overpayment_1 = overpayment_1 + Percentages;
                sum = sum - payment_per_month;
                i++;
            }
            Console.WriteLine("Переплата при уменьшении платежа: {0}p.", overpayment_1);
            sum = Convert.ToDouble(args[1]);
            rate = Convert.ToDouble(args[2]);
            term = Convert.ToInt32(args[3]);
            selectedMonth = Convert.ToInt32(args[4]);
            payment = Convert.ToDouble(args[5]);
            a = rate / 12 / 100;
            payment_per_month = (sum * a * (Math.Pow((1 + a), term))) / ((Math.Pow((1 + a), term)) - 1);
            i = 1;
            while (sum >= 0)
            {   
                Console.WriteLine(i);
                if (i == selectedMonth)
                {
                    sum = sum - payment;
                }
                Percentages = (sum * rate * DateTime.DaysInMonth(2021, i)) / (100 * 365);
                Console.WriteLine(Percentages);
                overpaymeny_2 = overpaymeny_2 + Percentages;
                sum = sum - payment_per_month;
                i++;
            }
            Console.WriteLine("Переплата при уменьшении платежа: {0}p.", overpaymeny_2);
            if (overpayment_1 > overpaymeny_2)
            {
                Console.WriteLine($"Уменьшение платежа выгоднее уменьшения срока на {overpayment_1 - overpaymeny_2}.");
            }
            else
            {
                Console.WriteLine($"Уменьшение срока выгоднее уменьшения платежа на {overpaymeny_2 - overpaymeny_1}.");
            }
            if (overpayment_1 == overpaymeny_2)
            {
                Console.WriteLine("Переплата одинакова в обоих вариантах.");
            }
        }
    }