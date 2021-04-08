using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace S1mple_SchoolManager.Common
{
    public class TimeHelper
    {
        /// <summary>
        /// 获取1970-01-01至dateTime的毫秒数
        /// </summary>
        public long GetTimestamp(DateTime dateTime)
        {
            DateTime dt1970 = new DateTime(1970, 1, 1, 0, 0, 0, 0);
            return (dateTime.Ticks - dt1970.Ticks) / 10000;
        }

        /// <summary>
        /// 根据时间戳timestamp（单位毫秒）计算日期
        /// </summary>
        public DateTime NewDate(long timestamp)
        {
            DateTime dt1970 = new DateTime(1970, 1, 1, 0, 0, 0, 0);
            long t = dt1970.Ticks + timestamp * 10000;
            return new DateTime(t);
        }
    }
}
