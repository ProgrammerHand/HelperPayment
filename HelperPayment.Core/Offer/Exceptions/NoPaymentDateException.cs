﻿using HelperPayment.Core.Exceptions;
namespace HelperPayment.Core.Offer.Exceptions
{
    public class NoPaymentDateException : CustomException
    {
        public NoPaymentDateException() : base("Offer dont have payment date")
        {

        }
    }
}