using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace S1mple_SchoolManager.Common
{
    public class ResultHelperEx<T>
    {
        private string _msg;

        public string msg
        {
            get { return _msg; }
            set { _msg = value; }
        }

        private bool _result;

        public bool result
        {
            get { return _result; }
            set { _result = value; }
        }

        private T _data;

        public T data
        {
            get { return _data; }
            set { _data = value; }
        }

        private T _delete;

        public T delete
        {   
            get { return _delete; }
            set { _delete = value; }
        }

        private bool _state;

        public bool State
        {
            get { return _state; }
            set { _state = value; }
        }//true 登录成功 false 登陆失败

        public string ToJson()
        {
            return JsonHelper.JsonSerializer<ResultHelperEx<T>>(this).Replace("null", "\"\"");
        }
    }
}
