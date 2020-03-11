using MVVMTestApp.ViewModels.Base;
using System;
using System.Timers;

namespace MVVMTestApp.ViewModels
{
    class MainWindowNewModel : ViewModel
    {
        private Timer _Timer;
        private DateTime _CurrentTime;

        public DateTime CurrentTime { 
            get => _CurrentTime;
            set
            {
                if (Equals(_CurrentTime, value)) return;
                _CurrentTime = value;
                OnPropertyChanged();
            }
        }
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
