using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork4._2
{
    class User
    {
        public Clock myClock = new Clock();

        public User()
        {
            myClock.Tick += new Action(TickMusic);
            myClock.Alarm += new Action(AlarmMusic);

        }
        public void SetAlarm(DateTime alarmTime)
        {
            myClock.AlarmTime = alarmTime;
        }

        public void TickMusic()
        {
            Console.WriteLine("Tick Tick Tick ...");
        }

        public void AlarmMusic()
        {
            Console.WriteLine("Di Di Di, It's time to get up");
        }
    }
}
