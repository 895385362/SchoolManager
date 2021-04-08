using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace S1mple_SchoolManager.Common
{
    public class APIResult<T>
    {
        private string _ErrMsg;

        public string ErrMsg
        {
            get { return _ErrMsg; }
            set { _ErrMsg = value; }
        }

        private bool _Result;

        public bool Result
        {
            get { return _Result; }
            set { _Result = value; }
        }

        private T _Data;

        public T Data
        {
            get { return _Data; }
            set { _Data = value; }
        }

        private T _delete;

        public T delete
        {
            get { return _delete; }
            set { _delete = value; }
        }

        public string ToJson()
        {
            return JsonHelper.JsonSerializer<APIResult<T>>(this).Replace("null", "\"\"");
        }

    }
}