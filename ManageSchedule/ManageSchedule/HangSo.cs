﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManageSchedule
{
    public static class HangSo
    {
        //public static string strCon = @"Server=204.2.195.207,18708;Database=manageschedule;User=team4;Password=Team45678";
        public static string strCon = System.Configuration.ConfigurationManager.ConnectionStrings["Conn"].ConnectionString;
    }
}
