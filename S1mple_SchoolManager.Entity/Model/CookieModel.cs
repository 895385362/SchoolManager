using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using S1mple_SchoolManager.Common;

namespace S1mple_SchoolManager.Entity.Model
{
    public class CookieModel
    {
        //只有get 只能获取， 根据需求， 获取cookie的取值即可不需要赋值
        public string UserCookieID
        {
            get
            {
                return CookieHelper.GetCookieValue("ID");
            }
        }
        public string UserCookieName
        {
            get
            {
                return CookieHelper.GetCookieValue("Name");
            }
        }
        public string UserCookiePwd
        {
            get
            {
                return CookieHelper.GetCookieValue("Password");
            }
        }


    }
}
