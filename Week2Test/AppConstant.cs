using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Week2Test
{
    public class AppConstant
    {
        public class AppConnection
        {
            public static String DevConnection = "Data Source=SQL5110.site4now.net;Initial Catalog=db_9ab8b7_25dda11927;User Id=db_9ab8b7_25dda11927_admin;Password=dSZm274x;";
            public static String TestConnection = "";
            public static String ProdConnection = "";
            public static String BetaConnection = "";
        }
        
        public enum TAbUser
        {
            UID,
            UserName,
            UserLevel
        }
        public class UserLevel
        {
            public static String Admin = "3";
            public static String User = "2";
            public static String Supervisor = "1";
        }
    }
}