using LottoLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lotto
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Round> rounds = Round.Load(@"D:\IoT\C#\Lotto\lotto.txt");

            Console.Write("1 ~ 45 사이 숫자 6개 입력 : ");
            string input = Console.ReadLine();
            string[] tokens = input.Split(' ');

            //List<int> numbers = new List<int>();
            //foreach(string token in tokens)
            //{
            //    int number = int.Parse(token);
            //    numbers.Add(number);
            //}

            List<int> numbers = tokens.Select(x => int.Parse(x)).ToList();

            List<Purchase> purchases = new List<Purchase>(rounds.Count);
            foreach (Round round in rounds)
            {
                Purchase purchase = new Purchase();
                purchase.Calculate(numbers, round);
                purchases.Add(purchase);
            }

            List<Grade> grades = new List<Grade>();

            for (int i = 0; i < 5; i++)
            {
                // Grade 생성
                Grade grade = new Grade();

                grade.No = i + 1;

                grades.Add(grade);
            }

            foreach(Grade grade in grades)
            {
                Console.WriteLine($"[{grade.No}]등 : {grade.Count}회, {grade.Amount:C0}");
            }



            Console.WriteLine($"총 구매금액 : {purchases.Count * 1000:C0}");
            // purchases의 1등, 2등, 3등, 4등, 5등의 총 당첨금들의 합
            Console.WriteLine($"총 당첨금액 : {0:C0}");
            Console.WriteLine($"수익률 : {0:P2}");

            Console.WriteLine();
        }
    }
}
