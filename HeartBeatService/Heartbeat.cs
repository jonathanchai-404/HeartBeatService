using System;
using System.IO;
using System.Timers;

namespace HeartBeatService
{
    class Heartbeat
    {
        private readonly Timer _timer;

        public Heartbeat()
        {
            _timer = new Timer(1000) { AutoReset = true };
            _timer.Elapsed += TimerElapsed;
        }

        private void TimerElapsed(object sender, ElapsedEventArgs e)
        {
            string[] lines = new string[] { DateTime.Now.ToString()};
            File.AppendAllLines(Path.Combine(Environment.CurrentDirectory, "heartbeat.txt"), lines);
        }

        public void Start() 
        {
            _timer.Start();
        }

        public void Stop()
        {
            _timer.Stop();
        }
    }
}
