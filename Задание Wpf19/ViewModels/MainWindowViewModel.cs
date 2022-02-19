using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Задание_Wpf19.Models;

namespace Задание_Wpf19.ViewModels
{
    class MainWindowViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        void OnPropertyChanged([CallerMemberName]string PropertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(PropertyName));
        }
        
        private double radius;
        public double Radius
        {
            get => radius;
            set
            {
                radius = value;
                OnPropertyChanged();
            }
        }
        
        private double result;
        public double Result
        {
            get => result;
            set
            {
                result = value;
                OnPropertyChanged();
            }
        }
        
        public ICommand  CircleLengthCalcCommand { get; }
        private void OnCircleLengthCalcCommand(object p)
        {
            Result = CircleCalculations.CircleLengthCalc(Radius);
        }

        private bool CanCircleLengthCalcCommandExecuted(object p)
        {
            if (Radius != 0)
                return true;
            else
                return false;
        }

        public MainWindowViewModel()
        {
            CircleLengthCalcCommand = new RelayCommand(OnCircleLengthCalcCommand, CanCircleLengthCalcCommandExecuted);
        }
    }
}
