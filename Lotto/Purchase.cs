using LottoLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lotto
{
    public class Purchase
    {
        public int No { get; set; }

        /// <summary>
        /// 등수
        /// </summary>
        public int Grade { get; set; }

        //public Grade grade;

        /// <summary>
        /// 당첨금액
        /// </summary>
        public long Prize { get; set; }

        /// <summary>
        /// 당첨금액을 계산하는 메서드
        /// </summary>
        /// <param name="numbers"></param>
        /// <param name="round"></param>
        public void Calculate(List<int> numbers, Round round)
        {
            //ex
            /*
            Grade = 1;
            Prize = 2_200_000_000;
            */


            // 일치하는 번호 갯수 구하기 LINQ 구현
            var winningNumbers = from number in numbers
                                 from roundNumber in round.Numbers
                                 where number == roundNumber
                                 select new { winnigNumber = number };

            var bonusNumber = from number in numbers
                              where number == round.Bonus
                              select new { bonusNumber = number };
            // 당첨 번호와 일치하는 번호의 개수
            int countOfWinningNumber = winningNumbers.Count();
            // 보너스 번호와 일치하는 번호의 개수
            int countOfBonusNumber = bonusNumber.Count();
            
             if (countOfWinningNumber == 6)
            {
                Grade = 1;
                Prize = round.FirstPrize;
            }
            else if ((countOfWinningNumber + countOfBonusNumber) == 6)
            {
                Grade = 2;
                Prize = round.SecondPrize;
            }
            else if (countOfWinningNumber == 5)
            {
                Grade = 3;
                Prize = round.ThirdPrize;
            }
            else if (countOfWinningNumber == 4)
            {
                Grade = 4;
                Prize = 50000;
            }
            else if (countOfWinningNumber == 3)
            {
                Grade = 5;
                Prize = 5000;
            }

        }

    }
}
