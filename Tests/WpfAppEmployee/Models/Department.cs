using System.ComponentModel;

namespace WpfAppEmployee.Models
{ 
    public class Department : INotifyPropertyChanged
    {
        private string _depName;

        public event PropertyChangedEventHandler PropertyChanged;

        public int DepId { get; set; }
        
        public string DepName
        {
            get => _depName;
            set
            {
                _depName = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(DepName)));
            }
        }
    }
}
