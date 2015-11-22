using Calculator.Models;
using NUnit.Framework;
using Calculator.ViewModels;

namespace Calculator.Tests.ViewModels
{
    [TestFixture]
    public class CalculatorViewModelTests
    {
        [Test()]
        public void TestAddtion()
        {
            var calculation = new CalculatorViewModel
            {
                OperandOne = 2,
                OperandTwo = 2,
                Operation = Operator.Addition
            };

            var result = calculation.Calculate();

            Assert.AreEqual(result, 4);
        }

        [Test()]
        public void TestMultiplication()
        {
            var calculation = new CalculatorViewModel
            {
                OperandOne = 4,
                OperandTwo = 4,
                Operation = Operator.Multiplication
            };

            var result = calculation.Calculate();

            Assert.AreEqual(result, 16);
        }

        [Test()]
        public void TestSubtraction()
        {
            var calculation = new CalculatorViewModel
            {
                OperandOne = 40,
                OperandTwo = 10,
                Operation = Operator.Subtraction
            };

            var result = calculation.Calculate();

            Assert.AreEqual(result, 30);
        }

        [Test()]
        public void TestDivision()
        {
            var calculation = new CalculatorViewModel
            {
                OperandOne = 100,
                OperandTwo = 5,
                Operation = Operator.Division
            };
            
            var result = calculation.Calculate();

            Assert.AreEqual(result, 20);
        }
    }
}