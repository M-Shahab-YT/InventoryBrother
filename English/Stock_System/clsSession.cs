using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Stock_System
{
    public static class  clsSession
    {

        private static string loginType;



        public static string LoginType
        {

            get { return loginType; }
            set { loginType = value; }
        }


    }
}
