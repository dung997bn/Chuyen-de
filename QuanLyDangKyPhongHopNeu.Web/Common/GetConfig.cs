using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace QuanLyDangKyPhongHopNeu.Web.Common
{
    public class GetConfig
    {
        public static string GetByKey(string key)
        {
            return ConfigurationManager.AppSettings[key].ToString();
        }
    }
}