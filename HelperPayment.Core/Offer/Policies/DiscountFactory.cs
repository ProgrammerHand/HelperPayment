﻿using HelperPayment.Core.Utility;

namespace HelperPayment.Core.Offer.Policies
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
