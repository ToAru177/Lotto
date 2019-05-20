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
            Grade = 1;
            Prize = 2_200_000_000;
        }

    }
}
