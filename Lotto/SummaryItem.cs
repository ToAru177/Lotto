using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lotto
{
    public class SummaryItem
    {
        /// <summary>
        /// 등수
        /// </summary>
        public int Grade { get; set; }

        /// <summary>
        /// 당첨 횟수
        /// </summary>
        public int Count { get; set; }

        // 상금의 단위가 int형을 넘어서서 long 사용

        /// <summary>
        /// 당첨금 합계
        /// </summary>
        public long Amount { get; set; }
    
    }
}
