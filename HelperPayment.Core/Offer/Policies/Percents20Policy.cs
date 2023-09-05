﻿namespace HelperPayment.Core.Offer.Policies
{
    public class Percents20Policy : IDiscounter
    {
        public double CalculateDiscount(double price)
        {
            return price * 0.8;
        }
    }
}
