using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace S1mple_SchoolManager.Entity
{
    public class Page<T>
    {
        public Page(IList<T> t, int pageIndex, int pageSize, int totalItemCount)
        {
            PageList = t;
            PageSize = pageSize;
            PageIndex = pageIndex;
            TotalItemCount = totalItemCount;
        }

        public Page(IList<T> t, int totalItemCount)
        {
            PageList = t;
            PageSize = 0;
            PageIndex = 0;
            TotalItemCount = totalItemCount;
        }

        /// <summary>
        /// 当前页数据集
        /// </summary>
        public IList<T> PageList { get; set; }
        /// <summary>
        /// 每页多少条
        /// </summary>
        public int PageSize { get; set; }
        /// <summary>
        /// 当前页数
        /// </summary>
        public int PageIndex { get; set; }
        /// <summary>
        /// 总条数
        /// </summary>
        public int TotalItemCount { get; set; }
    }
}