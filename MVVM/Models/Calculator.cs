using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CalculatorMAUI.MVVM.Models
{

    public class Calculator
    {
        public string Display { get; set; }
        public double FirstNumber { get; set; }
        public double SecondNumber { get; set; }
        public double Result { get; set; }
        public string Operator { get; set; }
    }

}
