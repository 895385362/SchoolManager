using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace S1mple_SchoolManager.Common
{
    /// <summary>
    /// Cookie辅助类 
    /// 2016-07-14 14:02:26 
    /// Eric
    /// </summary>
    public class CookieHelper
    {
        /// <summary>
        /// cookie前缀
        /// </summary>
        private const string _prevFix = "Admin_";

        #region 添加一个Cookie
        /// <summary>  
        /// 添加一个Cookie
        /// 2016-07-14 14:04:40
        /// Eric
        /// </summary>  
        /// <param name="cookiename">cookie名</param>  
        /// <param name="cookievalue">cookie值</param>  
        /// <param name="expires">过期时间 DateTime</param>  
        public static void SetCookie(string cookiename, string cookievalue, DateTime expires)
        {
            HttpCookie cookie = new HttpCookie(_prevFix + cookiename)
            {
                Value = HttpUtility.UrlEncode(cookievalue),
                Expires = expires
            };
            HttpContext.Current.Response.Cookies.Add(cookie);
        }
        #endregion

        #region 清除指定Cookie
        /// <summary>  
        /// 清除指定Cookie  
        /// 2016-07-14 14:05:10
        /// Eric
        /// </summary>  
        /// <param name="cookiename">cookiename</param>  
        public static void ClearCookie(string cookiename)
        {
            HttpCookie cookie = HttpContext.Current.Request.Cookies[_prevFix + cookiename];
            if (cookie != null)
            {
                cookie.Expires = DateTime.Now.AddYears(-3);
                HttpContext.Current.Response.Cookies.Add(cookie);
            }
        }
        #endregion

        #region 获取指定Cookie值
        /// <summary>  
        /// 获取指定Cookie值  
        /// 2016-07-14 14:05:48
        /// Eric
        /// </summary>  
        /// <param name="cookiename">cookiename</param>  
        /// <returns></returns>  
        public static string GetCookieValue(string cookiename)
        {
            HttpCookie cookie = HttpContext.Current.Request.Cookies[_prevFix + cookiename];
            string str = string.Empty;
            if (cookie != null)
            {
                str = HttpUtility.UrlDecode(cookie.Value);
            }
            return str;
        }
        #endregion
    }
}
