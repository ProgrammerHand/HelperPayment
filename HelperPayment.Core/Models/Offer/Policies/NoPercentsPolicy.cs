namespace HelperPayment.Core.Models.Offer.Policies
{
    public class NoPercentsPolicy : IDiscounter
    {
        public double CalculateDiscount(double price)
        {
            return price;
        }
    }
}
