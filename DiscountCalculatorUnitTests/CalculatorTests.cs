using DiscountCalculator.Classes;
using System;
using Xunit;

namespace DiscountCalculatorUnitTests
{
    public class CalculatorTests
    {
        [Fact]
        public void CalculateTotalPrice_ValidGoldPriceWeightDiscountParam_TotalPrice()
        {
            Calculator calculator = new Calculator();

            var totalPrice = calculator.CalculateTotalPrice("1000", "10", "5");

            Assert.IsType<double>(totalPrice);
        }

        [Fact]
        public void CalculateTotalPrice_ValidGoldPriceWeightParam_TotalPrice()
        {
            Calculator calculator = new Calculator();

            var totalPrice = calculator.CalculateTotalPrice("1000", "10", null);

            Assert.IsType<double>(totalPrice);
        }

        [Fact]
        public void CalculateTotalPrice_InvalidGoldPriceWeightDiscountParam_InvalidDataException()
        {
            Calculator calculator = new Calculator();

            try
            {
                calculator.CalculateTotalPrice("dgdfh", "bfdfgj", "dfhfhd");
            }
            catch(Exception ex)
            {
                Assert.IsType<Exception>(ex);
            }
        }
    }
}
