namespace Calculator.ViewModels
{
    using System;
    using System.Windows.Input;
    using Models;
    using Xamarin.Forms;
    using Base;

    public class CalculatorViewModel : ViewModelBase
    {
        private decimal? _operandOne;
        private decimal? _operandTwo;
        private Operator? _operation;
        private string _displayValue;
        private bool _hasOperation;

        public CalculatorViewModel()
        {
            _hasOperation = false;

            DigitComamnd = new Command<string>(DigitCommandExecute);
            OperatorCommand = new Command<string>(OperatorCommandExecute);
            DeleteCommand = new Command(DeleteCommandExecute);
            ClearEntryCommand = new Command(ClearEntryCommandExecute);
            ClearCommand = new Command(ClearCommandExecute);
            ComputeCommand = new Command(ComputeCommandExecute);

            DisplayValue = string.Empty;
        }

        public string DisplayValue
        {
            get { return _displayValue; }
            set
            {
                _displayValue = value;
                RaisePropertyChanged();
            }
        }

        public Operator? Operation
        {
            get { return _operation; }
            set
            {
                _operation = value;
                RaisePropertyChanged();
            }
        }

        public decimal? OperandOne
        {
            get { return _operandOne; }
            set
            {
                _operandOne = value;
                RaisePropertyChanged();
            }
        }

        public decimal? OperandTwo
        {
            get { return _operandTwo; }
            set
            {
                _operandTwo = value;
                RaisePropertyChanged();
            }
        }

        public ICommand DigitComamnd { get; private set; }
        public ICommand OperatorCommand { get; private set; }
        public ICommand DeleteCommand { get; private set; }
        public ICommand ClearEntryCommand { get; private set; }
        public ICommand ClearCommand { get; private set; }
        public ICommand ComputeCommand { get; private set; }

        private void DigitCommandExecute(string value)
        {
            decimal result;

            if (_hasOperation)
            {
                Clear();
                _hasOperation = false;
            }
         
            string newDisplay = DisplayValue + value;

            if (Decimal.TryParse(newDisplay, out result))
            {
                if (_operation.HasValue)
                {
                    _operandTwo = result;
                }
                else
                {
                    _operandOne = result;
                }

                DisplayValue = newDisplay;
            }
        }

        private void OperatorCommandExecute(string op)
        {
            Operator? operation;

            switch (op)
            {
                case "+":
                    operation = Operator.Addition;
                    break;
                case "-":
                    operation = Operator.Subtraction;
                    break;
                case "*":
                    operation = Operator.Multiplication;
                    break;
                case "/":
                    operation = Operator.Division;
                    break;
                default:
                    throw new ArgumentException("Invalid Operator!");
            }

            if (_operandTwo.HasValue)
            {
                var calculation = Calculate();
                if (calculation != 0)
                {
                    _operandOne = calculation;
                    _operation = operation;

                    DisplayValue = string.Empty;
                }
                else
                {
                    Clear();
                }
            }
            else if (_operandOne.HasValue)
            {
                _operation = operation;
                DisplayValue = string.Empty;
            }
        }

        private void DeleteCommandExecute()
        {
            if (_hasOperation)
                return;

            if (!String.IsNullOrWhiteSpace(DisplayValue))
            {
                DisplayValue = DisplayValue.Remove(DisplayValue.Length - 1);
            }
        }

        private void ClearEntryCommandExecute()
        {
            if (_operandTwo.HasValue)
            {
                _operandTwo = null;
            }
            else
            {
                _operation = null;
                _operandOne = null;
            }

            DisplayValue = string.Empty;
        }

        private void ClearCommandExecute()
        {
            Clear();
        }

        private void Clear()
        {
            _operandOne = null;
            _operandTwo = null;
            _operation = null;

            DisplayValue = string.Empty;
        }

        private void ComputeCommandExecute()
        {
            DisplayValue = Calculate().ToString();

            _hasOperation = true;
        }

        public decimal Calculate()
        {
            if (_operandOne.HasValue
                && _operation.HasValue
                && _operandTwo.HasValue)
            {
                switch (_operation.Value)
                {
                    case Operator.Addition:
                        return (_operandOne.Value + _operandTwo.Value);
                    case Operator.Subtraction:
                        return (_operandOne.Value - _operandTwo.Value);
                    case Operator.Multiplication:
                        return (_operandOne.Value * _operandTwo.Value);
                    case Operator.Division:
                        return (_operandOne.Value / _operandTwo.Value);
                    default:
                        return 0;
                }
            }
            return 0;
        }
    }
}
