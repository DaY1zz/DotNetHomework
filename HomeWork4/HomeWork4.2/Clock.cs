using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
namespace HomeWork4._2
{
    class Clock
    {
        public DateTime CurrentTime { get; set; }
        public DateTime AlarmTime { get; set; }

        public event Action Tick;
        public event Action Alarm;

        public Clock()
        {
            CurrentTime = DateTime.Now;
        }

        public void runTime()
        {
            while (true)
            {
                if (DateTime.Compare(CurrentTime,AlarmTime) >= 0)
                {
                    Alarm();
                    
                }   
                Thread.Sleep(1000);
                CurrentTime = DateTime.Now;
                Tick();
            }
        }
    }
}
