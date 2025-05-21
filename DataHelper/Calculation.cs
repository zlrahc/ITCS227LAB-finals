using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataHelper
{
    public class Calculation
    {
        public static decimal CalculateTotal(decimal totalAmount, string membership)
        {
            decimal vat = totalAmount * 0.10m;
            decimal discount = 0;

            if (totalAmount >= 10000)
            {
                switch (membership?.Trim().ToLower())
                {
                    case "silver":
                        discount = totalAmount * 0.05m;
                        break;
                    case "gold":
                        discount = totalAmount * 0.10m;
                        break;
                    case "platinum":
                        discount = totalAmount * 0.15m;
                        break;
                }
            }

            return (totalAmount + vat) - discount;
        }

        public static decimal CalculateVAT(decimal totalAmount)
        {
            return totalAmount * 0.10m;
        }

        public static decimal CalculateDiscount(decimal totalAmount, string membership)
        {
            if (totalAmount < 10000)
                return 0;

            switch (membership?.Trim().ToLower())
            {
                case "silver": return totalAmount * 0.05m;
                case "gold": return totalAmount * 0.10m;
                case "platinum": return totalAmount * 0.15m;
                default: return 0;
            }
        }
    }
}
