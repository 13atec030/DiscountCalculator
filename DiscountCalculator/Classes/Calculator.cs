using System;
using System.Collections.Generic;
using System.Text;

namespace DiscountCalculator.Classes
{
    public class Calculator
    {
        #region Properties

        private double PricePerGram { get; set; }
        private double TotalWeight { get; set; }
        private double DiscountInPercent { get; set; }

        #endregion

        #region Methods

        public double CalculateTotalPrice(string pricePerGram, string totalWeight, string discountInPercent = null)
        {
            try
            {
                if(IsValidParameter(pricePerGram, totalWeight, discountInPercent) == false)
                {
                    throw new Exception("Invalid data provides!");
                }

                double totalPrice = 0;

                if (discountInPercent == null)
                {
                    totalPrice = PricePerGram * TotalWeight;
                }
                else
                {
                    totalPrice = PricePerGram * TotalWeight;
                    double discount = (totalPrice * DiscountInPercent) / 100;

                    totalPrice = totalPrice - discount;
                }

                return totalPrice;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        private bool IsValidParameter(string pricePerGram, string totalWeight, string discountInPercent = null)
        {
            try
            {
                PricePerGram = double.Parse(pricePerGram);
                TotalWeight = double.Parse(totalWeight);

                if (string.IsNullOrEmpty(discountInPercent) == false)
                {
                    DiscountInPercent = double.Parse(discountInPercent);
                }

                return true;
            }
            catch(Exception ex)
            {
                return false;
            }
        }

        #endregion 
    }
}
