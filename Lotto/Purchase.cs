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

            // 당첨 번호와 일치하는 번호의 개수
            int countOfWinningNumber = 0;
            // 보너스 번호와 일치하는 번호의 개수
            int countOfBonusNumber = 0;

            for (int i = 0; i < numbers.Count(); i++)
            {
                for (int j = 0; j < numbers.Count(); j++)
                {
                    if (numbers[i] == round.Numbers[j])
                        countOfWinningNumber++;
                }

                if (numbers[i] == round.Bonus)
                    countOfBonusNumber++;
            }

            if (countOfBonusNumber == 6)
                Prize = round.FirstPrize;
            else if ((countOfBonusNumber + countOfBonusNumber) == 6)
                Prize = round.SecondPrize;
            else if (countOfWinningNumber == 5)
                Prize = round.ThirdPrize;
            else if (countOfWinningNumber == 4)
                Prize = 50000;
            else if (countOfWinningNumber == 3)
                Prize = 5000;
                 

        }

    }
}
