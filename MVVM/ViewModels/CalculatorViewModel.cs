using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using CalculatorMAUI.MVVM.Models;

namespace CalculatorMAUI.MVVM.ViewModels
{
    public class CalculatorViewModel : INotifyPropertyChanged
    {
        public Calculator model;
        private string display;

        public CalculatorViewModel()
        {
            model = new Calculator();
            Display = "0";
        }

        public string Display
        {
            get { return display; }
            set
            {
                display = value;
                OnPropertyChanged();
            }
        }

        public ICommand NumberCommand => new Command<string>(AppendNumber);
        public ICommand OperatorCommand => new Command<string>(SetOperator);
        public ICommand EqualsCommand => new Command(PerformOperation);

        private void AppendNumber(string number)
        {
            if (Display == "0" || model.Operator != null)
            {
                Display = number;
                model.Operator = model.Operator;
            }
            else
            {
                Display += number;
            }
        }

        private void SetOperator(string op)
        {
            model.Operator = op;
            model.FirstNumber = double.Parse(Display);
        }

        private void PerformOperation()
        {
            model.SecondNumber = double.Parse(Display);

            switch (model.Operator)
            {
                case "+":
                    model.Result = model.FirstNumber + model.SecondNumber;
                    break;
                case "-":
                    model.Result = model.FirstNumber - model.SecondNumber;
                    break;
                case "*":
                    model.Result = model.FirstNumber * model.SecondNumber;
                    break;
                case "%":
                    model.Result = (model.FirstNumber * model.SecondNumber) / 100;
                    break;
                case "/":
                    if (model.SecondNumber != 0)
                    {
                        model.Result = model.FirstNumber / model.SecondNumber;
                    }
                    else
                    {
                        model.Result = 0;
                    }
                    break;
            }

            Display = model.Result.ToString();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}