﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork4._2
{
    class Program
    {

        static void Main(string[] args)
        {
            User myUser = new User();

           
            myUser.SetAlarm(DateTime.Now.AddSeconds(5));

            myUser.myClock.runTime();
        }
    }
}