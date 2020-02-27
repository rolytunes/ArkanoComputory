using System;
using System.Collections.Generic;
using System.Text;

namespace ComputerInventory.Helpers.Utils
{
    public static class Constants
    {
        public static string BaseUrl = "http://192.168.1.4:5000";
        public static string ComputerUrl = BaseUrl + "/api/computer";
        public static string ComputerUrlLimit = BaseUrl + "/api/computer/limit";

        public static string RamUrl = BaseUrl + "/api/ram";
        public static string RamAbove8Url = BaseUrl + "/api/ram/above/8";
    }
}
