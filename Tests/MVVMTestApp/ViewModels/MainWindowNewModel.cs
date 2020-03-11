using System;
using System.Timers;

namespace MVVMTestApp.ViewModels
{
    class MainWindowNewModel
    {
        private Timer _Timer;
        public DateTime CurrentTime { get; set; }
        public string Title { get; set; } = "Title windows MVVM App";
        public MainWindowNewModel()
        {
            _Timer = new Timer(100) { AutoReset = true };
            _Timer.Elapsed += OnTimerTick;
            _Timer.Start();            
        }

        private void OnTimerTick(object Sender, ElapsedEventArgs E)
        {
            CurrentTime = DateTime.Now;
        }
    }
}
