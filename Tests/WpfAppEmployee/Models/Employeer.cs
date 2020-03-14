using System;
using System.ComponentModel;

namespace WpfAppEmployee.Models
{
    public class Employee : INotifyPropertyChanged
    {
        private string _Name;
        private int _Department;
        private DateTime _DayOfBirth;

        public event PropertyChangedEventHandler PropertyChanged;

        public int Id { get; set; }
        public string Name
        {
            get => _Name;
            set
            {
                _Name = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Name)));
            }
        }
        public string SurName { get; set; }
        public string Patronymic { get; set; }
        public DateTime DayOfBirth 
        {
            get => _DayOfBirth;
            set
            {
                _DayOfBirth = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(DayOfBirth)));
            }
        }

        public int Age => (int)Math.Floor((DateTime.Now - DayOfBirth).TotalDays / 365);

        public override string ToString() => $"Employee[{Id}]: {SurName}";

        public int Department
        {
            get
            {
                return _Department;
            }
            set 
            {
                _Department = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Department)));
            }
        }
    }
}
