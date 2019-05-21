using LottoLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
    1. lotto.txt 파일(859회차까지의 정보 저장된 파일)을 읽어와 Round 클래스의 객체에 저장
    2. 6개의 숫자를 입력 받는다. 
*/

namespace Lotto
{
    class Program
    {


        static void Main(string[] args)
        {
            List<Round> rounds = Round.Load(@"D:\IoT\C#\Lotto\lotto.txt");
            //List<Round> rounds = Round.Load(@"C:\Users\USER\Desktop\Git\Lotto\lotto.txt");
            List<int> numbers = new List<int>();
            while (true)
            {
                // 6개의 숫자를 입력 받는 것
                Console.Write("1 ~ 45 사이 숫자 6개 입력 : ");
                string input = Console.ReadLine();
                // 공백(스페이스)을 기준으로 단어(입력 받은 수)를 나누어 tokens 배열에 각각 저장
                string[] tokens = input.Split(' ');

                // 함수 구현 하기
                //numbers = GetInputNumbers();
                numbers = tokens.Select(x => int.Parse(x)).ToList();

                //var numbersCheck = from number in numbers
                //                   where number < 1 || number > 45
                //                   select number;

                // 람다식 변환
                var numbersCheck = numbers.Where(number => number < 1 || number > 45).Select(number => number);


                if (numbersCheck.Count() == 0 && numbers.Count() == 6)
                    break;

                Console.WriteLine("조건에 맞게 다시 입력하세요...");

            }

            // lotto 구매 정보 저장
            List < Purchase > purchases = new List<Purchase>(rounds.Count);

            foreach (Round round in rounds)
            {
                Purchase purchase = new Purchase();
                purchase.No = round.No;
                purchase.Calculate(numbers, round);
                purchases.Add(purchase);
            }

            var query = from x in purchases
                        group x by x.Grade into g
                        select new SummaryItem { Grade = g.Key, Count = g.Count(), Amount = g.Sum(p => p.Prize) };

            List<SummaryItem> summaryItems = query.ToList();

            summaryItems.RemoveAll(x => x.Grade == 0);
            /*
            List<SummaryItem> summaryItems = new List<SummaryItem>();

            for (int i = 0; i < 5; i++)
            {
                List<Purchase> list = purchases.FindAll(x => x.Grade == i + 1);
                // Grade 생성
                SummaryItem item = new SummaryItem();

                item.Grade = i + 1;
                item.Count = list.Count;
                item.Amount = list.Sum(x => x.Prize);

                summaryItems.Add(item);
            }
            */

            // 내부 join
            //var lottoResultList = from purchase in purchases
            //                      join grade in grades on purchase.Grade equals grade.No
            //                      select new { No = grade.No, Prize = purchase.Prize };


            /*
            // 내부 join 람다식으로 변환
            var lottoResultList = purchases.Join(summaryItems,
                                                    purchase => purchase.Grade,
                                                    item => item.Grade,
                                                    (purchase, item) => new { No = item.Grade, Prize = purchase.Prize });


            //var lottoResultList = from purchase in purchases
            //                      from grade in grades
            //                      where purchase.Grade == grade.No
            //                      select new { No = purchase.Grade, Prize = purchase.Prize };

            
            foreach (var lottoResult in lottoResultList)
            {
                foreach (SummaryItem item in summaryItems)
                {
                    if (lottoResult.No == item.Grade)
                    {
                        item.Count++;
                        item.Amount += lottoResult.Prize;
                    }
                }
            }
            */

            foreach(var item in summaryItems)
                Console.WriteLine($"[{item.Grade}]등 : {item.Count}회, {item.Amount:C0}");


            int totalPurchaseAmount = purchases.Count * 1000;
            Console.WriteLine($"총 구매금액 : {totalPurchaseAmount:C0}");
            // purchases의 1등, 2등, 3등, 4등, 5등의 총 당첨금들의 합
            //long totalPrize = 0;
            //foreach (SummaryItem item in summaryItems)
            //    totalPrize += item.Amount;

            long totalPrize = summaryItems.Sum(x => x.Amount);


            Console.WriteLine($"총 당첨금액 : {totalPrize:C0}");

            //double rateOfReturn = (double)(totalPrize - totalPurchaseAmount) / (double)totalPrize;
            double rateOfReturn = (double)(totalPrize - totalPurchaseAmount) / (double)totalPurchaseAmount;
            // 수익률???
            //double rateOfReturn = (double)(totalPrize) / (double)totalPurchaseAmount;

            Console.WriteLine($"수익률 : {rateOfReturn:P2}");

            Console.WriteLine();
        }
    }
}
