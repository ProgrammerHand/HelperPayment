﻿using HelperPayment.Core.External;

namespace HelperPayment.Core.Models.Offer.Policies
{
    public static class DiscountFactory
    {
        public static IDiscounter CreateDiscount(IClockCustom clock)
        {
            var condition = clock.Now.Month % 2;
            return condition switch
            {
                0 => new Percents20Policy(),
                1 => new Percents10Policy(),
                _ => new NoPercentsPolicy()
            };
        }
    }
}
